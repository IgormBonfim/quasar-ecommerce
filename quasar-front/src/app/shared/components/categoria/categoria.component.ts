import { Component, Input, OnInit } from '@angular/core';
import { CategoriaResponse } from '../../models/responses/categoria.response';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  @Input()
  public categoria!: CategoriaResponse

  constructor() { }

  ngOnInit(): void {
  }

}
