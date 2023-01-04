import { Component, OnInit } from '@angular/core';
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { UfResponse } from 'src/app/shared/models/responses/uf.response';
import { UfsService } from 'src/app/shared/services/ufs.service';

@Component({
  selector: 'app-vendas-endereco',
  templateUrl: './vendas-endereco.component.html',
  styleUrls: ['./vendas-endereco.component.css']
})
export class VendasEnderecoComponent implements OnInit {

  public houseIcon = faHouse;
  public estados!: UfResponse[];
  public request = new PaginacaoRequest({
    quantidade: 27
  });



  constructor(private ufService: UfsService) { }

  ngOnInit(): void {

    this.ufService.listarUf(this.request).subscribe({
      next: (res: UfResponse[]) => {
        this.estados = res;
      }
    })
  }

}
