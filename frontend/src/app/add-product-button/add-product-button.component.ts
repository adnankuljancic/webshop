import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Brand } from '../models/brand.model';
import { Category } from '../models/category.model';
import { NewProduct } from '../models/new-product.model';
import { ProductSize } from '../models/product_size.model';
import { BrandService } from '../services/brand.service';
import { CategoryService } from '../services/category.service';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-add-product-button',
  templateUrl: './add-product-button.component.html',
  styleUrls: ['./add-product-button.component.css']
})
export class AddProductButtonComponent implements OnInit{
  constructor(private formBuilder: FormBuilder, private productService: ProductsService, private categoryService: CategoryService, private brandService: BrandService, private toastr: ToastrService){}
  sizeForm=this.createProductSizeForm();
  productForm=this.createProductForm();
  productList: ProductSize[] = [];
  categories: Category[];
  brands: Brand[];
  @ViewChild('closebutton') closebutton;
  public ngOnInit(): void {
    this.categoryService.GetCategories().subscribe({
      next: (receivedCategories) => {this.categories = receivedCategories},
      error: (error) => {console.error(error)} 
    })
    this.brandService.GetBrands().subscribe({
      next: (receivedBrands) => {this.brands = receivedBrands},
      error: (error)=> {console.error(error)}
    })
  }

  addSize() {
    this.productList.push(this.sizeForm.value);
  }
 createProductSizeForm() {
  return this.formBuilder.group({
    size: [0, Validators.required], 
    price: [0, Validators.required],
    quantity: [0, Validators.required]
  })
  }
  createProductForm() {
    return this.formBuilder.group({
      productName: [""],
      productDescription: [""],
      image: [""],
      categoryId: [1],
      brandId: [1] 
    })
 }
 saveProduct(){
    const newProduct: NewProduct = this.productForm.value;
    newProduct.productSizeList = this.productList;
    console.log(newProduct);
    this.productService.addProduct(newProduct).subscribe({
      next: () => {console.log("Product added"), this.closebutton.nativeElement.click(); this.toastr.success("Product added")},
      error: (error) => {console.log(error)}
    })
    
 }
 

}
