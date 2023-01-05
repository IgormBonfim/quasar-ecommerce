import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarrinhoRoutingModule } from './carrinho-routing.module';
import { CarrinhoComponent } from './paginas/carrinho/carrinho.component';
import { BoxCarrinhoSelecionadosComponent } from './components/box-carrinho-selecionados/box-carrinho-selecionados.component';
import { FinalizacaoOutrosComponent } from './components/finalizacao-outros/finalizacao-outros.component';


@NgModule({
  declarations: [
    CarrinhoComponent,
    BoxCarrinhoSelecionadosComponent,
    FinalizacaoOutrosComponent
  ],
  imports: [
    CommonModule,
    CarrinhoRoutingModule,
    SharedModule,
    FontAwesomeModule
  ]
})
export class CarrinhoModule { }
