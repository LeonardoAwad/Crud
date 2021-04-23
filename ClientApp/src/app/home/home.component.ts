import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../services/ProdutoService';
import { Produto } from '../models/Produto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  arrayProduto: Produto[] = [];
  novoProduto: Produto = new Produto();
  produto: Produto;
  alterar: boolean = false;

  constructor(private produtoService: ProdutoService) { }

  ngOnInit() {
    this.ListaProdutos();
    this.alterar = false;
  }

  ListaProdutos() {
    this.produtoService.ListaProduto().subscribe(
      dado_json => {
        this.arrayProduto = dado_json;
      },
      error => {
        alert("Erro: " + error.error.toString());
      }
    )
  }

  Alterar(produto: Produto) {
    this.alterar = true
    this.produto = new Produto();
    this.produto = produto;
  }

  Voltar() {
    this.alterar = false;
  }

  InserirProduto() {
    if (this.novoProduto.nome == null || this.novoProduto.nome == "") {
      return alert("Digite o nome do produto");
    }
    if (this.novoProduto.preco < 0 || this.novoProduto.preco == null) {
      return alert("Digite um valor maior que 0");
    }


    this.produtoService.InsereProduto(this.novoProduto).subscribe(
      dado_json => {
        alert("Produto inserido com sucesso");
        this.ListaProdutos();
      },
      error => {
        alert("Erro: " + error.error.toString());
      }
    )
  }

  AlterarProduto(produto: Produto) {
    if (produto.nome == null || produto.nome == "") {
      return alert("Digite o nome do produto");
    }
    if (produto.preco < 0 || produto.preco == null) {
      return alert("Digite um valor maior que 0");
    }

    this.produtoService.AlteraProduto(produto).subscribe(
      dado_json => {
        alert("Produto alterado com sucesso");
        this.alterar = false;
        this.ListaProdutos();
      },
      error => {
        alert("Erro: " + error.error.toString());
      }
    )
  }

  ExcluirProduto(produto: Produto) {
    this.produtoService.ExcluirProduto(produto).subscribe(
      dado_json => {
        this.ListaProdutos();
      },
      error => {
        alert("Erro: " + error.error.toString());
      }
    )
  }


}
