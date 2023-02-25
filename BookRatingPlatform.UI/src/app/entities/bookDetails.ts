import { Review } from './review';

export interface BookDetails {
	id: number;
	title: string;
	author: string;
	cover: string;
	content: string;
	genre: string;
	rating: number;
	reviews: Review[];
}
