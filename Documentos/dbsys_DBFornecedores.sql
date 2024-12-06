-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: 192.168.1.198    Database: dbsys
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
-- Table structure for table `DBFornecedores`
--

DROP TABLE IF EXISTS `DBFornecedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DBFornecedores` (
  `IDFornecedor` int NOT NULL AUTO_INCREMENT,
  `TipoPessoa` varchar(8) DEFAULT NULL,
  `Cpf_Cnpj` varchar(14) NOT NULL,
  `Nome_RazaoSocial` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Endereco` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Numero` varchar(8) DEFAULT NULL,
  `Bairro` varchar(50) DEFAULT NULL,
  `Municipio` varchar(50) DEFAULT NULL,
  `UF` varchar(2) DEFAULT NULL,
  `Cep` varchar(8) DEFAULT NULL,
  `Contato` varchar(50) DEFAULT NULL,
  `Fone_1` varchar(10) DEFAULT NULL,
  `Fone_2` varchar(10) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `DataCadastro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`IDFornecedor`),
  UNIQUE KEY `Cpf_Cnpj_UNIQUE` (`Cpf_Cnpj`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DBFornecedores`
--

LOCK TABLES `DBFornecedores` WRITE;
/*!40000 ALTER TABLE `DBFornecedores` DISABLE KEYS */;
INSERT INTO `DBFornecedores` VALUES (1,'JURÍDICA','39927267000164','MT COMERCIO DE SALGADOS LTDA','RUA VILSON LEMOS','180','CENTRO','TIJUCAS','SC','88200000','(48) 3296-2203','4832962203','4832962203','mttijucas@gmail.com','2024-10-10 10:37:48'),(2,'JURÍDICA','08080115000145','VERONA MATERIAIS DE CONSTRUCAO LTDA','RODOVIA SC 411, KM 10','S/N','CENTRO','CANELINHA','SC','88230000','(48) 3263-0409','4832630409','4832630409','','2024-10-10 10:37:48'),(3,'JURÍDICA','21435819000151','MADEIREIRA JOAO VITOR LEAL LTDA','RODOVIA SC 410','2350','AREIAS DE CIMA','GOVERNADOR CELSO RAMOS','SC','88190000','(47) 3368-9784 / (47) 3368-9784 / (47) 3368-9784','4733689784','4733689784','societario@mjbcont.com.br','2024-10-10 10:37:48'),(4,'JURÍDICA','07757491000320','MS INDUSTRIA E COMERCIO DE PRODUTOS ALIMENTICIOS LTDA','RUA FRANCISCO JACINTO DE MELO','884','AREIAS','SAO JOSE','SC','88113300','(48) 3296-2203','4832962203','4832962203','administrativo3@maizumsalgados.com.br','2024-10-12 18:59:01'),(5,'JURÍDICA','07757491000401','MS INDUSTRIA E COMERCIO DE PRODUTOS ALIMENTICIOS LTDA','RUA ISALTINA PAULA CIDADE','16','BARREIROS','SAO JOSE','SC','88110065','(48) 3296-2203','4832962203','4832962203','administrativo3@maizumsalgados.com.br','2024-10-12 19:17:51'),(6,'FÍSICA','77073720930','REGINALDO','RUA GREGÓRIO DIEGOLI','S/N','SÃO LUIZ','BRUSQUE','SC','88351350','REGIALDO','9999999999','','','2024-10-12 19:35:26');
/*!40000 ALTER TABLE `DBFornecedores` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-11-14 16:54:29
