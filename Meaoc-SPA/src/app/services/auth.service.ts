import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginForm } from '../models/login-form.model';
import { User } from '../models/user.model';
import { Token } from '../models/token.model';
import { AlertifyService } from './alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiAuthUrl = 'http://localhost:5000/api/auth';
  public isUserAuthorized = false;

  constructor(private http: HttpClient, private alertifyService: AlertifyService) { }

  authenticate(auth: LoginForm) {
    return this.http.post<User>(this.apiAuthUrl, auth);
  }

  isUserAuthenticated(): any {
    const tokenObj = new Token();
    tokenObj.Token = localStorage.getItem('token');
    tokenObj.ValidToken = false;
    return this.validateToken(tokenObj).pipe(
      map(res => {
        return res['ValidToken'] === true ? true : false;
    })
    );
  }

  isUserNotAuthenticated(): any {
    const tokenObj = new Token();
    tokenObj.Token = localStorage.getItem('token');
    tokenObj.ValidToken = false;
    return this.validateToken(tokenObj).pipe(
      map(res => {
        return res['ValidToken'] === false ? true : false;
    })
    );
  }

  validateToken(token: Token): Observable<Token> {
    return this.http.post<Token>(this.apiAuthUrl + '/validatetoken', { Token: token.Token });
  }

  logout(): boolean {
    localStorage.removeItem('token');
    this.alertifyService.success('Thank you for visiting!');
    return true;
  }
}
