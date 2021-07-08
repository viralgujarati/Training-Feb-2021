
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { ContentService } from '../content.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  form: FormGroup | any;
  movies: any;
  constructor(private authService: AuthenticationService,
    private contentService : ContentService,
    private router: Router) { }

  ngOnInit(): void {
    this.contentService.getAllMovie().subscribe(
      res => {
        console.log(res);
        this.movies = res;
      });
      
    this.form = new FormGroup(
      {
        Username: new FormControl('', [Validators.required]),
        Password: new FormControl('', [Validators.required])
      }
    );
  }

  get Username() {
    return this.form.get('Username')
  };

  get Password() {
    return this.form.get('Password')
  };


  loginProcess() {

    if (this.form.valid) {
      this.authService.loginUser(this.form.value).subscribe(
        (res:any) => {
        if (res.token != undefined) {
          localStorage.setItem('token', res.token);
          localStorage.setItem('userId', res.userId);

          this.router.navigate(['/home']);
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

  navigateTohome() {
    this.router.navigate(['']);

  }
}



