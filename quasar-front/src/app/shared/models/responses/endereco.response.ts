import { CidadesResponse } from 'src/app/shared/models/responses/cidades.response';


export class EnderecoResponse {
  public codigo: number;
  public numero: number;
  public bairro: string;
  public rua: string;
  public pontoReferencia: string;
  public complemento: string;
  public cep: string;
  public cidade: CidadesResponse;

  constructor(params: Partial<EnderecoResponse>) {
    this.codigo = params.codigo || 0;
    this.numero = params.numero || 0;
    this.bairro = params.bairro || "";
    this.rua = params.rua || "";
    this.pontoReferencia = params.pontoReferencia || "";
    this.complemento = params.complemento || "";
    this.cep = params.cep || "";
    this.cidade = params.cidade || new CidadesResponse({});
  }

}
