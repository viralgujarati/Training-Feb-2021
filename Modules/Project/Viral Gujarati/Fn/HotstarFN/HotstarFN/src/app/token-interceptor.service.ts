import { Injectable, Injector } from '@angular/core';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService {

  constructor(private injector: Injector) { }

  intercept(req: any, next: any) {
    let authService = this.injector.get(AuthenticationService);
    let tokenizeReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authService.getToken()}`
      }
    });
    return next.handle(tokenizeReq);
  }
}
