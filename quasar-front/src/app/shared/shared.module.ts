import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { InputTextModule } from 'primeng/inputtext'
import { HeaderComponent } from './components/header/header.component';
import { HttpClientModule } from '@angular/common/http'

@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    HttpClientModule
  ],
  exports: [
    HeaderComponent
  ]
})
export class SharedModule { }
