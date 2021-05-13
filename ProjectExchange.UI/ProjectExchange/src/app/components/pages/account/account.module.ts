import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { LayoutComponent } from './layout/layout.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';



@NgModule({
  declarations: [
    LoginComponent,
    LogoutComponent,
    LayoutComponent,
    ForgotPasswordComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AccountModule { }
