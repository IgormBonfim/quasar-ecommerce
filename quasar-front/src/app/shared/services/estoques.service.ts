import { EstoqueResponse } from './../models/responses/estoque.response';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstoquesService {
  baseUrl = environment.apiBaseUrl + "estoques";

  constructor(private httpClient: HttpClient) { }

  recuperarEstoquePeloCodigoDoProduto(codigo: number): Observable<EstoqueResponse>  {
    return this.httpClient.get<EstoqueResponse>(`${this.baseUrl}/${codigo}/produtos`)
  }
}
