import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginacaoRequest } from '../models/requests/paginacao.request';
import { PaginacaoResponse } from '../models/responses/paginacao.response';
import { UfResponse } from '../models/responses/uf.response';

@Injectable({
  providedIn: 'root'
})
export class UfsService {
  baseUrl = environment.apiBaseUrl + "ufs";

  constructor(private httpClient: HttpClient) { }

  listarUf (
    params: PaginacaoRequest
  ): Observable<UfResponse[]> {
    return this.httpClient.get<UfResponse[]>(
      this.baseUrl,
      {
        params: params as any,
      }
    );
  }
  ;  
}
