import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { HomeComponent } from './home/home.component';
import { AccountModule } from './account/account.module';
import { ProductsModule } from './products/products.module';
import { SellOperationComponent } from './sell-operation/sell-operation.component';
import { TakeOperationComponent } from './take-operation/take-operation.component';
import { LoadOperationComponent } from './load-operation/load-operation.component';
import { MoneyDepositOperationComponent } from './money-deposit-operation/money-deposit-operation.component';
import { AdminComponent } from './admin/admin.component';
import { MatTableModule } from '@angular/material/table'
@NgModule({
  declarations: [
    HomeComponent,
    SellOperationComponent,
    TakeOperationComponent,
    LoadOperationComponent,
    MoneyDepositOperationComponent,
    AdminComponent
  ],
  imports: [
    CommonModule,
    ProductsModule,
    PagesRoutingModule,
    AccountModule,
    MatTableModule
  ],
  exports: [HomeComponent]
})
export class PagesModule { }
