import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';
import { CategoryService } from '../services/category.service';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {
  categories: Category[];
  searched : string="";

  constructor(private categoryService: CategoryService, private productService : ProductsService, private router: Router){}
  
  ngOnInit(): void {
    this.categoryService.GetCategories().subscribe({
      next: (receivedCategories) => {this.categories = receivedCategories},
      error: (error) => {console.error(error)} 
    })
    // this.productService.searchedProduct.emit(this.searched);
  }

  search(){
    this.productService.searchedProduct.emit(this.searched);
    this.productService.AllFilters.search = this.searched;
    this.productService.searched = this.searched;
    this.router.navigateByUrl("/products-list");
  }
  onSelect(event: any) {
    this.productService.AllFilters.category = event.target.value;
  }

}
