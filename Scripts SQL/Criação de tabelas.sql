CREATE SCHEMA IF NOT EXISTS quasarecommerce;
USE quasarecommerce;

CREATE TABLE IF NOT EXISTS quasarecommerce.statusVenda (
  idStatusVenda INT NOT NULL AUTO_INCREMENT,
  descricaoStatusVenda VARCHAR(50) NOT NULL,
  PRIMARY KEY (idStatusVenda)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.formaPagamento (
  idFormaPagamento INT NOT NULL,
  descricaoFormaPagamento VARCHAR(50) NOT NULL,
  PRIMARY KEY (idFormaPagamento)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.UF (
  idUf INT NULL AUTO_INCREMENT,
  siglaUf VARCHAR(2) NOT NULL,
  descUf VARCHAR(100) NOT NULL,
  PRIMARY KEY (idUf)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.cidade (
  idCidade INT NOT NULL AUTO_INCREMENT,
  nomeCidade VARCHAR(100) NOT NULL,
  idUf INT NOT NULL,
  PRIMARY KEY (idCidade),
  FOREIGN KEY (idUf) REFERENCES quasarecommerce.uf (idUf)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.tipoUsuario (
  idTipoUsuario INT NOT NULL AUTO_INCREMENT,
  nomeTipoUsuario VARCHAR(20) NULL,
  PRIMARY KEY (idTipoUsuario)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.usuario (
idUsuario INT NOT NULL AUTO_INCREMENT,
emailUsuario VARCHAR(100) NOT NULL UNIQUE,
senhaUsuario VARCHAR(100) NOT NULL,
nomeUsuario VARCHAR(100) NOT NULL,
idTipoUsuario INT NOT NULL,
telefoneUsuario VARCHAR(11) NULL,
cpfUsuario VARCHAR(11) NULL,
cnpjUsuario VARCHAR(14) NULL,
razaoSocialUsuario VARCHAR(100) NULL,
ieUsuario VARCHAR(14) NULL,
PRIMARY KEY (idUsuario),
FOREIGN KEY (idTipoUsuario)
REFERENCES quasarecommerce.tipoUsuario (idTipoUsuario)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.endereco (
  idEndereco INT NOT NULL AUTO_INCREMENT,
  numeroEndereco INT NOT NULL,
  bairroEndereco VARCHAR(100) NOT NULL,
  ruaEndereco VARCHAR(100) NOT NULL,
  pontoReferenciaEndereco VARCHAR(100) NULL,
  complementoEndereco VARCHAR(100) NULL,
  cepEndereco VARCHAR(8) NOT NULL,
  idCidade INT NOT NULL,
  idUsuario INT NOT NULL,
  PRIMARY KEY (idEndereco),
  FOREIGN KEY (idCidade)
  REFERENCES quasarecommerce.cidade (idCidade),
  FOREIGN KEY (idUsuario)
  REFERENCES quasarecommerce.usuario (idUsuario)
   );
   
   CREATE TABLE IF NOT EXISTS quasarecommerce.venda (
  idVenda INT NOT NULL AUTO_INCREMENT,
  idStatusVenda INT NOT NULL,
  idFormaPagamento INT NOT NULL,
  idEndereco INT NOT NULL,
  idUsuario INT NOT NULL,
  PRIMARY KEY (idVenda),
  FOREIGN KEY (idStatusVenda)
  REFERENCES quasarecommerce.statusVenda (idStatusVenda),
  FOREIGN KEY (idFormaPagamento)
  REFERENCES quasarecommerce.formaPagamento (idFormaPagamento),
  FOREIGN KEY (idEndereco)
  REFERENCES quasarecommerce.endereco (idEndereco),
  FOREIGN KEY (idUsuario)
  REFERENCES quasarecommerce.usuario (idUsuario)
);

   CREATE TABLE IF NOT EXISTS quasarecommerce.categoria (
  idCategoria INT NOT NULL AUTO_INCREMENT,
  nomeCategoria VARCHAR(100) NOT NULL,
  imgCategoria BLOB NOT NULL,
  PRIMARY KEY (idCategoria)
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.fornecedor (
  idFornecedor INT NOT NULL AUTO_INCREMENT,
  nomeFornecedor VARCHAR(100) NULL,
  razaoSocialFornecedor VARCHAR(100) NULL,
  cnpjFornecedor VARCHAR(14) NULL,
  ieFornecedor VARCHAR(14) NULL,
  PRIMARY KEY (idFornecedor)
  );

CREATE TABLE IF NOT EXISTS quasarecommerce.produto (
  idProduto INT NOT NULL AUTO_INCREMENT,
  descricaoProduto VARCHAR(255) NOT NULL,
  nomeProduto VARCHAR(100) NOT NULL,
  idCategoria INT NOT NULL,
  idFornecedor INT NOT NULL,
  imgPrincipalProduto BLOB NOT NULL,
  imgSegundaProduto BLOB NULL,
  imgTerceiraProduto BLOB NULL,
  PRIMARY KEY (idProduto),
  FOREIGN KEY (idCategoria)
  REFERENCES quasarecommerce.categoria (idCategoria),
  FOREIGN KEY (idFornecedor)
  REFERENCES quasarecommerce.fornecedor (idFornecedor)
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.itemVenda (
  idItemVenda INT NOT NULL AUTO_INCREMENT,
  idVenda INT NOT NULL,
  idProduto INT NOT NULL,
  quantidadeItemVenda INT NOT NULL,
  PRIMARY KEY (idItemVenda),
  FOREIGN KEY (idVenda)
  REFERENCES quasarecommerce.venda (idVenda),
  FOREIGN KEY (idProduto)
  REFERENCES quasarecommerce.produto (idProduto)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.estoque (
  idEstoque INT NOT NULL auto_increment,
  qtdEstoque INT NOT NULL,
  idProduto INT NOT NULL,
  PRIMARY KEY (idEstoque),
  FOREIGN KEY (idProduto)
  REFERENCES quasarecommerce.produto (idProduto)
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.favorito (
  idFavorito INT NOT NULL AUTO_INCREMENT,
  idProduto INT NOT NULL,
  idUsuario INT NOT NULL,
  PRIMARY KEY (idFavorito),
  FOREIGN KEY (idProduto)
  REFERENCES quasarecommerce.produto (idProduto),
  FOREIGN KEY (idUsuario)
  REFERENCES quasarecommerce.usuario (idUsuario)
  );
  
CREATE TABLE IF NOT EXISTS quasarecommerce.carrinho (
  idCarrinho INT NOT NULL AUTO_INCREMENT,
  idUsuario INT NOT NULL,
  idProduto INT NOT NULL,
  PRIMARY KEY (idCarrinho),
  FOREIGN KEY (idUsuario)
  REFERENCES quasarecommerce.usuario (idUsuario),
  FOREIGN KEY (idProduto)
  REFERENCES quasarecommerce.produto (idProduto)  
  );
  
  CREATE TABLE IF NOT EXISTS quasarecommerce.especificacao (
  idEspecificacao INT NOT NULL AUTO_INCREMENT,
  posicaoEspecificacao VARCHAR(50) NOT NULL,
  corEspecificacao VARCHAR(20) NOT NULL,
  anoEspecificacao DATE NOT NULL,
  veiculoEspecificacao VARCHAR(45) NOT NULL,
  idProduto INT NOT NULL,
  PRIMARY KEY (idEspecificacao),
  FOREIGN KEY (idProduto)
  REFERENCES quasarecommerce.produto (idProduto)
  );
  
