import { Component, OnInit } from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-box-carrinho-selecionados',
  templateUrl: './box-carrinho-selecionados.component.html',
  styleUrls: ['./box-carrinho-selecionados.component.css']
})
export class BoxCarrinhoSelecionadosComponent implements OnInit {

  iconeLixo = faTrash
  
  constructor() { }

  ngOnInit(): void {
  }

}
