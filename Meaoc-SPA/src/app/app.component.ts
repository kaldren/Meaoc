import { Component, Input, OnInit } from '@angular/core';
import { Token } from './models/token.model';
import { Observable } from 'rxjs';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Meaoc-SPA';
  token$: Observable<Token>;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    console.log('initializing navbar component...');
    const tokenObj = new Token();
    tokenObj.Token = localStorage.getItem('token') ? localStorage.getItem('token') : 'dummttoken';

    this.token$ = this.authService.validateToken(tokenObj);
  }
}
