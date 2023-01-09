export class CategoriaResponse {
  public codigo: number;
  public nome: string;
  public imagem: string;

  constructor(params: Partial<CategoriaResponse>) {
    this.codigo = params.codigo || 0;
    this.nome = params.nome || '';
    this.imagem = params.imagem || '';
  }
}
