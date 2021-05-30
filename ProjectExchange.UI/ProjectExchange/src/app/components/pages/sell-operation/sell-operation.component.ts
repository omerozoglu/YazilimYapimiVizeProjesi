import { Component, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product/product.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-sell-operation',
  templateUrl: './sell-operation.component.html',
  styleUrls: ['./sell-operation.component.scss']
})
export class SellOperationComponent implements OnInit {

  @Output() OperationName: string = "Sell";
  public products: Observable<Product[]> | any;

  constructor(private productService: ProductService, private userService?: UserService) { }
  ngOnInit(): void {
    this.getUserProducts();
  }
  public getUserProducts() {
    var mockUserId: string = "60af7e0417369373599f3a8d";
    this.userService.getUserById(mockUserId).subscribe(user => {
      this.productService.getProductUser(user[0].products).subscribe(products => {
        this.products = products;
      });
    });
  }
}
