import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private tokenHelper;

  constructor() {
    this.tokenHelper = new JwtHelperService();
   }

  verificaUsuarioLogado(): boolean {
    const token = this.recuperarToken();

    if (token != null) {
      if (this.tokenHelper.isTokenExpired(token)) {
        return false;
      }
      return true;
    }
    else {
      return false;
    }
  }

  public recuperarCodigo() {

    let token = this.recuperarToken() || ""

    let tokenDecodificado = this.tokenHelper.decodeToken(token)

    return tokenDecodificado.codigoUsuario;
  }

  recuperarToken() {
    return localStorage.getItem("token");
  }
}
