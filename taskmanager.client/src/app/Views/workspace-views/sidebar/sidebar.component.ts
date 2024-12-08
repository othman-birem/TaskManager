import { Component } from '@angular/core';
import { AuthService } from '../../../Services/Authentication/AuthService/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
})
export class SidebarComponent {
  selectedLink: string = '';
  constructor(private auth: AuthService, private router: Router) {}
  logout(): void {
    this.auth.logout();
    this.router.navigate(['/']);
  }
  selectLink(link: string): void {
    this.selectedLink = link;
  }
}
