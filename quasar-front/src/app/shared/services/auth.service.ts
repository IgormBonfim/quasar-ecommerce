import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  verificaUsuarioLogado(): boolean {
    const token = localStorage.getItem("token");

    if (token != null) {
      return true;
    }
    return false;
  }

  recuperarToken() {
    return localStorage.getItem("token");
  }
}
