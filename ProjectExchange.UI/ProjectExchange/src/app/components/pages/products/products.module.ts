import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductRoutingModule } from './pages-routing.module';
import { ProductComponent } from './product/product.component';
import { ProductsComponent } from './products.component';


@NgModule({
  declarations: [
    ProductsComponent,
    ProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule
  ], exports: [ProductsComponent, ProductComponent]
})
export class ProductsModule { }
