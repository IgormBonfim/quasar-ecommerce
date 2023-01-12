import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
import { UsuarioResponse } from 'src/app/shared/models/responses/usuario.response';
import { AuthService } from 'src/app/shared/services/auth.service';
import { UsuariosService } from 'src/app/shared/services/usuarios.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  iconeUsuario = faUserCircle;
  public usuario!: UsuarioResponse;
  public administrador: boolean = false;

  constructor(
    private usuarioService: UsuariosService,
    private authService: AuthService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.recuperarDados();
  }

  private recuperarDados() {
    let codigoUsuario: string = this.authService.recuperarCodigo();

    this.usuarioService.recuperar(codigoUsuario).subscribe({
      next: (res: UsuarioResponse) => {
        this.usuario = res;
        this.administrador = res.cliente.nome == "Quasar E-commerce"
      }
    })
  }

  public botaoLogout() {
    this.authService.logout();
    this.router.navigate(['/home']);
  }
}
