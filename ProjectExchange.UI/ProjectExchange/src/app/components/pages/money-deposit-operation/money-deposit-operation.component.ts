import { Component, OnInit } from '@angular/core';
import { MoneyApproval } from 'src/app/models/operations/money-approval.model';
import { DepositService } from 'src/app/services/operations/deposit/deposit.service';

@Component({
  selector: 'app-money-deposit-operation',
  templateUrl: './money-deposit-operation.component.html',
  styleUrls: ['./money-deposit-operation.component.scss']
})
export class MoneyDepositOperationComponent implements OnInit {

  MoneyApprovalModel = new MoneyApproval();
  constructor(private depositService?: DepositService) { }

  ngOnInit(): void {
  }
  public DepositOperaiton(money) {
    var mockUserId: string = "60af7e0417369373599f3a8d";
    this.MoneyApprovalModel.userId = mockUserId;
    this.MoneyApprovalModel.deposit = money;

    this.depositService.DepositOperation(this.MoneyApprovalModel).subscribe(operation => {
      console.log(operation);
    });
  }
}
