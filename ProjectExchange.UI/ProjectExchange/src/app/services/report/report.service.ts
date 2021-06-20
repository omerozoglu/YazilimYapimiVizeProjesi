import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse } from 'src/app/models/api-response';
import { Report } from 'src/app/models/report.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  public report: Report[] | any;
  constructor(private http: HttpClient) { }
  public getAllReport(): Observable<Report[]> {
    return this.http.get<ApiResponse>(`${environment.reportApiUrl}/Report`, {}).pipe(
      map(
        (response: ApiResponse) => {
          return this.report = response.content;
        }
      )
    );
  }
}
