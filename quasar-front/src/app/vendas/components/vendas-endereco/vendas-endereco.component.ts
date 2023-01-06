import { Component, OnInit } from '@angular/core';
import { EtapasService } from '../../services/etapas.service';

@Component({
  selector: 'app-vendas-endereco',
  templateUrl: './vendas-endereco.component.html',
  styleUrls: ['./vendas-endereco.component.css']
})
export class VendasEnderecoComponent implements OnInit {

  constructor(public etapasService: EtapasService) { }

  ngOnInit(): void {
  }

}
