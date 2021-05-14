import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import { HomeComponent } from './home/home.component';
import { AccountModule } from './account/account.module';
import { ProductsModule } from './products/products.module';

@NgModule({
  declarations: [
    HomeComponent,
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
