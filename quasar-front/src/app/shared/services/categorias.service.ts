import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { CategoriaResponse } from '../models/responses/categoria.response';
import { environment } from './../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  baseUrl = environment.apiBaseUrl + "categorias";

  constructor(private httpClient: HttpClient) { }

  listarCategorias(): Observable<CategoriaResponse[]> {
    return this.httpClient.get<CategoriaResponse[]>(this.baseUrl);
  }

}
