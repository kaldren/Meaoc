import { Component, OnInit, ChangeDetectorRef, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { LoginForm } from 'src/app/models/login-form.model';
import { Token } from 'src/app/models/token.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  email: string;
  password: string;
  @Output() isUserAuthorized = new EventEmitter<boolean>();

  constructor(private authService: AuthService, private router: Router, private change: ChangeDetectorRef) { }

  ngOnInit() {
  }

  onSubmit() {
    const authenticateUser: LoginForm = {
      email: this.email,
      password: this.password,
    };

    this.login(authenticateUser);
  }

  login(authUser: LoginForm) {
    return this.authService.authenticate(authUser).subscribe((result) => {
      localStorage.setItem('token', result.token);
        this.isUserAuthorized.emit(true);
        this.router.navigate(['/home']);
    }, error => {
      this.isUserAuthorized.emit(false);
      console.log(error);
    });
  }

}
