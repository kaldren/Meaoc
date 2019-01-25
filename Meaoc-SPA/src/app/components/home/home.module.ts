import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { HomeRoutingModule } from './home-routing.module';
import { MessagesListComponent } from './messages/messages-list/messages-list.component';
import { MessageDetailComponent } from './messages/messages-list/message-detail/message-detail.component';
import { MessageCreateComponent } from './messages/message-create/message-create.component';
import { FormsModule } from '@angular/forms';
import { UserSearchComponent } from './user-search/user-search.component';
import { MessageArchiveComponent } from './messages/message-archive/message-archive.component';
import { MessageReplyComponent } from './messages/messages-list/message-detail/message-reply/message-reply.component';
import { ProfileComponent } from './profile/profile.component';
import { SidebarComponent } from './sidebar/sidebar.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HomeRoutingModule
  ],
  declarations: [
      HomeComponent,
      MessagesComponent,
      MessagesListComponent,
      MessageDetailComponent,
      MessageCreateComponent,
      MessageArchiveComponent,
      MessageReplyComponent,
      UserSearchComponent,
      ProfileComponent,
      SidebarComponent
    ]
})
export class HomeModule { }
