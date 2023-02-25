import { Component, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Inject } from '@angular/core';
import { BookService } from '../services/book.service';
import { map, Observable } from 'rxjs';
import { BookDetails } from '../entities/bookDetails';

@Component({
	selector: 'app-book-list-item',
	templateUrl: './book-list-item.component.html',
	styleUrls: ['./book-list-item.component.css'],
	providers: [BookService],
})
export class BookListItemComponent implements OnInit {
	bookDetails$: Observable<BookDetails> | undefined;

	constructor(
		@Inject(MAT_DIALOG_DATA) public bookId: number,
		private bookService: BookService
	) {}

	ngOnInit(): void {
		this.getBookDetails();
	}

	public getBookDetails() {
		this.bookDetails$ = this.bookService.getBookDetails(this.bookId).pipe(
			map((res) => {
				return {
					id: res.id,
					title: res.title,
					author: res.author,
					cover: res.cover,
					content: res.content,
					genre: res.genre,
					rating: parseFloat(res.rating.toString()),
					reviews: res.reviews,
				};
			})
		);
	}
}
