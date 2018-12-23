import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { isUndefined } from 'util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  isUserAuthenticated = false;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.isUserAuthenticated = this.authService.isUserAuthenticated();
  }
}
