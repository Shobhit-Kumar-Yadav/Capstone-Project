import { Component, OnInit } from '@angular/core';
import { ApiListService } from '../api-list.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-recommended',
  templateUrl: './recommended.component.html',
  styleUrls: ['./recommended.component.scss']
})
export class RecommendedComponent implements OnInit {

  recommendedBooks: any[] = [];
  loading: boolean = false;
  subject: string = 'science_fiction'; // Default subject
  limit: number = 10; // Default limit

  subjects: string[] = [
    'science_fiction', 
    'fantasy', 
    'romance', 
    'mystery', 
    'horror',
    'history',
    'biography',
    'children',
    'thriller',
    'non_fiction',
    'classics',
    'adventure',
    'poetry',
    'drama',
    'philosophy',
    'self_help',
    'health',
    'travel',
    'sports',
    'religion',
    'art',
    'cookbooks'
  ];

  constructor(private apiListService: ApiListService, private cookieService: CookieService) { }

  ngOnInit(): void {
    this.loadRecommendations();
  }

  loadRecommendations(): void {
    this.loading = true;
    this.apiListService.getRecommendations(this.subject, this.limit).subscribe((data: any) => {
      this.loading = false;
      this.recommendedBooks = data.works; // Adjust based on actual API response structure
    });
  }

  getCoverImageUrl(coverId: number): string {
    return this.apiListService.getCoverImageUrl(coverId);
  }

  onSubjectChange(newSubject: string): void {
    this.subject = newSubject;
    this.loadRecommendations();
  }

  onLimitChange(newLimit: number): void {
    if (newLimit < 1) {
      this.limit = 1;
    } else if (newLimit > 100) {
      this.limit = 100;
    } else {
      this.limit = newLimit;
    }
    this.loadRecommendations();
  }

  addToFavourite(book: any): void {
    const favouriteBooks = JSON.parse(this.cookieService.get('favouriteBooks') || '[]');
    favouriteBooks.push({
      coverImageUrl: book.cover_id,
      title: book.title,
      author: book.author_name ? book.author_name.join(', ') : 'Unknown',
      description: book.description // Assuming `description` is a property in `book`
    });
    this.cookieService.set('favouriteBooks', JSON.stringify(favouriteBooks), 7);
    alert('added to favourites');
  }
}
