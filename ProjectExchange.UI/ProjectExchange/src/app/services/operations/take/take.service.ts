
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../../models/api-response';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { Taker } from 'src/app/models/operations/taker.model';

@Injectable({
  providedIn: 'root'
})
export class TakeService {
  constructor(private http: HttpClient) { }

  public TakeOperation(params: Taker): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(`${environment.gateWayApiUrl}/Exchange/TakeOperation`, params).pipe(
      map(
        (response: ApiResponse) => {
          console.log(response);
          return response;
        }
      )
    );
  }
}
