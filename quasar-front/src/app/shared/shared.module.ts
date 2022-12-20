import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { InputTextModule } from 'primeng/inputtext';

import { HeaderComponent } from './components/header/header.component';
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';


@NgModule({
  declarations: [
    HeaderComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    FontAwesomeModule,
    HttpClientModule
  ],
  exports: [
    HeaderComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent
  ]
})
export class SharedModule { }
