import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioCadastroRequest } from 'src/app/usuario/models/request/usuarioCadastroRequest';
import { UsuarioCadastroResponse } from 'src/app/usuario/models/response/usuarioCadastroResponse';
import { environment } from 'src/environments/environment';
import { UsuarioResponse } from '../models/responses/usuario.response';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  public baseUrl = environment.apiBaseUrl + "usuarios";

  constructor(private httpClient: HttpClient) { }

  public recuperar(codigo: string): Observable<UsuarioResponse> {
    return this.httpClient.get<UsuarioResponse>(`${this.baseUrl}/${codigo}`);
  }

  adicionar(request: UsuarioCadastroRequest): Observable<UsuarioCadastroResponse> {
    return this.httpClient.post<UsuarioCadastroResponse>(this.baseUrl + "/cadastrar", request);
  }
}
