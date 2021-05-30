import { Component, OnInit } from '@angular/core';

import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public Products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    console.log(this.Products);
    this.getAllProducts();
  }
  public getAllProducts() {
    this.productService.getGroupedProducts().subscribe(products => {
      console.log(products);
      this.Products = products;
    });
  }
}
