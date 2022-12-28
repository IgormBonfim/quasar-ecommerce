import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CidadesResponse } from '../models/responses/cidades.response';

@Injectable({
  providedIn: 'root'
})
export class CidadesService {
  baseUrl = environment.apiBaseUrl + "cidades";

  constructor(private httpClient: HttpClient) { }

  listarCidades (
    params: CidadesResponse
  ): Observable<CidadesResponse> {
    return this.httpClient.get<CidadesResponse>(
      this.baseUrl,
      {
          params: params as any,
      }
    );
  }
}
