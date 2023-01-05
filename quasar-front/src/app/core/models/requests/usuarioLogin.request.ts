export class UsuarioLoginRequest {
    public login! : string;
    public senha! : string;

    constructor(params: Partial<UsuarioLoginRequest>) {
        this.login = params.login || "";
        this.senha = params.senha || "";
    }
}