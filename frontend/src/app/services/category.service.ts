import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }
  public GetCategories() {
    return this.http.get<Category[]>('https://localhost:5000/api/Category');
  }
  
}
