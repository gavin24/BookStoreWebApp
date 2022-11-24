import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(
    private router: Router) { }
  onRegister() {
    this.router.navigate(['/Register']);

  }
  onLogin() {
    this.router.navigate(['/Login']);

  }
  onApiRegister() {
    this.router.navigate(['/Api-Register']);

  }

}
