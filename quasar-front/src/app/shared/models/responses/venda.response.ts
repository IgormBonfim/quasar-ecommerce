import { EnderecoResponse } from './endereco.response';
import { FormasPagamentoResponse } from './formas-pagamento.response';
import { ItemVendaResponse } from './itemVenda.response';
import { StatusVendaResponse } from './statusVenda.response';

export class VendaResponse {
  public codigo: number;
  public endereco: EnderecoResponse;
  public formaPagamento: FormasPagamentoResponse;
  public statusVenda: StatusVendaResponse;
  public itens: ItemVendaResponse[];

  constructor(params: Partial<VendaResponse>) {
    this.codigo = params.codigo || 0;
    this.endereco = params.endereco || new EnderecoResponse({});
    this.formaPagamento = params.formaPagamento || new FormasPagamentoResponse({});
    this.statusVenda = params.statusVenda || new StatusVendaResponse({});
    this.itens = params.itens || [];
  }
}
