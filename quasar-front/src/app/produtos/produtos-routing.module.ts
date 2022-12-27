import { ProdutosAdicionarComponent } from './paginas/produtos-adicionar/produtos-adicionar.component';
import { ProdutosListagemComponent } from './paginas/produtos-listagem/produtos-listagem.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, CanActivate } from '@angular/router';
import { AuthGuard } from '../shared/guards/auth.guard';

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
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProdutosRoutingModule { }
