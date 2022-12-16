import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './paginas/home/home.component';
import { CarouselBannersComponent } from './components/carousel-banners/carousel-banners.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';



@NgModule({
  declarations: [
    HomeComponent,
    CarouselBannersComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    CarouselModule
  ],
  exports: [
    HomeComponent
  ]
})
export class CoreModule { }
