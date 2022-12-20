import { CarrinhoInserirRequest } from './../models/requests/carrinhoInserir.request';
import { first, Observable, delay } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CarrinhosService {
  public baseUrl = environment.apiBaseUrl + "carrinhos";

  constructor(
    private httpClient: HttpClient
  ) { }

  adicionar(params: CarrinhoInserirRequest) {

    setTimeout(() => {
      return this.httpClient.post(this.baseUrl, params);
    }, 10000)

  }
}
