import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedModule } from './../shared/shared.module';
import { ProdutosDetalhesComponent } from './paginas/produtos-detalhes/produtos-detalhes.component';
import { ProdutosRoutingModule } from './produtos-routing.module';
import { InputNumberModule } from 'primeng/inputnumber';
import { ProdutoInfoComponent } from './components/produto-info/produto-info.component';



@NgModule({
  declarations: [
    ProdutosDetalhesComponent,
    ProdutoInfoComponent
  ],
  imports: [
    CommonModule,
    ProdutosRoutingModule,
    SharedModule,
    InputNumberModule
  ]
})
export class ProdutosModule { }
