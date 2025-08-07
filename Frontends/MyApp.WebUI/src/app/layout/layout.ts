import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, RouterModule, RouterOutlet } from '@angular/router';
import { AuthService } from '../services/auth';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-layout',
  imports: [RouterModule, CommonModule],
  templateUrl: './layout.html',
  styleUrls: ['./layout.css']
})
export class Layout implements OnInit, OnDestroy {
  isLoggedIn = false;
  username = '';
  private authSub?: Subscription;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.checkAuth();

    this.authSub = this.authService.authStatus$.subscribe(status => {
      this.isLoggedIn = status;
      if (status) {
        this.username = this.authService.getUsername();
      } else {
        this.username = '';
      }
    });
  }

  checkAuth() {
    this.isLoggedIn = this.authService.isAuthenticated();
    if (this.isLoggedIn) {
      this.username = this.authService.getUsername();
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  ngOnDestroy(): void {

    this.authSub?.unsubscribe();
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }
}