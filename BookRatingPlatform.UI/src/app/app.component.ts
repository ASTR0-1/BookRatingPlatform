import { Component, ViewChild } from '@angular/core';
import { BookListComponent } from './book-list/book-list.component';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css'],
})
export class AppComponent {
	@ViewChild(BookListComponent) bookListComponent!: BookListComponent;

	selectedBookId: number = 0;
	title = 'BookRatingPlatform';

	reloadBookList() {
		setTimeout(() => {
			this.bookListComponent.loadAllBooks();
			this.bookListComponent.loadRecommendedBooks();
		}, 100);
	}
}
