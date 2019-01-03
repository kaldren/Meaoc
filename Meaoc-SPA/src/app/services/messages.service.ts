import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessagesService {

  private apiMessagesUrl = 'http://localhost:5000/api/messages';

  httpOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
  };

  constructor(private http: HttpClient) { }

  getAllMessages(): Observable<Object> {
    return this.http.get<Object>(this.apiMessagesUrl, this.httpOptions);
  }

  getMessageByid(id: number): Observable<Object> {
    return this.http.get<Object>(this.apiMessagesUrl + '/' + id, this.httpOptions);
  }

  createMessage(data: any, recipient: string): Observable<Object> {
    return this.http.post(this.apiMessagesUrl + '/create', data, this.httpOptions);
  }

}
