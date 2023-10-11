import { Component } from '@angular/core';
import { EmailValidator, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserJwt } from '../models/user-jwt.model';
import { User } from '../models/user.model';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {
  constructor (private formBuilder: FormBuilder, private userService: UserService, private router: Router) { }
  userForm = this.createForm();
  createForm() {
    return this.formBuilder.group({
      email: ["",Validators.email],
      password: ["", Validators.minLength(6)]

    })
  }
  logIn() {
    if(!this.userForm.valid && this.userForm.touched)  {
      return;
    }
    const userValue: User = this.userForm.value;
    this.userService.logIn(userValue).subscribe({
      next: (userJwt: UserJwt)=> {
        localStorage.setItem('jwt', userJwt.jwt);
        localStorage.setItem('userId', userJwt.userId.toString());
        localStorage.setItem('role', userJwt.role.toString());
        this.userService.status.emit(true);
        this.router.navigateByUrl('/')
      },
      error: (error)=> {console.log(error)}
      
    })
  }

}
