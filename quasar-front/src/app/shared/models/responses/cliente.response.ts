export class ClienteResponse {
  public codigo: number;
  public nome: string;
  public nomeFantasia: string;
  public cpfCnpj: string;
  public inscricaoEstadual: string;
  public razaoSocial: string;

  constructor(params: Partial<ClienteResponse>) {
    this.codigo = params.codigo || 0;
    this.nome = params.nome || "";
    this.nomeFantasia = params.nomeFantasia || "";
    this.cpfCnpj = params.cpfCnpj || "";
    this.inscricaoEstadual = params.inscricaoEstadual || "";
    this.razaoSocial = params.razaoSocial || "";
  }
}
