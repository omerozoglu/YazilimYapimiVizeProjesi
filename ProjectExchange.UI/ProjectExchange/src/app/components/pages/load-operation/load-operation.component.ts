import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-load-operation',
  templateUrl: './load-operation.component.html',
  styleUrls: ['./load-operation.component.scss']
})
export class LoadOperationComponent implements OnInit {
  isClick: boolean = false;
  Product = {
    Name: "",
    Weight: 0,
    UnitPrice: 0,
    ImgUrl: ""
  };
  public products = [{
    Name: "Wheat",
    Weight: 150.0,
    UnitPrice: 1.5,
    ImgUrl: "https://i.ibb.co/yB5cfPM/icons8-wheat-100.png"
  }, {
    Name: "Apple",
    Weight: 150.0,
    UnitPrice: 1.5,
    ImgUrl: "https://i.ibb.co/zNjTcQM/icons8-apple-100.png"
  }, {
    Name: "Barley",
    Weight: 150.0,
    UnitPrice: 1.5,
    ImgUrl: "https://i.ibb.co/wctBDds/icons8-barley-100.png"
  }, {
    Name: "Patato",
    Weight: 150.0,
    UnitPrice: 1.5,
    ImgUrl: "https://i.ibb.co/Mg5Xpgd/icons8-potato-100.png"
  }, {
    Name: "Corn",
    Weight: 150.0,
    UnitPrice: 1.5,
    ImgUrl: "https://i.ibb.co/wSxnXbT/icons8-corn-100.png"
  }];

  constructor() { }

  ngOnInit(): void {

  }
}
