import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-input-quantidade',
  templateUrl: './input-quantidade.component.html',
  styleUrls: ['./input-quantidade.component.css']
})
export class InputQuantidadeComponent implements OnInit {
  iconeMenos = faMinus;
  iconeMais = faPlus;

  @Output()
  quantidade = new EventEmitter<number>();

  @Input()
  quantidadeBotao: number = 1;

  constructor() { }

  ngOnInit(): void {
  }

  decrementar() {
    if(this.quantidadeBotao > 1 ) {
      this.quantidadeBotao--;
      this.emitir()
    }
  }

  incrementar() {
    this.quantidadeBotao++;
    this.emitir()
  }

  emitir() {
    this.quantidade.emit(this.quantidadeBotao)
  }

}
