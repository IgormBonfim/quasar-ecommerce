import { CadastroJuridicoComponent } from './components/cadastro-juridico/cadastro-juridico.component';
import { CadastroFisicoComponent } from './components/cadastro-fisico/cadastro-fisico.component';
import { CadastroOpcaoComponent } from './components/cadastro-opcao/cadastro-opcao.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { UsuarioRoutingModule } from './usuario-routing.module';
import { PerfilComponent } from './paginas/perfil/perfil.component';
import { CadastroComponent } from './paginas/cadastro/cadastro.component';

@NgModule({
  declarations: [
    PerfilComponent,
    CadastroComponent,
    CadastroOpcaoComponent,
    CadastroFisicoComponent,
    CadastroJuridicoComponent,
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    FontAwesomeModule
  ]
})
export class UsuarioModule { }
