import { Component, OnInit } from '@angular/core';
import { CurrencyType } from 'src/app/models/Enums/currency-type';
import { MoneyApproval } from 'src/app/models/operations/money-approval.model';
import { User } from 'src/app/models/user.model';
import { DepositService } from 'src/app/services/operations/deposit/deposit.service';

@Component({
  selector: 'app-money-deposit-operation',
  templateUrl: './money-deposit-operation.component.html',
  styleUrls: ['./money-deposit-operation.component.scss']
})
export class MoneyDepositOperationComponent implements OnInit {

  public user: User = new User();
  MoneyApprovalModel = new MoneyApproval();
  constructor(private depositService?: DepositService) { }

  ngOnInit(): void {
    if (localStorage.getItem('id')) {
      this.user.id = localStorage.getItem('id');
    }
  }
  public DepositOperaiton(money: number, currency: string = "TRY") {
    this.MoneyApprovalModel.userId = this.user.id;
    this.MoneyApprovalModel.deposit = money;
    if (currency == CurrencyType.EUR.value) {
      this.MoneyApprovalModel.currency = CurrencyType.EUR;
    } else if (currency = CurrencyType.GBP.value) {
      this.MoneyApprovalModel.currency = CurrencyType.GBP;
    } else if (currency = CurrencyType.CHF.value) {
      this.MoneyApprovalModel.currency = CurrencyType.CHF;
    } else {
      this.MoneyApprovalModel.currency = CurrencyType.TRY;
    }
    this.depositService.DepositOperation(this.MoneyApprovalModel).subscribe(operation => {
      console.log(operation);
    });
  }
}
