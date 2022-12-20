import { Component, OnInit } from '@angular/core';
import { faCartShopping } from '@fortawesome/free-solid-svg-icons';
import { faHeart } from '@fortawesome/free-regular-svg-icons';

@Component({
  selector: 'app-produto-card',
  templateUrl: './produto-card.component.html',
  styleUrls: ['./produto-card.component.css']
})
export class ProdutoCardComponent implements OnInit {
  public iconeCoracaoCheio = faHeart;
  public iconeCarrinho = faCartShopping;
  public favorito = false;
  constructor() { }

  ngOnInit(): void {
  }

  favoritar() {
    this.favorito = !this.favorito;
  }

}
