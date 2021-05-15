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

@NgModule({
  declarations: [
    HomeComponent,
    SellOperationComponent,
    TakeOperationComponent,
    LoadOperationComponent,
    MoneyDepositOperationComponent
  ],
  imports: [
    CommonModule,
    ProductsModule,
    PagesRoutingModule,
    AccountModule
  ],
  exports: [HomeComponent]
})
export class PagesModule { }
