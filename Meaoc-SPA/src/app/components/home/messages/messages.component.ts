import { Component, OnInit } from '@angular/core';
import { MessagesService } from 'src/app/services/messages.service';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {

  messagesList: any;

  httpOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
  };

  constructor(private messageService: MessagesService, private http: HttpClient) { }

  ngOnInit() {
    this.getAllUserMessagesReceived();
  }

  getAllUserMessagesReceived() {
    this.messageService.getAllMessages().subscribe(result => {
      this.messagesList = result;
    });
  }
}
