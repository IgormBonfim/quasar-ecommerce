import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { VendasEtapasComponent } from './components/vendas-etapas/vendas-etapas.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendasRoutingModule } from './vendas-routing.module';
import { FinalizarVendaComponent } from './paginas/finalizar-venda/finalizar-venda.component';
import { VendasEnderecoComponent } from './components/vendas-endereco/vendas-endereco.component';
import { VendasDadosComponent } from './components/vendas-dados/vendas-dados.component';
import { VendasPagamentoComponent } from './components/vendas-pagamento/vendas-pagamento.component';


@NgModule({
  declarations: [
    FinalizarVendaComponent,
    VendasEnderecoComponent,
    VendasDadosComponent,
    VendasPagamentoComponent,
    VendasEtapasComponent
  ],
  imports: [
    CommonModule,
    VendasRoutingModule,
    FontAwesomeModule
  ],
  exports: [
    FinalizarVendaComponent
  ]
})
export class VendasModule { }
