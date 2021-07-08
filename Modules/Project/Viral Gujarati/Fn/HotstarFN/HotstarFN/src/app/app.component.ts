import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';
import { ContentService } from './content.service';
import { UserService } from './user.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HotstarFN';

  //decaring variable 
  Subscribe: any;


  constructor(private route: Router,
    private contentService : ContentService,
    private userService : UserService,
    private authservice: AuthenticationService
  ) {
  }
//
  movies: any;

  ngOnInit(): void {
//
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


   
  Reload(id:number,category:string){
    this.contentService.setsub(id);
  //  this.contentService.selectedContent = id;
this.route.navigate([`/${category}/${id}`]);
// location.reload();


  }
}


  