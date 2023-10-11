import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartItem } from '../models/cart-item.model';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit{
  constructor(private cartService: CartService, private toastr: ToastrService, private router: Router) {}
  cartItemList: CartItem[];
  quantity: number;
  total: number = 0;
  shipping: number = 0;
  totalPositive = false;
  ngOnInit(): void {
    this.cartService.getCartItems().subscribe({
      next: (products) => {
        this.cartItemList = products; console.log(this.cartItemList); this.TotalSum();
  },
      error: (error) => {console.error(error)}
    })
  }
  TotalForItem(id: number) {
    this.quantity = parseInt((document.getElementById("quantity"+id) as HTMLInputElement)?.value);
    this.cartService.updateCartItemQuantity(id, this.quantity).subscribe({
      next: () => {this.cartService.getCartItems().subscribe({
        next: (products) => {this.cartItemList = products; console.log(this.cartItemList); this.TotalSum();},
        error: (error) => {console.error(error)}
      })},
      error: (error)=>{console.log(error)}
    }
    )
  }
  TotalSum() {
    this.total=0;
    this.cartItemList.forEach(element => 
      {if(element.checked) {this.total+=element.quantity*element.productSize.price; console.log(element.checked)}
    });
    if(this.total<100) {this.shipping=10} else {this.shipping=0}
    if(this.total>10) {this.totalPositive=true}
  }
  DeleteItem(id: number) {
    this.cartService.deleteCartItem(id).subscribe({
      next: ()=> {this.cartService.getCartItems().subscribe({
        next: (products) => {this.cartItemList = products; console.log(this.cartItemList); this.TotalSum(); this.toastr.success("Item removed")},
        error: (error) => {console.error(error)}})}
    })
  }
  Checkout() {
      if(this.cartService.checkedCartItems.length > 0) {
          this.router.navigateByUrl('/checkout');
      } else {
        this.toastr.error("Please select items for checkout");
      }
  }
  checkboxMarked(cartItem) {
    cartItem.checked=!cartItem.checked;
    this.TotalSum();
    if(cartItem.checked) {
        this.cartService.addCheckoutItem(cartItem);
    } else {
        this.cartService.removeCheckoutItem(cartItem);
    }
  }
  

}

