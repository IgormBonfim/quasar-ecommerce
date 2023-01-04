import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CarouselModule } from 'primeng/carousel';
import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';

import { BotaoAdicionarCarrinhoComponent } from './components/botao-adicionar-carrinho/botao-adicionar-carrinho.component';
import { CarroselDeProdutoComponent } from './components/carrosel-de-produto/carrosel-de-produto.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { MenuLateralComponent } from './components/menu-lateral/menu-lateral.component';
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
    BotaoAdicionarCarrinhoComponent,
    LoadingSpinnerComponent,
    MenuLateralComponent,
    CarroselDeProdutoComponent,
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    FontAwesomeModule,
    HttpClientModule,
    SidebarModule,
    CarouselModule,
    BsDropdownModule,
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
    LoadingSpinnerComponent,
    MenuLateralComponent,
    CarroselDeProdutoComponent,
  ],
})
export class SharedModule {}
