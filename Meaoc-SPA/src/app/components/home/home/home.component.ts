import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public isTokenValid$ = false;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.isUserAuthenticated();
  }

  isUserAuthenticated() {
    // return this.authService.isUserAuthenticated().subscribe((result) => {
    //   this.isTokenValid$ = result['IsTokenValid'];
    //   console.log(this.isTokenValid$);
    // });
  }
}
