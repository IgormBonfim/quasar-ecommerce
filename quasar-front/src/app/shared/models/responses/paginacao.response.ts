export class PaginacaoResponse<T> {
  pagina: number;
  quantidade: number; // Número de itens por página
  totalPaginas: number; // Total de paginas existentes
  lista: Array<T>; // Lista de itens da página atual

  constructor(params: Partial<PaginacaoResponse<T>>) {
    this.pagina = params.pagina || 0;
    this.quantidade = params.quantidade || 0;
    this.totalPaginas = params.totalPaginas || 0;
    this.lista = params.lista || [];
  }
}
