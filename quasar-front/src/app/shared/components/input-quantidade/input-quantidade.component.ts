import { Component, OnInit } from '@angular/core';
import { faMinus, faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-input-quantidade',
  templateUrl: './input-quantidade.component.html',
  styleUrls: ['./input-quantidade.component.css']
})
export class InputQuantidadeComponent implements OnInit {
  iconeMenos = faMinus;
  iconeMais = faPlus;

  constructor() { }

  ngOnInit(): void {
  }

}
