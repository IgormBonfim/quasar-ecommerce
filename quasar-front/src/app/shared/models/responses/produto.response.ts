import { CategoriaResponse } from "./categoria.response";
import { EspecificacaoResponse } from "./especificacao.response";
import { FornecedorResponse } from "./fornecedor.response";

export class ProdutoResponse {

  public codigo: number;
  public descricao: string;
  public nome: string;
  public valor: number;
  public imagem: string;
  public fornecedor: FornecedorResponse;
  public categoria: CategoriaResponse;
  public especificacao: EspecificacaoResponse


  constructor(params: Partial<ProdutoResponse>) {
    this.codigo = params.codigo || 0;
    this.descricao = params.descricao || '';
    this.nome = params.nome || '';
    this.valor = params.valor || 0;
    this.imagem = params.imagem || '';
    this.fornecedor = params.fornecedor || new FornecedorResponse({});
    this.categoria = params.categoria || new CategoriaResponse({});
    this.especificacao = params.especificacao || new EspecificacaoResponse({});
  }
}
