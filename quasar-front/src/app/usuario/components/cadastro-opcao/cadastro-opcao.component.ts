import { Component, OnInit } from '@angular/core';
import { faUserCircle } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-cadastro-opcao',
  templateUrl: './cadastro-opcao.component.html',
  styleUrls: ['./cadastro-opcao.component.css']
})
export class CadastroOpcaoComponent implements OnInit {

  public userIcon = faUserCircle;

  public pessoaFisica: boolean = true;
  public pessoaJuridica: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  trocarParaJuridico() {
    this.pessoaFisica = false;
    this.pessoaJuridica = true;
  }

  trocarParaFisica() {
    this.pessoaJuridica = false;
    this.pessoaFisica = true;
  }

}
