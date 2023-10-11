import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartItem } from '../models/cart-item.model';
import { NewCartItem } from '../models/new-cart-item.model';
import { NewProduct } from '../models/new-product.model';
import { ProductSize } from '../models/product_size.model';
import { CartService } from '../services/cart.service';
import { ProductsService } from '../services/products.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  
  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router, private productsService: ProductsService, private cartService: CartService, private toastr: ToastrService){
  }
  singleProduct: NewProduct;
  product: ProductSize;
  quantity: number;
  cartItem: NewCartItem;
  admin: boolean = false;
  id: number = parseInt(this.route.snapshot.params['id']);
  
  ngOnInit(): void {
    this.productsService.getProductByID(this.id).subscribe(
      { 
        next: (product)=> {
          this.singleProduct=product
          this.product = this.singleProduct.productSizeList[0]
          console.log(this.singleProduct)
        
          
        },
        error: (error)=>console.log(error)
        
       }
    )
    if (parseInt(localStorage.getItem('role')) == 1) {
      this.admin = true;
    }
    this.userService.status.subscribe(
      (userLoggedIn: boolean) => this.admin = userLoggedIn
    )
    
  }
  optionChanged(event : any) {
    this.product = this.singleProduct?.productSizeList.find(c => c.size == event);
     
  }
  addToCart() {
    this.quantity = parseInt((document.getElementById("selectedQuantity") as HTMLInputElement)?.value);
    console.log(this.quantity)
    this.cartItem = new NewCartItem(parseInt(localStorage.getItem('userId')), this.product.productSizeId, this.quantity);
    console.log(this.cartItem);
    this.cartService.addToCart(this.cartItem).subscribe({
      next: () => { this.toastr.success("Product added!") },
      error: (error)=> { console.log(error) }
    }
    )
  }
  deleteProduct() {
    this.productsService.deleteProduct(this.id).subscribe({
      next: ()=> {this.toastr.success("Product deleted."); this.router.navigateByUrl('/products-list')},
      error: ()=> this.toastr.error("Error: Couldn't delete product!")
    })
  }
}

