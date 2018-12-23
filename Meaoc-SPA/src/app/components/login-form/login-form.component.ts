import { Component, OnInit } from '@angular/core';
import { AuthenticateUser } from 'src/app/interfaces/authenticate-user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  formSubmitted = false;
  email: string;
  password: string;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  onSubmit() {
    this.formSubmitted = true;

    const authenticateUser = {
      email: this.email,
      password: this.password,
    };

    this.login(authenticateUser);

    console.log('Form has been submitted');
  }

  login(authUser: AuthenticateUser) {
    return this.authService.authenticate(authUser).subscribe((result) => {
      localStorage.setItem('token', result.token);
    }, error => {
      console.log(error);
    });
  }

}
