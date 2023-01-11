import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { FavoritoRequest } from '../models/requests/favorito.request';

@Injectable({
  providedIn: 'root'
})
export class FavoritosService {
  baseUrl = environment.apiBaseUrl + "favoritos/"

  constructor(private httpClient: HttpClient) { }

  adicionarFavorito(request: FavoritoRequest): Observable<any> {
    return this.httpClient.post<any>(this.baseUrl + "adicionar", request);
  }

  removerFavorito(request: FavoritoRequest): Observable<any> {
    return this.httpClient.post<any>(this.baseUrl + "remover", request);
  }

}
