import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginFormComponent } from '../index/login-form/login-form.component';
import { NavbarComponent } from './navbar.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
  ],
  declarations: [
    NavbarComponent,
    LoginFormComponent
  ]
})
export class NavbarModule { }
