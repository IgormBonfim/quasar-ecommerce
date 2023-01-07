import { EspecificacaoInserirRequest } from "./especificacaoInserir.request";

export class ProdutoInserirRequest {
  public descricao: string;
  public nome: string;
  public valor: number;
  public imagem: string;
  public codigoCategoria: number;
  public codigoFornecedor: number;
  public especificacao: EspecificacaoInserirRequest;

  constructor(params: Partial<ProdutoInserirRequest>) {
    this.descricao = params.descricao || '';
    this.nome = params.nome || '';
    this.valor = params.valor || 0;
    this.imagem = params.imagem || '';
    this.codigoCategoria = params.codigoCategoria || 0;
    this.codigoFornecedor = params.codigoFornecedor || 0;
    this.especificacao = params.especificacao || new EspecificacaoInserirRequest({});
  }
}


