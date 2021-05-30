import { Component, Input, OnInit } from '@angular/core';
import { ProductApproval } from 'src/app/models/operations/product-approval.model';
import { Product } from 'src/app/models/product.model';
import { LoadService } from 'src/app/services/operations/load/load.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-load-operation',
  templateUrl: './load-operation.component.html',
  styleUrls: ['./load-operation.component.scss']
})


export class LoadOperationComponent implements OnInit {
  SystemProducts = [
    { name: "Wheat", imgUrl: "https://i.ibb.co/yB5cfPM/icons8-wheat-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Apple", imgUrl: "https://i.ibb.co/zNjTcQM/icons8-apple-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Barley", imgUrl: "https://i.ibb.co/wctBDds/icons8-barley-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Cabbage", imgUrl: "https://i.ibb.co/1MmtGVn/icons8-cabbage-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Watermelon", imgUrl: "https://i.ibb.co/W03nyTv/icons8-watermelon-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Pear", imgUrl: "https://i.ibb.co/7VPJr3j/icons8-pear-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Orange", imgUrl: "https://i.ibb.co/L6S8M5b/icons8-orange-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Olive", imgUrl: "https://i.ibb.co/YybGDy2/icons8-olive-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Corn", imgUrl: "https://i.ibb.co/wSxnXbT/icons8-corn-100.png", Id: null, UnitPrice: 0, Weight: 0 },
    { name: "Carrot", imgUrl: "https://i.ibb.co/474BWNM/icons8-carrot-100.png", Id: null, UnitPrice: 0, Weight: 0 },
  ];
  isClick: boolean = false;
  Product = new Product();
  ProductApprovalModel = new ProductApproval();

  constructor(private productService?: ProductService, private loadService?: LoadService) { }


  ngOnInit(): void {
    //  this.getAllProducts();
    //  console.log(this.Product);
  }
  public getAllProducts() {
  }
  public loadOperation(weight, productName, productImgUrl) {
    var mockUserId: string = "60af7e0417369373599f3a8d";
    this.ProductApprovalModel.userId = mockUserId;
    this.ProductApprovalModel.productName = productName;
    this.ProductApprovalModel.productImgUrl = productImgUrl;
    this.ProductApprovalModel.productWeight = weight;

    this.loadService.LoadOperation(this.ProductApprovalModel).subscribe(operation => {
      console.log(operation);
    });
  }

}
