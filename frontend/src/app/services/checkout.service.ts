import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CartItem } from '../models/cart-item.model';
import { OrderHistory } from '../models/order-history.model';
import { Order } from '../models/order.model';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  constructor(private http: HttpClient) { }
  public AddOrder(order: Order) {
    let headers = new HttpHeaders();
    const orderJSON = JSON.stringify(order);
    headers = headers.set('content-type', 'application/json; charset=utf-8');
    return this.http.post('https://localhost:5000/api/Order', orderJSON, {headers});
  }
  public GetAllOrders(id: number) {
    return this.http.get<OrderHistory[]>('https://localhost:5000/api/Order/id?id='+id);
  }
}
