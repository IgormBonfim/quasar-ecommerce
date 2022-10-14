CREATE SCHEMA IF NOT EXISTS quasarecommerce;
USE quasarecommerce;

CREATE TABLE IF NOT EXISTS quasarecommerce.statusVenda (
  codStatusVenda INT NOT NULL AUTO_INCREMENT,
  descricao VARCHAR(50) NOT NULL,
  PRIMARY KEY (codStatusVenda)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.formaPagamento (
  codFormaPagamento INT NOT NULL,
  descricao VARCHAR(50) NOT NULL,
  PRIMARY KEY (codFormaPagamento)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.UF (
  codUf INT NOT NULL AUTO_INCREMENT,
  sigla VARCHAR(2) NOT NULL,
  nome VARCHAR(100) NOT NULL,
  PRIMARY KEY (codUf)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.cidade (
  codCidade INT NOT NULL AUTO_INCREMENT,
  nome VARCHAR(100) NOT NULL,
  codUf INT NOT NULL,
  PRIMARY KEY (codCidade),
  FOREIGN KEY (codUf) REFERENCES quasarecommerce.uf (codUf)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.usuario (
  id INT NOT NULL AUTO_INCREMENT,
  email VARCHAR(100) NOT NULL UNIQUE,
  senha VARCHAR(100) NOT NULL,
  nome VARCHAR(100) NOT NULL,
  telefone VARCHAR(11) NULL,
  cpf VARCHAR(11) NULL,
  dataNascimento DATE NULL,
  cnpj VARCHAR(14) NULL,
  razaoSocial VARCHAR(100) NULL,
  ie VARCHAR(14) NULL,
  PRIMARY KEY (id)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.endereco (
  codEndereco INT NOT NULL AUTO_INCREMENT,
  numero INT NOT NULL,
  bairro VARCHAR(100) NOT NULL,
  rua VARCHAR(100) NOT NULL,
  pontoReferencia VARCHAR(100) NULL,
  complemento VARCHAR(100) NULL,
  cep VARCHAR(8) NOT NULL,
  codCidade INT NOT NULL,
  codUsuario INT NOT NULL,
  PRIMARY KEY (codEndereco),
  FOREIGN KEY (codCidade) REFERENCES quasarecommerce.cidade (codCidade),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.usuario (id)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.venda (
  codVenda INT NOT NULL AUTO_INCREMENT,
  codStatusVenda INT NOT NULL,
  codFormaPagamento INT NOT NULL,
  codEndereco INT NOT NULL,
  codUsuario INT NOT NULL,
  PRIMARY KEY (codVenda),
  FOREIGN KEY (codStatusVenda) REFERENCES quasarecommerce.statusVenda (codStatusVenda),
  FOREIGN KEY (codFormaPagamento) REFERENCES quasarecommerce.formaPagamento (codFormaPagamento),
  FOREIGN KEY (codEndereco) REFERENCES quasarecommerce.endereco (codEndereco),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.usuario (id)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.categoria (
  codCategoria INT NOT NULL AUTO_INCREMENT,
  nome VARCHAR(100) NOT NULL,
  imagem VARCHAR(255) NOT NULL,
  PRIMARY KEY (codCategoria)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.fornecedor (
  codFornecedor INT NOT NULL AUTO_INCREMENT,
  nome VARCHAR(100) NOT NULL,
  razaoSocial VARCHAR(100) NOT NULL,
  cnpj VARCHAR(14) NOT NULL,
  ie VARCHAR(14) NULL,
  PRIMARY KEY (codFornecedor)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.produto (
  codProduto INT NOT NULL AUTO_INCREMENT,
  descricao VARCHAR(255) NOT NULL,
  nome VARCHAR(100) NOT NULL,
  codCategoria INT NOT NULL,
  codFornecedor INT NOT NULL,
  codEspecificacao INT NOT NULL,
  imagem VARCHAR(255) NOT NULL,
  PRIMARY KEY (codProduto),
  FOREIGN KEY (codEspecicacao) REFERENCES quasarecommerce.especificacao(codEspecificacao),
  FOREIGN KEY (codCategoria) REFERENCES quasarecommerce.categoria (codCategoria),
  FOREIGN KEY (codFornecedor) REFERENCES quasarecommerce.fornecedor (codFornecedor)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.itemVenda (
  codItemVenda INT NOT NULL AUTO_INCREMENT,
  codVenda INT NOT NULL,
  codProduto INT NOT NULL,
  quantidade INT NOT NULL,
  PRIMARY KEY (codItemVenda),
  FOREIGN KEY (codVenda) REFERENCES quasarecommerce.venda (codVenda),
  FOREIGN KEY (codProduto) REFERENCES quasarecommerce.produto (codProduto)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.estoque (
  codEstoque INT NOT NULL auto_increment,
  quantidade INT NOT NULL,
  codProduto INT NOT NULL,
  PRIMARY KEY (codEstoque),
  FOREIGN KEY (codProduto) REFERENCES quasarecommerce.produto (codProduto)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.favorito (
  codFavorito INT NOT NULL AUTO_INCREMENT,
  codProduto INT NOT NULL,
  codUsuario INT NOT NULL,
  PRIMARY KEY (codFavorito),
  FOREIGN KEY (codProduto) REFERENCES quasarecommerce.produto (codProduto),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.usuario (id)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.carrinho (
  codCarrinho INT NOT NULL AUTO_INCREMENT,
  codUsuario INT NOT NULL,
  codProduto INT NOT NULL,
  PRIMARY KEY (codCarrinho),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.usuario (id),
  FOREIGN KEY (codProduto) REFERENCES quasarecommerce.produto (codProduto)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.especificacao (
  codEspecificacao INT NOT NULL AUTO_INCREMENT,
  posicao VARCHAR(50) NOT NULL,
  cor VARCHAR(20) NOT NULL,
  ano DATE NOT NULL,
  veiculo VARCHAR(45) NOT NULL,
  PRIMARY KEY (codEspecificacao)
);