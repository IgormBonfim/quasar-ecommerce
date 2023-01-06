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

  constructor(private readonly httpService: HttpClient) {}

  listarProdutos(
    params: ProdutoBuscarRequest
  ): Observable<PaginacaoResponse<ProdutoResponse>> {
    return this.httpService.get<PaginacaoResponse<ProdutoResponse>>(
      this.baseUrl,
      {
        params: params as any,
      }
    );
  }
}
