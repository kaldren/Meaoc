import { Component, OnInit, Renderer2 } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { UserSearch } from 'src/app/models/user-search.model';
import { distinctUntilChanged, debounceTime, switchMap } from 'rxjs/operators';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-search',
  templateUrl: './user-search.component.html',
  styleUrls: ['./user-search.component.css']
})
export class UserSearchComponent implements OnInit {

  users$: Observable<UserSearch[]>;
  private searchTerms = new Subject<string>();
  searchBoxUsername: string;
  isUsernameSelected = false;

  constructor(private userService: UserService, private render: Renderer2) { }

  search(term: string): void {
    this.isUsernameSelected = false;
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.users$ = this.searchTerms.pipe(
      debounceTime(300),

      distinctUntilChanged(),

      switchMap((term: string) => this.userService.searchUser(term)
    ));
  }

  setUsername(username: string) {
    this.isUsernameSelected = true;
    this.searchBoxUsername = username;
  }

}
