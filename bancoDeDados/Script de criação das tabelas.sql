
CREATE database projetoPIM;

USE projetoPIM;



CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` longtext DEFAULT NULL,
  `email` varchar(254) DEFAULT NULL,
  `password` varchar(254) DEFAULT NULL,
  `dataCriacao` datetime DEFAULT current_timestamp(),
  `dataAtualizacao` datetime DEFAULT NULL ON UPDATE current_timestamp(),
  PRIMARY KEY (`id`)
)
