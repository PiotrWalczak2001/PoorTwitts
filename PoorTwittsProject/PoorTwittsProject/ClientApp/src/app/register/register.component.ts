import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserRegisterDto } from '../Models/user-register-dto.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userRegisterDto = new UserRegisterDto();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  sendRegisterRequest() {
    this.http.post("https://localhost:44369/" + "account" + "/registerUser", this.userRegisterDto).subscribe(response => {
      this.router.navigate(['/login'])
    },
      error => {

      });
  }

}
