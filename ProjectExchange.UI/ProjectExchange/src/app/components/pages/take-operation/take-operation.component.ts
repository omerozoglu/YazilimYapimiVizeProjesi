import { Component, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-take-operation',
  templateUrl: './take-operation.component.html',
  styleUrls: ['./take-operation.component.scss']
})
export class TakeOperationComponent implements OnInit {
  @Output() OperationName: string = "Take";

  public products: Observable<Product[]> | any;
  constructor(private productService: ProductService) { }
  ngOnInit(): void {
    this.getAllProducts();
  }
  public getAllProducts() {
    this.productService.getGroupedProducts().subscribe(products => {
      this.products = products;
    });
  }
}
