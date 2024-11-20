
CREATE database pim_ads;

USE pim_ads;


CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` longtext DEFAULT NULL,
  `email` varchar(254) DEFAULT NULL,
  `password` varchar(254) DEFAULT NULL,
  `dataCriacao` datetime DEFAULT current_timestamp(),
  `dataAtualizacao` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
)

CREATE TABLE `produtos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` longtext DEFAULT NULL,
  `quantidade` int(10) DEFAULT NULL,
  `linkImg` varchar(1024) DEFAULT NULL,
  `preco` decimal(15,2) DEFAULT NULL,
  `descricao` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
)

CREATE TABLE `fornecedores` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` longtext DEFAULT NULL,
  `telefone` varchar(15) DEFAULT NULL,
  `email` varchar(1024) DEFAULT NULL,
  `site` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`id`)
)

CREATE TABLE `insumos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(1024) DEFAULT NULL,
  `qtd` int(11) DEFAULT NULL,
  `linkImg` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`id`)
)


CREATE TABLE `carrinho` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL DEFAULT 1,
  PRIMARY KEY (`id`),
  UNIQUE KEY `unique_cart` (`user_id`,`product_id`),
  KEY `product_id` (`product_id`),
  CONSTRAINT `carrinho_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  CONSTRAINT `carrinho_ibfk_2` FOREIGN KEY (`product_id`) REFERENCES `produtos` (`id`)
)