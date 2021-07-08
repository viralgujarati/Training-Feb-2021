import { Component, OnInit } from '@angular/core';
import {FormBuilder,FormControl,FormGroup,Validators} from '@angular/forms';
import { Router } from '@angular/router';
import {AuthenticationService} from '../authentication.service';
import { ContentService } from '../content.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form: FormGroup | any ;
  movies: any;
  constructor(private _auth : AuthenticationService,
    private contentService: ContentService,
     private route : Router) { }
 

  ngOnInit(): void {
    this.contentService.getAllMovie().subscribe(
      res => {
        console.log(res);
        this.movies = res;
      });
    this.form = new FormGroup(
      {
        Name:new FormControl('',[Validators.required]),
        Username:new FormControl('',[Validators.required]),
        Email: new FormControl('',[Validators.required,Validators.email]),
        Phone:new FormControl('',[Validators.required]),
        Password:new FormControl('',[Validators.required]),
        Address:new FormControl('',[Validators.required])
      }
    );
    }
   
    get Name()
    {
      return this.form.get('Name')
     };

     get Username()
    {
      return this.form.get('Username')
     };

     get Email()
     {
       return this.form.get('Email')
      };

      get Phone()
      {
        return this.form.get('Phone')
       };
  
     get Password()
    {
      return this.form.get('Password')
     };

     get Address()
     {
       return this.form.get('Address')
      };

registerUser() {
    console.log(this.form.valid)

    if (this.form.valid) {

      this._auth.registerUser(this.form.value).subscribe(res => {
//token storage
        console.log(res)
      
        if (res.status == "Success") {

          console.log(res);

          this.route.navigate(['']);

          setTimeout(() => {
            alert(res.message);
          }, 500);
        }
        else {
          alert(res.message);
        }
      });
    }
  }
}

