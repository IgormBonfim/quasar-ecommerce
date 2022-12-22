export class CarrinhoInserirRequest {
    public quantidade: number;
    public codProduto: number

    constructor(quantidade: number, codigo: number) {
      this.quantidade = quantidade;
      this.codProduto = codigo;
    }
}
