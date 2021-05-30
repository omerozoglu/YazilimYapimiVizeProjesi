import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { ApprovalStatus } from 'src/app/models/Enums/approval-status.enum';
import { MoneyApproval } from 'src/app/models/operations/money-approval.model';
import { ProductApproval } from 'src/app/models/operations/product-approval.model';
import { Product } from 'src/app/models/product.model';
import { AdminConfirmService } from 'src/app/services/operations/admin-confrim/admin-confirm.service';
import { ProductService } from 'src/app/services/product/product.service';
@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  public products: Observable<Product[]> | any;

  public loadOperations: Observable<ProductApproval[]>;
  public depositOperations: Observable<MoneyApproval[]>;

  constructor(private productService: ProductService, private adminConfirmService: AdminConfirmService) { }

  displayedProductColumns: string[] = ['UserId', 'Product', "Weight", "Actions"];
  displayedMoneyColumns: string[] = ['UserId', 'Deposit', "Actions"];
  loadDataSource: MatTableDataSource<ProductApproval> = new MatTableDataSource<ProductApproval>();
  depositDataSource: MatTableDataSource<MoneyApproval> = new MatTableDataSource<MoneyApproval>();

  ngOnInit(): void {
    this.getAllProducts();
    this.getAllLoadOperations();
    this.getAllDepositOperations();
  }
  public getAllProducts() {
    this.productService.getAllProducts().subscribe(products => {
      this.products = products;
    });
  }
  public getAllLoadOperations() {
    this.loadOperations = this.adminConfirmService.getAllProductApproval();
    this.loadOperations.subscribe(p => {
      this.loadDataSource.data = p.filter(p => p.status.value == ApprovalStatus.Pending.value);
    });
  }
  public getAllDepositOperations() {
    this.depositOperations = this.adminConfirmService.getAllMoneyApproval();
    this.depositOperations.subscribe(p => {
      this.depositDataSource.data = p.filter(p => p.status.value == ApprovalStatus.Pending.value);
    });
  }

  public submitLoadResponse(item, status: number) {
    let productApproval: ProductApproval = item;
    if (status == 1) {
      productApproval.status = ApprovalStatus.Approved;
    } else {
      productApproval.status = ApprovalStatus.Denied;
    }

    this.adminConfirmService.LoadConfirmOperation(productApproval).subscribe(p => console.log(p));
  }

  public submitDepositResponse(item, status: number) {
    let moneyApproval: MoneyApproval = item;
    if (status == 1) {
      moneyApproval.status = ApprovalStatus.Approved;
    } else {
      moneyApproval.status = ApprovalStatus.Denied;
    }

    this.adminConfirmService.DepositConfirmOperation(moneyApproval).subscribe(p => console.log(p));
  }
}
