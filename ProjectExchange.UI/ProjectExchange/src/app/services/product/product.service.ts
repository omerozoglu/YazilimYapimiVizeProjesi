import { Product } from '../../models/product.model';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../models/api-response';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  public productlist: Product[] | any;
  public product: Product | any;
  constructor(private http: HttpClient) { }

  public getAllProducts(): Observable<Product[]> {
    return this.http.get<ApiResponse>(`${environment.productApiUrl}/Product`, {}).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return this.productlist = response.content;
        }
      )
    );
  }
  public getProductById(id: string): Observable<Product> {

    return this.http.get<ApiResponse>(`${environment.productApiUrl}/Product/${id}`, {}).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return this.product = response.content;
        }
      )
    );
  }
  ///api/v1/
  public getGroupedProducts(): Observable<Product[]> {
    return this.http.get<ApiResponse>(`${environment.productApiUrl}/Product/GetGroupedProducts`).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return this.productlist = response.content;
        }
      )
    );
  }

  public getProductByName(name: string): Observable<Product> {

    return this.http.get<ApiResponse>(`${environment.productApiUrl}/Product/GetProductByName/${name}`).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return response.content;
        }
      )
    );
  }

  public getProductUser(idlist: string[]): Observable<Product> {

    return this.http.post<ApiResponse>(`${environment.productApiUrl}/Product/GetProductUser`, idlist).pipe(
      map(
        (response: ApiResponse) => {
          return response.content;
        }
      )
    );
  }

  public createProduct(params: Product): Observable<Product> {

    return this.http.post<ApiResponse>(`${environment.productApiUrl}/Product/`, params).pipe(
      map(
        (response: ApiResponse) => {
          return response.content;
        }
      )
    );
  }

  public updateProduct(params: Product): Observable<Product> {
    return this.http.put<ApiResponse>(`${environment.productApiUrl}/Product/`, params).pipe(
      map(
        (response: ApiResponse) => {
          return response.content;
        }
      )
    );
  }
}
