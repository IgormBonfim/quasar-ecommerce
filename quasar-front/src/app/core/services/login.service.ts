import { HttpClient } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { UsuarioLoginRequest } from '../models/requests/usuarioLogin.request';
import { UsuarioLoginResponse } from '../models/responses/usuarioLogin.response';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl = environment.apiBaseUrl + "usuarios/";

  constructor(private httpClient: HttpClient) { }

  login(request: UsuarioLoginRequest): Observable<UsuarioLoginResponse>{
    return this.httpClient.post<UsuarioLoginResponse>(this.baseUrl + "login", request);
    // .subscribe((response)=>{
    //   let token = Object.values(response)[1]
    //   localStorage.setItem("token", token)
    // });
  }
  
}
