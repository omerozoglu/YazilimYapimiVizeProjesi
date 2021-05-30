import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../../models/api-response';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Seller } from 'src/app/models/operations/seller.model';

@Injectable({
  providedIn: 'root'
})
export class SellService {
  constructor(private http: HttpClient) { }

  public SellOperation(params: Seller): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(`${environment.gateWayApiUrl}/Exchange/SellOperation`, params).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return response;
        }
      )
    );
  }
}
