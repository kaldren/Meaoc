import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private authService: AuthService) { }

  isUserAuthenticated = false;

  ngOnInit() {
    this.isUserAuthenticated = this.authService.isUserAuthenticated();
  }

  logout() {
    console.log(this.authService.logout());
  }

}
