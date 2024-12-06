-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 192.168.1.198    Database: DBOrdenServicos
-- ------------------------------------------------------
-- Server version	9.0.1

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
-- Table structure for table `DBModelos`
--

DROP TABLE IF EXISTS `DBModelos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DBModelos` (
  `IDModelo` int NOT NULL AUTO_INCREMENT,
  `IDMarca` int NOT NULL,
  `Descricao` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`IDModelo`)
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DBModelos`
--

LOCK TABLES `DBModelos` WRITE;
/*!40000 ALTER TABLE `DBModelos` DISABLE KEYS */;
INSERT INTO `DBModelos` VALUES (1,3,'HP DeskJet 1112'),(2,3,'HP DeskJet 2130'),(3,3,'HP DeskJet 3630'),(4,3,'HP ENVY 4520'),(5,3,'HP ENVY 5055'),(6,3,'HP ENVY 6055'),(7,3,'HP OfficeJet 3830'),(8,3,'HP OfficeJet Pro 6978'),(9,3,'HP OfficeJet Pro 9015'),(10,3,'HP LaserJet Pro M15w'),(11,3,'HP LaserJet Pro MFP M130fw'),(12,3,'HP LaserJet Pro MFP M428fdw'),(13,3,'HP Smart Tank 515'),(14,3,'HP Smart Tank 530'),(15,3,'HP Smart Tank 615'),(16,3,'HP DesignJet T210'),(17,3,'HP DesignJet T630'),(18,3,'HP DesignJet Z9+'),(19,2,'CCCCCC'),(20,1,'iPhone 15 Pro Max'),(21,1,'iPhone 15 Pro'),(22,1,'iPhone 15 Plus'),(23,1,'iPhone 15'),(24,1,'iPad Pro (12.9-inch)'),(25,1,'iPad Pro (11-inch)'),(26,1,'iPad Air'),(27,1,'iPad (10th generation)'),(28,1,'iPad mini'),(29,1,'MacBook Air (M2)'),(30,1,'MacBook Pro (14-inch)'),(31,1,'MacBook Pro (16-inch)'),(32,1,'Apple Watch Series 9'),(33,1,'Apple Watch SE'),(34,1,'Apple Watch Ultra 2'),(35,1,'AirPods Pro (2nd generation)'),(36,1,'AirPods Max'),(37,1,'Apple TV 4K'),(38,1,'HomePod mini'),(39,2,'Inspiron 14 Plus'),(40,2,'Latitude 7420'),(41,2,'XPS 13'),(42,2,'G15 Gaming'),(43,2,'Alienware m15 R7'),(44,2,'Precision 5570'),(45,2,'OptiPlex 7090'),(46,2,'XPS Desktop'),(47,2,'Inspiron Desktop'),(48,2,'Alienware Aurora R13'),(49,2,'Dell UltraSharp 27 4K USB-C Monitor (U2720Q)'),(50,2,'Dell 24 Monitor (P2422H)'),(51,2,'Dell 27 Gaming Monitor (S2721DGF)'),(52,2,'Dell Thunderbolt Dock (WD19TBS)'),(53,2,'Dell Pro Wireless Keyboard and Mouse (KM5221W)'),(54,2,'Dell Mobile Adapter Speakerphone (MH3021P)');
/*!40000 ALTER TABLE `DBModelos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-14 16:54:30
