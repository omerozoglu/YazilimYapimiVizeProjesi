import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
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
