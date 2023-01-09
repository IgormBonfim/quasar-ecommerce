import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarouselModule } from 'primeng/carousel';
import { InputNumberModule } from 'primeng/inputnumber';
import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';

import { BotaoAdicionarCarrinhoComponent } from './components/botao-adicionar-carrinho/botao-adicionar-carrinho.component';
import { CarroselDeProdutoComponent } from './components/carrosel-de-produto/carrosel-de-produto.component';
import { CategoriaComponent } from './components/categoria/categoria.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';
import { InputQuantidadeComponent } from './components/input-quantidade/input-quantidade.component';
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
    InputQuantidadeComponent,
    LoadingSpinnerComponent,
    MenuLateralComponent,
    CarroselDeProdutoComponent,
    CategoriaComponent,
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    FontAwesomeModule,
    InputNumberModule,
    SidebarModule,
    CarouselModule,
    BsDropdownModule,
  ],
  exports: [
    HeaderComponent,
    CategoriaComponent,
    FooterComponent,
    InputQuantidadeComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
    LoadingSpinnerComponent,
    MenuLateralComponent,
    CarroselDeProdutoComponent,
  ],
})
export class SharedModule {}
