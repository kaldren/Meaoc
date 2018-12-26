import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginForm } from '../models/login-form.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiAuthUrl = 'http://localhost:5000/api/auth';

  constructor(private http: HttpClient) { }

  authenticate(auth: LoginForm): Observable<User> {
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
