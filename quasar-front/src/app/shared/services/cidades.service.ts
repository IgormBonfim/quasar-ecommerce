import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CidadeListarRequests } from '../models/requests/cidadeListar.request';
import { CidadesResponse } from '../models/responses/cidades.response';
import { PaginacaoResponse } from '../models/responses/paginacao.response';
import { UfResponse } from '../models/responses/uf.response';

@Injectable({
  providedIn: 'root'
})
export class CidadesService {
  baseUrl = environment.apiBaseUrl + "cidades";

  constructor(private httpClient: HttpClient,
    private router: Router
    ) { }

 

  listarCidades (
    params: CidadeListarRequests
  ): Observable<PaginacaoResponse<CidadesResponse>> {
    return this.httpClient.get<PaginacaoResponse<CidadesResponse>>(
      this.baseUrl,
      {
          params: params as any,
      }
    );
  }
}
