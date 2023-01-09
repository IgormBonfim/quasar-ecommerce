export class UfResponse{
    public codigo: number;
    public sigla: string;
    public nome: string;

    constructor (params: Partial<UfResponse>) {
        this.codigo = params.codigo || 0;
        this.sigla = params.sigla || '';
        this.nome = params.nome || '';
    }
}
