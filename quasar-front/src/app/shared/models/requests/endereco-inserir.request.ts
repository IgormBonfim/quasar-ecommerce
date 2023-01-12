export class EnderecoInserirRequest {
  public numero: number;
  public bairro: string;
  public rua: string;
  public pontoReferencia: string;
  public complemento: string;
  public cep: string;
  public codigoCidade: number;

  constructor(params: Partial<EnderecoInserirRequest>) {
    this.numero = params.numero || 0;
    this.bairro = params.bairro || "";
    this.rua = params.rua || "";
    this.pontoReferencia = params.pontoReferencia || "";
    this.complemento = params.complemento || "";
    this.cep = params.cep || "";
    this.codigoCidade = params.codigoCidade || 0;
  }
}
