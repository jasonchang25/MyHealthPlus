import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from './_services/token-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private UserType: string[] = [];
  isLoggedIn = false;
  showAdminBoard = false;
  showStaffBoard = false;
  showAny = false;
  username?: string;

  constructor(private tokenStorageService: TokenStorageService) { }

  ngOnInit(): void {
    this.isLoggedIn = !!this.tokenStorageService.getToken();

    if (this.isLoggedIn) {
      const user = this.tokenStorageService.getUser();
      this.showAny = this.validateUserAttributes(user);
      this.UserType = user.userType;
      this.showAdminBoard = this.UserType.includes('Admin') && this.showAny;
      this.showStaffBoard = (this.UserType.includes('Admin') || this.UserType.includes('Staff')) && this.showAny;
      this.username = user.email;
    }
  }

  validateUserAttributes(user: any): boolean{
    if (!user.firstName || !user.lastName || !user.phoneNumber || !user.dateOfBirth){
      return false;
    }
    return true;
  }

  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }
}
