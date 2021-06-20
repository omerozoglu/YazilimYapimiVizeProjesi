import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { Seller } from 'src/app/models/operations/seller.model';
import { Taker } from 'src/app/models/operations/taker.model';
import { SellService } from 'src/app/services/operations/sell/sell.service';
import { TakeService } from 'src/app/services/operations/take/take.service';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})

export class ProductComponent implements OnInit {
  @Input() Product: Product;
  @Input() OperationName: string;

  public user: User = new User();
  TakerModel = new Taker();
  SellerModel = new Seller();
  isClick: boolean = false;

  constructor(private takeService?: TakeService, private sellService?: SellService) { }

  ngOnInit(): void {
    console.log(this.Product);
    if (localStorage.getItem('id')) {
      this.user.id = localStorage.getItem('id');
    }
  }
  public TakeOperaiton(weight: number, unitprice: number) {
    this.TakerModel.productName = this.Product.name;
    this.TakerModel.userId = this.user.id;
    this.TakerModel.weight = weight;
    this.TakerModel.unitPrice = unitprice;
    console.log(this.TakerModel);
    this.takeService.TakeOperation(this.TakerModel).subscribe(operation => {
      console.log(operation);
    });
  }
  public SellOperation(weight: number, unitprice: number) {
    this.SellerModel.userId = this.Product.userId;
    this.SellerModel.productId = this.Product.id;
    this.SellerModel.weight = weight;
    this.SellerModel.unitPrice = unitprice;
    this.sellService.SellOperation(this.SellerModel).subscribe(operation => {
      console.log(operation);
    });
  }
}
