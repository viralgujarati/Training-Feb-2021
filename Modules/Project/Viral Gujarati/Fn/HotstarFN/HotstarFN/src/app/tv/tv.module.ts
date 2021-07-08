import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TVRoutingModule } from './tv-routing.module';
import { TVComponent } from './tv.component';


@NgModule({
  declarations: [
    TVComponent
  ],
  imports: [
    CommonModule,
    TVRoutingModule
  ]
})
export class TVModule { }
