import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { InputTextModule } from 'primeng/inputtext';

import { HeaderComponent } from './components/header/header.component';
<<<<<<< HEAD
import { FooterComponent } from './components/footer/footer.component';
=======
import { ProdutoCardComponent } from './components/produto-card/produto-card.component';
import { IconeCoracaoComponent } from './components/icone-coracao/icone-coracao.component';
import { BotaoAdicionarCarrinhoComponent } from './components/botao-adicionar-carrinho/botao-adicionar-carrinho.component';

>>>>>>> 87fda87f34fb790299ad8fad1fcaffdcc6131429

@NgModule({
  declarations: [
    HeaderComponent,
<<<<<<< HEAD
    FooterComponent,
=======
    ProdutoCardComponent,
    IconeCoracaoComponent,
    BotaoAdicionarCarrinhoComponent,
>>>>>>> 87fda87f34fb790299ad8fad1fcaffdcc6131429
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
    FooterComponent
=======
    ProdutoCardComponent,
    IconeCoracaoComponent
>>>>>>> 87fda87f34fb790299ad8fad1fcaffdcc6131429
  ]
})
export class SharedModule { }
