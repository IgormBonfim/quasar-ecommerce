import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProdutoResponse } from 'src/app/shared/models/responses/produto.response';

@Injectable({
  providedIn: 'root',
})
export class ProdutosService {
  baseUrl = environment.apiBaseUrl + 'produtos';

  constructor(private httpClient: HttpClient) {}

  listarProdutos() {
    return this.httpClient.get<Observable<ProdutoResponse>>;
  }
}
