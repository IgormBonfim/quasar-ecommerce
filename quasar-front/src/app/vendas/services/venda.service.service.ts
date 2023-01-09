import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { CidadesResponse } from 'src/app/shared/models/responses/cidades.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { UfResponse } from 'src/app/shared/models/responses/uf.response';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VendaServiceService {
  baseUrl = environment.apiBaseUrl + 'vendas';

  constructor(private readonly httpClient: HttpClient) { }
}
