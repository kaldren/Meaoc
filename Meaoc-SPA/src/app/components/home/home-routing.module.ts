import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'src/app/components/home/home/home.component';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { MessagesComponent } from 'src/app/components/home/messages/messages.component';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { WelcomeComponent } from '../index/welcome/welcome.component';
import { MessageDetailComponent } from './messages/messages-list/message-detail/message-detail.component';
import { MessageCreateComponent } from './messages/message-create/message-create.component';
import { MessagesListComponent } from './messages/messages-list/messages-list.component';
import { MessageArchiveComponent } from './messages/message-archive/message-archive.component';

const homeRouting: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        component: HomeComponent,
        children: [
          {
          path: 'messages',
          component: MessagesComponent,
          children: [
            { path: 'list', component: MessagesListComponent },
            { path: 'create', component: MessageCreateComponent },
            { path: 'archive', component: MessageArchiveComponent },
            { path: ':id', component: MessageDetailComponent },
            { path: '**', redirectTo: 'list' }
          ]
          },
          // { path: 'home', component: HomeComponent }
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
