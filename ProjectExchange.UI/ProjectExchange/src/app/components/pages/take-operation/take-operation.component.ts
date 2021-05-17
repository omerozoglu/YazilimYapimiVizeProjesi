import { Component, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-take-operation',
  templateUrl: './take-operation.component.html',
  styleUrls: ['./take-operation.component.scss']
})
export class TakeOperationComponent implements OnInit {
  @Output() OperationName: string = "Take";
  constructor() { }

  ngOnInit(): void {
  }

}
