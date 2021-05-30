import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../../models/api-response';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { MoneyApproval } from 'src/app/models/operations/money-approval.model';

@Injectable({
  providedIn: 'root'
})
export class DepositService {
  constructor(private http: HttpClient) { }

  public DepositOperation(params: MoneyApproval): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${environment.gateWayApiUrl}/Exchange/MoneyDepositOperation`, params).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return response;
        }
      )
    );
  }
}
