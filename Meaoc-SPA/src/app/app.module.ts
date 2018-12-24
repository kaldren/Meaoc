import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeModule } from './components/home/home.module';
import { HomeRoutingModule } from './modules/home-routing/home-routing.module';
import { IndexModule } from './components/index/index.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HomeRoutingModule,
    HttpClientModule,
    FormsModule,
    HomeModule,
    IndexModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
