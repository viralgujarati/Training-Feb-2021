import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css']
})
export class ConfirmEmailComponent implements OnInit {
emailConfirmed : boolean = false;
  urlParams : {
    token : string,
    userId : string
  }={
    token : "",
    userId : ""
  };

  constructor(
    private route : ActivatedRoute,
    private authService : AuthenticationService,
    private router : Router
    ){ }

  ngOnInit() {
     this.route.queryParamMap.subscribe(
      (param:any) =>{
        this.urlParams.token = param.params.token;
        this.urlParams.userId = param.params.userid;
        
      }
    );
    
  this.ConfirmEmail();
  }


  ConfirmEmail(){
    
    this.authService.confirmEmail(this.urlParams).subscribe(
      ()=>{
        this.emailConfirmed = true;
      },
      (error)=>{
        this.emailConfirmed = false;
      }
    )
  }

  navigateToLogin(){
    this.router.navigate(['/']);
  }
}