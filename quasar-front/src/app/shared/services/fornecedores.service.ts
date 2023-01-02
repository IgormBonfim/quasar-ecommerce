import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FornecedorResponse } from '../models/responses/fornecedor.response';
import { PaginacaoResponse } from '../models/responses/paginacao.response';


@Injectable({
  providedIn: 'root'
})
export class FornecedoresService {
  public baseUrl = environment.apiBaseUrl + "fornecedores";

  constructor(private httpClient: HttpClient) { }

  listarFornecedores(params: PaginacaoRequest): Observable<PaginacaoResponse<FornecedorResponse>> {
    return this.httpClient.get<PaginacaoResponse<FornecedorResponse>>(
      this.baseUrl,
      {
        params: params as any,
      }
      );
  }
}
