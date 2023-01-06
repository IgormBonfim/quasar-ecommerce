import { PaginationModule } from 'ngx-bootstrap/pagination';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProdutosRoutingModule } from './produtos-routing.module';
import { ProdutosListagemComponent } from './paginas/produtos-listagem/produtos-listagem.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [ProdutosListagemComponent],
  imports: [
    CommonModule,
    ProdutosRoutingModule,
    SharedModule,
    FontAwesomeModule,
    PaginationModule,
  ],
})
export class ProdutosModule {}
