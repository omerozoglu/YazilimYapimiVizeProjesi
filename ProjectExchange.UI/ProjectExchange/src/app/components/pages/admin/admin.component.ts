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
  public depositOperations: Observable<MoneyApproval[]> | any;

  public ProductApprovalModel: ProductApproval = new ProductApproval();

  public response;
  constructor(private productService: ProductService, private adminConfirmService: AdminConfirmService) { }

  displayedProductColumns: string[] = ['Name', "Weight"];
  public loadtablemodels: LoadTableModel[] = [];
  dataSource: MatTableDataSource<LoadTableModel>;
  ngOnInit(): void {
    //this.getAllProducts();
    this.getAllLoadOperations();

  }
  public getAllProducts() {
    this.productService.getAllProducts().subscribe(products => {
      this.products = products;
    });
  }
  public getAllLoadOperations() {
    var loadTableModel = new LoadTableModel();
    this.adminConfirmService.getAllProductApproval().subscribe(operation => {
      operation.filter(p => p.status.Value != ApprovalStatus.Approved.Value).forEach(p => {
        loadTableModel.Name = p.productName;
        loadTableModel.Weight = p.productWeight;
        this.loadtablemodels.push(loadTableModel);
        this.dataSource = new MatTableDataSource<LoadTableModel>(this.loadtablemodels);
        console.log(p);
      });
    });
  }
  public getAllDepositOperations() {

  }

  public submitDepositResponse(deposite) {
    var mockUserId: string = "60af7e0417369373599f3a8d";
    //var productId: string = this.Product.id;
    //  this.AdminModel.UserId = mockUserId;
    // this.AdminModel.Deposite =
    //  this.AdminModel.ProductId = productId;

    //   this.adminConfirmService.AdminConfirmOperation(this.AdminModel).subscribe();
  }
}
class LoadTableModel {
  Name: string;
  Weight: number;
}
