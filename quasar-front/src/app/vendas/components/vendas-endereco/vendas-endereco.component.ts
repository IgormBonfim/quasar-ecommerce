import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { CidadeListarRequests } from 'src/app/shared/models/requests/cidadeListar.request';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { CidadesResponse } from 'src/app/shared/models/responses/cidades.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { UfResponse } from 'src/app/shared/models/responses/uf.response';
import { CidadesService } from 'src/app/shared/services/cidades.service';
import { UfsService } from 'src/app/shared/services/ufs.service';

@Component({
  selector: 'app-vendas-endereco',
  templateUrl: './vendas-endereco.component.html',
  styleUrls: ['./vendas-endereco.component.css']
})
export class VendasEnderecoComponent implements OnInit {

  formulario! : FormGroup;

  public houseIcon = faHouse;
  public estados!: UfResponse[];
  public estado!: number;
  public cidades!: CidadesResponse[];
  public request = new PaginacaoRequest({
    quantidade: 27
  });



  constructor(
    private ufService: UfsService,
    private cidadesService: CidadesService,
    private formBuilder : FormBuilder,
    private router : Router
    ) { }

  ngOnInit(): void {

    this.formulario = this.formBuilder.group({
      rua: ['', [Validators.required]],
      cep: ['', [Validators.required]],
      numero: ['', [Validators.required]],
      complemento: ['', [Validators.required]],
      pontoReferencia: ['', [Validators.required]],
      bairro: ['', [Validators.required]],
      codigoCidade: [0, [Validators.required]]
    })

    this.ufService.listarUf(this.request).subscribe({
      next: (res: UfResponse[]) => {
        this.estados = res;
      }
    })

    this.listarCidades();
  }

  listarCidades() {
    let params = new CidadeListarRequests({
      quantidade: 999
    });

    this.cidadesService.listarCidades(params).subscribe({
      next: (res: PaginacaoResponse<CidadesResponse>) => {
        this.cidades = res.lista;
        console.log(res);
      }
    })
  }

  teste() {
    console.log(this.formulario);
  }
}
