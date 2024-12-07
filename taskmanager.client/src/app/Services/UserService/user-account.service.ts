import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserAccount } from '../../Models/user-account';

@Injectable({
  providedIn: 'root'
})
export class UserAccountService {

  private apiUrl = '/useraccount';

  constructor(private http: HttpClient) {}

  createUser(user: UserAccount): Observable<UserAccount> {
    return this.http.post<UserAccount>(this.apiUrl + '/register', user);
  }
  // getUsers(){
  //   this.http.get<UserAccount[]>('/useraccount/register').subscribe(
  //     (result) => {
  //       console.log(result);
  //       return result;
  //     },
  //     (error) => {
  //       console.error(error);
  //     }
  //   )
  // }
}
