import { Component, OnInit, ChangeDetectorRef, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { LoginForm } from 'src/app/models/login-form.model';
import { AlertifyService } from 'src/app/services/alertify.service';

declare let alertify: any;

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})


export class LoginFormComponent implements OnInit {
  email: string;
  password: string;
  @Output() isUserAuthorized = new EventEmitter<boolean>();

  constructor(
    private authService: AuthService,
    private alertifyService: AlertifyService,
    private router: Router
    ) { }

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
        this.alertifyService.success('Logged in successfuly.');
        this.router.navigate(['/home/profile']);
    }, error => {
      this.isUserAuthorized.emit(false);
      this.alertifyService.error('Wrong username / password.');
    });
  }

}
