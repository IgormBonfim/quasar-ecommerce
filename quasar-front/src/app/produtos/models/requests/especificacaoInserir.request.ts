export class EspecificacaoInserirRequest {
  public posicao: string;
  public cor: string;
  public ano: string;
  public veiculo: string;

  constructor(params: Partial<EspecificacaoInserirRequest>) {
    this.posicao = params.posicao || '';
    this.cor = params.cor || '';
    this.ano = params.ano || '';
    this.veiculo = params.veiculo || '';
  }
}
