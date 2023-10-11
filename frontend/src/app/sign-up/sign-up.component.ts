import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NewUser } from '../models/new-user.model';
import { NewUserService } from '../services/new-user.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent 
{
  constructor(private formBuilder: FormBuilder, private newUserService: NewUserService, private router: Router) { }
  userForm = this.createUserForm();

  createUser() {
    const newUser: NewUser = this.userForm.value;
    this.newUserService.createNewUser(newUser).subscribe(
      {
        complete: () => {this.router.navigateByUrl('/log-in')},
        error: (error) => {console.error(error)}
      }
    )

  }

  createUserForm() {
    return this.formBuilder.group({
      name: [""],
      lastName: [""],
      email: [""],
      password: [""]
    })

  }

}
