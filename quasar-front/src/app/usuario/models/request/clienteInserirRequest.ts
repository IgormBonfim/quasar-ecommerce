export class ClienteInserirRequest {
  public nome: string;
  public sobrenome: string;
  public nomeFantasia: string;
  public cpfCnpj: string;
  public inscricaoEstadual: string;
  public razaoSocial: string;
  public tipoCliente: string;

  constructor(params: Partial<ClienteInserirRequest>) {
    this.nome = params.nome || '';
    this.sobrenome = params.sobrenome || '';
    this.nomeFantasia = params.nomeFantasia || '';
    this.cpfCnpj = params.cpfCnpj || '';
    this.inscricaoEstadual = params.inscricaoEstadual || '';
    this.razaoSocial = params.razaoSocial || '';
    this.tipoCliente = params.tipoCliente || '';
  }
}
