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
INSERT INTO `tb_view` VALUES (0,0,'E_Speed','r/min'),(1,1,'E_Torque','Nm'),(2,10,'T_Luboil','°C'),(3,11,'P_LubOil','bar'),(4,12,'T_WtrOut','°C'),(5,13,'T_Exhaust','°C'),(6,14,'T_WtrIn','°C'),(7,15,'T_FuelIn','°C'),(8,16,'Air Flow','kg/hr'),(9,17,'Blby','lpm'),(10,18,'T_CAC','°C'),(12,20,'SmkValue','m¯¹'),(13,21,'F_Time','Secs'),(14,22,'C_Factor','***'),(15,26,'C_Power','hp'),(16,27,'C_SFC','g/hphr'),(17,28,'bmep','bar'),(18,29,'ToTal_Hrs','Unit'),(19,30,'Alarm','Unit'),(20,124,'Not_Prog','Unit'),(21,100,'Not_Prog','Unit'),(22,38,'T-Spare1','°C'),(23,100,'Not Prog','Unit'),(24,100,'Not Prog','Unit'),(25,100,'Not_Prog','Unit'),(26,100,'Not Prog','Unit'),(27,100,'Not Prog','Unit'),(28,100,'Not Prog','Unit'),(29,100,'Not Prog','Unit'),(30,100,'Not Prog','Unit'),(31,100,'Not Prog','Unit'),(32,100,'Not Prog','Unit'),(33,100,'Not_Prog','Unit'),(34,100,'Not Prog','Unit'),(35,100,'Not Prog','Unit'),(36,100,'Not Prog','Unit'),(37,100,'Not Prog','Unit'),(38,100,'Not Prog','Unit'),(39,100,'Not Prog','Unit'),(40,100,'Not Prog','Unit'),(41,100,'Not Prog','Unit'),(42,100,'Not Prog','Unit'),(43,100,'Not Prog','Unit'),(44,100,'Not Prog','Unit'),(45,100,'Not Prog','Unit'),(46,100,'Not Prog','Unit'),(47,100,'Not Prog','Unit'),(48,100,'Not Prog','Unit'),(49,100,'Not Prog','Unit'),(50,100,'Not Prog','Unit'),(51,100,'Not Prog','Unit'),(52,100,'Not Prog','Unit'),(53,100,'Not Prog','Unit'),(54,100,'Not Prog','Unit'),(55,100,'Not Prog','Unit'),(56,100,'Not Prog','Unit'),(57,100,'Not Prog','Unit'),(58,100,'Not Prog','Unit'),(59,100,'Not Prog','Unit'),(60,100,'Not Prog','Unit'),(61,100,'Not Prog','Unit'),(62,100,'Not Prog','Unit'),(63,100,'Not Prog','Unit'),(64,100,'Not Prog','Unit'),(65,100,'Not Prog','Unit'),(66,100,'Not Prog','Unit'),(67,100,'Not Prog','Unit'),(68,100,'Not Prog','Unit'),(69,100,'Not Prog','Unit'),(70,100,'Not Prog','Unit'),(71,100,'Not Prog','Unit'),(72,100,'Not Prog','Unit'),(73,100,'Not Prog','Unit'),(74,100,'Not Prog','Unit'),(75,100,'Not Prog','Unit'),(76,100,'Not Prog','Unit'),(77,100,'Not Prog','Unit'),(78,100,'Not Prog','Unit'),(79,100,'Not Prog','Unit'),(80,100,'Not Prog','Unit'),(81,100,'Not Prog','Unit'),(82,100,'Not Prog','Unit'),(83,100,'Not Prog','Unit'),(84,100,'Not Prog','Unit'),(85,100,'Not Prog','Unit'),(86,100,'Not Prog','Unit'),(87,100,'Not Prog','Unit'),(88,100,'Not Prog','Unit'),(89,100,'Not Prog','Unit'),(90,100,'Not Prog','Unit'),(91,100,'Not Prog','Unit'),(92,100,'Not Prog','Unit'),(93,100,'Not Prog','Unit'),(94,100,'Not Prog','Unit'),(95,100,'Not Prog','Unit'),(96,100,'Not Prog','Unit'),(97,100,'Not Prog','Unit'),(98,100,'Not Prog','Unit'),(99,100,'Not Prog','Unit'),(100,100,'Not Prog','Unit'),(101,100,'Not Prog','Unit'),(102,100,'Not Prog','Unit'),(103,100,'Not Prog','Unit'),(104,100,'Not Prog','Unit'),(105,100,'Not Prog','Unit'),(106,100,'Not Prog','Unit'),(107,100,'Not Prog','Unit'),(108,100,'Not Prog','Unit'),(109,100,'Not Prog','Unit'),(110,100,'Not Prog','Unit'),(111,100,'Not Prog','Unit'),(112,100,'Not Prog','Unit'),(113,100,'Not Prog','Unit'),(114,100,'Not Prog','Unit'),(115,100,'Not Prog','Unit'),(116,100,'Not Prog','Unit'),(117,100,'Not Prog','Unit'),(118,100,'Not Prog','Unit'),(119,100,'Not Prog','Unit'),(120,100,'Not Prog','Unit'),(121,100,'Not Prog','Unit'),(122,100,'Not Prog','Unit'),(123,100,'Not Prog','Unit'),(124,100,'Not Prog','Unit'),(125,100,'Not Prog','Unit'),(126,100,'Not Prog','Unit');
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

-- Dump completed on 2018-11-21  9:55:49
