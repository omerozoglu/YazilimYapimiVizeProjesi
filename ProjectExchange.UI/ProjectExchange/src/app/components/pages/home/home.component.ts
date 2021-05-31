import { Component, OnInit } from '@angular/core';

import { Product } from 'src/app/models/product.model';
import { User } from 'src/app/models/user.model';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public Products: Product[];
  public user: User = new User();
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getAllProducts();
    if (localStorage.getItem('id')) {
      this.user.credit = Number(localStorage.getItem('credit'));
    }
  }
  public getAllProducts() {
    this.productService.getGroupedProducts().subscribe(products => {
      this.Products = products;
    });
  }
}
