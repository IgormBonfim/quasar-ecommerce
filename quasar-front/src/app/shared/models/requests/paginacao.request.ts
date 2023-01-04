export class PaginacaoRequest<T> {
  pagina: number; // página atual
  quantidade: number; // número de itens por página

  constructor(params: Partial<PaginacaoRequest<T>>) {
    this.pagina = params.pagina || 1;
    this.quantidade = params.quantidade || 20;
  }
}
