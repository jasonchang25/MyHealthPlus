import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { TokenStorageService } from '../_services/token-storage.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any = {
    username: null,
    password: null
  };
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  UserType: string[] = [];
  FirstName: string = "";
  LastName: string = "";

  constructor(private authService: AuthService, private tokenStorage: TokenStorageService, private router: Router) { }

  ngOnInit(): void {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.UserType = this.tokenStorage.getUser().userType;
      this.FirstName = this.tokenStorage.getUser().firstName;
      this.LastName = this.tokenStorage.getUser().lastName;
      if (!this.validateUserAttributes()){
        this.router.navigate(['/profile']);
      }
    }
  }

  validateUserAttributes(): boolean{
    var user = this.tokenStorage.getUser();
    if (!user.firstName || !user.lastName || !user.phoneNumber || !user.dateOfBirth){
      return false;
    }
    return true;
  }

  onSubmit(): void {
    const { username, password } = this.form;

    this.authService.Login(username, password).subscribe(
      data => {
        this.tokenStorage.saveToken(data.token);
        this.tokenStorage.saveUser(data);
        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.UserType = this.tokenStorage.getUser().userType;
        this.FirstName = this.tokenStorage.getUser().firstName;
        this.LastName = this.tokenStorage.getUser().lastName;
        this.reloadPage();
      },
      err => {
        this.errorMessage = err.error.message;
        this.isLoginFailed = true;
      }
    );
  }
  
  reloadPage(): void {
    window.location.reload();
  }
}
