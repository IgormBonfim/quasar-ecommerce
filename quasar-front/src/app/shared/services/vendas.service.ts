import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { PaginacaoRequest } from '../models/requests/paginacao.request';
import { PaginacaoResponse } from '../models/responses/paginacao.response';
import { VendaResponse } from '../models/responses/venda.response';

@Injectable({
  providedIn: 'root'
})
export class VendasService {

  public baseUrl = environment.apiBaseUrl + "vendas";

  constructor(private httpClient: HttpClient) { }

  listar(params: PaginacaoRequest<VendaResponse>): Observable<PaginacaoResponse<VendaResponse>> {
    return this.httpClient.get<PaginacaoResponse<VendaResponse>>(this.baseUrl);
  }

}
