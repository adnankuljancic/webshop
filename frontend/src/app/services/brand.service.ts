import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Brand } from '../models/brand.model';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  constructor(private http: HttpClient) { }
  public GetBrands() {
    return this.http.get<Brand[]>('https://localhost:5000/api/Brand');
  }
  
}