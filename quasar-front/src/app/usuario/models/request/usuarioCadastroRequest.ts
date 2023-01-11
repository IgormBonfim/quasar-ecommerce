import { ClienteInserirRequest } from './clienteInserirRequest';
export class UsuarioCadastroRequest {
  public email: string;
  public senha: string;
  public senhaConfirmacao: string;
  public cliente: ClienteInserirRequest

  constructor(params: Partial<UsuarioCadastroRequest>) {
    this.email = params.email || '';
    this.senha = params.senha || '';
    this.senhaConfirmacao = params.senhaConfirmacao || '';
    this.cliente = params.cliente || new ClienteInserirRequest({});
  }
}
