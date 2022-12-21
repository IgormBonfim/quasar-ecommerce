import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { faSlidersH } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-produtos-listagem',
  templateUrl: './produtos-listagem.component.html',
  styleUrls: ['./produtos-listagem.component.css'],
})
export class ProdutosListagemComponent implements OnInit {
  public filtro = faSlidersH;

  constructor() {}

  ngOnInit(): void {}
}
