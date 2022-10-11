CREATE SCHEMA IF NOT EXISTS quasarecommerce;
USE quasarecommerce;

CREATE TABLE IF NOT EXISTS quasarecommerce.statusVenda (
  codStatusVenda INT NOT NULL AUTO_INCREMENT,
  descricaoStatusVenda VARCHAR(50) NOT NULL,
  PRIMARY KEY (codStatusVenda)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.formaPagamento (
  codFormaPagamento INT NOT NULL,
  descricaoFormaPagamento VARCHAR(50) NOT NULL,
  PRIMARY KEY (codFormaPagamento)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.UF (
  codUf INT NULL AUTO_INCREMENT,
  siglaUf VARCHAR(2) NOT NULL,
  descUf VARCHAR(100) NOT NULL,
  PRIMARY KEY (codUf)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.cidade (
  codCidade INT NOT NULL AUTO_INCREMENT,
  nomeCidade VARCHAR(100) NOT NULL,
  idUf INT NOT NULL,
  PRIMARY KEY (codCidade),
  FOREIGN KEY (codUf) REFERENCES quasarecommerce.uf (idUf)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.tipoUsuario (
  codTipoUsuario INT NOT NULL AUTO_INCREMENT,
  nomeTipoUsuario VARCHAR(20) NULL,
  PRIMARY KEY (codTipoUsuario)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.usuario (
id INT NOT NULL AUTO_INCREMENT,
emailUsuario VARCHAR(100) NOT NULL UNIQUE,
senhaUsuario VARCHAR(100) NOT NULL,
nomeUsuario VARCHAR(100) NOT NULL,
codTipoUsuario INT NOT NULL,
telefoneUsuario VARCHAR(11) NULL,
cpfUsuario VARCHAR(11) NULL,
dataNascimentoUsuario DATE NULL,
cnpjUsuario VARCHAR(14) NULL,
razaoSocialUsuario VARCHAR(100) NULL,
ieUsuario VARCHAR(14) NULL,
PRIMARY KEY (codUsuario),
FOREIGN KEY (codTipoUsuario)
REFERENCES quasarecommerce.tipoUsuario (codTipoUsuario)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.endereco (
  codEndereco INT NOT NULL AUTO_INCREMENT,
  numeroEndereco INT NOT NULL,
  bairroEndereco VARCHAR(100) NOT NULL,
  ruaEndereco VARCHAR(100) NOT NULL,
  pontoReferenciaEndereco VARCHAR(100) NULL,
  complementoEndereco VARCHAR(100) NULL,
  cepEndereco VARCHAR(8) NOT NULL,
  codCidade INT NOT NULL,
  codUsuario INT NOT NULL,
  PRIMARY KEY (codEndereco),
  FOREIGN KEY (codCidade)
  REFERENCES quasarecommerce.cidade (codCidade),
  FOREIGN KEY (codUsuario)
  REFERENCES quasarecommerce.usuario (codUsuario)
   );
   
   CREATE TABLE IF NOT EXISTS quasarecommerce.venda (
  codVenda INT NOT NULL AUTO_INCREMENT,
  codStatusVenda INT NOT NULL,
  codFormaPagamento INT NOT NULL,
  codEndereco INT NOT NULL,
  codUsuario INT NOT NULL,
  PRIMARY KEY (codVenda),
  FOREIGN KEY (codStatusVenda)
  REFERENCES quasarecommerce.statusVenda (codStatusVenda),
  FOREIGN KEY (codFormaPagamento)
  REFERENCES quasarecommerce.formaPagamento (codFormaPagamento),
  FOREIGN KEY (codEndereco)
  REFERENCES quasarecommerce.endereco (codEndereco),
  FOREIGN KEY (codUsuario)
  REFERENCES quasarecommerce.usuario (codUsuario)
);

   CREATE TABLE IF NOT EXISTS quasarecommerce.categoria (
  codCategoria INT NOT NULL AUTO_INCREMENT,
  nomeCategoria VARCHAR(100) NOT NULL,
  imgCategoria VARCHAR(255) NOT NULL,
  PRIMARY KEY (codCategoria)
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.fornecedor (
  codFornecedor INT NOT NULL AUTO_INCREMENT,
  nomeFornecedor VARCHAR(100) NOT NULL,
  razaoSocialFornecedor VARCHAR(100) NOT NULL,
  cnpjFornecedor VARCHAR(14) NOT NULL,
  ieFornecedor VARCHAR(14) NULL,
  PRIMARY KEY (codFornecedor)
  );

CREATE TABLE IF NOT EXISTS quasarecommerce.produto (
  codProduto INT NOT NULL AUTO_INCREMENT,
  descricaoProduto VARCHAR(255) NOT NULL,
  nomeProduto VARCHAR(100) NOT NULL,
  codCategoria INT NOT NULL,
  codFornecedor INT NOT NULL,
  imgProduto VARCHAR(255) NOT NULL,
  PRIMARY KEY (codProduto),
  FOREIGN KEY (codCategoria)
  REFERENCES quasarecommerce.categoria (codCategoria),
  FOREIGN KEY (codFornecedor)
  REFERENCES quasarecommerce.fornecedor (codFornecedor)
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.itemVenda (
  codItemVenda INT NOT NULL AUTO_INCREMENT,
  codVenda INT NOT NULL,
  codProduto INT NOT NULL,
  quantcodadeItemVenda INT NOT NULL,
  PRIMARY KEY (codItemVenda),
  FOREIGN KEY (codVenda)
  REFERENCES quasarecommerce.venda (codVenda),
  FOREIGN KEY (codProduto)
  REFERENCES quasarecommerce.produto (codProduto)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.estoque (
  codEstoque INT NOT NULL auto_increment,
  qtdEstoque INT NOT NULL,
  codProduto INT NOT NULL,
  PRIMARY KEY (codEstoque),
  FOREIGN KEY (codProduto)
  REFERENCES quasarecommerce.produto (codProduto)
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.favorito (
  codFavorito INT NOT NULL AUTO_INCREMENT,
  codProduto INT NOT NULL,
  codUsuario INT NOT NULL,
  PRIMARY KEY (codFavorito),
  FOREIGN KEY (codProduto)
  REFERENCES quasarecommerce.produto (codProduto),
  FOREIGN KEY (codUsuario)
  REFERENCES quasarecommerce.usuario (codUsuario)
  );
  
CREATE TABLE IF NOT EXISTS quasarecommerce.carrinho (
  codCarrinho INT NOT NULL AUTO_INCREMENT,
  codUsuario INT NOT NULL,
  codProduto INT NOT NULL,
  PRIMARY KEY (codCarrinho),
  FOREIGN KEY (codUsuario)
  REFERENCES quasarecommerce.usuario (codUsuario),
  FOREIGN KEY (codProduto)
  REFERENCES quasarecommerce.produto (codProduto)  
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.especificacao (
  codEspecificacao INT NOT NULL AUTO_INCREMENT,
  posicaoEspecificacao VARCHAR(50) NOT NULL,
  corEspecificacao VARCHAR(20) NOT NULL,
  anoEspecificacao DATE NOT NULL,
  veiculoEspecificacao VARCHAR(45) NOT NULL,
  codProduto INT NOT NULL,
  PRIMARY KEY (codEspecificacao),
  FOREIGN KEY (codProduto)
  REFERENCES quasarecommerce.produto (codProduto)
  );
  
