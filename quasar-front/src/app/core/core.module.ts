import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import SharedModule from '../shared/shared.module';
import { HomeComponent } from './paginas/home/home.component';
import { LoginComponent } from './paginas/login/login.component';

@NgModule({
  declarations: [HomeComponent, LoginComponent],
  imports: [
    CommonModule,
    SharedModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  exports: [HomeComponent, LoginComponent],
})
export class CoreModule {}
