import { Component, OnDestroy, OnInit } from '@angular/core';
// import { Router } from '@angular/router';
import { ContentService } from '../content.service';
import { HomeService } from '../home.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-sports',
  templateUrl: './sports.component.html',
  styleUrls: ['./sports.component.css']
})
export class SportsComponent implements OnInit,OnDestroy {
  subCatId: number;
  shows: any;
  subscription: Subscription;

  constructor(private activatedRoute: ActivatedRoute,
   private contentService: ContentService,
   private route: Router,
   private homeService : HomeService) { }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
   }

  movies: any;
  ngOnInit(): void {
      this.homeService.GetSportsBySubCat(parseInt(this.activatedRoute.snapshot.paramMap.get('subCategoryId')!)).subscribe(
        res => {
          console.log(res);
          this.shows = res;
        }
      )
    

    this.subscription = this.contentService.sub.subscribe(res=>{this.subCatId = res;
    console.log(res);
    this.homeService.GetSportsBySubCat(this.subCatId).subscribe(
      res => {
        console.log(res);
        this.shows = res;
      }
    )
  });

  }

  
  
  login() {
    this.route.navigate(['login']);
  }

  register() {
    this.route.navigate(['register']);
  }


  IsLoggedIn(){
    return !!localStorage.getItem('token')

  }

  logout(){
    localStorage.clear()
    this.route.navigate(['/']);
  }

}
