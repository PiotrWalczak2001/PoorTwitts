import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserLoginDto } from '../Models/user-login-dto.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLoginDto = new UserLoginDto();

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  sendLoginRequest() {
    this.http.post("https://localhost:44369/" + "account" + "/loginUser", this.userLoginDto).subscribe(response => {
      this.router.navigate(['/wall'])
    },
      error => {

      });
  }

}
