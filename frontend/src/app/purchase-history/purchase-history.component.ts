import { Component, OnInit } from '@angular/core';
import { OrderHistory } from '../models/order-history.model';
import { Order } from '../models/order.model';
import { CheckoutService } from '../services/checkout.service';

@Component({
  selector: 'app-purchase-history',
  templateUrl: './purchase-history.component.html',
  styleUrls: ['./purchase-history.component.css']
})
export class PurchaseHistoryComponent implements OnInit {
  constructor(private checkoutService: CheckoutService){}
  userOrders: OrderHistory[];
  ngOnInit(): void {
    this.checkoutService.GetAllOrders(parseInt(localStorage.getItem('userId'))).subscribe({
      next: (orders)=> {this.userOrders=orders; console.log(this.userOrders)},
      error: (error)=> console.log(error)
    })
  }

}
