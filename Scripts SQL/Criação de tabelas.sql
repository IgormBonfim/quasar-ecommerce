DROP SCHEMA IF EXISTS quasarecommerce;

CREATE SCHEMA quasarecommerce;
USE quasarecommerce;

CREATE TABLE IF NOT EXISTS CLIENTE (
	CodCliente INT AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    NomeFantasia VARCHAR(100) NULL,
    CpfCnpj VARCHAR(14) NOT NULL,
    Ie VARCHAR(9) NULL,
    RazaoSocial VARCHAR(256) NULL,
    Tipo INT NOT NULL,
    PRIMARY KEY (CodCliente)
);

CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `CodCliente` int NOT NULL, 
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `LockoutEndUnixTimeSeconds` bigint NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`),
  FOREIGN KEY (`CodCliente`) REFERENCES Cliente(CodCliente)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` longtext DEFAULT NULL,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
CREATE TABLE IF NOT EXISTS quasarecommerce.especificacao (
  codEspecificacao INT NOT NULL AUTO_INCREMENT,
  posicao VARCHAR(50) NOT NULL,
  cor VARCHAR(20) NOT NULL,
  ano VARCHAR(100) NOT NULL,
  veiculo VARCHAR(45) NOT NULL,
  PRIMARY KEY (codEspecificacao)
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
  codUsuario VARCHAR(255) NOT NULL,
  PRIMARY KEY (codEndereco),
  FOREIGN KEY (codCidade) REFERENCES quasarecommerce.cidade (codCidade),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.aspnetusers (id)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.venda (
  codVenda INT NOT NULL AUTO_INCREMENT,
  codStatusVenda INT NOT NULL,
  codFormaPagamento INT NOT NULL,
  codEndereco INT NOT NULL,
  codUsuario VARCHAR(255) NOT NULL,
  PRIMARY KEY (codVenda),
  FOREIGN KEY (codStatusVenda) REFERENCES quasarecommerce.statusVenda (codStatusVenda),
  FOREIGN KEY (codFormaPagamento) REFERENCES quasarecommerce.formaPagamento (codFormaPagamento),
  FOREIGN KEY (codEndereco) REFERENCES quasarecommerce.endereco (codEndereco),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.aspnetusers (id)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.produto (
  codProduto INT NOT NULL AUTO_INCREMENT,
  descricao VARCHAR(255) NOT NULL,
  nome VARCHAR(100) NOT NULL,
  valor DECIMAL(7,2) NOT NULL,
  codCategoria INT NOT NULL,
  codFornecedor INT NOT NULL,
  codEspecificacao INT NOT NULL,
  imagem VARCHAR(255) NOT NULL,
  PRIMARY KEY (codProduto),
  FOREIGN KEY (codEspecificacao) REFERENCES quasarecommerce.especificacao(codEspecificacao),
  FOREIGN KEY (codCategoria) REFERENCES quasarecommerce.categoria (codCategoria),
  FOREIGN KEY (codFornecedor) REFERENCES quasarecommerce.fornecedor (codFornecedor)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.itemVenda (
  codItemVenda INT NOT NULL AUTO_INCREMENT,
  codVenda INT NOT NULL,
  codProduto INT NOT NULL,
  quantidade INT NOT NULL,
  valorUnitario DECIMAL (7,2) NOT NULL,
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
  codUsuario VARCHAR(255) NOT NULL,
  PRIMARY KEY (codFavorito),
  FOREIGN KEY (codProduto) REFERENCES quasarecommerce.produto (codProduto),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.aspnetusers (id)
);
CREATE TABLE IF NOT EXISTS quasarecommerce.carrinho (
  codCarrinho INT NOT NULL AUTO_INCREMENT,
  codUsuario VARCHAR(255) NOT NULL,
  codProduto INT NOT NULL,
  quantidade INT NOT NULL,
  PRIMARY KEY (codCarrinho),
  FOREIGN KEY (codUsuario) REFERENCES quasarecommerce.aspnetusers (id),
  FOREIGN KEY (codProduto) REFERENCES quasarecommerce.produto (codProduto)
);
