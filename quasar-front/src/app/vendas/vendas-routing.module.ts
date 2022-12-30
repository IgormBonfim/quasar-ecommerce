import { VendasPagamentoComponent } from './components/vendas-pagamento/vendas-pagamento.component';
import { VendasEnderecoComponent } from './components/vendas-endereco/vendas-endereco.component';
import { VendasEtapasComponent } from './components/vendas-etapas/vendas-etapas.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VendasDadosComponent } from './components/vendas-dados/vendas-dados.component';
import { EtapasGuard } from './guards/etapas.guard';

const routes: Routes = [
  {
    path: "",
    pathMatch: "full",
    redirectTo: "dados"
  },
  {
    path: "dados",
    component: VendasDadosComponent,
  },
  {
    path: "endereco",
    component: VendasEnderecoComponent,
    canActivate: [EtapasGuard]
  },
  {
    path: "pagamento",
    component: VendasPagamentoComponent,
    canActivate: [EtapasGuard]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendasRoutingModule { }
