import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products.component';
import { SellOperationComponent } from './sell-operation/sell-operation.component';
import { TakeOperationComponent } from './take-operation/take-operation.component';

const routes: Routes = [{
  path: 'products',
  component: ProductsComponent,
  children: [
    { path: '', redirectTo: 'products', pathMatch: 'full' },
    { path: 'sell', component: SellOperationComponent },
    { path: 'take', component: TakeOperationComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
