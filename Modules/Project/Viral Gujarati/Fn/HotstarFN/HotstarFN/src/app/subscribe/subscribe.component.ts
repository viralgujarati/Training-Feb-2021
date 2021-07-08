import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { UserService } from '../user.service';


@Component({
  selector: 'app-subscribe',
  templateUrl: './subscribe.component.html',
  styleUrls: ['./subscribe.component.css']
})

export class SubscribeComponent implements OnInit {

  userId : any;
  checkbox : number = 1;
  planId :number;

  constructor(
    private userService: UserService,
    private router : Router) {}

  ngOnInit(): void {

    //to get data from local storage 
    this.userId = localStorage.getItem('userId');

   
    
  }
 //method to get value from radiobox
changeCheckbox(value: any){
  this.planId = value;
  console.log(" Your Subcription Value Plan is : ", value );
}


//for subscription 
subscribe(){
  // DoSubscribe(customerId:number, planId:number){
  //   return this.httpClient.post(`${this.apiServer}/${customerId}`,planId);
  //     }
  
  console.log(this.userId,this.planId);
    this.userService.DoSubscribe(this.userId,this.planId).subscribe(
    (res : any)=>{
      console.log(res);
      alert(res.message);
    this.router.navigate(['']);

    // this.router.navigate(['/home']); 
  }
  );
  }
}
