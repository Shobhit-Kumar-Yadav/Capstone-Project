import { Component, OnInit } from '@angular/core';
import { ApiListService } from '../api-list.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss']
})
export class AuthorComponent implements OnInit {

  authors: any[] = [];
  loading: boolean = false;

  constructor(private apiListService: ApiListService) {}

  ngOnInit(): void {
    this.loadAuthors();
  }

  loadAuthors(): void {
    this.loading = true;
    this.apiListService.getAuthors().subscribe(
      (data: any[]) => {
        this.loading = false;
        this.authors = data;
      },
      error => {
        this.loading = false;
        console.error('Error fetching authors', error);
      }
    );
  }

}
