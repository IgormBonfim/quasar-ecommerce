import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProdutoInserirRequest } from 'src/app/produtos/models/requests/produtoInserir.request';
import { ProdutoInserirResponse } from 'src/app/produtos/models/responses/produtoInserir.response';
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

  adicionar(request: ProdutoInserirRequest) : Observable<ProdutoInserirResponse> {
    return this.httpClient.post<ProdutoInserirResponse>(this.baseUrl, request);
  }

  public recuperarProduto(codigo: number): Observable<ProdutoResponse>  {
    return this.httpClient.get<ProdutoResponse>(`${this.baseUrl}/${codigo}`)
  }
}
