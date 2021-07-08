import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminService } from '../admin.service';
import { AuthenticationService } from '../authentication.service';
import { ContentService } from '../content.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  form: FormGroup | any;
  movies: any;
  constructor(private _auth: AuthenticationService,
    private contentService: ContentService,
    private route: Router,
    private adminservice:AdminService) { }


  ngOnInit(): void {
    // this.contentService.getAllMovie().subscribe(
    //   res => {
    //     console.log(res);
    //     this.movies = res;
    //   });
    this.form = new FormGroup(
      {
        ContentLink: new FormControl('', [Validators.required]),
        ContentPosterLink: new FormControl('', [Validators.required]),
        Title: new FormControl('', [Validators.required]),
        Genre: new FormControl('', [Validators.required]),
        Description: new FormControl('', [Validators.required]),
        ReleaseDate: new FormControl('', [Validators.required]),
        SuitableAge: new FormControl('', [Validators.required]),
        SubCategoryId: new FormControl('', [Validators.required]),
        CategoryId: new FormControl('', [Validators.required]),
        PlanId: new FormControl('', [Validators.required]),
        ContentLanguage: new FormControl('', [Validators.required])
      }
    );
  }

  get ContentLink() {
    return this.form.get('ContentLink')
  };

  get ContentPosterLink() {
    return this.form.get('ContentPosterLink')
  };

  get Title() {
    return this.form.get('Title')
  };

  get Genre() {
    return this.form.get('Genre')
  };

  get Description() {
    return this.form.get('Description')
  };

  get ReleaseDate() {
    return this.form.get('ReleaseDate')
  };
  get SuitableAge() {
    return this.form.get('SuitableAge')
  };
  get SubCategoryId() {
    return this.form.get('SubCategoryId')
  };
  get CategoryId() {
    return this.form.get('CategoryId')
  };
  get PlanId() {
    return this.form.get('PlanId')
  };
  get ContentLanguage() {
    return this.form.get('ContentLanguage')
  };

  postcontent() {
  console.log(this.form.value);
    if (this.form.valid) {
      this.adminservice.postcontent(this.form.value).subscribe(res => {
      alert("Data Posted")
      },
      err=>console.log(err)
      );
    }
  }
}

