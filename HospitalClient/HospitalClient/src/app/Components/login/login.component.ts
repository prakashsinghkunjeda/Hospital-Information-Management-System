import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../Service/api.service';
import { Login } from '../../Model/Login';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit
{
   login:Login = new Login();
  constructor(private apiservice:ApiService,private cookie:CookieService,private router:Router){}

  ngOnInit(): void {
      
  }
doLogin(){
    let loginData = this.login.LoginForm.value;
    this.apiservice.Login(loginData).subscribe(
        res=>{
          this.cookie.set("tokenKey",res.token);
          this.router.navigate(['/home/dashboard']);
        },
        err=>{
            alert("Invalid Credentials");
          console.log(err);
        }
    );
}
  
}
