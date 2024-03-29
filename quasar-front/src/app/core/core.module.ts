import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import  { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './paginas/home/home.component';
import { CarouselBannersComponent } from './components/carousel-banners/carousel-banners.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';

import { LoginComponent } from './paginas/login/login.component';

@NgModule({

  declarations: [
    HomeComponent,
    CarouselBannersComponent,
    LoginComponent],

  imports: [
    CommonModule,
    SharedModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    HttpClientModule,
    CarouselModule,
    RouterModule
  ],

  exports: [
    HomeComponent,
    LoginComponent
  ],

})
export class CoreModule {}
