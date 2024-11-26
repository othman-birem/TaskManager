import { Component, Injectable, HostListener } from '@angular/core';
import { ScrollService } from '../../Services/ScrollService/scroll-service.service';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})

@Injectable({ providedIn: 'root' })
export class NavbarComponent {
  isMenuOpen: boolean = false;
  languages = [
    { name: 'English', code: 'en', icon: '/Icons/britan.png' },
    { name: 'French', code: 'fr', icon: '/Icons/france.png' }
  ];
  
  selectedLang = this.languages[0]; 
  dropdownOpen = false;
  currentComponent: string = "";

  constructor(private ScrollService: ScrollService, private router: Router, private activatedRoute: ActivatedRoute) {
    
  }

  switchLang(event: Event): void {
    // const selectElement = event.target as HTMLSelectElement;
    // const selectedCode = selectElement.value;

    // this.translator.use(selectedCode);
    
    // // Update the selected language and its icon
    // this.selectedLang = this.languages.find(lang => lang.code === selectedCode) || this.selectedLang;

    // // Dynamically change the icon
    // const languageIcon = document.getElementById('languageIcon') as HTMLImageElement;
    // if (languageIcon) {
    //   languageIcon.src = this.selectedLang.icon;
    // }
  }

  @HostListener('window:scroll', ['$event'])
  onWindowScroll() {
    let element = document.querySelector('.mat-toolbar') as HTMLElement;
    if (element) {
      if (window.pageYOffset > element.clientHeight) {
        element.classList.remove('white-panel');
        element.classList.add('glass-panel');
      } else {
        element.classList.remove('glass-panel');
        element.classList.add('white-panel');
      }
    }
  }

  ScrollToContact() {
    this.ScrollService.scrollToElement('contact');
  }

  scrollToPricing() {
    if(this.getDisplayedComponent() != "_HomeComponent") {

      this.router.navigateByUrl("");
      this.router.events.pipe(
        filter(event => event instanceof NavigationEnd)
      ).subscribe((event: NavigationEnd) => {
        // Routing is finished, place your logic here
        // console.log('Navigation finished:', event);
        this.ScrollService.scrollToElement('pricing');
      });
    } else this.ScrollService.scrollToElement('pricing');
  }

  getDisplayedComponent() {
    let route = this.activatedRoute;

    while (route.firstChild) {
      route = route.firstChild;
    }
    return route.component?.name;
  }

  toggleDropdown() {
    this.dropdownOpen = !this.dropdownOpen;
  }
}
