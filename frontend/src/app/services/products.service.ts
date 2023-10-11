import { HttpClient, HttpHeaders } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { NewProduct } from "../models/new-product.model";

import { Product } from "../models/product.model";
@Injectable( { providedIn: 'root'})
export class ProductsService {
    constructor(private http: HttpClient){}
    searchedProduct = new EventEmitter<string>;
    pageChange = new EventEmitter<any>;
    searched: string = "";

    public AllFilters = {
        search: '',
        orderBy: 0,
        page: 1,
        category: 0,
        brand: 0
    }
    
    getAllProducts() {
        console.log(this.AllFilters);
        return this.http.get<Product[]>('https://localhost:5000/api/Product', {params: {...this.AllFilters}} )
    }
    getProductByID(id: number) {
        return this.http.get<NewProduct>(`https://localhost:5000/api/Product/${id}`)
    }

    addProduct(product: NewProduct) {
        var options: {};
        let headers = new HttpHeaders();
        headers = headers.set('content-type', 'application/json; charset=utf-8');
        options = {
        headers: headers };
        const productJson = JSON.stringify(product);

        return this.http.post<NewProduct>('https://localhost:5000/api/Product', productJson, options);
    }
    deleteProduct(id: number) {
        
            return this.http.delete<number>('https://localhost:5000/api/Product?id='+ id);
    }
}