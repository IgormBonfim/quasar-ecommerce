import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { DropdownModule } from 'primeng/dropdown';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextareaModule } from 'primeng/inputtextarea';

import { SharedModule } from './../shared/shared.module';
import { ProdutoEspecificacoesComponent } from './components/produto-especificacoes/produto-especificacoes.component';
import { ProdutoInfoComponent } from './components/produto-info/produto-info.component';
import { ProdutosAdicionarComponent } from './paginas/produtos-adicionar/produtos-adicionar.component';
import { ProdutosDetalhesComponent } from './paginas/produtos-detalhes/produtos-detalhes.component';
import { ProdutosListagemComponent } from './paginas/produtos-listagem/produtos-listagem.component';
import { ProdutosRoutingModule } from './produtos-routing.module';



@NgModule({
  declarations: [
    ProdutosDetalhesComponent,
    ProdutoInfoComponent,
    ProdutosListagemComponent,
    ProdutoEspecificacoesComponent,
    ProdutosAdicionarComponent
  ],
  imports: [
    CommonModule,
    ProdutosRoutingModule,
    SharedModule,
    InputNumberModule,
    FontAwesomeModule,
    DropdownModule,
    ReactiveFormsModule,
    InputTextareaModule,
    InputNumberModule,
    PaginationModule,
  ]
})
export class ProdutosModule {}
