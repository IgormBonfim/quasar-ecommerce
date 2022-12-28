import { ProdutoInserirRequest } from './../../models/requests/produtoInserir.request';
import { HttpErrorResponse } from '@angular/common/http';
import { ProdutoInserirResponse } from './../../models/responses/produtoInserir.response';
import { ProdutosService } from './../../services/produtos.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EspecificacaoInserirRequest } from '../../models/requests/especificacaoInserir.request';

@Component({
  selector: 'app-produtos-adicionar',
  templateUrl: './produtos-adicionar.component.html',
  styleUrls: ['./produtos-adicionar.component.css']
})
export class ProdutosAdicionarComponent implements OnInit {

  produtoForm!: FormGroup;
  teste = [
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "vidros", value: 1},
    { name: "farois", value: 2}
  ]

  constructor(
    private formBuilder: FormBuilder,
    private produtosService: ProdutosService
    ) { }

  ngOnInit(): void {
    this.produtoForm = this.formBuilder.group({
      nome: ['', [Validators.required]],
      descricao: ['', [Validators.required]],
      imagem: ['', [Validators.required]],
      posicao: ['', [Validators.required]],
      cor: ['', [Validators.required]],
      ano: ['', [Validators.required]],
      modelo: ['', [Validators.required]],
      quantidade: [0, [Validators.required]],
      valor: ['', [Validators.required]],
      categoria: [0, [Validators.required]],
      fornecedor: [0, [Validators.required]],
    })
  }

  botaoEnviar() {
    let formulario = this.produtoForm.getRawValue();
    console.log(formulario);

    let especificacao = new EspecificacaoInserirRequest();

    especificacao.ano = formulario.ano;
    especificacao.cor = formulario.cor;
    especificacao.posicao = formulario.posicao;
    especificacao.veiculo = formulario.modelo;

    let produto = new ProdutoInserirRequest();

    produto.nome = formulario.nome;
    produto.descricao = formulario.descricao;
    produto.imagem = formulario.imagem;
    produto.codigoCategoria = formulario.categoria;
    produto.codigoFornecedor = formulario.fornecedor;
    produto.especificacao = especificacao;

    this.produtosService.adicionar(produto).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (erro: HttpErrorResponse) => {
        console.log(erro);
      }
    });
  }

}
