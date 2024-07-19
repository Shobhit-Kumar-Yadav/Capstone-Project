import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { ApiListService } from '../api-list.service';

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.scss']
})
export class FavoriteComponent implements OnInit {

  favouriteBooks: any[] = [];

  constructor(private apiListService: ApiListService, private cookieService: CookieService) { }

  ngOnInit(): void {
    const cookieData = this.cookieService.get('favouriteBooks');
    this.favouriteBooks = cookieData ? JSON.parse(cookieData) : [];
  }

  getCoverImageUrl(coverImageUrl: number): string {
    return this.apiListService.getCoverImageUrl(coverImageUrl);
  }

}
