CREATE TABLE `player` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `graduationYear` int(11) NOT NULL,
  `gender` bit NOT NULL,
  `dateInserted` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `dateUpdated` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
