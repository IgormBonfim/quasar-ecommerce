import { ProdutoResponse } from './produto.response';

export class CarrinhoResponse {
  public codigo!: number;
  public quantidade!: number;
  public produto!: ProdutoResponse;
}
