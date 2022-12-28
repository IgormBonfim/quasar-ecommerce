import { Component, OnInit } from '@angular/core';
import { CarouselConfig } from 'ngx-bootstrap/carousel';

@Component({
  selector: 'app-carousel-banners',
  templateUrl: './carousel-banners.component.html',
  styleUrls: ['./carousel-banners.component.css'],
  providers: [
  { provide: CarouselConfig, useValue: { interval: 6000, noPause: true, showIndicators: true } }
  ]
})
export class CarouselBannersComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
