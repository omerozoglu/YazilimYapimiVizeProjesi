import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { AdminComponent } from './admin/admin.component';
import { HomeComponent } from './home/home.component';
import { LoadOperationComponent } from './load-operation/load-operation.component';
import { MoneyDepositOperationComponent } from './money-deposit-operation/money-deposit-operation.component';
import { SellOperationComponent } from './sell-operation/sell-operation.component';
import { TakeOperationComponent } from './take-operation/take-operation.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'sell', component: SellOperationComponent },
  { path: 'take', component: TakeOperationComponent },
  { path: 'load', component: LoadOperationComponent },
  { path: 'moneydeposit', component: MoneyDepositOperationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'admin', component: AdminComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
