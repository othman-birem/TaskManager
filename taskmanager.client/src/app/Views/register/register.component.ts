import { Component, OnInit } from '@angular/core';
import { AccessPrivileges, UserAccount } from '../../Models/user-account';
import { UserAccountService } from '../../Services/UserService/user-account.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  accessPrivileges = Object.keys(AccessPrivileges)
    .filter(key => !isNaN(Number(key)))
    .map(key => ({
      value: AccessPrivileges[key as unknown as number],
      label: key
    }));

  isLoading: boolean = false;
  public accounts: UserAccount[] = [];

  fullName: string = '';
  dateOfBirth: string = '';
  occupation: string = '';
  mail: string = '';
  password: string = '';
  accessPrivilege = 0;
  
  constructor(private userService: UserAccountService, private router: Router){

  }

  ngOnInit(): void {
    
  }

  isFormValid = () => this.fullName && this.dateOfBirth && this.occupation;

  onSubmit() {
    this.isLoading = true;
    this.createUser();
    this.isLoading = false;
    
  }
  createUser() {
    const user: UserAccount = {
      Id: '',
      fullName: this.fullName,
      dateOfBirth: this.dateOfBirth,
      occupation: this.occupation,
      email: this.mail,
      password: this.password,
      teamId: '',
      accessPrivilege: this.accessPrivilege
    };
    this.userService.createUser(user).subscribe(
      response => {
        console.log('User created successfully:', response);
        this.router.navigate(['/login']);
      },
      error => {
        console.error('Error creating user:', error);
      }
    );
  }
}
