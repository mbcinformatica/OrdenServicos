-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 192.168.1.198    Database: iot
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
-- Table structure for table `historico_sensor`
--

DROP TABLE IF EXISTS `historico_sensor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `historico_sensor` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idsensor` int NOT NULL,
  `valor` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dateregister` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idsensor` (`idsensor`),
  CONSTRAINT `historico_sensor_ibfk_1` FOREIGN KEY (`idsensor`) REFERENCES `sensor` (`idsensor`)
) ENGINE=InnoDB AUTO_INCREMENT=502 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `historico_sensor`
--

LOCK TABLES `historico_sensor` WRITE;
/*!40000 ALTER TABLE `historico_sensor` DISABLE KEYS */;
INSERT INTO `historico_sensor` VALUES (340,1,'26.10','2024-10-02 15:09:35'),(341,2,'75','2024-10-02 15:09:35'),(342,3,'Normal','2024-10-02 15:09:35'),(343,1,'26.10','2024-10-02 15:09:45'),(344,2,'75','2024-10-02 15:09:45'),(345,3,'Normal','2024-10-02 15:09:45'),(346,1,'26.10','2024-10-02 15:09:55'),(347,2,'75','2024-10-02 15:09:55'),(348,3,'Normal','2024-10-02 15:09:55'),(349,1,'26.10','2024-10-02 15:10:05'),(350,2,'75','2024-10-02 15:10:05'),(351,3,'Normal','2024-10-02 15:10:05'),(352,1,'26.10','2024-10-02 15:10:15'),(353,2,'75','2024-10-02 15:10:15'),(354,3,'Normal','2024-10-02 15:10:15'),(355,1,'26.10','2024-10-02 15:10:25'),(356,2,'75','2024-10-02 15:10:25'),(357,3,'Normal','2024-10-02 15:10:25'),(358,1,'26.10','2024-10-02 15:10:35'),(359,2,'75','2024-10-02 15:10:35'),(360,3,'Normal','2024-10-02 15:10:35'),(361,1,'26.10','2024-10-02 15:10:45'),(362,2,'75','2024-10-02 15:10:45'),(363,3,'Normal','2024-10-02 15:10:45'),(364,1,'26.10','2024-10-02 15:10:55'),(365,2,'75','2024-10-02 15:10:55'),(366,3,'Normal','2024-10-02 15:10:55'),(367,1,'26.10','2024-10-02 15:11:05'),(368,2,'75','2024-10-02 15:11:05'),(369,3,'Normal','2024-10-02 15:11:05'),(370,1,'26.10','2024-10-02 15:11:15'),(371,2,'75','2024-10-02 15:11:15'),(372,3,'Normal','2024-10-02 15:11:15'),(373,1,'26.10','2024-10-02 15:11:25'),(374,2,'75','2024-10-02 15:11:25'),(375,3,'Normal','2024-10-02 15:11:25'),(376,1,'26.10','2024-10-02 15:11:35'),(377,2,'75','2024-10-02 15:11:35'),(378,3,'Normal','2024-10-02 15:11:35'),(379,1,'26.10','2024-10-02 15:11:45'),(380,2,'75','2024-10-02 15:11:45'),(381,3,'Normal','2024-10-02 15:11:45'),(382,1,'26.00','2024-10-02 15:11:55'),(383,2,'75','2024-10-02 15:11:55'),(384,3,'Normal','2024-10-02 15:11:55'),(385,1,'26.10','2024-10-02 15:12:05'),(386,2,'75','2024-10-02 15:12:05'),(387,3,'Normal','2024-10-02 15:12:05'),(388,1,'26.10','2024-10-02 15:12:15'),(389,2,'75','2024-10-02 15:12:15'),(390,3,'Normal','2024-10-02 15:12:15'),(391,1,'26.10','2024-10-02 15:12:25'),(392,2,'75','2024-10-02 15:12:25'),(393,3,'Normal','2024-10-02 15:12:25'),(394,1,'26.10','2024-10-02 15:12:35'),(395,2,'75','2024-10-02 15:12:35'),(396,3,'Normal','2024-10-02 15:12:35'),(397,1,'26.10','2024-10-02 15:12:45'),(398,2,'76','2024-10-02 15:12:45'),(399,3,'Normal','2024-10-02 15:12:45'),(400,1,'26.10','2024-10-02 15:12:55'),(401,2,'76','2024-10-02 15:12:55'),(402,3,'Normal','2024-10-02 15:12:55'),(403,1,'26.10','2024-10-02 15:13:05'),(404,2,'76','2024-10-02 15:13:05'),(405,3,'Normal','2024-10-02 15:13:05'),(406,1,'26.00','2024-10-02 15:13:15'),(407,2,'75','2024-10-02 15:13:15'),(408,3,'Normal','2024-10-02 15:13:15'),(409,1,'26.00','2024-10-02 15:13:25'),(410,2,'75','2024-10-02 15:13:25'),(411,3,'Normal','2024-10-02 15:13:25'),(412,1,'26.00','2024-10-02 15:13:35'),(413,2,'75','2024-10-02 15:13:35'),(414,3,'Normal','2024-10-02 15:13:35'),(415,1,'26.00','2024-10-02 15:13:45'),(416,2,'75','2024-10-02 15:13:45'),(417,3,'Normal','2024-10-02 15:13:45'),(418,1,'26.10','2024-10-02 15:13:55'),(419,2,'75','2024-10-02 15:13:55'),(420,3,'Normal','2024-10-02 15:13:55'),(421,1,'26.00','2024-10-02 15:14:05'),(422,2,'75','2024-10-02 15:14:05'),(423,3,'Normal','2024-10-02 15:14:05'),(424,1,'26.10','2024-10-02 15:14:15'),(425,2,'75','2024-10-02 15:14:15'),(426,3,'Normal','2024-10-02 15:14:15'),(427,1,'26.10','2024-10-02 15:14:25'),(428,2,'75','2024-10-02 15:14:25'),(429,3,'Normal','2024-10-02 15:14:25'),(430,1,'26.10','2024-10-02 15:14:35'),(431,2,'76','2024-10-02 15:14:35'),(432,3,'Normal','2024-10-02 15:14:35'),(433,1,'26.10','2024-10-02 15:14:45'),(434,2,'76','2024-10-02 15:14:45'),(435,3,'Normal','2024-10-02 15:14:45'),(436,1,'26.10','2024-10-02 15:14:55'),(437,2,'76','2024-10-02 15:14:55'),(438,3,'Normal','2024-10-02 15:14:55'),(439,1,'26.10','2024-10-02 15:15:05'),(440,2,'76','2024-10-02 15:15:05'),(441,3,'Normal','2024-10-02 15:15:05'),(442,1,'26.10','2024-10-02 15:15:15'),(443,2,'76','2024-10-02 15:15:15'),(444,3,'Normal','2024-10-02 15:15:15'),(445,1,'26.10','2024-10-02 15:15:25'),(446,2,'76','2024-10-02 15:15:25'),(447,3,'Normal','2024-10-02 15:15:25'),(448,1,'26.10','2024-10-02 15:15:35'),(449,2,'76','2024-10-02 15:15:35'),(450,3,'Normal','2024-10-02 15:15:35'),(451,1,'26.10','2024-10-02 15:15:45'),(452,2,'76','2024-10-02 15:15:45'),(453,3,'Normal','2024-10-02 15:15:45'),(454,1,'26.10','2024-10-02 15:15:55'),(455,2,'76','2024-10-02 15:15:55'),(456,3,'Normal','2024-10-02 15:15:55'),(457,1,'26.10','2024-10-02 15:16:05'),(458,2,'76','2024-10-02 15:16:05'),(459,3,'Normal','2024-10-02 15:16:05'),(460,1,'26.10','2024-10-02 15:16:15'),(461,2,'76','2024-10-02 15:16:15'),(462,3,'Normal','2024-10-02 15:16:15'),(463,1,'26.10','2024-10-02 15:16:25'),(464,2,'76','2024-10-02 15:16:25'),(465,3,'Normal','2024-10-02 15:16:25'),(466,1,'26.10','2024-10-02 15:16:35'),(467,2,'76','2024-10-02 15:16:35'),(468,3,'Normal','2024-10-02 15:16:35'),(469,1,'26.10','2024-10-02 15:16:45'),(470,2,'76','2024-10-02 15:16:45'),(471,3,'Normal','2024-10-02 15:16:45'),(472,1,'26.10','2024-10-02 15:16:55'),(473,2,'75','2024-10-02 15:16:55'),(474,3,'Normal','2024-10-02 15:16:55'),(475,1,'26.10','2024-10-02 15:17:05'),(476,2,'75','2024-10-02 15:17:05'),(477,3,'Normal','2024-10-02 15:17:05'),(478,1,'26.10','2024-10-02 15:17:15'),(479,2,'75','2024-10-02 15:17:15'),(480,3,'Normal','2024-10-02 15:17:15'),(481,1,'26.10','2024-10-02 15:17:25'),(482,2,'75','2024-10-02 15:17:25'),(483,3,'Normal','2024-10-02 15:17:25'),(484,1,'26.10','2024-10-02 15:17:35'),(485,2,'75','2024-10-02 15:17:35'),(486,3,'Normal','2024-10-02 15:17:35'),(487,1,'26.20','2024-10-02 15:17:45'),(488,2,'75','2024-10-02 15:17:45'),(489,3,'Normal','2024-10-02 15:17:45'),(490,1,'26.20','2024-10-02 15:17:55'),(491,2,'75','2024-10-02 15:17:55'),(492,3,'Normal','2024-10-02 15:17:55'),(493,1,'26.20','2024-10-02 15:18:05'),(494,2,'75','2024-10-02 15:18:05'),(495,3,'Normal','2024-10-02 15:18:05'),(496,1,'26.10','2024-10-02 15:18:15'),(497,2,'75','2024-10-02 15:18:15'),(498,3,'Normal','2024-10-02 15:18:15'),(499,1,'26.10','2024-10-02 15:18:25'),(500,2,'75','2024-10-02 15:18:25'),(501,3,'Normal','2024-10-02 15:18:25');
/*!40000 ALTER TABLE `historico_sensor` ENABLE KEYS */;
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
