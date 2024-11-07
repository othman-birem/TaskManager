import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  firstName: string = '';
  secondName: string = '';
  dateOfBirth: string = '';
  occupation: string = '';

  isFormValid = () => this.firstName && this.secondName && this.dateOfBirth && this.occupation;

  onSubmit() {
    console.log('First Name:', this.firstName);
    console.log('Second Name:', this.secondName);
    console.log('Date of Birth:', this.dateOfBirth);
    console.log('Occupation:', this.occupation);

    // Add registration logic here, such as calling an API service
    alert('Registration successful!');
  }
}
