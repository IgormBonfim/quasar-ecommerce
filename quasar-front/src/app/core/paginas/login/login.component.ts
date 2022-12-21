import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { UsuarioLoginRequest } from '../../models/requests/usuarioLogin.request';
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
    private loginService: LoginService
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
      next: response => {
        console.log(response);
        
      }
    })
  }

}
