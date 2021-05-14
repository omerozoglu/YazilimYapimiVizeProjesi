import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  @Input() Product = {
    Name: "",
    Weight: 0,
    UnitPrice: 0,
    ImgUrl: ""
  };
  @Input() OperationName: string;

  isClick: boolean = false;
  isOperationSell: boolean = true;

  constructor() { }
  displayNone;
  ngOnInit(): void {
  }
}
