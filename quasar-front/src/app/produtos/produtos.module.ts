import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedModule } from './../shared/shared.module';
import { ProdutosDetalhesComponent } from './paginas/produtos-detalhes/produtos-detalhes.component';
import { ProdutosRoutingModule } from './produtos-routing.module';
import { InputNumberModule } from 'primeng/inputnumber';



@NgModule({
  declarations: [
    ProdutosDetalhesComponent
  ],
  imports: [
    CommonModule,
    ProdutosRoutingModule,
    SharedModule,
    InputNumberModule
  ]
})
export class ProdutosModule { }
