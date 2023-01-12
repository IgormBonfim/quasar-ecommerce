import { UfResponse } from "./uf.response";

export class CidadesResponse {
    public codigo: number;
    public nome: string;
    public uf: UfResponse;

    constructor(params: Partial<CidadesResponse>) {
      this.codigo = params.codigo || 0;
      this.nome = params.nome || "";
      this.uf = params.uf || new UfResponse({});
    }
}
