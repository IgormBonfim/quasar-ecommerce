CREATE SCHEMA IF NOT EXISTS quasarecommerce;
USE quasarecommerce;

CREATE TABLE IF NOT EXISTS quasarecommerce.status_venda (
  id_status_venda INT NOT NULL AUTO_INCREMENT,
  descricao_status_venda VARCHAR(50) NOT NULL,
  PRIMARY KEY (id_status_venda)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.forma_pagamento (
  id_forma_pagamento INT NOT NULL,
  descricao_forma_pagamento VARCHAR(50) NOT NULL,
  PRIMARY KEY (id_forma_pagamento)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.UF (
  id_uf INT NULL AUTO_INCREMENT,
  sigla_uf VARCHAR(2) NOT NULL,
  desc_uf VARCHAR(100) NOT NULL,
  PRIMARY KEY (id_uf)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.cidade (
  id_cidade INT NOT NULL AUTO_INCREMENT,
  nome_cidade VARCHAR(100) NOT NULL,
  id_uf INT NOT NULL,
  PRIMARY KEY (id_cidade),
  FOREIGN KEY (id_uf) REFERENCES quasarecommerce.uf (id_uf)
);

CREATE TABLE IF NOT EXISTS quasarecommerce.tipo_usuario (
  id_tipo_usuario INT NOT NULL AUTO_INCREMENT,
  nome_tipo_usuario VARCHAR(20) NULL,
  PRIMARY KEY (id_tipo_usuario)
);