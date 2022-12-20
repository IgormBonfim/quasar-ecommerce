import { ProdutoResponse } from './../../../shared/models/responses/produto.response';
import { Component, OnInit } from '@angular/core';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public faCoffee = faCoffee;
  public produto = new ProdutoResponse();

  constructor() { }

  ngOnInit(): void {
  }

}
