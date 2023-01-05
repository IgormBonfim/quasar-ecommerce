import { ProdutoResponse } from './produto.response';

export class CarrinhoResponse {
  codigo! : number;
  quantidade!: number;
  produto!: ProdutoResponse
}
