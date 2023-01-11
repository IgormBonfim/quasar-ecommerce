import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { SweetAlertService } from 'src/app/shared/services/sweet-alert.service';
import { UsuarioLoginRequest } from '../../models/requests/usuarioLogin.request';
import { UsuarioLoginResponse } from '../../models/responses/usuarioLogin.response';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public userIcon = faUserCircle;

  formulario!: FormGroup;

  constructor(private formBuilder: FormBuilder,
    private loginService: LoginService,
    private sweetAlertService: SweetAlertService,
    private Router: Router
    ) { }

  ngOnInit(): void {

      this.formulario = this.formBuilder.group({
        login: ['', [Validators.required]],
        senha: ['', [Validators.required]]
      })
  }

  logarUsuario() {
    const request = new UsuarioLoginRequest(
      this.formulario.getRawValue()
    )

    this.loginService.login(request).subscribe({
      next: (response: UsuarioLoginResponse) => {
        if(response.sucesso) {
          let token = response.token;
          localStorage.setItem("token", token)
          this.Router.navigate(["home"])
        }
        if(!response.sucesso) {
          this.sweetAlertService.erro(response.erro);
        }
      },
    })
  }

}
