import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserSearch } from '../models/user-search.model';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUsersUrl = 'http://localhost:5000/api/users';

  httpOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
  };

  constructor(private http: HttpClient) { }

  getRecipientIdByUsername(username: string) {
    return this.http.get(this.apiUsersUrl + '/' + username, this.httpOptions);
  }

  searchUser(term: string): Observable<UserSearch[]> {
    if (!term.trim()) {
      return of([]);
    }

    return this.http.get<UserSearch[]>(`${this.apiUsersUrl}/?term=${term}`, this.httpOptions).pipe(
      catchError(null)
    );

  }

}
