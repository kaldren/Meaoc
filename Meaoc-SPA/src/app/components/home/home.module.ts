import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { HomeRoutingModule } from './home-routing.module';
import { MessagesListComponent } from './messages/messages-list/messages-list.component';
import { MessageDetailComponent } from './messages/messages-list/message-detail/message-detail.component';
import { MessageCreateComponent } from './messages/message-create/message-create.component';

@NgModule({
  imports: [
    CommonModule,
    HomeRoutingModule
  ],
  declarations: [
      HomeComponent,
      MessagesComponent,
      MessagesListComponent,
      MessageDetailComponent,
      MessageCreateComponent
    ]
})
export class HomeModule { }
