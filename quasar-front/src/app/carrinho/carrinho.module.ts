import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CarrinhoRoutingModule } from './carrinho-routing.module';
import { CarrinhoComponent } from './paginas/carrinho/carrinho.component';
import { BoxCarrinhoSelecionadosComponent } from './components/box-carrinho-selecionados/box-carrinho-selecionados.component';
import { FavoritadosComponent } from './components/favoritados/favoritados.component';
import { FinalizacaoOutrosComponent } from './components/finalizacao-outros/finalizacao-outros.component';


@NgModule({
  declarations: [
    CarrinhoComponent,
    BoxCarrinhoSelecionadosComponent,
    FavoritadosComponent,
    FinalizacaoOutrosComponent
  ],
  imports: [
    CommonModule,
    CarrinhoRoutingModule
  ]
})
export class CarrinhoModule { }
