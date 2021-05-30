import { User } from '../../models/user.model';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../models/api-response';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public userlist: User[] | any;
  public user: User | any;
  constructor(private http: HttpClient) { }

  public getAllUsers(): Observable<User[]> {
    return this.http.get<ApiResponse>(`${environment.userApiUrl}/User`, {}).pipe(
      map(
        (response: ApiResponse) => {
          return this.userlist = response.content;
        }
      )
    );
  }
  public getUserById(id: string): Observable<User> {

    return this.http.get<ApiResponse>(`${environment.userApiUrl}/User/${id}`, {}).pipe(
      map(
        (response: ApiResponse) => {
          return this.user = response.content;
        }
      )
    );
  }

  public createUser(params: any): Observable<User> {

    return this.http.post<ApiResponse>(`${environment.userApiUrl}/User/`, params).pipe(
      map(
        (response: ApiResponse) => {
          return response.content;
        }
      )
    );
  }

  public updateUser(params: any): Observable<User> {
    return this.http.put<ApiResponse>(`${environment.userApiUrl}/User/`, params).pipe(
      map(
        (response: ApiResponse) => {
          return response.content;
        }
      )
    );
  }
}
