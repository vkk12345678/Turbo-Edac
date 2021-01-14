CREATE DATABASE  IF NOT EXISTS `gen_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `gen_db`;
-- MySQL dump 10.13  Distrib 8.0.11, for Win64 (x86_64)
--
-- Host: localhost    Database: gen_db
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tb_view`
--

DROP TABLE IF EXISTS `tb_view`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_view` (
  `N` int(11) NOT NULL DEFAULT '0',
  `Cn` int(11) DEFAULT '0',
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_view`
--

LOCK TABLES `tb_view` WRITE;
/*!40000 ALTER TABLE `tb_view` DISABLE KEYS */;
INSERT INTO `tb_view` VALUES (0,0,'E_Speed','r/min'),(1,1,'E_Torque','Nm'),(2,36,'T_FuelIn','°C'),(3,34,'RT_WaterIn','°C'),(4,35,'RT_WaterOut','°C'),(5,42,'T_LubOil','°C'),(6,43,'T_AirInlet','°C'),(7,12,'T1_CompIn','°C'),(8,38,'T2_CompOut','°C'),(9,39,'T2A_IntOut','°C'),(10,41,'T4_TurbOut','°C'),(12,9,'P_Luboil','bar'),(13,31,'P1_CompIn','bar'),(14,32,'P2_CompOut','bar'),(15,33,'P2A_IntOut','bar'),(16,28,'P4_ExBack','bar'),(17,19,'P2_Ambient','bar'),(18,113,'F_Flow','kg/hr'),(19,101,'Smoke','FSN'),(20,102,'Blowby','lpm'),(21,47,'TurboSpeed','rpm'),(22,113,'F_Flow','kg/hr'),(23,101,'Smoke','FSN'),(24,115,'Power','hp'),(25,47,'TurboSpeed','rpm'),(26,48,'Air_Flow','kg/cm^2'),(27,100,'Not Prog','Unit'),(28,100,'Not Prog','Unit'),(29,100,'Not Prog','Unit'),(30,100,'Not Prog','Unit'),(31,100,'Not Prog','Unit'),(32,100,'Not Prog','Unit'),(33,100,'Not_Prog','Unit'),(34,100,'Not Prog','Unit'),(35,100,'Not Prog','Unit'),(36,100,'Not Prog','Unit'),(37,100,'Not Prog','Unit'),(38,100,'Not Prog','Unit'),(39,100,'Not Prog','Unit'),(40,100,'Not Prog','Unit'),(41,100,'Not Prog','Unit'),(42,100,'Not Prog','Unit'),(43,100,'Not Prog','Unit'),(44,100,'Not Prog','Unit'),(45,100,'Not Prog','Unit'),(46,100,'Not Prog','Unit'),(47,100,'Not Prog','Unit'),(48,100,'Not Prog','Unit'),(49,100,'Not Prog','Unit'),(50,100,'Not Prog','Unit'),(51,100,'Not Prog','Unit'),(52,100,'Not Prog','Unit'),(53,100,'Not Prog','Unit'),(54,100,'Not Prog','Unit'),(55,100,'Not Prog','Unit'),(56,100,'Not Prog','Unit'),(57,100,'Not Prog','Unit'),(58,100,'Not Prog','Unit'),(59,100,'Not Prog','Unit'),(60,100,'Not Prog','Unit'),(61,100,'Not Prog','Unit'),(62,100,'Not Prog','Unit'),(63,100,'Not Prog','Unit'),(64,100,'Not Prog','Unit'),(65,100,'Not Prog','Unit'),(66,100,'Not Prog','Unit'),(67,100,'Not Prog','Unit'),(68,100,'Not Prog','Unit'),(69,100,'Not Prog','Unit'),(70,100,'Not Prog','Unit'),(71,100,'Not Prog','Unit'),(72,100,'Not Prog','Unit'),(73,100,'Not Prog','Unit'),(74,100,'Not Prog','Unit'),(75,100,'Not Prog','Unit'),(76,100,'Not Prog','Unit'),(77,100,'Not Prog','Unit'),(78,100,'Not Prog','Unit'),(79,100,'Not Prog','Unit'),(80,100,'Not Prog','Unit'),(81,100,'Not Prog','Unit'),(82,100,'Not Prog','Unit'),(83,100,'Not Prog','Unit'),(84,100,'Not Prog','Unit'),(85,100,'Not Prog','Unit'),(86,100,'Not Prog','Unit'),(87,100,'Not Prog','Unit'),(88,100,'Not Prog','Unit'),(89,100,'Not Prog','Unit'),(90,100,'Not Prog','Unit'),(91,100,'Not Prog','Unit'),(92,100,'Not Prog','Unit'),(93,100,'Not Prog','Unit'),(94,100,'Not Prog','Unit'),(95,100,'Not Prog','Unit'),(96,100,'Not Prog','Unit'),(97,100,'Not Prog','Unit'),(98,100,'Not Prog','Unit'),(99,100,'Not Prog','Unit'),(100,100,'Not Prog','Unit'),(101,100,'Not Prog','Unit'),(102,100,'Not Prog','Unit'),(103,100,'Not Prog','Unit'),(104,100,'Not Prog','Unit'),(105,100,'Not Prog','Unit'),(106,100,'Not Prog','Unit'),(107,100,'Not Prog','Unit'),(108,100,'Not Prog','Unit'),(109,100,'Not Prog','Unit'),(110,100,'Not Prog','Unit'),(111,100,'Not Prog','Unit'),(112,100,'Not Prog','Unit'),(113,100,'Not Prog','Unit'),(114,100,'Not Prog','Unit'),(115,100,'Not Prog','Unit'),(116,100,'Not Prog','Unit'),(117,100,'Not Prog','Unit'),(118,100,'Not Prog','Unit'),(119,100,'Not Prog','Unit'),(120,100,'Not Prog','Unit'),(121,100,'Not Prog','Unit'),(122,100,'Not Prog','Unit'),(123,100,'Not Prog','Unit'),(124,100,'Not Prog','Unit'),(125,100,'Not Prog','Unit'),(126,100,'Not Prog','Unit');
/*!40000 ALTER TABLE `tb_view` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-18 16:01:46
