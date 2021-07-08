import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) { }


  private baseUrl = environment.baseUrl;

  GetAllMovies() {
    return this.http.get(`${this.baseUrl}/Home/AllMovies`);
  }
  GetAllSports() {
    return this.http.get(`${this.baseUrl}/Home/AllSports`);
  }
  GetTvShowByChannel(subCategoryId: number) {
    return this.http.get(`${this.baseUrl}/Home/GetShowByCategory/1/${subCategoryId}`)
  }
  GetMoviesByLanguage(lang: string) {
    return this.http.get(`${this.baseUrl}/Home/GetAllMoviesByLanguage/${lang}`)
  }

  GetSportsBySubCat(subCategoryId: number) {
    return this.http.get(`${this.baseUrl}/Home/GetShowByCategory/3/${subCategoryId}`)
  }

  GetAllPremium() {
    return this.http.get(`${this.baseUrl}/Home/AllPremium`)
  }

  GetAllShows() {
    return this.http.get(`${this.baseUrl}/Home/AllShows`);

  }

}
