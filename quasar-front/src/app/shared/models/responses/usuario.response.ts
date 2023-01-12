import { ClienteResponse } from './cliente.response';
export class UsuarioResponse {
  public codigo: string;
  public email: string;
  public cliente: ClienteResponse;

  constructor(params: Partial<UsuarioResponse>) {
    this.codigo = params.codigo || "";
    this.email = params.email || "";
    this.cliente = params.cliente || new ClienteResponse({});
  }
}
