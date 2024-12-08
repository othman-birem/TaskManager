import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.isLoggedInSubject.asObservable();

  private currentUserSubject: BehaviorSubject<any>;
  public currentUser: Observable<any>;

  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<any>(
      JSON.parse(localStorage.getItem('currentUser') || 'null')
    );
    this.currentUser = this.currentUserSubject.asObservable();
    if (localStorage.getItem('currentUser')){
      this.isLoggedInSubject.next(true);
    }
    else{
      this.isLoggedInSubject.next(false);
    }
  }

  login(email: string, password: string): Observable<any> {
    return this.http.post<any>('/useraccount/login', { email, password }).pipe(
      map((response) => {
        if (response && response.token) {
          localStorage.setItem('currentUser', JSON.stringify(response));
          localStorage.setItem('token', response.token);

          this.currentUserSubject.next(response);
          this.isLoggedInSubject.next(true);
        }
        return response;
      })
    );
  }

  logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('token');
    
    this.currentUserSubject.next(null);
    this.isLoggedInSubject.next(false);
  }

  public get isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
  public get currentUserValue() {
    return this.currentUserSubject.value;
  }
}
