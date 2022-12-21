import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './paginas/home/home.component';

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule, SharedModule, FontAwesomeModule, HttpClientModule],
  exports: [HomeComponent],
})
export class CoreModule {}
