import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { HomeComponent } from './home/home.component';
import { ProductsModule } from './products/products.module';
import { AccountModule } from './account/account.module';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    ProductsModule,
    AccountModule,
  ],exports:[ HomeComponent]
})
export class PagesModule { }
