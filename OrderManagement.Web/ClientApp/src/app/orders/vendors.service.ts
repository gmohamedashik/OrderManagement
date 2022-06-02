import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Vendor } from "./vendor";

@Injectable({
  providedIn: 'root'
})
export class VendorsService {

  private apiURL = "http://localhost:50016/api";
  
  constructor(private httpClient: HttpClient) { }

  getVendors(): Observable<Vendor[]> {
    return this.httpClient.get<Vendor[]>(this.apiURL + '/vendors')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
