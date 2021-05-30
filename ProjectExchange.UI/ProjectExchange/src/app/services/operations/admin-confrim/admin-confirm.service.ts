import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../../models/api-response';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { ProductApproval } from 'src/app/models/operations/product-approval.model';
import { MoneyApproval } from 'src/app/models/operations/money-approval.model';

@Injectable({
  providedIn: 'root'
})
export class AdminConfirmService {
  public productApproval: ProductApproval[] | any;
  public moneyApproval: MoneyApproval[] | any;
  constructor(private http: HttpClient) { }

  public LoadConfirmOperation(params: ProductApproval): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(`${environment.gateWayApiUrl}/Exchange/LoadConfirmOperation`, params).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return response;
        }
      )
    );
  }

  public DepositConfirmOperation(params: MoneyApproval): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(`${environment.gateWayApiUrl}/Exchange/DepositConfirmOperation`, params).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return response;
        }
      )
    );
  }

  public getAllProductApproval(): Observable<ProductApproval[]> {
    return this.http.get<ApiResponse>(`${environment.adminApiUrl}/ProductApproval`, {}).pipe(
      map(
        (response: ApiResponse) => {
          return this.productApproval = response.content;
        }
      )
    );
  }
  public getAllMoneyApproval(): Observable<MoneyApproval[]> {
    return this.http.get<ApiResponse>(`${environment.adminApiUrl}/MoneyApproval`, {}).pipe(
      map(
        (response: ApiResponse) => {
          return this.moneyApproval = response.content;
        }
      )
    );
  }
}
