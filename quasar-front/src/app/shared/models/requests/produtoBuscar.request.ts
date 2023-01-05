import { PaginacaoRequest } from './paginacao.request';

export class ProdutoBuscarRequest extends PaginacaoRequest {

  codigo: ( number | string ) ;
  nome: string;
  codCategoria: ( number | string );

  constructor(params: Partial<ProdutoBuscarRequest>) {
    super(params);
    this.codigo = params.codigo || '';
    this.nome = params.nome || '';
    this.codCategoria = params.codCategoria || '';
  }
}
