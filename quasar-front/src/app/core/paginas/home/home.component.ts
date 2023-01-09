import { CategoriaResponse } from './../../../shared/models/responses/categoria.response';
import { CategoriasService } from './../../../shared/services/categorias.service';
import { Component, OnInit } from '@angular/core';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public categorias!: CategoriaResponse[];

  constructor(private categoriasService: CategoriasService) { }

  ngOnInit(): void {
    this.listarCategorias();
  }

  listarCategorias() {
    let request = new PaginacaoRequest({
      quantidade: 5
    });

    this.categoriasService.listarCategorias(request).subscribe(
      (res: PaginacaoResponse<CategoriaResponse>) => {
        this.categorias = res.lista;
        console.log(this.categorias);
      }
    )
  }

}
