import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {InputNumberModule} from 'primeng/inputnumber';


import { InputTextModule } from 'primeng/inputtext'
import { HeaderComponent } from './components/header/header.component';
import { InputQuantidadeComponent } from './components/input-quantidade/input-quantidade.component';

@NgModule({
  declarations: [
    HeaderComponent,
    InputQuantidadeComponent,
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    FontAwesomeModule,
    InputNumberModule
  ],
  exports: [
    HeaderComponent,
    InputQuantidadeComponent
   ]
})
export class SharedModule { }
