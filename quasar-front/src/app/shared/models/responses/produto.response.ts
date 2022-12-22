import { CategoriaResponse } from "./categoria.response";
import { EspecificacaoResponse } from "./especificacao.response";
import { FornecedorResponse } from "./fornecedor.response";

export class ProdutoResponse {

  public codigo!: number;
  public descricao!: string;
  public nome!: string;
  public valor!: number;
  public imagem!: string;
  public fornecedor?: FornecedorResponse;
  public categoria?: CategoriaResponse;
  public especificacao?: EspecificacaoResponse


  constructor() {

  }
}
