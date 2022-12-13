import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProdutoResponse } from '../models/responses/produto.response';

@Injectable({
  providedIn: 'root'
})
export class ProdutosService {
  baseUrl = environment.apiBaseUrl;

  constructor(
    private httpClient: HttpClient
  ) { }

  public recuperarProduto(codigo: number): Observable<ProdutoResponse>  {
    return this.httpClient.get<ProdutoResponse>(`${this.baseUrl}produtos/${codigo}`)
  }
}

