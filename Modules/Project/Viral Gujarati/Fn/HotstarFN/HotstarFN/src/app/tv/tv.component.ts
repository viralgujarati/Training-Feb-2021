import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContentService } from '../content.service';
import { HomeService } from '../home.service';
import{Observable }  from 'rxjs'


@Component({
  selector: 'app-tv',
  templateUrl: './tv.component.html',
  styleUrls: ['./tv.component.css']
})
export class TVComponent implements OnInit {

  shows: any;
  subCatId : number;
  SubCatObv : Observable<any>;

  constructor(
    private homeService : HomeService,
    private activatedRoute : ActivatedRoute,
    private contentService: ContentService,
    private route: Router) { 
      
    this.homeService.GetTvShowByChannel(parseInt(this.activatedRoute.snapshot.paramMap.get('subCategoryId')!)).subscribe(
      res => {
        console.log(res);
        this.shows = res;
      }
    )


this.contentService.sub.subscribe(res=>{this.subCatId=res;
console.log(res,"TV")
  this.homeService.GetTvShowByChannel(this.subCatId).subscribe(
    res => {
        console.log(res);
        this.shows = res;
      }
  )
});
    }

  ngOnInit(): void {
  }
}

