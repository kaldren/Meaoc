import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'src/app/components/home/home/home.component';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { MessagesComponent } from 'src/app/components/home/messages/messages.component';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { WelcomeComponent } from '../index/welcome/welcome.component';

const homeRouting: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        canActivateChild: [AuthGuard],
        component: HomeComponent,
        children: [
          { path: 'messages', component: MessagesComponent },
          { path: 'home', component: HomeComponent }
        ],
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(homeRouting)
  ],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
