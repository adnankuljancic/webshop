import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CartItem } from "../models/cart-item.model";
import { Product } from "../models/product.model"
@Injectable({providedIn: 'root'})
export class CartService {
    constructor(private http: HttpClient) {}
    public checkedCartItems: CartItem[] = [];
    getCartItems() {
        const id = Number(localStorage.getItem('userId'));
        return this.http.get<CartItem[]>(`https://localhost:5000/api/Cart/${id}`);
    }
    addToCart(product: CartItem) {
        var options: {};
        let headers = new HttpHeaders();
        headers = headers.set('content-type', 'application/json; charset=utf-8');
        options = {
        headers: headers };
        const productJson = JSON.stringify(product);
        console.log(productJson);
        return this.http.post<CartItem>('https://localhost:5000/api/Cart', productJson, options);
    }
    updateCartItemQuantity(id: number, quantity: number) {
        var options: {};
        let headers = new HttpHeaders();
        headers = headers.set('content-type', 'application/json; charset=utf-8');
        options = {
        headers: headers };
        return this.http.put<CartItem[]>('https://localhost:5000/api/Cart/'+ id + '?quantity=' + quantity, headers);
    }
    deleteCartItem(id: number) {
        
        return this.http.delete<CartItem[]>('https://localhost:5000/api/Cart/id?id='+ id);
    }
    addCheckoutItem(item: CartItem){
        this.checkedCartItems.push(item);
    }
    removeCheckoutItem(item: CartItem){
        let index = this.checkedCartItems.indexOf(item);
        this.checkedCartItems.splice(index);
    }
}