import { EnderecoResponse } from "src/app/shared/models/responses/endereco.response";
import { FormasPagamentoResponse } from "src/app/shared/models/responses/formas-pagamento.response";

export class VendaInserirResponse {
  public endereco: EnderecoResponse;
  public formaPagamento: FormasPagamentoResponse

  constructor(params: Partial<VendaInserirResponse>){
    this.endereco = params.endereco || new EnderecoResponse({});
    this.formaPagamento = params.formaPagamento || new FormasPagamentoResponse({});
  }
}
