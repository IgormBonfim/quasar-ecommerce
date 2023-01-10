import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';

import { environment } from './../../../environments/environment';
import { ProdutoBuscarRequest } from './../models/requests/produtoBuscar.request';

@Injectable({
  providedIn: 'root',
})
export class ProdutosService {
  baseUrl = environment.apiBaseUrl + 'produtos';

  constructor(private readonly httpClient: HttpClient) {}

  listarProdutos(
    params: ProdutoBuscarRequest
  ): Observable<PaginacaoResponse<ProdutoResponse>> {
    return this.httpClient.get<PaginacaoResponse<ProdutoResponse>>(
      this.baseUrl,
      {
        params: params as any,
      }
    );
  }

  public recuperarProduto(codigo: number): Observable<ProdutoResponse>  {
    return this.httpClient.get<ProdutoResponse>(`${this.baseUrl}/${codigo}`)
  }
}
