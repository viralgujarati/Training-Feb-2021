import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { ContentService } from '../content.service';



@Component({
  selector: 'app-content-display',
  templateUrl: './content-display.component.html',
  styleUrls: ['./content-display.component.css']
})


export class ContentDisplayComponent implements OnInit {
  contentId: number = 0;
  contentdetail?: any;

  constructor(private route: ActivatedRoute
    , private contentService: ContentService) { }



  ngOnInit(): void {
    this.contentId = parseInt(this.route.snapshot.paramMap.get('id')!);
    console.log(this.contentId);
    this.contentService.getContentById(this.contentId).subscribe(
      (res: any) => {
        if(res.status=="fail"){
          alert(res.message);
        }
        this.contentdetail = res;
        console.log(res);
        console.log(this.contentdetail.url);
      }
    )
  }
}
