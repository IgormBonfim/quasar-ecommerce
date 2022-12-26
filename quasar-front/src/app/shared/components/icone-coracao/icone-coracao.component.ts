import { Component, OnInit } from '@angular/core';
import { faHeart } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-icone-coracao',
  templateUrl: './icone-coracao.component.html',
  styleUrls: ['./icone-coracao.component.css']
})
export class IconeCoracaoComponent implements OnInit {
  public icone = faHeart;

  constructor() { }

  ngOnInit(): void {
  }

}
