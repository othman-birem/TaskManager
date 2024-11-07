import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  onSubmit() {
    console.log('Username:', this.username);
    console.log('Password:', this.password);

    // Add authentication logic here, such as calling an API service
    if (this.username === 'admin' && this.password === 'password') {
      alert('Login successful!');
    } else {
      alert('Invalid credentials');
    }
  }
}
