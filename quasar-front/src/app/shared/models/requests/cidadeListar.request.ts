import { PaginacaoRequest } from "./paginacao.request";

export class CidadeListarRequests extends PaginacaoRequest<CidadeListarRequests> {
    public nome: string;
    public codUf: number | string;

    constructor (params: Partial<CidadeListarRequests>) {
        super(params);
        this.nome = params.nome || '';
        this.codUf = params.codUf || '';
    }
}
