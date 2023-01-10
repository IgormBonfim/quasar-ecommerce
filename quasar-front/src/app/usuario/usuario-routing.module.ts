import { PerfilComponent } from './paginas/perfil/perfil.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroComponent } from './paginas/cadastro/cadastro.component';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "perfil",
  },
  {
    path: "perfil",
    component: PerfilComponent
  },

  {
    path: "cadastro",
    component: CadastroComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioRoutingModule { }
