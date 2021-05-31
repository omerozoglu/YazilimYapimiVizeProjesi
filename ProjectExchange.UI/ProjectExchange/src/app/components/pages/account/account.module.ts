import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { LayoutComponent } from './layout/layout.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RegisterComponent } from './register/register.component';
import { AccountRoutingModule } from './account-routing.module';
import { UserService } from 'src/app/services/user/user.service';
import { AuthGuard } from './auth-gurad/auth-guard';



@NgModule({
  declarations: [
    LoginComponent,
    LogoutComponent,
    LayoutComponent,
    ForgotPasswordComponent,
    RegisterComponent,
  ],
  imports: [
    CommonModule,
    AccountRoutingModule
  ],
  providers: [
    UserService,
    AuthGuard
  ]
})
export class AccountModule { }
