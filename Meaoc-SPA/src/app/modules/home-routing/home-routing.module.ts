import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'src/app/components/home/home/home.component';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { MessagesComponent } from 'src/app/components/home/messages/messages.component';

const homeRouting: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        children: [
          { path: 'messages', component: MessagesComponent }
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
