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

CREATE TABLE IF NOT EXISTS quasarecommerce.usuario (
id_usuario INT NOT NULL AUTO_INCREMENT,
email_usuario VARCHAR(100) NOT NULL UNIQUE,
senha_usuario VARCHAR(100) NOT NULL,
nome_usuario VARCHAR(100) NOT NULL,
id_tipo_usuario INT NOT NULL,
telefone_usuario VARCHAR(11) NULL,
cpf_usuario VARCHAR(11) NULL,
cnpj_usuario VARCHAR(14) NULL,
razao_social_usuario VARCHAR(100) NULL,
ie_usuario VARCHAR(14) NULL,
PRIMARY KEY (id_usuario),
FOREIGN KEY (id_tipo_usuario)
REFERENCES quasarecommerce.tipo_usuario (id_tipo_usuario)
);

  
  
