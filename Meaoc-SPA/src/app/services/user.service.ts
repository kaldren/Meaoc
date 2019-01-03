import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiMessagesUrl = 'http://localhost:5000/api/users';

  httpOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
  };

  constructor(private http: HttpClient) { }

  getRecipientIdByUsername(username: string) {
    return this.http.get(this.apiMessagesUrl + '/' + username, this.httpOptions);
  }

}
