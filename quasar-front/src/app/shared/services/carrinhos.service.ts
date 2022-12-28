import { CarrinhoResponse } from './../models/responses/carrinho.response';
import { CarrinhoInserirRequest } from './../models/requests/carrinhoInserir.request';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { PaginacaoResponse } from '../models/responses/paginacao.response';

@Injectable({
  providedIn: 'root'
})
export class CarrinhosService {
  public baseUrl = environment.apiBaseUrl + "carrinhos"; // == "https://localhost:7263/api/carrinhos"



  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) { }

  adicionar(params: CarrinhoInserirRequest) {
    return this.httpClient.post(this.baseUrl, params);
  }

  listar() : Observable<PaginacaoResponse<CarrinhoResponse>> {
    return this.httpClient.get<PaginacaoResponse<CarrinhoResponse>>(this.baseUrl);
  }
}
