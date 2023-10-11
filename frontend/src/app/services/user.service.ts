import { HttpClient, HttpHeaders } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { User } from "../models/user.model";

@Injectable( {providedIn: 'root'} )
export class UserService {
    constructor (private http: HttpClient) {}
    
    logIn(user: User) {
        var options: {};
        let headers = new HttpHeaders();
        headers = headers.set('content-type', 'application/json; charset=utf-8');
        options = {
            headers: headers
        };
        const userJson = JSON.stringify(user);
        return this.http.post('https://localhost:5000/api/Auth/Login', userJson, options)
    }
    status = new EventEmitter<boolean>();
    

}