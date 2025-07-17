import { Component } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  name = new FormControl('');
  password = new FormControl('');
  resultMessage: string = '';
  userData: any = null;

  isLoggedIn: boolean = false;
  activeForm: string = '';
  allUsers: any[] = [];

  // Bindings for user CRUD
  newUser: any = {};
  updateUser: any = {};
  searchEmail: string = '';
  searchId: number | null = null;
  deleteUserId: number | null = null;

  constructor(private http: HttpClient) {}

  // ✅ Login
  loginUser() {
    const loginData = {
      emailAddress: this.name.value,
      password: this.password.value
    };

    this.http.post<any>('https://localhost:7277/api/Login/LoginUser', loginData)
      .subscribe({
        next: (res) => {
          this.resultMessage = res.message;
          if (res.result === 1 && res.data) {
            this.userData = res.data;
            this.isLoggedIn = true;
            this.updateUser.emailAddress = this.userData.emailAddress; // Pre-fill email for update
          } else {
            this.userData = null;
            this.isLoggedIn = false;
          }
        },
        error: () => {
          this.resultMessage = "Login failed. Please check your credentials.";
          this.userData = null;
          this.isLoggedIn = false;
        }
      });
  }

  // ✅ Show specific form section
  showForm(form: string) {
    this.activeForm = form;
  }

  // ✅ Create user
  createUser() {
    this.http.post<any>('https://localhost:7277/api/Login/CreateUser', this.newUser)
      .subscribe({
        next: (res) => {
          this.resultMessage = res.message;
        },
        error: () => {
          this.resultMessage = "Failed to create user.";
        }
      });
  }

  // ✅ Get user by email
  getUserByEmail() {
    this.http.get<any>(`https://localhost:7277/api/Login/GetUserByEmail?email=${this.searchEmail}`)
      .subscribe({
        next: (res) => {
          this.userData = res.data;
          this.resultMessage = res.message;
        },
        error: () => {
          this.resultMessage = "Failed to fetch user by email.";
        }
      });
  }

  // ✅ Get user by ID
  getUserById() {
    this.http.get<any>(`https://localhost:7277/api/Login/GetUserById/${this.searchId}`)
      .subscribe({
        next: (res) => {
          this.userData = res.data;
          this.resultMessage = res.message;
        },
        error: () => {
          this.resultMessage = "Failed to fetch user by ID.";
        }
      });
  }

  // ✅ Update user by email
  updateUserByEmail() {
    this.http.put<any>('https://localhost:7277/api/Login/UpdateUserByEmail', this.updateUser)
      .subscribe({
        next: (res) => {
          this.resultMessage = res.message;
        },
        error: () => {
          this.resultMessage = "Failed to update user.";
        }
      });
  }

  // ✅ Delete user
  deleteUser() {
    this.http.delete<any>(`https://localhost:7277/api/Login/DeleteUser/${this.deleteUserId}`)
      .subscribe({
        next: (res) => {
          this.resultMessage = res.message;
        },
        error: () => {
          this.resultMessage = "Failed to delete user.";
        }
      });
  }

  // ✅ Get all users
  getAllUsers() {
    this.http.get<any>('https://localhost:7277/api/Login/GetAllUsers')
      .subscribe({
        next: (res) => {
          this.resultMessage = res.message;
          this.allUsers = res.data || [];
        },
        error: () => {
          this.resultMessage = "Failed to fetch all users.";
        }
      });
  }
}
