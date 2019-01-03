import { Component, OnInit, AfterViewInit, ChangeDetectionStrategy } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { MessagesService } from 'src/app/services/messages.service';

@Component({
  selector: 'app-messages-list',
  templateUrl: './messages-list.component.html',
  styleUrls: ['./messages-list.component.css'],
  changeDetection: ChangeDetectionStrategy.Default
})
export class MessagesListComponent implements OnInit {

  messagesList: any;

  httpOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
  };

  constructor(private messageService: MessagesService) {
    this.getAllUserMessagesReceived();
  }

  ngOnInit() {
  }

  getAllUserMessagesReceived() {
    this.messageService.getAllMessages().subscribe(result => {
      this.messagesList = result;
    });
  }
}
