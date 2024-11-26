import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './Services/Authentication/AuthService/auth.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient, 
              private router: Router, 
              private auth: AuthService) {}

  ngOnInit() {
    if(this.auth.isLoggedIn){
      this.router.navigate(['/']);
    }
    else{
      this.router.navigate(['/login']);
    }
  }

  title = 'taskmanager.client';
}
