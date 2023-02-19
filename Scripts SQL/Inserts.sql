INSERT INTO categoria(nome, imagem)
VALUES
    (
      'Vidro',
      'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Categorias/VidroCategorias.png'
    ),
    (
      'Farol',
      'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Categorias/FarolCategorias.png'
    ),
    (
      'Lanterna',
      'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Categorias/LanternaCategorias.png'
    ),
    (
      'Retrovisor',
      'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Categorias/RetrovisorCategorias.png'
    ),
    (
      'Para-Choque',
      'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Categorias/ParachoqueCategorias.png'
    )
    ;
    
    INSERT INTO fornecedor(nome, razaoSocial, cnpj, ie)
VALUES (
    'CAR7',
    'CAR SEVEN DISTRIBUIDORA DE VIDROS',
    07239512000154,
    509892477
  ),
  #vidro 
  (
    'ParaShock',
    'ParaShock Industrias e Serviços LTDA',
    99508600000122,
    125005717
  ),
  #parachoque
  (
    'Retro Visor',
    'Distribuidora de Retrovisores',
    13266572000169,
    322370949
  ),
  #retrovisor
  (
    'Lanternas FX',
    'Lanternas FX Serviços e Distruibuição',
    85987299000172,
    898313821
  ),
  #lanternas
  (
    'FlashFarois',
    'FlashFarois Comércio e Industria LTDA',
    746564845979,
    407516646
  ),
  #farol
  (
    'Controle de Lanternagem',
    'Controle de Lanternagem Serviço',
    59450336000107,
    138338884
  ),
  #lanternas
  (
    'All Vidros',
    'All Vidros Industria e Serviços',
    27648252000188,
    127545760
  ),
  #vidro
  (
    'AutoFaróis',
    'AutoFaróis Distribuidora',
    82003008000176,
    244519021
  ),
  #farol
  (
    'Industria do Parachoque',
    'Industria do Parachoque Industria e Comércio',
    11280694000184,
    437341844
  ),
  #parachoque
  (
    'Lumus Retrovisores',
    'Distribuidora Lumus Retrovisores',
    38338393000110,
    309143233
  );
#retrovisor

INSERT INTO especificacao(codEspecificacao, posicao, cor, ano, veiculo) 
VALUES 
  (
    1,
    'Dianteira',
    'Verde Faixa Azul',
    '2021, 2022',
    'Civic'
  ),
#vidro parabrisa
  (
    2,
    'Dianteira',
    'Preto Liso',
    '2018, 2019',
    'Saveiro'
  ),
#parachoque
  (
    3,
    'Esquerdo (Motorista)',
    'Preto Liso',
    '2020, 2021',
    'Outlander'
  ),
#retrovisor
  (
    4,
    'Esquerdo',
    'Bicolor',
    '2021, 2022',
    'Airtrek'
  ),
#lanternas
  (
    5,
    'Direito',
    'Cromado',
    '2005, 2006',
    'Fit'
  ),
#farol
  (
    6,
    'Direito',
    'Verde Faixa Azul',
    '2002, 2003',
    'Escort'
  ),
#vidro janela
  (
    7,
    'Dianteira',
    'Preto',
    '2013, 2014',
    'Crossfox'
  ),
#parachoque grade
  (
    8,
    'Direito',
    'Preto',
    '2014, 2015',
    'Outlander'
  ),
#retrovisor
  (
    9,
    'Direito',
    'Bicolor',
    '2005, 2006',
    'Airtrek'
  ),
#lanternas
  (
    10,
    'Direito',
    'Cromado',
    '2020, 2021',
    'Compass'
  );
#farol diurno

INSERT INTO produto(codProduto, descricao, nome, valor, imagem, codCategoria, codFornecedor, codEspecificacao) 
VALUES
  (
	1,
    'Vidro Parabrisa aplicável nos veículos Citroen C4 Picasso Hatch 4 portas , anos 2021 a 2022 .',
    'Parabrisa Citroen C4 Picasso',
     1608.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Parabrisa%20Citroen%20C4%20Picasso.png',
    1,
    1,
    1
  ),
#vidro parabrisa
  (
	2,
    'Parachoque Dianteiro aplicável nos veículos Volkswagen Saveiro G7 Cross Cabine Dupla e Cabine Estendida , anos 2018 a 2019 .',
    'Parachoque Volkswagen Saveiro G7 Cross Dianteiro',
    588.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Parachoque%20Volkswagen%20Saveiro%20G7%20Cross%20Dianteiro.png',
    5,
    2,
    2
  ),
#parachoque
  (
	3,
    'Capa Superior do Retrovisor Lado Esquerdo, do Motorista, aplicável nos veículos Mitsubishi Outlander , anos 2020 a 2021 .',
    'Capa Retrovisor Mitsubishi Outlander',
    885.51,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Capa%20Retrovisor%20Mitsubishi%20Outlander.png',
    4,
    3,
    3
  ),
#retrovisor
  (
	4,
    'Lanterna Traseira Lado Direito, do Passageiro, aplicável nos veículos Toyota Hilux Srx Cabine Dupla , anos 2021 a 2022 .',
    'Lanterna Toyota Hilux Srx Direito',
    2408.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Lanterna%20Toyota%20Hilux%20Srx%20Direito.png',
    3,
    4,
    4
  ),
#lanternas
  (
	5,
    'Farol Auxiliar Lado Direito, do Passageiro, aplicável nos veículos Honda Fit Hatch 4 portas , anos 2005 a 2006 .',
    'Farol Milha Honda Fit Direito',
    2100.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Farol%20Milha%20Honda%20Fit%20Direito.png',
    2,
    5,
    5
  ),
#farol
  (
	6,
    'Vidro Janela Lado Direito, do Passageiro, aplicável nos veículos Ford Escort Hatch 2 portas , anos 2002 a 2003 .',
    'Vidro Janela Ford Escort',
    1412.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Vidro%20Janela%20Ford%20Escort.png',
    1,
    7,
    6
  ),
#vidro janela
  (
	7,
    'Grade Central do Parachoque aplicável nos veículos Volkswagen Crossfox Hatch 4 portas , anos 2013 a 2014 .',
    'Grade Parachoque Volkswagen Crossfox',
    720.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Grade%20Parachoque%20Volkswagen%20Crossfox.png',
    5,
    9,
    7
  ),
#parachoque grade
  (
	8,
    'Capa Superior do Retrovisor Lado Direito, do Passageiro, aplicável nos veículos Mitsubishi Outlander , anos 2014 a 2015 .',
    'Capa Retrovisor Mitsubishi Outlander',
    901.20,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Categorias/RetrovisorCategorias.png',
    4,
    10,
    8
  ),
#retrovisor
  (
	9,
    'Lanterna Traseira Lado Esquerdo, do Motorista, aplicável nos veículos Mitsubishi Airtrek , anos 2005 a 2006 .',
    'Lanterna Mitsubishi Airtrek Esquerdo',
    1800.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Lanterna%20Mitsubishi.png',
    3,
    6,
    9
  ),
#lanternas
  (
	10,
    'Farol Diurno Lado Direito, do passageiro aplicável nos veículos Jeep Compass , anos 2020 a 2021 , compatível com os modelos Compass',
    'Farol Diurno Jeep',
    1230.00,
    'https://raw.githubusercontent.com/IgormBonfim/quasar-media/main/Produtos/Farol%20Diurno%20Jeep.png',
    2,
    8,
    10
  );
#farol diurno

INSERT INTO estoque(codEstoque, quantidade, codProduto)
VALUES
	(
    1,
    556,
    1
),
	(
    2,
    564,
    2
),
	(
    3,
    10,
    3
),
	(
    4,
    78,
    4
),
	(
    5,
    97,
    5
),
	(
    6,
    56,
    6
),
	(
    7,
    23,
    7
),
	(
    8,
    32,
    8
),
	(
	9,
    27,
    9
),
	(
    10,
    100,
    10
);

INSERT INTO uf (nome, sigla)
VALUES ("Acre", "AC"),
    ("Alagoas", "AL"),
    ("Amazonas", "AM"),
    ("Amapá", "AP"),
    ("Bahia", "BA"),
    ("Ceará", "CE"),
    ("Distrito Federal", "DF"),
    ("Espírito Santo", "ES"),
    ("Goiás", "GO"),
    ("Maranhão", "MA"),
    ("Minas Gerais", "MG"),
    ("Mato Grosso do Sul", "MS"),
    ("Mato Grosso", "MT"),
    ("Pará", "PA"),
    ("Paraíba", "PB"),
    ("Pernambuco", "PE"),
    ("Piauí", "PI"),
    ("Paraná", "PR"),
    ("Rio de Janeiro", "RJ"),
    ("Rio Grande do Norte", "RN"),
    ("Rondônia", "RO"),
    ("Roraima", "RR"),
    ("Rio Grande do Sul", "RS"),
    ("Santa Catarina", "SC"),
    ("Sergipe", "SE"),
    ("São Paulo", "SP"),
    ("Tocantins", "TO")
    ;
    
    INSERT INTO cidade (nome, codUf)
VALUES -- ES (8)
    ('Guarapari', 8),
    ('Itapemirim', 8),
    ('Viana', 8),
    ('Vila Velha', 8),
    ('Vitória', 8),
    -- ACRE (1)
    ('Acrelândia', 1),
    ('Capixaba', 1),
    ('Cruzeiro do Sul', 1),
    ('Porto Acre', 1),
    ('Rio Branco', 1),
    -- ALAGOAS (2)
    ('Campo Alegre', 2),
    ('Estrela de Alagoas', 2),
    ('Feira Grande', 2),
    ('Maceió', 2),
    ('Ouro Branco', 2),
    -- AMAPÁ (4)
    ('Amapá', 4),
    ('Macapá', 4),
    ('Porto Grande', 4),
    ('Pracuúba', 4),
    ('Vitória do Jari', 4),
    -- AMAZONAS (3)
    ('Alvarães', 3),
    ('Amaturá', 3),
    ('Itamarati', 3),
    ('Itapiranga', 3),
    ('Manaus', 3),
    -- BAHIA (5)
    ('Porto Seguro', 5),
    ('Prado', 5),
    ('Ruy Barbosa', 5),
    ('Salinas da Margarida', 5),
    ('Salvador', 5),
    -- CEARÁ (6)
    ('Fortaleza', 6),
    ('Fortim', 6),
    ('Frecheirinha', 6),
    ('General Sampaio', 6),
    ('Graça', 6),
    -- DISTRITO FEDERAL (7)
    ('Brasília', 7),
    ('Sudoeste/Octogonal', 7),
    ('Varjão', 7),
    ('Park Way', 7),
    ('SCIA', 7),
    -- GOIÁS (9)
    ('Goiânia', 9),
    ('Goianira', 9),
    ('Goiás', 9),
    ('Goiatuba', 9),
    ('Gouvelândia', 9),
    -- MARANHÃO (10)
    ('São João do Soter', 10),
    ('São João dos Patos', 10),
    ('São José de Ribamar', 10),
    ('São José dos Basílios', 10),
    ('São Luís', 10),
    -- MATO GROSSO (13)
    ('Cuiabá', 13),
    ('Denise', 13),
    ('Diamantino', 13),
    ('Dom Aquino', 13),
    ('Feliz Natal', 13),
    -- MATO GROSSO DO SUL (12)
    ('Campo Grande', 12),
    ('Caracol', 12),
    ('Cassilândia', 12),
    ('Chapadão do Sul', 12),
    ('Corguinho', 12),
    -- MINAS GERAIS (11)
    ('Belo Horizonte', 11),
    ('Belo Oriente', 11),
    ('Belo Vale', 11),
    ('Berilo', 11),
    ('Berizal', 11),
    -- PARÁ (14)
    ('Belém', 14),
    ('Belterra', 14),
    ('Benevides', 14),
    ('Bom Jesus do Tocantins', 14),
    ('Bonito', 14),
    -- PARAÍBA (15)
    ('Itapororoca', 15),
    ('Itatuba', 15),
    ('Jacaraú', 15),
    ('Jericó', 15),
    ('João Pessoa', 15),
    -- PARANÁ (18)
    ('Cruzeiro do Iguaçu', 18),
    ('Cruzeiro do Oeste', 18),
    ('Cruzeiro do Sul', 18),
    ('Cruzmaltina', 18),
    ('Curitiba', 18),
    -- PERNAMBUCO (16)
    ('Recife', 16),
    ('Riacho das Almas', 16),
    ('Ribeirão', 16),
    ('Rio Formoso', 16),
    ('Sairé', 16),
    -- PIAUÍ (17)
    ('Socorro do Piauí', 17),
    ('Sussuapara', 17),
    ('Tamboril do Piauí', 17),
    ('Tanque do Piauí', 17),
    ('Teresina', 17),
    -- RIO DE JANEIRO (19)
    ('Niterói', 19),
    ('Rio das Ostras', 19),
    ('Rio de Janeiro', 19),
    ('Macaé', 19),
    ('Campos dos Goytacazes', 19),
    -- RIO GRANDE DO NORTE (20)
    ('Montanhas', 20),
    ('Monte Alegre', 20),
    ('Monte das Gameleiras', 20),
    ('Mossoró', 20),
    ('Natal', 20),
    -- RIO GRANDE DO SUL (23)
    ('Poço das Antas', 23),
    ('Pontão', 23),
    ('Ponte Preta', 23),
    ('Portão', 23),
    ('Porto Alegre', 23),
    -- RONDÔNIA (21)
    ('Porto Velho', 21),
    ('Presidente Médici', 21),
    ('Primavera de Rondônia', 21),
    ('Rio Crespo', 21),
    ('Rolim de Moura', 21),
    -- RORAIMA (22)
    ('Boa Vista', 22),
    ('Bonfim', 22),
    ('Cantá', 22),
    ('Caracaraí', 22),
    ('Caroebe', 22),
    -- SANTA CATARINA (24)
    ('Ermo', 24),
    ('Erval Velho', 24),
    ('Faxinal dos Guedes', 24),
    ('Flor do Sertão', 24),
    ('Florianópolis', 24),
    -- SÃO PAULO (26)
    ('São Paulo', 26),
    ('Guarulhos', 26),
    ('Ribeirão Preto', 26),
    ('São Bernardo do Campo', 26),
    ('Vitória Brasil', 26),
    -- SERGIPE (25)
    ('Aracaju', 25),
    ('Arauá', 25),
    ('Areia Branca', 25),
    ('Barra dos Coqueiros', 25),
    ('Boquim', 25),
    -- TOCANTINS (27)
    ('Novo Acordo', 27),
    ('Novo Alegre', 27),
    ('Novo Jardim', 27),
    ('Oliveira de Fátima', 27),
    ('Palmas', 27)
    ;
    
    INSERT INTO formaPagamento(codFormaPagamento, descricao)
VALUES(1, 'Cartão de Crédito'),
(2, 'Boleto'),
(3, 'Pix');

INSERT INTO statusVenda (descricao)
VALUES ("Aguardando pagamento"),
("Pagamento aprovado"),
("Pedido enviado"),
("Cancelado"),
("Pagamento recusado"),
("Pedido em separação"),
("Finalizado")
;


