import { Injectable } from '@angular/core';
import { AuthenticateUser } from '../interfaces/authenticate-user';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiAuthUrl = 'http://localhost:5000/api/auth';

  constructor(private http: HttpClient) { }

  authenticate(auth: AuthenticateUser): Observable<User> {
    return this.http.post<User>(this.apiAuthUrl, auth);
  }

  isUserAuthenticated() {
    return localStorage.getItem('token') ? true : false;
  }

  logout(): boolean {
    if (this.isUserAuthenticated()) {
      localStorage.removeItem('token');
      return true;
    }

    return false;
  }
}
