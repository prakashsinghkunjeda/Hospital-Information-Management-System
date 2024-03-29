import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  constructor(private Cookie:CookieService,private router:Router){  }
  ngOnInit(): void {
   
}
  logout(){
    this.Cookie.delete("tokenKey");
    this.router.navigate(['/login']);
  }
}
