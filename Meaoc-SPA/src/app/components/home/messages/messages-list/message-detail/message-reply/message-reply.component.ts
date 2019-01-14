import { Component, OnInit, Input } from '@angular/core';
import { MessagesService } from 'src/app/services/messages.service';
import { UserService } from 'src/app/services/user.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-message-reply',
  templateUrl: './message-reply.component.html',
  styleUrls: ['./message-reply.component.css']
})
export class MessageReplyComponent implements OnInit {

  btnSubmitText: string;
  message: string;
  isMessageSent: boolean;
  @Input() recipient: string;
  recipientId: any;
  model: { content: string, authorId: number, recipientId: number };

  constructor(
    private messagesService: MessagesService,
    private userService: UserService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.btnSubmitText = 'Reply';
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
      this.btnSubmitText = 'Message Sent';
    }, error => {
      this.alertifyService.error('Unable to send the message. Try again later.');
      this.isMessageSent = false;
    });
  }

}
