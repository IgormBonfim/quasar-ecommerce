import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { CadastroFisicoComponent } from './components/cadastro-fisico/cadastro-fisico.component';
import { CadastroJuridicoComponent } from './components/cadastro-juridico/cadastro-juridico.component';
import { CadastroOpcaoComponent } from './components/cadastro-opcao/cadastro-opcao.component';
import { CadastroComponent } from './paginas/cadastro/cadastro.component';
import { UsuarioRoutingModule } from './usuario-routing.module';


@NgModule({
  declarations: [
    CadastroComponent,
    CadastroOpcaoComponent,
    CadastroFisicoComponent,
    CadastroJuridicoComponent,
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    FontAwesomeModule,
    ReactiveFormsModule
  ]
})
export class UsuarioModule { }
