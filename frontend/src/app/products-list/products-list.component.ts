import { Component, OnDestroy, OnInit } from '@angular/core';
import { Brand } from '../models/brand.model';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';
import { ProductSize } from '../models/product_size.model';
import { BrandService } from '../services/brand.service';
import { CategoryService } from '../services/category.service';
import { ProductsService } from '../services/products.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit, OnDestroy {
  productList: Product[];
  page: number = 1;
  search: string = "";
  fetchProducts: any;
  fetchCategories: any;
  admin: boolean = false;
  categories: Category[];
  brands: Brand[];


  constructor(private productsService: ProductsService, private userService: UserService,
    private categoryService: CategoryService, private brandService: BrandService) { }

  ngOnInit(): void {
    this.search = this.productsService.searched;
    this.fetchCategories = this.productsService.searchedProduct.subscribe(
      (s) => { this.search = s; this.productsService.pageChange.emit(1); this.fetch() }
    );
    this.fetchProducts = this.productsService.getAllProducts().subscribe(
      {
        next: (products) => {
          this.productList = products;
          console.log(this.productList);
        },
        error: (error) => {
          console.log(error);
        }
      }
    );

    this.categoryService.GetCategories().subscribe({
      next: (receivedCategories) => { this.categories = receivedCategories },
      error: (error) => { console.error(error) }
    });

    this.brandService.GetBrands().subscribe({
      next: (receivedBrands) => { this.brands = receivedBrands; console.log(receivedBrands) },
      error: (error) => { console.error(error) }
    });

    this.productsService.pageChange.subscribe(
      (n) => { this.page = n; this.productsService.AllFilters.page = this.page; this.fetch() }
    )
    if (parseInt(localStorage.getItem('role')) == 1) {
      this.admin = true;
    }
    this.userService.status.subscribe(
      (userLoggedIn: boolean) => this.admin = userLoggedIn
    )
    console.log(localStorage.getItem('role'));

  }
  ngOnDestroy(): void {
    this.fetchProducts.unsubscribe();
  }

  fetch() {
    this.fetchProducts.unsubscribe();
    this.fetchProducts = this.productsService.getAllProducts().subscribe(
      {
        next: (products) => {
          this.productList = products;
        },
        error: (error) => {
          console.log(error);
        }
      }
    )
  }
  onSelectBrand(event: any) {
    this.productsService.AllFilters.brand = event.target.value;
    this.fetch();
  }
  onSelectOrderBy(event: any) {
    this.productsService.AllFilters.orderBy = event.target.value;
    this.fetch();
  }


  choose(p1) {
    this.page = p1;
    this.productsService.pageChange.emit(this.page);
  }
  previousPage() {
    this.page = this.page - 1;
    if (this.page <= 0) this.page = 1;
    this.productsService.pageChange.emit(this.page)
  }

  nextPage() {
    this.page = this.page + 1;
    this.productsService.pageChange.emit(this.page)
  }

}
