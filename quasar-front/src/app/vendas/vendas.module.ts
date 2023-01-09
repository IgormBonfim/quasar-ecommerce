import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { VendasEtapasComponent } from './components/vendas-etapas/vendas-etapas.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VendasRoutingModule } from './vendas-routing.module';
import { FinalizarVendaComponent } from './paginas/finalizar-venda/finalizar-venda.component';
import { VendasEnderecoComponent } from './components/vendas-endereco/vendas-endereco.component';
import { VendasDadosComponent } from './components/vendas-dados/vendas-dados.component';
import { VendasPagamentoComponent } from './components/vendas-pagamento/vendas-pagamento.component';
import { VendasPagamentoBoletoComponent } from './components/vendas-pagamento-boleto/vendas-pagamento-boleto.component';
import { VendasPagamentoPixComponent } from './components/vendas-pagamento-pix/vendas-pagamento-pix.component';
import { VendasPagamentoCartaoComponent } from './components/vendas-pagamento-cartao/vendas-pagamento-cartao.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
    declarations: [
        FinalizarVendaComponent,
        VendasEnderecoComponent,
        VendasDadosComponent,
        VendasPagamentoComponent,
        VendasEtapasComponent,
        VendasPagamentoBoletoComponent,
        VendasPagamentoPixComponent,
        VendasPagamentoCartaoComponent
    ],
    exports: [
        FinalizarVendaComponent
    ],
    imports: [
        CommonModule,
        VendasRoutingModule,
        FontAwesomeModule,
        SharedModule
    ]
})
export class VendasModule { }
