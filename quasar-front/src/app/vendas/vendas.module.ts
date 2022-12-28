import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendasRoutingModule } from './vendas-routing.module';
import { FinalizarVendaComponent } from './paginas/finalizar-venda/finalizar-venda.component';
import { VendasEnderecoComponent } from './components/vendas-endereco/vendas-endereco.component';
import { VendasDadosComponent } from './components/vendas-dados/vendas-dados.component';
import { VendasPagamentoComponent } from './components/vendas-pagamento/vendas-pagamento.component';
import { VendasIconesComponent } from './components/vendas-icones/vendas-icones.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SharedModule } from '../shared/shared.module';
import { DropdownModule } from 'primeng/dropdown';



@NgModule({
  declarations: [
    FinalizarVendaComponent,
    VendasEnderecoComponent,
    VendasDadosComponent,
    VendasPagamentoComponent,
    VendasIconesComponent
  ],
  imports: [
    CommonModule,
    VendasRoutingModule,
    FontAwesomeModule,
    SharedModule,
    DropdownModule
  ]
})
export class VendasModule { }
