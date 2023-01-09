import { EspecificacaoInserirRequest } from "./especificacaoInserir.request";

export class ProdutoInserirRequest {
  public descricao: string;
  public nome: string;
  public valor: number;
  public imagem: string;
  public quantidadeEstoque: number;
  public codigoCategoria: number;
  public codigoFornecedor: number;
  public especificacao: EspecificacaoInserirRequest;

  constructor(params: Partial<ProdutoInserirRequest>) {
    this.descricao = params.descricao || '';
    this.nome = params.nome || '';
    this.valor = params.valor || 0;
    this.imagem = params.imagem || '';
    this.quantidadeEstoque = params.quantidadeEstoque || 0;
    this.codigoCategoria = params.codigoCategoria || 0;
    this.codigoFornecedor = params.codigoFornecedor || 0;
    this.especificacao = params.especificacao || new EspecificacaoInserirRequest({});
  }
}
