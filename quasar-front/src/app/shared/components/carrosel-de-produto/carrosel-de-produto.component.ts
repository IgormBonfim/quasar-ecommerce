import { Component, Input, OnInit } from '@angular/core';

import { ProdutoBuscarRequest } from './../../models/requests/produtoBuscar.request';
import { ProdutoResponse } from './../../models/responses/produto.response';

@Component({
  selector: 'app-carrosel-de-produto',
  templateUrl: './carrosel-de-produto.component.html',
  styleUrls: ['./carrosel-de-produto.component.css']
})
export class CarroselDeProdutoComponent implements OnInit {

  request = new ProdutoBuscarRequest({
    quantidade: 10
  });

  @Input()
  produtos!: ProdutoResponse[];

  responsiveOptions = [

    {
        breakpoint: '1024px',
        numVisible: 3,
        numScroll: 3
    },
    {
        breakpoint: '768px',
        numVisible: 2,
        numScroll: 2
    },
    {
        breakpoint: '560px',
        numVisible: 1,
        numScroll: 1
    }
];

  constructor() { }

  ngOnInit(): void {
  }

}
