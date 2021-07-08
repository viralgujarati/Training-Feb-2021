import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContentService } from '../content.service';


@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.css']
})
export class NewsComponent implements OnInit {

  constructor(private contentService: ContentService,private route: Router) { }

  movies: any;
  ngOnInit(): void {
    this.contentService.getAllMovie().subscribe(
      res => {
        console.log(res);
        this.movies = res;
      }
    )
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