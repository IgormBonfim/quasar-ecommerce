import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';

@Injectable({
  providedIn: 'root',
})
export class ProdutosService {
  baseUrl = environment.apiBaseUrl + 'produtos';

  constructor(private readonly httpClient: HttpClient) {}

  listarProdutos(
    params: PaginacaoRequest
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
