import { EspecificacaoInserirRequest } from "./especificacaoInserir.request";

export class ProdutoInserirRequest {
  public descricao!: string;
  public nome!: string;
  public valor!: number;
  public imagem!: string;
  public codigoCategoria!: number;
  public codigoFornecedor!: number;
  public especificacao!: EspecificacaoInserirRequest;
}


