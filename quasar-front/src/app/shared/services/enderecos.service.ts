import { EnderecoResponse } from './../models/responses/endereco.response';
import { EnderecoInserirRequest } from './../models/requests/endereco-inserir.request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EnderecosService {

  public baseUrl = environment.apiBaseUrl + "enderecos"

  constructor(private httpClient: HttpClient) { }

  adicionar(request: EnderecoInserirRequest): Observable<EnderecoResponse> {
    return this.httpClient.post<EnderecoResponse>(this.baseUrl, request);
  }
}
