import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewUser } from '../models/new-user.model';

@Injectable({
  providedIn: 'root'
})
export class NewUserService {

  constructor(private http: HttpClient) { }
  createNewUser(newUser: NewUser) {
      let headers = new HttpHeaders();
      const newUserJSON = JSON.stringify(newUser);
      headers = headers.set('content-type', 'application/json; charset=utf-8');
      return this.http.post('https://localhost:5000/api/Auth/Register', newUserJSON, {headers});
  }
}
