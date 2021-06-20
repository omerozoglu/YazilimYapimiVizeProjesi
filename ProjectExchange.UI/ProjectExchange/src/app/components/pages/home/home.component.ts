import { Component, OnInit } from '@angular/core';
import jsPDF from 'jspdf';
import { report } from 'process';

import { Product } from 'src/app/models/product.model';
import { User } from 'src/app/models/user.model';
import { ProductService } from 'src/app/services/product/product.service';
import { ReportService } from 'src/app/services/report/report.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public Products: Product[];
  public user: User = new User();
  constructor(private productService: ProductService, private reportService: ReportService) { }

  ngOnInit(): void {
    this.getAllProducts();
    if (localStorage.getItem('id')) {
      this.user.credit = Number(localStorage.getItem('credit'));
    }
  }
  public getAllProducts() {
    this.productService.getGroupedProducts().subscribe(products => {
      this.Products = products;
    });
  }
  public getReport() {
    var doc = new jsPDF();
    this.reportService.getAllReport().subscribe(reports => {
      var text = "";
      reports.forEach(r => {
        text += "Tarih: " + r.createdDate + "\n Ürün Adı:" + + r.productName + "\n İşlem Fiyatı:" + r.unitPrice + "\n İşlem Ağırlığı:" + r.weight;
      });
      doc.text(text, 10, 10);
      doc.save("Report.pdf");
    });
  }
}
