-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: biblio
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `stores`
--

DROP TABLE IF EXISTS `stores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `stores` (
  `id_store` int NOT NULL AUTO_INCREMENT,
  `book_id` int DEFAULT NULL,
  `available` int DEFAULT '0',
  `books_sold` int DEFAULT '0',
  `books_requisited` int DEFAULT '0',
  `name_store` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_store`),
  KEY `book_id` (`book_id`),
  CONSTRAINT `stores_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `books` (`id_book`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=223 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stores`
--

LOCK TABLES `stores` WRITE;
/*!40000 ALTER TABLE `stores` DISABLE KEYS */;
INSERT INTO `stores` VALUES (1,1,10,0,0,'FNAC'),(2,2,8,0,0,'FNAC'),(3,3,5,0,0,'FNAC'),(4,4,12,0,0,'FNAC'),(5,5,6,0,0,'FNAC'),(6,6,7,0,0,'FNAC'),(7,37,11,0,0,'FNAC'),(8,38,6,0,0,'FNAC'),(9,39,9,0,0,'FNAC'),(10,40,7,0,0,'FNAC'),(11,41,4,0,0,'FNAC'),(12,42,5,0,0,'FNAC'),(13,63,10,0,0,'FNAC'),(14,64,4,0,0,'FNAC'),(15,65,8,0,0,'FNAC'),(16,66,6,0,0,'FNAC'),(17,67,12,0,0,'FNAC'),(18,68,5,0,0,'FNAC'),(19,99,8,0,0,'FNAC'),(21,9,7,0,0,'FNAC'),(22,10,5,0,0,'FNAC'),(23,11,8,0,0,'FNAC'),(24,12,6,0,0,'FNAC'),(25,13,4,0,0,'FNAC'),(26,14,9,0,0,'FNAC'),(27,15,7,0,0,'FNAC'),(28,16,11,0,0,'FNAC'),(29,17,6,0,0,'FNAC'),(30,18,5,0,0,'FNAC'),(31,19,10,0,0,'FNAC'),(32,20,4,0,0,'FNAC'),(33,21,9,0,0,'FNAC'),(34,22,7,0,0,'FNAC'),(35,23,8,0,0,'FNAC'),(36,24,6,0,0,'FNAC'),(37,25,10,0,0,'FNAC'),(38,26,12,0,0,'FNAC'),(39,27,7,0,0,'FNAC'),(40,28,9,0,0,'FNAC'),(41,29,5,0,0,'FNAC'),(42,30,6,0,0,'FNAC'),(43,31,8,0,0,'FNAC'),(44,32,11,0,0,'FNAC'),(45,33,7,0,0,'FNAC'),(46,34,5,0,0,'FNAC'),(47,35,6,0,0,'FNAC'),(48,36,10,0,0,'FNAC'),(49,7,9,0,0,'Bertrand'),(50,8,11,0,0,'Bertrand'),(51,9,10,0,0,'Bertrand'),(52,10,4,0,0,'Bertrand'),(53,11,3,0,0,'Bertrand'),(54,12,5,0,0,'Bertrand'),(55,43,3,0,0,'Bertrand'),(56,44,8,0,0,'Bertrand'),(57,45,6,0,0,'Bertrand'),(58,46,7,0,0,'Bertrand'),(59,47,9,0,0,'Bertrand'),(60,48,10,0,0,'Bertrand'),(61,69,7,0,0,'Bertrand'),(62,70,9,0,0,'Bertrand'),(63,71,8,0,0,'Bertrand'),(64,72,6,0,0,'Bertrand'),(65,73,4,0,0,'Bertrand'),(66,74,3,0,0,'Bertrand'),(67,13,6,0,0,'Bertrand'),(68,14,9,0,0,'Bertrand'),(69,15,7,0,0,'Bertrand'),(70,16,11,0,0,'Bertrand'),(71,17,5,0,0,'Bertrand'),(72,18,8,0,0,'Bertrand'),(73,19,4,0,0,'Bertrand'),(74,20,6,0,0,'Bertrand'),(75,21,7,0,0,'Bertrand'),(76,22,3,0,0,'Bertrand'),(77,23,5,0,0,'Bertrand'),(78,24,10,0,0,'Bertrand'),(79,25,8,0,0,'Bertrand'),(80,26,4,0,0,'Bertrand'),(81,27,6,0,0,'Bertrand'),(82,28,9,0,0,'Bertrand'),(83,29,11,0,0,'Bertrand'),(84,30,7,0,0,'Bertrand'),(85,31,8,0,0,'Bertrand'),(86,32,10,0,0,'Bertrand'),(87,33,5,0,0,'Bertrand'),(88,34,4,0,0,'Bertrand'),(89,35,6,0,0,'Bertrand'),(90,36,8,0,0,'Bertrand'),(91,49,7,0,0,'Bertrand'),(92,50,10,0,0,'Bertrand'),(93,51,6,0,0,'Bertrand'),(94,52,4,0,0,'Bertrand'),(95,53,9,0,0,'Bertrand'),(96,54,5,0,0,'Bertrand'),(97,55,8,0,0,'Bertrand'),(98,56,7,0,0,'Bertrand'),(99,57,6,0,0,'Bertrand'),(100,58,11,0,0,'Bertrand'),(101,59,8,0,0,'Bertrand'),(102,60,9,0,0,'Bertrand'),(103,61,7,0,0,'Bertrand'),(104,62,6,0,0,'Bertrand'),(105,63,5,0,0,'Bertrand'),(106,64,10,0,0,'Bertrand'),(107,65,8,0,0,'Bertrand'),(108,66,7,0,0,'Bertrand'),(109,67,9,0,0,'Bertrand'),(110,68,6,0,0,'Bertrand'),(111,13,6,0,0,'Livraria Lello'),(112,14,8,0,0,'Livraria Lello'),(113,15,9,0,0,'Livraria Lello'),(114,16,12,0,0,'Livraria Lello'),(115,17,6,0,0,'Livraria Lello'),(116,18,4,0,0,'Livraria Lello'),(117,49,11,0,0,'Livraria Lello'),(118,50,12,0,0,'Livraria Lello'),(119,75,10,0,0,'Livraria Lello'),(120,76,12,0,0,'Livraria Lello'),(121,77,9,0,0,'Livraria Lello'),(122,78,7,0,0,'Livraria Lello'),(123,79,8,0,0,'Livraria Lello'),(124,80,6,0,0,'Livraria Lello'),(125,32,9,0,0,'Livraria Lello'),(126,92,8,0,0,'Livraria Lello'),(127,74,14,0,0,'Livraria Lello'),(129,19,5,0,0,'Livraria Lello'),(130,70,10,0,0,'Livraria Lello'),(131,104,8,0,0,'Livraria Lello'),(132,43,10,0,0,'Livraria Lello'),(133,95,4,0,0,'Livraria Lello'),(134,57,9,0,0,'Livraria Lello'),(135,19,7,0,0,'Worten'),(136,20,8,0,0,'Worten'),(137,21,10,0,0,'Worten'),(138,22,5,0,0,'Worten'),(139,23,6,0,0,'Worten'),(140,24,9,0,0,'Worten'),(141,81,9,0,0,'Worten'),(142,82,8,0,0,'Worten'),(143,83,10,0,0,'Worten'),(144,84,6,0,0,'Worten'),(145,85,7,0,0,'Worten'),(146,86,12,0,0,'Worten'),(147,101,5,0,0,'Worten'),(148,102,9,0,0,'Worten'),(149,103,8,0,0,'Worten'),(150,104,12,0,0,'Worten'),(151,105,6,0,0,'Worten'),(152,10,6,0,0,'Worten'),(153,13,13,0,0,'Worten'),(154,69,8,0,0,'Worten'),(155,73,14,0,0,'Worten'),(156,74,12,0,0,'Worten'),(157,71,8,0,0,'Worten'),(158,98,9,0,0,'Worten'),(159,94,14,0,0,'Worten'),(160,39,8,0,0,'Worten'),(161,72,13,0,0,'Worten'),(162,25,11,0,0,'Wook'),(163,26,7,0,0,'Wook'),(164,27,6,0,0,'Wook'),(165,28,8,0,0,'Wook'),(166,29,10,0,0,'Wook'),(167,30,4,0,0,'Wook'),(168,51,8,0,0,'Wook'),(169,52,9,0,0,'Wook'),(170,53,10,0,0,'Wook'),(171,54,6,0,0,'Wook'),(172,55,7,0,0,'Wook'),(173,56,12,0,0,'Wook'),(174,87,10,0,0,'Wook'),(175,88,8,0,0,'Wook'),(176,89,6,0,0,'Wook'),(177,90,9,0,0,'Wook'),(178,91,12,0,0,'Wook'),(179,92,5,0,0,'Wook'),(180,101,7,0,0,'Wook'),(181,102,8,0,0,'Wook'),(182,103,6,0,0,'Wook'),(183,104,5,0,0,'Wook'),(184,105,10,0,0,'Wook'),(185,69,15,0,0,'Wook'),(186,22,8,0,0,'Wook'),(187,46,14,0,0,'Wook'),(188,12,13,0,0,'Wook'),(189,84,14,0,0,'Wook'),(190,98,4,0,0,'Wook'),(191,35,7,0,0,'Wook'),(192,31,10,0,0,'Wook'),(193,73,14,0,0,'Wook'),(194,61,10,0,0,'Wook'),(195,31,9,0,0,'El Corte Inglés'),(196,32,12,0,0,'El Corte Inglés'),(197,33,10,0,0,'El Corte Inglés'),(198,34,5,0,0,'El Corte Inglés'),(199,35,7,0,0,'El Corte Inglés'),(200,36,8,0,0,'El Corte Inglés'),(201,57,8,0,0,'El Corte Inglés'),(202,58,10,0,0,'El Corte Inglés'),(203,59,6,0,0,'El Corte Inglés'),(204,60,11,0,0,'El Corte Inglés'),(205,61,5,0,0,'El Corte Inglés'),(206,62,7,0,0,'El Corte Inglés'),(207,93,7,0,0,'El Corte Inglés'),(208,94,9,0,0,'El Corte Inglés'),(209,95,10,0,0,'El Corte Inglés'),(210,96,8,0,0,'El Corte Inglés'),(211,97,6,0,0,'El Corte Inglés'),(212,98,4,0,0,'El Corte Inglés'),(213,67,9,0,0,'El Corte Inglés'),(214,70,7,0,0,'El Corte Inglés'),(215,72,10,0,0,'El Corte Inglés'),(216,74,11,0,0,'El Corte Inglés'),(217,68,8,0,0,'El Corte Inglés'),(218,65,13,0,0,'El Corte Inglés'),(219,69,6,0,0,'El Corte Inglés'),(220,71,14,0,0,'El Corte Inglés'),(221,73,7,0,0,'El Corte Inglés'),(222,64,8,0,0,'El Corte Inglés');
/*!40000 ALTER TABLE `stores` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-02 13:39:04
