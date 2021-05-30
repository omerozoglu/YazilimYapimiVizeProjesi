import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { Seller } from 'src/app/models/operations/seller.model';
import { Taker } from 'src/app/models/operations/taker.model';
import { SellService } from 'src/app/services/operations/sell/sell.service';
import { TakeService } from 'src/app/services/operations/take/take.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  @Input() Product: Product;
  @Input() OperationName: string;
  TakerModel = new Taker();
  SellerModel = new Seller();
  isClick: boolean = false;

  constructor(private takeService?: TakeService, private sellService?: SellService) { }

  ngOnInit(): void {
    console.log(this.Product);
  }
  public TakeOperaiton(weight, productId) {
    var mockUserId: string = "60af7e0417369373599f3a8d";
    this.TakerModel.productId = productId;
    this.TakerModel.userId = mockUserId;
    this.TakerModel.weight = weight;
    console.log(this.Product.id);
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