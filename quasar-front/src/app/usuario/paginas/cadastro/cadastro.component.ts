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
import { UsuariosService } from 'src/app/shared/services/usuarios.service';
import { UsuarioCadastroRequest } from '../../models/request/usuarioCadastroRequest';
import { UsuarioCadastroResponse } from '../../models/response/usuarioCadastroResponse';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent implements OnInit {
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
      razaoSocail: [
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
      cpf: [
        '',
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(11),
        ],
      ],
      cnpj: [
        '',
        [
          Validators.required,
          Validators.minLength(14),
          Validators.maxLength(14),
        ],
      ],
      ie: [
        0,
        [Validators.required, Validators.minLength(9), Validators.maxLength(9)],
      ],
      email: ['', [Validators.required, Validators.email]],
      confirmarEmail: ['', [Validators.required, EmailValidator]],
      senha: ['', [Validators.required]],
      confirmarSenha: ['', [Validators.required]],
    });
  }
  botaoEnviar() {
    let formulario = this.cadastroForm.getRawValue();
    let usuario = new UsuarioCadastroRequest(formulario);

    this.usuariosService.adicionar(usuario).subscribe({
      next: (res: UsuarioCadastroResponse) => {
        this.router.navigate(['/produtos'])
        this.alertsService.adicionarAlerta(
          "Produto adicionado com sucesso",
          "O produto foi cadastrado com o codigo " + res.codigo,
          AlertTypes.SUCESSO
        )
      },
      error: (erro: HttpErrorResponse) => {
        this.alertsService.adicionarAlerta(
          "Erro ao adicionar produto",
          erro.error,
          AlertTypes.ERROR
        )
      }
    });
  }

}
