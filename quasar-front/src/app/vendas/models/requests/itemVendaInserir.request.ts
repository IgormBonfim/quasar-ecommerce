export class ItemVendaInserirRequest {
  public quantidade: number;
  public codProduto: number;

  constructor(params: Partial<ItemVendaInserirRequest>) {
    this.quantidade = params.quantidade || 0;
    this.codProduto =  params.codProduto || 0;
  }
}
