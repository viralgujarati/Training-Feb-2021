import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HomeService } from '../home.service';


@Component({
  selector: 'app-premium',
  templateUrl: './premium.component.html',
  styleUrls: ['./premium.component.css']
})
export class PremiumComponent implements OnInit {
  constructor(private homeService: HomeService,
    private route: Router) { }

  movies: any;
  ngOnInit(): void {
    this.homeService.GetAllPremium().subscribe(
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
