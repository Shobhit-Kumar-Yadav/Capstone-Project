import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiListService {
  private baseUrl = 'https://openlibrary.org';
  private apiUrl = 'http://openlibrary.org/search.json';
  private loginUrl = 'https://localhost:7207/api/Account/login';
  private popularBooksUrl = 'http://localhost:5201/api/books';
  private registerUrl = 'https://localhost:7207/api/Account/register';
  private authorsUrl = 'http://localhost:5201/api/Authors';

  constructor(private http: HttpClient) { }

  // getPopularBooks(): Observable<any> {
  //   return this.http.get(`${this.baseUrl}/search.json?q=popular`);
  // }

  getCoverImageUrl(coverId: number): string {
    return `https://covers.openlibrary.org/b/id/${coverId}-L.jpg`;
  }

  getRecommendations(subject: string, limit: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/subjects/${subject}.json?limit=${limit}`);
  }

  searchBooks(query: string): Observable<any> {
    return this.http.get(`${this.apiUrl}?q=${query}`);
  }

  login(username: string, password: string): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { username, password };

    return this.http.post<any>(this.loginUrl, body, { headers });
  }

  getPopularBooks(): Observable<any> {
    return this.http.get<any>(this.popularBooksUrl);
  }

  register(user: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(this.registerUrl, user, { headers });
  }

  getAuthors(): Observable<any[]> {
    return this.http.get<any[]>(this.authorsUrl);
  }

}
