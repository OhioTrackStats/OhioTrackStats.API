CREATE TABLE `division` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `division` int NOT NULL,
  `maleMinimumEnrollment` int NOT NULL,
  `maleMaximumEnrollment` int NOT NULL,
  `femaleMinimumEnrollment` int NOT NULL,
  `femaleMaximumEnrollment` int NOT NULL,
  `year` int NOT NULL,
  `dateInserted` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `dateUpdated` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
