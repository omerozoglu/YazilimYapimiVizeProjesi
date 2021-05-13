import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SellProductComponent } from './sell-product/sell-product.component';
import { TakeProductComponent } from './take-product/take-product.component';



@NgModule({
  declarations: [
    SellProductComponent,
    TakeProductComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductsModule { }
