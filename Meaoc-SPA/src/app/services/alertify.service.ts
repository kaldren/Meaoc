import { Injectable } from '@angular/core';

declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  confirm(message: string): any {
    return alertify.confirm('Confirm', message,
    function() {
      alertify.success('Ok');
    },
    function() {
      alertify.error('Cancelled');
    });
  }
}
