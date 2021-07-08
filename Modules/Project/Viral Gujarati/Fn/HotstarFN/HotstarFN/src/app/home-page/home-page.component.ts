import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContentService } from '../content.service';
import { HomeService } from '../home.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  title = 'HotstarFN';

  //decaring variable 
  Subscribe: any;
  getAllMovieSub: any;
  getAllShowsSub: any;
  GetAllSportsSub: any;

  constructor(private route: Router,
    private homeService: HomeService,
    private contentService: ContentService

  ) {
  }
  movies: any;
  sports: any;
  shows: any;
  top: any;

  ngOnInit(): void {

    var getAllMoviesSub = this.homeService.GetAllMovies().subscribe(
      (res: any) => {
        console.log(res);
        this.top = res.splice(0, 5);
        getAllMoviesSub.unsubscribe();
      });

    var getAllMovieSub = this.contentService.getAllMovie().subscribe(
      (res: any) => {
        console.log(res);
        this.movies = res;
        this.getAllMovieSub.unsubscribe();
      }
    );
    var GetAllSportsSub = this.homeService.GetAllSports().subscribe(
      res => {
        console.log(res);
        this.sports = res;
        this.GetAllSportsSub.unsubscribe();
      },
      err => console.log(err)
    );

    var GetAllShowsSub = this.homeService.GetAllShows().subscribe(
      res => {
        console.log(res);
        this.shows = res;
        this.getAllShowsSub.unsubscribe();
      },
      err => console.log(err)
    );
  }
}
