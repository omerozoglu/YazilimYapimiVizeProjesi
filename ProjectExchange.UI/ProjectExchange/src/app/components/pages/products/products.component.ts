import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  @Input() OperationName: string;

  @Input()
  public Products: Product[] | any;

  ngOnInit(): void {
  }

}
