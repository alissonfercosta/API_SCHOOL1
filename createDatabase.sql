CREATE DATABASE `education` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

CREATE TABLE `school` (
  `id` int NOT NULL AUTO_INCREMENT,
  `IsActive` int DEFAULT NULL,
  `name` varchar(100) DEFAULT NULL,
  `description` varchar(300) DEFAULT NULL,
  `creatAt` datetime DEFAULT NULL,
  `updateAt` datetime DEFAULT NULL,
  `capacity` int DEFAULT NULL,
  `grade` varchar(400) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
