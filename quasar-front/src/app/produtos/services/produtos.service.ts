import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';

import { environment } from './../../../environments/environment';
import { ProdutoInserirRequest } from './../models/requests/produtoInserir.request';
import { ProdutoInserirResponse } from './../models/responses/produtoInserir.response';

@Injectable({
  providedIn: 'root',
})
export class ProdutosService {
  baseUrl = environment.apiBaseUrl + 'produtos';

  constructor(private readonly httpService: HttpClient) {}

  listarProdutos(
    params: PaginacaoRequest
  ): Observable<PaginacaoResponse<ProdutoResponse>> {
    return this.httpService.get<PaginacaoResponse<ProdutoResponse>>(
      this.baseUrl,
      {
        params: params as any,
      }
    );
  }

  recuperar(CodigoProduto: number): Observable<ProdutoResponse> {
    return this.httpService.get<ProdutoResponse>(
      `${this.baseUrl}/${CodigoProduto}`
    );
  }

  // METODO HTTP POST
  adicionar(request: ProdutoInserirRequest) : Observable<ProdutoInserirResponse> {
    return this.httpService.post<ProdutoInserirResponse>(this.baseUrl, request);
  }
}
