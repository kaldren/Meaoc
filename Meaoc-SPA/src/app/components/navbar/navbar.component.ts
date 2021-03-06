import { Component, OnInit, OnChanges, Input } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Token } from 'src/app/models/token.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  public isUserLoggedIn$ = false;
  public isTokenValid$: Observable<Token>;
  public isAuthenticatedUser = false;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.isUserAuthenticated();
  }

  isUserAuthenticated(): Observable<boolean> {
    return this.authService.isUserAuthenticated().subscribe(user => {
      this.isAuthenticatedUser = user;
    });
  }

  validateToken(): boolean {
    const localStorageToken = localStorage.getItem('token');

    if (!localStorageToken) {
      return false;
    }

    const tokenObj = new Token();
    tokenObj.Token = localStorageToken;

    this.authService.validateToken(tokenObj).subscribe(res => {
      if (res['ValidToken']) {
        this.isAuthenticatedUser = true;
      }
    });
  }

  logout() {
    this.authService.logout();
    this.isAuthenticatedUser = false;
    this.router.navigate(['index/welcome']);
    window.location.reload();
  }

  onUserAuthorized(authenticated: boolean) {
    authenticated ? this.isAuthenticatedUser = true : this.isAuthenticatedUser = false;
  }
}
