import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserAccount } from '../../Models/user-account';
import { UserAccountService } from '../../Services/UserService/user-account.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  public accounts: UserAccount[] = [];
  firstName: string = '';
  secondName: string = '';
  dateOfBirth: string = '';
  occupation: string = '';
  mail: string = '';
  password: string = '';
  
  constructor(private userService: UserAccountService){

  }

  ngOnInit(): void {
    
  }

  isFormValid = () => this.firstName && this.secondName && this.dateOfBirth && this.occupation;

  onSubmit() {
    this.createUser();
  }
  createUser() {
    const user: UserAccount = {
      firstName: this.firstName,
      secondName: this.secondName,
      dateOfBirth: this.dateOfBirth,
      occupation: this.occupation,
      email: this.mail,
      password: this.password
    };
    this.userService.createUser(user).subscribe(
      response => {
        console.log('User created successfully:', response);
      },
      error => {
        console.error('Error creating user:', error);
      }
    );
  }
}
