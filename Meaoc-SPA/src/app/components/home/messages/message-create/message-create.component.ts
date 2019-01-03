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
  recipientId: any;
  isMessageSent: boolean;
  message: string;
  model: { content: string, authorId: number, recipientId: number };

  constructor(
    private messagesService: MessagesService,
    private userService: UserService,
    private alertifyService: AlertifyService) {
  }

  ngOnInit() {
  }

  onFormSubmit() {
    this.createMessage();
  }

  private createMessage() {
    this.userService.getRecipientIdByUsername(this.recipient).subscribe(result => {
      this.recipientId = result['userId'];

      this.constructMessageModel();

      this.sendMessage();
    }, error => {
      this.alertifyService.error('Unable to send the message. Try again later.');
    });
  }
  private constructMessageModel() {
    this.model = {
      content: this.message,
      authorId: 1,
      recipientId: this.recipientId,
    };
  }

  private sendMessage() {
    this.messagesService.createMessage(this.model).subscribe(() => {
      this.alertifyService.success('Message sent.');
      this.isMessageSent = true;
    }, error => {
      this.alertifyService.error('Unable to send the message. Try again later.');
      this.isMessageSent = false;
    });
  }

}
