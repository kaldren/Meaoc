import { Component, OnInit } from '@angular/core';
import { MessagesService } from 'src/app/services/messages.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { UserService } from 'src/app/services/user.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-message-create',
  templateUrl: './message-create.component.html',
  styleUrls: ['./message-create.component.css']
})
export class MessageCreateComponent implements OnInit {

  recipient: string;
  message: string;
  model: {content: string, authorId: number, recipientId: number};

  constructor(
    private messagesService: MessagesService,
    private userService: UserService,
    private alertifyService: AlertifyService) {
  }

  ngOnInit() {
  }

  onFormSubmit() {

    this.model = {
      content: this.message,
      authorId: 1,
      recipientId: -999, // will be initialized when sending the message in the backend
    };

    this.messagesService.createMessage(this.model, this.recipient).subscribe(result => {
      this.alertifyService.success('Message sent.');
    }, error => {
      this.alertifyService.error('Unable to send the message. Try again later.');
    });
  }

  // getRecipientByUsername(username: string) {
  //   this.userService.getRecipientIdByUsername(username).subscribe(result => {
  //     this.recipientObject = result;
  //   });
  // }
}
