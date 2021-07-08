import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private _baseUrl = environment.baseUrl;


  isLoggedIn: boolean = false;

  constructor(private http: HttpClient, private route: Router) { }

  registerUser(user: any) {
    return this.http.post<any>(`${this._baseUrl}/authenticate/register`, user);
  }

  confirmEmail(model: any) {

    return this.http.post(`${this._baseUrl}/authenticate/verifyEmail`, model);
  }



  loginUser(user: any) {
    return this.http.post(`${this._baseUrl}/authenticate/login`, user);
  }

  loggedIn() {
    return !!localStorage.getItem('token');
  }
  logoutUser() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    this.route.navigate(['']);
  }

  getToken() {
    return localStorage.getItem('token');
  }

  resetPasswordToken(form: any) {
    return this.http.post(`${this._baseUrl}/authenticate/ResetPasswordToken`, form);
  }

  resetPassword(resetForm: any) {
    return this.http.post(`${this._baseUrl}/authenticate/ResetPassword`, resetForm);
  }
}
