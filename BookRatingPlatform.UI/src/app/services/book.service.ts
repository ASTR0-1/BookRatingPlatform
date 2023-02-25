import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Book } from '../entities/book';
import { BookDetails } from '../entities/bookDetails';
import { BookForCreation } from '../entities/bookForCreation';

@Injectable()
export class BookService {
	constructor(
		private http: HttpClient,
		@Inject('BASE_URL') private baseUrl: string
	) {}

	getAllBooks() {
		return this.http.get<Book[]>(this.baseUrl + '/books');
	}

	getRecommended() {
		return this.http.get<Book[]>(this.baseUrl + '/recommended');
	}

	getBookDetails(id: number) {
		return this.http.get<BookDetails>(this.baseUrl + '/books/' + id);
	}

	postBook(book: BookForCreation) {
		return this.http.post<BookForCreation>(
			this.baseUrl + '/books/save',
			book
		);
	}
}
