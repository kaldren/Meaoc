import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  isReplyBtnClicked: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private messagesService: MessagesService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.getMessage();
    this.isReplyBtnClicked = false;
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

  deleteMessage(id: number): void {

    this.alertifyService.confirm('Are you sure you want to delete this message?').set('onok', () => {
      this.messagesService.deleteMessage(id).subscribe((result) => {
        this.alertifyService.success('Message deleted.');
        this.router.navigate(['home/messages']);
      }, error => {
        this.alertifyService.error(error);
      });
    });

  }

}
