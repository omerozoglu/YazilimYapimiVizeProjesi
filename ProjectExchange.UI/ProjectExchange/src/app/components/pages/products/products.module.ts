import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TakeOperationComponent } from './take-operation/take-operation.component';
import { SellOperationComponent } from './sell-operation/sell-operation.component';
import { ProductRoutingModule } from './pages-routing.module';
import { ProductComponent } from './product/product.component';
import { ProductsComponent } from './products.component';


@NgModule({
  declarations: [
    ProductsComponent,
    TakeOperationComponent,
    SellOperationComponent,
    ProductComponent
  ],
  imports: [
    CommonModule,
    ProductRoutingModule
  ], exports: [ProductsComponent, ProductComponent]
})
export class ProductsModule { }
