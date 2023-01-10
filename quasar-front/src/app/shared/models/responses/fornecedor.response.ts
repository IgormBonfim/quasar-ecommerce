export class FornecedorResponse {
  public codigo: number;
  public nome: string;
  public razaoSocial: string;
  public cnpj: string;
  public ie: string;

  constructor(params: Partial<FornecedorResponse>) {
    this.codigo = params.codigo || 0;
    this.nome = params.nome || '';
    this.razaoSocial = params.razaoSocial || '';
    this.cnpj = params.cnpj || '';
    this.ie = params.ie || '';
  }
}
