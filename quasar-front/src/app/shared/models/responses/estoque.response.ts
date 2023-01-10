import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';

export class EstoqueResponse {
  public codigo: number;
  public quantidade: number;
  public produto: ProdutoResponse;

  constructor(params: Partial<EstoqueResponse>) {
    this.codigo = params.codigo || 0;
    this.quantidade = params.quantidade || 0;
    this.produto = params.produto || new ProdutoResponse({});
  }
}
