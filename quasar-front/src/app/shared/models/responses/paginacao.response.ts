export class PaginacaoResponse<T> {
  Pagina: number;
  Quantidade: number; // Total de itens cadastrados
  TotalPaginas: number; // Total de paginas que foram formadas
  Lista: Array<T>; // Lista de itens da página atual

  constructor(params: Partial<PaginacaoResponse<T>>) {
    this.Pagina = params.Pagina || 0;
    this.Quantidade = params.Quantidade || 0;
    this.TotalPaginas = params.TotalPaginas || 0;
    this.Lista = params.Lista || [];
  }
}
