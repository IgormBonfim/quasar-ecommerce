export class FormasPagamentoResponse {
  public codigo: number;
  public descricao: string;

  constructor(params: Partial<FormasPagamentoResponse>) {
    this.codigo = params.codigo || 0;
    this.descricao = params.descricao || '';
  }
}
