import { ProdutosDetalhesComponent } from './paginas/produtos-detalhes/produtos-detalhes.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "", component: ProdutosDetalhesComponent},
  { path: ":id", component: ProdutosDetalhesComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProdutosRoutingModule { }
