import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Order } from "./order";

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  private apiURL = "http://localhost:50016/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.httpClient.get<Order[]>(this.apiURL + '/orders')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getOrder(id): Observable<Order> {
    return this.httpClient.get<Order>(this.apiURL + '/orders/' + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createOrder(order): Observable<Order> {
    return this.httpClient.post<Order>(this.apiURL + '/orders/', JSON.stringify(order), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updateOrder(id, order): Observable<Order> {
    return this.httpClient.put<Order>(this.apiURL + '/orders/' + id, JSON.stringify(order), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deleteOrder(id) {
    return this.httpClient.delete<Order>(this.apiURL + '/orders/' + id, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deleteOrders(order) {
    return this.httpClient.put<Order>(this.apiURL + '/orders/', JSON.stringify(order), this.httpOptions)
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
