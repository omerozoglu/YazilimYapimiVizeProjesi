import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../../models/api-response';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { ProductApproval } from 'src/app/models/operations/product-approval.model';

@Injectable({
  providedIn: 'root'
})
export class LoadService {
  constructor(private http: HttpClient) { }

  public LoadOperation(params: ProductApproval): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(`${environment.gateWayApiUrl}/Exchange/ProductLoadOperation`, params).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return response;
        }
      )
    );
  }
}
