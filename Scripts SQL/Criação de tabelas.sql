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

CREATE TABLE IF NOT EXISTS quasarecommerce.endereco (
  id_endereco INT NOT NULL AUTO_INCREMENT,
  numero_endereco INT NOT NULL,
  bairro_endereco VARCHAR(100) NOT NULL,
  rua_endereco VARCHAR(100) NOT NULL,
  ponto_referencia_endereco VARCHAR(100) NULL,
  complemento_endereco VARCHAR(100) NULL,
  cep_endereco VARCHAR(100) NOT NULL,
  cidade_idcidade INT NOT NULL,
  usuario_id_usuario INT NOT NULL,
  PRIMARY KEY (id_endereco),
  FOREIGN KEY (cidade_idcidade)
  REFERENCES quasarecommerce.cidade (id_cidade),
  FOREIGN KEY (usuario_id_usuario)
  REFERENCES quasarecommerce.usuario (id_usuario)
   );
   
   CREATE TABLE IF NOT EXISTS quasarecommerce.venda (
  id_venda INT NOT NULL AUTO_INCREMENT,
  id_status_venda INT NOT NULL,
  id_forma_pagamento INT NOT NULL,
  id_endereco INT NOT NULL,
  id_usuario INT NOT NULL,
  PRIMARY KEY (id_venda),
  FOREIGN KEY (id_status_venda)
  REFERENCES quasarecommerce.status_venda (id_status_venda),
  FOREIGN KEY (id_forma_pagamento)
  REFERENCES quasarecommerce.forma_pagamento (id_forma_pagamento),
  FOREIGN KEY (id_endereco)
  REFERENCES quasarecommerce.endereco (id_endereco),
  FOREIGN KEY (id_usuario)
  REFERENCES quasarecommerce.usuario (id_usuario)
);

   CREATE TABLE IF NOT EXISTS quasarecommerce.categoria (
  id_categoria INT NOT NULL AUTO_INCREMENT,
  nome_categoria VARCHAR(100) NOT NULL,
  img_categoria BLOB NOT NULL,
  PRIMARY KEY (id_categoria)
  );
  
  
