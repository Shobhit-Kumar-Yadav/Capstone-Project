import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiListService } from '../api-list.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private router: Router, private apiListService: ApiListService) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
  }

  login(): void {
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;
      this.apiListService.login(email, password).subscribe({
        next: response => {
          // Handle successful login (e.g., store token, redirect)
          let res = response.Description
          if (res == 'Success') {
            alert('Login successful');
          this.router.navigate(['/dashboard']);
          } else {
            alert('Incorrect Credentials');
          }
          
        },
        error: err => {
          // Handle login error
          alert('Invalid email or password');
        }
      });
    }
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

}
