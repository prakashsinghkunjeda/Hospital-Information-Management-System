import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { CookieService } from "ngx-cookie-service";

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(public _router: Router, public cookies:CookieService) {
  }
  canActivate(): boolean {
    if (!this.cookies.get('tokenKey')) {
      this._router.navigate(['login']);
      return false;
    }
    return true;
  }
}  