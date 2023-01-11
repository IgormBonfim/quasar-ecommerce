import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  EmailValidator,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { AlertsService, AlertTypes } from 'src/app/shared/services/alerts.service';
import { UsuariosService } from 'src/app/shared/services/usuarios.service';
import { ClienteInserirRequest } from '../../models/request/clienteInserirRequest';
import { UsuarioCadastroRequest } from '../../models/request/usuarioCadastroRequest';
import { UsuarioCadastroResponse } from '../../models/response/usuarioCadastroResponse';

@Component({
  selector: 'app-cadastro-juridico',
  templateUrl: './cadastro-juridico.component.html',
  styleUrls: ['./cadastro-juridico.component.css'],
})
export class CadastroJuridicoComponent implements OnInit {
  cadastroForm!: FormGroup;

  public userIcon = faUserCircle;

  constructor(
    private formBuilder: FormBuilder,
    private usuariosService: UsuariosService,
    private router: Router,
    private alertsService: AlertsService,

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
      nomeFantasia: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(256),
        ],
      ],
      razaoSocial: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(256),
        ],
      ],
      telefone: [
        0,
        [
          Validators.required,
          Validators.minLength(11),
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
      inscricaoEstadual: [
        0,
        [Validators.required, Validators.minLength(9), Validators.maxLength(9)],
      ],
      email: ['', [Validators.required, Validators.email]],
      confirmarEmail: ['', [Validators.required]],
      senha: ['', [Validators.required]],
      senhaConfirmacao: ['', [Validators.required]],
      tipoCliente: [1]
    });
  }
  botaoEnviar() {
    let formulario = this.cadastroForm.getRawValue();
    let usuario = new UsuarioCadastroRequest(formulario);
    let cliente = new ClienteInserirRequest(formulario);
    usuario.cliente = cliente;
    console.log(usuario)

    this.usuariosService.adicionar(usuario).subscribe({
      next: (res: UsuarioCadastroResponse) => {
        if (res.sucesso)
        {
        this.router.navigate(['/home'])
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
        this.alertsService.adicionarAlerta(
          "Erro, tente novamente",
          erro.error,
          AlertTypes.ERROR
        )
          console.log(erro)
      }
    });
  }

}
