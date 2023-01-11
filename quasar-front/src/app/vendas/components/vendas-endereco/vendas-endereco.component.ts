import { EnderecoResponse } from './../../../shared/models/responses/endereco.response';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { faHouse } from '@fortawesome/free-solid-svg-icons';
import { CidadeListarRequests } from 'src/app/shared/models/requests/cidadeListar.request';
import { EnderecoInserirRequest } from 'src/app/shared/models/requests/endereco-inserir.request';
import { PaginacaoRequest } from 'src/app/shared/models/requests/paginacao.request';
import { CidadesResponse } from 'src/app/shared/models/responses/cidades.response';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { UfResponse } from 'src/app/shared/models/responses/uf.response';
import { CidadesService } from 'src/app/shared/services/cidades.service';
import { EnderecosService } from 'src/app/shared/services/enderecos.service';
import { UfsService } from 'src/app/shared/services/ufs.service';
import { EtapasService } from '../../services/etapas.service';
import { HttpErrorResponse } from '@angular/common/http';
import { SweetAlertService } from 'src/app/shared/services/sweet-alert.service';

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
    private enderecoService: EnderecosService,
    private sweetAlertService: SweetAlertService,
    private etapasService: EtapasService,
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
      }
    })
  }

  botaoContinuar() {
    let formulario = this.formulario.getRawValue()
    let endereco = new EnderecoInserirRequest(formulario);

    this.enderecoService.adicionar(endereco).subscribe({
      next: (res: EnderecoResponse) => {
        localStorage.setItem("codigoEndereco", res.codigo.toString());
        this.sweetAlertService.sucesso("Endereço cadastrado com sucesso!")
        this.etapasService.irParaPagamento();
      },
      error: (erro: HttpErrorResponse) => {
        this.sweetAlertService.excecao(erro.error)
      }
    })
  }
}
