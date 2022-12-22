import { CarrinhoInserirRequest } from './../models/requests/carrinhoInserir.request';
import { delay, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CarrinhosService {
  public baseUrl = environment.apiBaseUrl + "carrinhos";
  public teste = environment.apiBaseUrl + "produtos";

  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) { }

  adicionar(params: CarrinhoInserirRequest) {
    return this.httpClient.post(this.baseUrl, params);
  }
}
