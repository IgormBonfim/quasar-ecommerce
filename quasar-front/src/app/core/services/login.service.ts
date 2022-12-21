import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UsuarioLoginRequest } from '../models/requests/usuarioLogin.request';
import { UsuarioLoginResponse } from '../models/responses/usuarioLogin.response';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl = environment.apiBaseUrl + "usuarios/";

  constructor(private httpClient: HttpClient) { }

  login(request: UsuarioLoginRequest) : Observable<UsuarioLoginResponse> {
    return this.httpClient.post<UsuarioLoginResponse>(this.baseUrl + "login", request);
  }
}
