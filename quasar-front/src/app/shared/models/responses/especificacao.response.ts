export class EspecificacaoResponse {
  public codigo: number;
  public posicao: string;
  public cor: string;
  public ano: string;
  public veiculo: string;

  constructor(params: Partial<EspecificacaoResponse>) {
    this.codigo = params.codigo || 0;
    this.posicao = params.posicao || '';
    this.cor = params.cor || '';
    this.ano = params.ano || '';
    this.veiculo = params.veiculo || '';
  }
}
