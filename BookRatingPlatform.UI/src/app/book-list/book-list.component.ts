import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { map, Observable } from 'rxjs';
import { BookListItemComponent } from '../book-list-item/book-list-item.component';
import { Book } from '../entities/book';
import { BookService } from '../services/book.service';

@Component({
	selector: 'app-book-list',
	templateUrl: './book-list.component.html',
	styleUrls: ['./book-list.component.css'],
	providers: [BookService],
})
export class BookListComponent implements OnInit {
	@Output() editBookId = new EventEmitter<number>();

	allBooks$: Observable<Book[]> | undefined;
	recommendedBooks$: Observable<Book[]> | undefined;

	constructor(private bookService: BookService, public dialog: MatDialog) {}

	ngOnInit(): void {
		this.loadAllBooks();
		this.loadRecommendedBooks();
	}

	public openDetails(id: number) {
		this.dialog.open(BookListItemComponent, {
			data: id,
		});
	}

	public onEditBook(id: number) {
		this.editBookId.emit(id);
	}

	public loadAllBooks() {
		this.allBooks$ = this.bookService.getAllBooks().pipe(
			map((res) => {
				return res.map((book) => {
					return {
						id: book.id,
						title: book.title,
						author: book.author,
						cover: book.cover,
						rating: parseFloat(book.rating.toString()),
						reviewsNumber: book.reviewsNumber,
					};
				});
			})
		);
	}

	public loadRecommendedBooks() {
		this.recommendedBooks$ = this.bookService.getRecommended().pipe(
			map((res) => {
				return res.map((book) => {
					return {
						id: book.id,
						title: book.title,
						author: book.author,
						cover: book.cover,
						rating: parseFloat(book.rating.toString()),
						reviewsNumber: book.reviewsNumber,
					};
				});
			})
		);
	}
}
