import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { IndexComponent } from './components/index/index.component';
import { HomeComponent } from './components/home/home/home.component';
import { MessagesComponent } from './components/home/messages/messages.component';
import { HomeModule } from './components/home/home.module';
import { HomeRoutingModule } from './modules/home-routing/home-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    IndexComponent,
    LoginFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HomeRoutingModule,
    HttpClientModule,
    FormsModule,
    HomeModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
