import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdminService {


  private apiServer = `${environment.baseUrl}`;


  constructor(private httpClient: HttpClient) { }

  postcontent(content: any) {
    return this.httpClient.post(`${this.apiServer}/Admin`,
      content
    );
  }
}


