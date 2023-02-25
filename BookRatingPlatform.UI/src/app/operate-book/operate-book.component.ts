import {
	Component,
	EventEmitter,
	Input,
	OnChanges,
	OnInit,
	Output,
	SimpleChanges,
} from '@angular/core';
import { BookService } from '../services/book.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map, Observable } from 'rxjs';
import { BookDetails } from '../entities/bookDetails';
import { Review } from '../entities/review';
import { BookForCreation } from '../entities/bookForCreation';

@Component({
	selector: 'app-operate-book',
	templateUrl: './operate-book.component.html',
	styleUrls: ['./operate-book.component.css'],
	providers: [BookService, FormBuilder],
})
export class OperateBookComponent implements OnInit, OnChanges {
	@Output() bookOperationComplete: EventEmitter<void> =
		new EventEmitter<void>();

	bookForm!: FormGroup;
	@Input() bookId: number = 0;
	coverPreview: string | undefined;

	constructor(
		private formBuilder: FormBuilder,
		private bookService: BookService
	) {}

	ngOnInit(): void {
		this.bookForm = this.formBuilder.group({
			title: ['', Validators.required],
			author: ['', Validators.required],
			cover: ['', Validators.required],
			content: ['', Validators.required],
			genre: ['', Validators.required],
		});
	}

	ngOnChanges(changes: SimpleChanges): void {
		if (changes['bookId'] && changes['bookId'].currentValue) {
			this.getBookForEdit();
		}
	}

	public getBookForEdit() {
		if (this.bookId !== undefined) {
			this.bookService.getBookDetails(this.bookId).subscribe((res) => {
				const book: BookDetails = {
					id: res.id,
					title: res.title,
					author: res.author,
					cover: res.cover,
					content: res.content,
					genre: res.genre,
					rating: res.rating,
					reviews: res.reviews,
				};
				this.bookForm.patchValue({
					title: book.title,
					author: book.author,
					cover: book.cover,
					content: book.content,
					genre: book.genre,
				});
			});
		}
	}

	public onFileSelect(event: Event) {
		const file = (event.target as HTMLInputElement).files![0];
		const reader = new FileReader();
		reader.onload = () => {
			this.coverPreview = reader.result as string;
			this.bookForm.patchValue({ cover: reader.result });
		};
		reader.readAsDataURL(file);
	}

	public onSubmit() {
		if (this.bookForm.invalid) {
			return;
		}

		const bookForCreation: BookForCreation = {
			id: this.bookId !== 0 ? <number>this.bookId : 0,
			title: this.bookForm.value.title,
			author: this.bookForm.value.author,
			cover: this.bookForm.value.cover,
			content: this.bookForm.value.content,
			genre: this.bookForm.value.genre,
		};

		this.bookService.postBook(bookForCreation).subscribe();
		this.bookOperationComplete.emit();
	}

	public onClear() {
		this.bookForm.reset();
		this.bookId = 0;
	}
}
