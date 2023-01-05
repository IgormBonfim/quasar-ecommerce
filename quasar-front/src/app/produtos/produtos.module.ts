import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { InputNumberModule } from 'primeng/inputnumber';

import { SharedModule } from './../shared/shared.module';
import { ProdutoInfoComponent } from './components/produto-info/produto-info.component';
import { ProdutosDetalhesComponent } from './paginas/produtos-detalhes/produtos-detalhes.component';
import { ProdutosListagemComponent } from './paginas/produtos-listagem/produtos-listagem.component';
import { ProdutosRoutingModule } from './produtos-routing.module';



@NgModule({
  declarations: [
    ProdutosDetalhesComponent,
    ProdutoInfoComponent,
    ProdutosListagemComponent
  ],
  imports: [
    CommonModule,
    ProdutosRoutingModule,
    SharedModule,
    InputNumberModule,
    FontAwesomeModule
  ]
})
export class ProdutosModule {}
