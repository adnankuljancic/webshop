import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { OrderItem } from '../models/order-item.model';
import { Order } from '../models/order.model';
import { CartService } from '../services/cart.service';
import { CheckoutService } from '../services/checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit{
    constructor(private cartService: CartService, private checkoutService: CheckoutService, private toastr: ToastrService, private router: Router){}
    checkoutItemsList;
    total: number = 0;
    shipping: number = 0;
    orderItemList: OrderItem[] = [];
    order: Order;
    ngOnInit(): void {
      this.checkoutItemsList = this.cartService.checkedCartItems;
      this.checkoutItemsList.forEach(element => {
        this.total+=element.quantity*element.productSize.price;
      });
      if(this.total<100) {
        this.shipping = 10;
      } else {
        this.shipping = 0;
      }
    }
    ConfirmCheckout() {
      this.checkoutItemsList.forEach(element => {
        this.orderItemList.push(new OrderItem(element.productSize.product.productName, element.productSize.product.image, element.productSize.price ))
      });  
      this.order = new Order(parseInt(localStorage.getItem('userId')), this.orderItemList);
      this.checkoutService.AddOrder(this.order).subscribe({
        next: () => {this.toastr.success("Thank you for your order!"); this.router.navigateByUrl('/')},
        error: () => {this.toastr.error("Error! Ordering failed!")}
      })
      }
    
}
