import { PaginacaoRequest } from './../../../shared/models/requests/paginacao.request';
import { FornecedoresService } from './../../../shared/services/fornecedores.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoriaResponse } from 'src/app/shared/models/responses/categoria.response';
import { FornecedorResponse } from 'src/app/shared/models/responses/fornecedor.response';

import { EspecificacaoInserirRequest } from '../../models/requests/especificacaoInserir.request';
import { ProdutoInserirRequest } from './../../models/requests/produtoInserir.request';
import { ProdutosService } from './../../services/produtos.service';
import { PaginacaoResponse } from 'src/app/shared/models/responses/paginacao.response';
import { CategoriasService } from 'src/app/shared/services/categorias.service';

@Component({
  selector: 'app-produtos-adicionar',
  templateUrl: './produtos-adicionar.component.html',
  styleUrls: ['./produtos-adicionar.component.css']
})
export class ProdutosAdicionarComponent implements OnInit {

  produtoForm!: FormGroup;
  categorias!: CategoriaResponse[];
  fornecedores!: FornecedorResponse[];

  constructor(
    private formBuilder: FormBuilder,
    private produtosService: ProdutosService,
    private fornecedoresService: FornecedoresService,
    private categoriasService: CategoriasService
    ) { }

  ngOnInit(): void {
    this.listarFornecedores();
    this.listarCategorias();
    this.produtoForm = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(100)]],
      descricao: ['', [Validators.required, Validators.minLength(20), Validators.maxLength(255)]],
      imagem: ['', [Validators.required]],
      quantidadeEstoque: [0],
      posicao: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      cor: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      ano: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      veiculo: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(45)]],
      valor: [0, [Validators.required]],
      codigoCategoria: [0, [Validators.required]],
      codigoFornecedor: [0, [Validators.required]],
    })
  }

  listarFornecedores() {
    let params = new PaginacaoRequest({
      quantidade: 999
    })

    this.fornecedoresService.listarFornecedores(params).subscribe({
      next: (res: PaginacaoResponse<FornecedorResponse>) => {
        this.fornecedores = res.lista;
      }
    })
  }

  listarCategorias() {
    let params = new PaginacaoRequest({
      quantidade: 999
    })

    this.categoriasService.listarCategorias(params).subscribe({
      next: (res: PaginacaoResponse<CategoriaResponse>) => {
        this.categorias = res.lista;
      }
    })
  }

  botaoEnviar() {
    let formulario = this.produtoForm.getRawValue();

    let especificacao = new EspecificacaoInserirRequest(formulario);

    let produto = new ProdutoInserirRequest(formulario);
    produto.especificacao = especificacao;

    this.produtosService.adicionar(produto).subscribe({
      next: () => {
        // Adicionar alerta
      },
      error: (erro: HttpErrorResponse) => {
        console.log(erro);
      }
    });
  }

}
