import { Component, OnInit, OnChanges } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit  {

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  isUserAuthenticated(): boolean {
    return this.authService.isUserAuthenticated();
  }

  logout() {
    console.log(this.authService.logout());
    this.router.navigate(['/login']);
  }

}
