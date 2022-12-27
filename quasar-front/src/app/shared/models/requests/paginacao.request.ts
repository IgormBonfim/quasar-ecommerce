export class PaginacaoRequest {
  pagina: number; // página atual
  quantidade: number; // número de itens por página

  constructor(params: Partial<PaginacaoRequest>) {
    this.pagina = params.pagina || 1;
    this.quantidade = params.quantidade || 20;
  }
}
