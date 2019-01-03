import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessagesService } from 'src/app/services/messages.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-message-detail',
  templateUrl: './message-detail.component.html',
  styleUrls: ['./message-detail.component.css']
})
export class MessageDetailComponent implements OnInit {

  routeId: number;
  message: any;

  constructor(private route: ActivatedRoute, private messagesService: MessagesService, private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.getMessage();
  }

  getMessage() {
    this.route.params.subscribe(params => {
      this.routeId = params['id'];
      this.message = this.messagesService.getMessageByid(this.routeId).subscribe(
        (result) => {
          this.message = result;
        },
        error => {
          this.alertifyService.error('Unable to get that message. Try again later.');
        });
    });
  }

}
