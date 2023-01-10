export class UsuarioCadastroResponse {
  public sucesso!: boolean;
  public erro!: string;

  constructor(params: Partial<UsuarioCadastroResponse>) {
    this.sucesso = params.sucesso || true;
    this.erro = params.erro || '';
  }
}
