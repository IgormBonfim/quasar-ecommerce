import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DropdownModule } from 'primeng/dropdown';

import { SharedModule } from './../shared/shared.module';
import { ProdutosAdicionarComponent } from './paginas/produtos-adicionar/produtos-adicionar.component';
import { ProdutosListagemComponent } from './paginas/produtos-listagem/produtos-listagem.component';
import { ProdutosRoutingModule } from './produtos-routing.module';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputNumberModule } from 'primeng/inputnumber';



@NgModule({
  declarations: [ProdutosListagemComponent, ProdutosAdicionarComponent],
  imports: [
    CommonModule,
    ProdutosRoutingModule,
    SharedModule,
    FontAwesomeModule,
    DropdownModule,
    ReactiveFormsModule,
    InputTextareaModule,
    InputNumberModule
  ],
})
export class ProdutosModule {}
