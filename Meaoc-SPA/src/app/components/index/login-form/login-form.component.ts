import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { LoginForm } from 'src/app/models/login-form.model';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  formSubmitted = false;
  email: string;
  password: string;

  constructor(private authService: AuthService, private router: Router, private change: ChangeDetectorRef) { }

  ngOnInit() {
  }

  onSubmit() {
    this.formSubmitted = true;

    const authenticateUser: LoginForm = {
      email: this.email,
      password: this.password,
    };

    this.login(authenticateUser);

    console.log('Form has been submitted');
  }

  login(authUser: LoginForm) {
    return this.authService.authenticate(authUser).subscribe((result) => {
      localStorage.setItem('token', result.token);
      this.change.detectChanges();
      this.router.navigate(['/home']);
    }, error => {
      console.log(error);
    });
  }

}
