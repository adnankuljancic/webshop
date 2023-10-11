import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor(private userService: UserService, private router: Router){}
  loggedIn = false;
  ngOnInit(): void {
    if(localStorage.getItem('jwt')!=null) {
      this.loggedIn = true;
    }
    this.userService.status.subscribe(
      (userLoggedIn: boolean)=> this.loggedIn = userLoggedIn
    )
  }
  
  logOut() {
    localStorage.clear();
    this.userService.status.emit(false);
    this.router.navigateByUrl('/');

  }
   

}
