import { FormasPagamentoResponse } from './../models/responses/formas-pagamento.response';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FormasPagamentoService {

  public baseUrl = environment.apiBaseUrl + "formaspagamento"

  constructor(private httpClient: HttpClient) { }

  public recuperar(codigo: number): Observable<FormasPagamentoResponse> {
    return this.httpClient.get<FormasPagamentoResponse>(`${this.baseUrl}/${codigo}`);
  }
}
