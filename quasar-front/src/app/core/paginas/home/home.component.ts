import { CategoriaResponse } from './../../../shared/models/responses/categoria.response';
import { CategoriasService } from './../../../shared/services/categorias.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public categorias!: any;

  constructor(private categoriasService: CategoriasService) { }

  ngOnInit(): void {
    this.categoriasService.listarCategorias().subscribe(
      (res: CategoriaResponse[]) => {
        this.categorias = res;
        console.log(this.categorias);
      }
    )
  }

}
