import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendasDadosComponent } from './components/vendas-dados/vendas-dados.component';
import { FinalizarVendaComponent } from './paginas/finalizar-venda/finalizar-venda.component';

const routes: Routes = [
  {
    path: "",
    component: FinalizarVendaComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendasRoutingModule { }
