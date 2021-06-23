import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { BookAppointmentComponent } from './book-appointment/book-appointment.component';
import { ViewAppointmentsCompontent } from './view-appointments/view-appointments.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'bookAppointment', component: BookAppointmentComponent },
  { path: 'viewAppointments', component: ViewAppointmentsCompontent },
  { path: 'createStaffAcount', component: RegisterComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
