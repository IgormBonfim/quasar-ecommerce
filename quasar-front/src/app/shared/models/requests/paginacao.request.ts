export class PaginacaoRequest<T> {
  Pagina: number; // página atual
  Quantidade: number; // número de itens por página

  constructor(params: Partial<PaginacaoRequest<T>>) {
    this.Pagina = params.Pagina || 1;
    this.Quantidade = params.Quantidade || 20;
  }
}
