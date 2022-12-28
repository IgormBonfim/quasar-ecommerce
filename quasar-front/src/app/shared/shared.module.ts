import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { InputTextModule } from 'primeng/inputtext';
import { InputNumberModule} from 'primeng/inputnumber';
import { SidebarModule } from 'primeng/sidebar';

import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';
import { MenuLateralComponent } from './components/menu-lateral/menu-lateral.component';
import { BotaoAdicionarCarrinhoComponent } from './components/botao-adicionar-carrinho/botao-adicionar-carrinho.component';

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
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    FontAwesomeModule,
    HttpClientModule,
    InputNumberModule,
    SidebarModule,
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    InputQuantidadeComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
    LoadingSpinnerComponent,
    MenuLateralComponent,
  ],
})
export class SharedModule {}
