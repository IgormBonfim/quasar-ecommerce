import { UsuarioCadastroResponse } from './../../usuario/models/response/usuarioCadastroResponse';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UsuarioCadastroRequest } from "src/app/usuario/models/request/usuarioCadastroRequest";
import { environment } from "src/environments/environment";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService {
  baseUrl = environment.apiBaseUrl + 'usuarios';

  constructor(private readonly httpService: HttpClient) {}


  adicionar(request: UsuarioCadastroRequest) : Observable<UsuarioCadastroResponse> {
    return this.httpService.post<UsuarioCadastroResponse>(this.baseUrl, request);
  }
}
