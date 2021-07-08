import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { ContentService } from '../content.service';


@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  movies: any;
  getAllMovieSub: any;

  constructor(private contentService: ContentService,
    private route: Router) { }
  
  ngOnInit(): void {
    var getAllMovieSub = this.contentService.getAllMovie().subscribe(
      res => {
        console.log(res);
        this.movies = res;
        this.getAllMovieSub.unsubscribe();
      }
    )
  }

  
  login() {
    this.route.navigate(['login']);
  }
  IsLoggedIn(){
    return !!localStorage.getItem('token')
  }
}
