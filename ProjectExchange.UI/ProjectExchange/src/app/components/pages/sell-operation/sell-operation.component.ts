import { Component, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-sell-operation',
  templateUrl: './sell-operation.component.html',
  styleUrls: ['./sell-operation.component.scss']
})
export class SellOperationComponent implements OnInit {

  @Output() OperationName: string = "Sell";
  constructor() {

  }

  ngOnInit(): void {
  }

}
