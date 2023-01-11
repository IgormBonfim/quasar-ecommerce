import { ItemVendaInserirRequest } from './itemVendaInserir.request';

export class VendaInserirRequest {
  public codEndereco: number;
  public codFormaPagamento: number;
  public codStatusVenda: number;
  public itens: ItemVendaInserirRequest[];

  constructor(params: Partial<VendaInserirRequest>) {
    this.codEndereco = params.codEndereco || 0;
    this.codFormaPagamento = params.codFormaPagamento || 0;
    this.codStatusVenda = params.codStatusVenda || 0;
    this.itens = params.itens || [];
  }
}
