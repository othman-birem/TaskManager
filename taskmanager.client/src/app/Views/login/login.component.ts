import { Component } from '@angular/core';
import { AuthService } from '../../Services/Authentication/AuthService/auth.service';
import { first } from 'rxjs/operators';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  isLoading: boolean = false;
  email: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router){

  }

  onSubmit() {
    this.isLoading = true;
    this.authService.login(this.email, this.password)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/dashboard']);
        },
        error => {
          alert('Invalid email or password');
        });
    this.isLoading = false;
  }
}
