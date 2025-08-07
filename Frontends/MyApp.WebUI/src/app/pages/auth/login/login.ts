import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  model = {
    userName: '',
    password: ''
  };

  message = '';

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    this.authService.login(this.model).subscribe({
      next: (res: any) => {
        this.authService.saveToken(res.token);
        this.router.navigate(['/contents']);
      },
      error: (err) => {
        this.message = err.error || 'Giriş başarısız';
      }
    });
  }
}
