import { Component, OnInit } from '@angular/core';
import { faHouse } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-vendas-endereco',
  templateUrl: './vendas-endereco.component.html',
  styleUrls: ['./vendas-endereco.component.css']
})
export class VendasEnderecoComponent implements OnInit {

  public houseIcon = faHouse;

  constructor() { }

  ngOnInit(): void {
  }

}
