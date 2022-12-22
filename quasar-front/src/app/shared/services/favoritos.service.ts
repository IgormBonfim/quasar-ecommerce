import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FavoritoRequest } from '../models/requests/favorito.request';

@Injectable({
  providedIn: 'root'
})
export class FavoritosService {
  baseUrl = environment.apiBaseUrl + "favoritos/"

  constructor(private httpClient: HttpClient) { }

  adicionarFavorito(request: FavoritoRequest) {
    return this.httpClient.post(this.baseUrl + "adicionar", request);
  }

  removerFavorito(request: FavoritoRequest) {
    return this.httpClient.post(this.baseUrl + "remover", request);
  }

}
