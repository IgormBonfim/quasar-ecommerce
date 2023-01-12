import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { AlertsService, AlertTypes } from 'src/app/shared/services/alerts.service';
import { SweetAlertService } from 'src/app/shared/services/sweet-alert.service';
import { UsuariosService } from 'src/app/shared/services/usuarios.service';

import { UsuarioCadastroRequest } from '../../models/request/usuarioCadastroRequest';
import { UsuarioCadastroResponse } from '../../models/response/usuarioCadastroResponse';
import { ClienteInserirRequest } from './../../models/request/clienteInserirRequest';

@Component({
  selector: 'app-cadastro-fisico',
  templateUrl: './cadastro-fisico.component.html',
  styleUrls: ['./cadastro-fisico.component.css'],
})
export class CadastroFisicoComponent implements OnInit {

  cadastroForm!: FormGroup;

  public userIcon = faUserCircle;

  constructor(
    private formBuilder: FormBuilder,
    private usuariosService: UsuariosService,
    private router: Router,
    private alertsService: AlertsService,
    private sweetAletService: SweetAlertService
  ) {}

  ngOnInit(): void {
    this.cadastroForm = this.formBuilder.group({
      nome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(256),
        ],
      ],
      sobrenome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(256),
        ],
      ],
      telefone: [
        '',
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(11),
        ],
      ],
      cpfCnpj: [
        '',
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(11),
        ],
      ],
      email: ['', [Validators.required, Validators.email]],
      confirmarEmail: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]],
      senhaConfirmacao: ['', [Validators.required]],
      tipoCliente: [0],
      termos: [false, [Validators.required, Validators.requiredTrue]]
    });
  }
  botaoEnviar() {
    let formulario = this.cadastroForm.getRawValue();
    let usuario = new UsuarioCadastroRequest(formulario);
    let cliente = new ClienteInserirRequest(formulario);
    usuario.cliente = cliente;
    console.log(formulario);



    this.usuariosService.adicionar(usuario).subscribe({
      next: (res: UsuarioCadastroResponse) => {
        if (res.sucesso)
        {
        this.router.navigate(['/home']);
        this.alertsService.adicionarAlerta(
          "Sucesso",
          "Cadastro realizado com sucesso",
          AlertTypes.SUCESSO
        )}
        else {
          this.alertsService.adicionarAlerta(
            "Aviso",
            res.erro,
            AlertTypes.AVISO
          )
        }
      },
      error: (erro: HttpErrorResponse) => {
        if (erro.status == 400) {
          this.sweetAletService.aviso(erro.error.errors.SenhaConfirmacao[0],"Aviso");
        }
        else {
          this.sweetAletService.excecao(erro.error);
        }
      }
    });
  }

}
