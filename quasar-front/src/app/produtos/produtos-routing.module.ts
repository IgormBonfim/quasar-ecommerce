import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProdutosDetalhesComponent } from './paginas/produtos-detalhes/produtos-detalhes.component';
import { ProdutosListagemComponent } from './paginas/produtos-listagem/produtos-listagem.component';


const routes: Routes = [
  {
    path: "",
    pathMatch: 'full',
    component: ProdutosListagemComponent,
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
