import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';

import { HeaderComponent } from './components/header/header.component';
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';
import { MenuLateralComponent } from './components/menu-lateral/menu-lateral.component';
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';


@NgModule({
  declarations: [
    HeaderComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
    BotaoAdicionarCarrinhoComponent,
    LoadingSpinnerComponent,
    MenuLateralComponent,
  ],
  imports: [
    CommonModule,
    InputTextModule,
    RouterModule,
    FontAwesomeModule,
    HttpClientModule,
    SidebarModule,
    BrowserAnimationsModule
  ],
  exports: [
    HeaderComponent,
    ProdutoCardComponent,
    IconeCoracaoComponent,
    LoadingSpinnerComponent,
    MenuLateralComponent
  ]
})
export class SharedModule { }
