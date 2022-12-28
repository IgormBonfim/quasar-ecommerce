import { PaginacaoRequest } from "./paginacao.request";

export class CidadeListarRequests extends PaginacaoRequest {
    public nome: string;
    public codUf: number;

    constructor (params: Partial<CidadeListarRequests>) {
        super(params);
        this.nome = params.nome || '';
        this.codUf = params.codUf || 0;
    }
}
