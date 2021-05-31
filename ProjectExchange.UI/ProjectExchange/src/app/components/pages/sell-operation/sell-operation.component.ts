import { Component, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { User } from 'src/app/models/user.model';
import { ProductService } from 'src/app/services/product/product.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-sell-operation',
  templateUrl: './sell-operation.component.html',
  styleUrls: ['./sell-operation.component.scss']
})
export class SellOperationComponent implements OnInit {

  @Output() OperationName: string = "Sell";
  public user: User = new User();
  public products: Observable<Product[]> | any;

  constructor(private productService: ProductService, private userService?: UserService) { }
  ngOnInit(): void {
    if (localStorage.getItem('id')) {
      this.user.id = localStorage.getItem('id');
      this.getUserProducts();
    }
  }
  public getUserProducts() {
    this.userService.getUserById(this.user.id).subscribe(user => {
      this.productService.getProductUser(user[0].products).subscribe(products => {
        this.products = products;
      });
    });
  }
}
