import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { PaginacaoRequest } from '../models/requests/paginacao.request';
import { CategoriaResponse } from '../models/responses/categoria.response';
import { PaginacaoResponse } from '../models/responses/paginacao.response';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {
  public baseUrl = environment.apiBaseUrl + "categorias";

  constructor(private httpClient: HttpClient) { }

  listarCategorias(params: PaginacaoRequest): Observable<PaginacaoResponse<CategoriaResponse>> {
    return this.httpClient.get<PaginacaoResponse<CategoriaResponse>>(
      this.baseUrl,
      {
        params: params as any,
      }
      )
  }
}
