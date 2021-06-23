import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { TokenStorageService } from '../_services/token-storage.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  form: any = {
    username: null,
    password: null,
    userType: "",
  };
  userTypes: Array<string>;
  isSuccessful = false;
  isSignUpFailed = false;
  isAdmin = false;
  errorMessage = '';

  constructor(private authService: AuthService, private token : TokenStorageService) {
    this.userTypes = ["Admin", "Staff", "Client"];
   }

  ngOnInit(): void {
    this.isAdmin = this.token.getUser()?.userType == "Admin";
  }

  OnSubmit(): void {
    const { username, password, userType } = this.form;
    if (this.isAdmin){
      this.authService.RegisterStaff(username, password, userType).subscribe(
        data => {
          this.isSuccessful = true;
          this.isSignUpFailed = false;
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
        }
      );
    }
    else{
      this.authService.Register(username, password).subscribe(
        data => {
          this.isSuccessful = true;
          this.isSignUpFailed = false;
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
        }
      );
    }    
  }
}
