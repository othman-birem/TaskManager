import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './Services/Authentication/AuthService/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  constructor(private router: Router, 
              private auth: AuthService) {}

  ngOnInit() {
    // if(this.auth.isLoggedIn){
    //   // TODO: Handle direction to dashboard
    //   this.router.navigate(['/']);
    // }
    // else{
    //   this.router.navigate(['/']);
    // }
  }

  title = 'taskmanager.client';
}
