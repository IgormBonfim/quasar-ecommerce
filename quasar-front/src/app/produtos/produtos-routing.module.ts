import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from '../shared/guards/auth.guard';
import { ProdutosAdicionarComponent } from './paginas/produtos-adicionar/produtos-adicionar.component';
import { ProdutosDetalhesComponent } from './paginas/produtos-detalhes/produtos-detalhes.component';
import { ProdutosListagemComponent } from './paginas/produtos-listagem/produtos-listagem.component';

const routes: Routes = [
  {
    path: "",
    pathMatch: 'full',
    component: ProdutosListagemComponent,
  },
  {
    path: "adicionar",
    component: ProdutosAdicionarComponent,
    canActivate: [AuthGuard]
  },
  {
    path: ":codigo",
    component: ProdutosDetalhesComponent
  },


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProdutosRoutingModule { }
