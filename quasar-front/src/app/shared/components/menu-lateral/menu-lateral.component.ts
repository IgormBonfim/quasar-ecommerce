import { Component, Input, OnInit } from '@angular/core';
import { UsuarioResponse } from '../../models/responses/usuario.response';
import { AuthService } from '../../services/auth.service';
import { UsuariosService } from '../../services/usuarios.service';

@Component({
  selector: 'app-menu-lateral',
  templateUrl: './menu-lateral.component.html',
  styleUrls: ['./menu-lateral.component.css']
})
export class MenuLateralComponent implements OnInit {
  @Input()
  public visibilidade = false;
  public administrador: boolean = false;

  constructor(
    private authService: AuthService,
    private usuarioService: UsuariosService
    ) { }

  ngOnInit(): void {
    this.recuperarDados();
  }

  private recuperarDados() {
    let codigoUsuario: string = this.authService.recuperarCodigo();

    if (codigoUsuario != null) {
          this.usuarioService.recuperar(codigoUsuario).subscribe({
            next: (res: UsuarioResponse) => {
              this.administrador = res.cliente.nome == "Quasar E-commerce";
            }
          })
    }
    else {
      this.administrador = false;
    }
  }

}
