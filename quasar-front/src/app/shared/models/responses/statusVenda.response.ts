export class StatusVendaResponse {
  public codigo: number;
  public descricao: string;

  constructor(params: Partial<StatusVendaResponse>) {
    this.codigo = params.codigo || 0;
    this.descricao = params.descricao || '';
  }
}
