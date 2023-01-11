import { Observable } from 'rxjs';
import { VendaInserirResponse } from '../models/responses/vendaInserir.response';
import { VendaInserirRequest } from '../models/requests/vendaInserir.request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VendasService {

  public baseUrl = environment.apiBaseUrl + "vendas";

  constructor(private httpClient: HttpClient) { }

  public adicionar(request: VendaInserirRequest): Observable<VendaInserirResponse> {
    return this.httpClient.post<VendaInserirResponse>(this.baseUrl, request);
  }
}
