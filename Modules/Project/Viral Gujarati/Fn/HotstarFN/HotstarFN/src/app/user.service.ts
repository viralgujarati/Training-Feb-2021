import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiServer = environment.baseUrl;
  sub: any;
  constructor(private httpClient: HttpClient) { }

  DoSubscribe(customerId: number, planId: number) {
    return this.httpClient.get(`${this.apiServer}/User/${customerId}/Subscribe/${planId}`);
  }
}
