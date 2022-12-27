import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { InputTextModule } from 'primeng/inputtext';

import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';
import { BotaoAdicionarCarrinhoComponent } from './components/botao-adicionar-carrinho/botao-adicionar-carrinho.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
<<<<<<< HEAD
    BotaoAdicionarCarrinhoComponent
=======
    BotaoAdicionarCarrinhoComponent,
    LoadingSpinnerComponent,
>>>>>>> 52dcc0d57ca2fa3b02809ba30e5fc147fee37dec
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
<<<<<<< HEAD
    FooterComponent,
    IconeCoracaoComponent
=======
    ProdutoCardComponent,
    IconeCoracaoComponent,
    LoadingSpinnerComponent
>>>>>>> 52dcc0d57ca2fa3b02809ba30e5fc147fee37dec
  ]
})
 export class SharedModule{};