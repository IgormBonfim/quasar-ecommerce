import { BotaoFinalizarComponent } from './components/botao-finalizar/botao-finalizar.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CarouselModule } from 'primeng/carousel';
import { SidebarModule } from 'primeng/sidebar';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule} from 'primeng/inputnumber';

import { BotaoAdicionarCarrinhoComponent } from './components/botao-adicionar-carrinho/botao-adicionar-carrinho.component';
import { CarroselDeProdutoComponent } from './components/carrosel-de-produto/carrosel-de-produto.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';
import { MenuLateralComponent } from './components/menu-lateral/menu-lateral.component';
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';
import { CategoriaComponent } from './components/categoria/categoria.component';
import { TituloComponent } from './components/titulo/titulo.component';



import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { InputQuantidadeComponent } from './components/input-quantidade/input-quantidade.component';

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
    TituloComponent,
    BotaoFinalizarComponent
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    FontAwesomeModule,
    HttpClientModule,
    InputNumberModule,
    SidebarModule,
    CarouselModule,
    BsDropdownModule,
    HttpClientModule,
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
    TituloComponent,
    BotaoFinalizarComponent,
  ],
})
export class SharedModule {}
