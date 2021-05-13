import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { HomeComponent } from './home/home.component';
import { AccountModule } from './account/account.module';
import { ProductModule } from './product/products.module';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    AccountModule,
    ProductModule
  ], exports: [HomeComponent]
})
export class PagesModule { }
