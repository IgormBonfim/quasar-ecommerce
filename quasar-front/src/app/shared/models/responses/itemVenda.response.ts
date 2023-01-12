import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';

export class ItemVendaResponse {
  public codigo: number;
  public quantidade: number;
  public produto: ProdutoResponse;
  public valorUnitario: number;

  constructor(params: Partial<ItemVendaResponse>) {
    this.codigo = params.codigo || 0;
    this.quantidade = params.quantidade || 0;
    this.produto = params.produto || new ProdutoResponse({});
    this.valorUnitario = params.valorUnitario || 0;
  }
}

