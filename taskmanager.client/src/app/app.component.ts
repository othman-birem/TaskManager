import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './Services/Authentication/AuthService/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  showNavbar: boolean = true;
  showSidebar: boolean = false;

  constructor(private router: Router, private auth: AuthService) {}

  ngOnInit() {
    // if(this.auth.isLoggedIn){
    //   // TODO: Handle direction to dashboard
    //   this.router.navigate(['/']);
    // }
    // else{
    //   this.router.navigate(['/']);
    // }
    this.auth.isLoggedIn$.subscribe((isLoggedIn) => {
      this.showNavbar = !isLoggedIn;
      this.showSidebar = isLoggedIn;
    });
  }

  title = 'taskmanager.client';
}
