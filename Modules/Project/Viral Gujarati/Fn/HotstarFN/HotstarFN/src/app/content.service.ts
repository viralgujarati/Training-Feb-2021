import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContentService {

  private apiServer = `${environment.baseUrl}`;  // "https://localhost:44308/api/content";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }


  constructor(private httpClient: HttpClient) { }

  selectedContent: number = null;
  sub: Subject<number> = new Subject<number>();
  setsub(id: number) {
    this.selectedContent = id;
    this.sub.next(id);
  }

  getContentById(contentid: number) {
    return this.httpClient.get(`${this.apiServer}/Content/${contentid}`)
  }

  getAllMovie() {
    return this.httpClient.get(`${this.apiServer}/Movie`)
      .pipe(
        catchError(this.errorHandler)
      )
  }

  postcontent(content: any) {
    return this.httpClient.post<any>(`${this.apiServer}/Admin`, JSON.stringify(content), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      )
  }


  errorHandler(error: { error: { message: string; }; status: any; message: any; }) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
