CREATE DATABASE  IF NOT EXISTS `lim_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */;
USE `lim_db`;
-- MySQL dump 10.13  Distrib 8.0.11, for Win64 (x86_64)
--
-- Host: localhost    Database: lim_db
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
-- Table structure for table `lim_s_327`
--

DROP TABLE IF EXISTS `lim_s_327`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `lim_s_327` (
  `Pn` double NOT NULL,
  `ParameterName` varchar(30) DEFAULT NULL,
  `Lower1` varchar(8) DEFAULT NULL,
  `Low1` varchar(8) DEFAULT NULL,
  `High1` varchar(8) DEFAULT NULL,
  `Higher1` varchar(8) DEFAULT NULL,
  `MinV` varchar(8) DEFAULT NULL,
  `MaxV` varchar(8) DEFAULT NULL,
  `Unit` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Pn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lim_s_327`
--

LOCK TABLES `lim_s_327` WRITE;
/*!40000 ALTER TABLE `lim_s_327` DISABLE KEYS */;
INSERT INTO `lim_s_327` VALUES (0,'E_Speed','N','N','N','N','0','10000','r/min'),(1,'E_Torque','N','N','N','N','0','500.0','Nm'),(2,'SFC_RESET','N','N','N','N','0','100.0','Unit'),(3,'L_Weight','N','N','N','N','0','600.0','g'),(4,'SFC_Time','N','N','N','N','0','999.9','sec'),(5,'F_Weight','N','N','N','N','0','600.0','g'),(6,'T_Luboil','N','N','A115.0','I130.0','0','200.0','°C'),(7,'P_LubOil','N','A01.20','A07.00','N','0','10.00','bar'),(8,'Not_Prog','N','N','N','N','0','100.0','Unit'),(9,'Not_Prog','N','N','N','N','0','2.500','Unit'),(10,'T_WtrOut','N','N','A085.0','I090.0','0','200.0','°C'),(11,'T_AirIn','N','N','N','N','0','100.0','°C'),(12,'T_BIC','N','N','N','N','0','200.0','°C'),(13,'T_Exhaust','N','N','A720','I750','0','1000','°C'),(14,'Not_Prog','N','N','N','N','0.250','0.250','Unit'),(15,'Not_Prog','N','N','N','N','0','10.00','Unit'),(16,'P_ExBk','N','N','N','N','0','2.500','bar'),(17,'P_BIC','N','N','N','N','0','2.500','bar'),(18,'P_AIC','N','N','N','N','0','10.00','bar'),(19,'P_AirInDepr','N','N','N','N','-500.0','500.0','mbar'),(20,'T_EBT','N','N','A720','I750','0','1000','°C'),(21,'T_WtrIn','N','N','A085.0','I090.0','0','200.0','°C'),(22,'T_FuelIn','N','N','N','N','0','200.0','°C'),(23,'T_FuelOut','N','N','N','N','0','200.0','°C'),(24,'Not_Prog','N','N','N','N','0','100.0','Unit'),(25,'Not_Prog','N','N','N','N','0','200.0','Unit'),(26,'Not_Prog','N','N','N','N','0','200.0','Unit'),(27,'Not_Prog','N','N','N','N','0','200.0','Unit'),(28,'Not_Prog','N','N','N','N','0','200.0','Unit'),(29,'Not_Prog','N','N','N','N','0','200.0','Unit'),(30,'Not_Prog','N','N','N','N','0','200.0','Unit'),(31,'T_Dbt','N','N','N','N','0','1000','°C'),(32,'T_Wbt','N','N','N','N','0','1000','°C'),(33,'T_WtrOut','N','N','N','N','0','1000','°C'),(34,'Temp4','N','N','N','N','0','1000','°C'),(35,'Temp5','N','N','N','N','0','1000','°C'),(36,'Temp6','N','N','N','N','0','1000','°C'),(37,'Temp7','N','N','N','N','0','1000','°C'),(38,'Temp','N','N','N','N','0','1000','°C'),(39,'Not_Prog','N','N','N','N','0','1.000','Unit'),(40,'P_Atms','N','N','N','N','0.800','1.200','bar'),(41,'Not_Prog','N','N','N','N','0','1.000','Unit'),(42,'Not_Prog','N','N','N','N','0','1.000','Unit'),(43,'Not_Prog','N','N','N','N','0','1.000','Unit'),(44,'Not_Prog','N','N','N','N','0','1.000','Unit'),(45,'Not_Prog','N','N','N','N','0','1.000','Unit'),(46,'Press8','N','N','N','N','0','1000','bar'),(47,'Not_Prog','N','N','N','N','0','1000','Unit'),(48,'Not_Prog','N','N','N','N','0','1000','Unit'),(49,'Not_Prog','N','N','N','N','0','1000','Unit'),(50,'Not_Prog','N','N','N','N','0','1000','Unit'),(51,'Not_Prog','N','N','N','N','0','1000','Unit'),(52,'Not_Prog','N','N','N','N','0','1000','Unit'),(53,'Not_Prog','N','N','N','N','0','1000','Unit'),(54,'Not_Prog','N','N','N','N','0','1000','Unit'),(55,'Not_Prog','N','N','N','N','0','100.0','Unit'),(56,'Not_Prog','N','N','N','N','0','100.0','Unit'),(57,'Not_Prog','N','N','N','N','0','100.0','Unit'),(58,'Not_Prog','N','N','N','N','0','100.0','Unit'),(59,'Not_Prog','N','N','N','N','0','100.0','Unit'),(60,'Not_Prog','N','N','N','N','0','100.0','Unit'),(61,'Not_Prog','N','N','N','N','0','100.0','Unit'),(62,'Not_Prog','N','N','N','N','0','100.0','Unit'),(63,'Not_Prog','N','N','N','N','0','10000','Unit'),(64,'Not_Prog','N','N','N','N','0','100.0','Unit'),(65,'Not_Prog','N','N','N','N','0','100.0','Unit'),(66,'Not_Prog','N','N','N','N','0','100.0','Unit'),(67,'Not_Prog','N','N','N','N','0','75.00','Unit'),(68,'Not_Prog','N','N','N','N','0','10.0','Unit'),(69,'Not_Prog','N','N','N','N','0','100.0','Unit'),(70,'Not_Prog','N','N','N','N','0','100.0','Unit'),(71,'Not_Prog','N','N','N','N','0','100.0','Unit'),(72,'Not_Prog','N','N','N','N','0','100.0','Unit'),(73,'Not_Prog','N','N','N','N','0','100.0','Unit'),(74,'Not_Prog','N','N','N','N','0','100.0','Unit'),(75,'Not_Prog','N','N','N','N','0','100.0','Unit'),(76,'Not_Prog','N','N','N','N','0','100.0','Unit'),(77,'Not_Prog','N','N','N','N','0','100.0','Unit'),(78,'Not_Prog','N','N','N','N','0','100.0','Unit'),(79,'Not_Prog','N','N','N','N','0','100.0','Unit'),(80,'Not_Prog','N','N','N','N','0','100.0','Unit'),(81,'Not_Prog','N','N','N','N','0','100.0','Unit'),(82,'Not_Prog','N','N','N','N','0','100.0','Unit'),(83,'Not_Prog','N','N','N','N','0','100.0','Unit'),(84,'Not_Prog','N','N','N','N','0','100.0','Unit'),(85,'Not_Prog','N','N','N','N','0','100.0','Unit'),(86,'Not_Prog','N','N','N','N','0','100.0','Unit'),(87,'Not_Prog','N','N','N','N','0','100.0','Unit'),(88,'Not_Prog','N','N','N','N','0','100.0','Unit'),(89,'Not_Prog','N','N','N','N','0','100.0','Unit'),(90,'Not_Prog','N','N','N','N','0','100.0','Unit'),(91,'Not_Prog','N','N','N','N','0','100.0','Unit'),(92,'Not_Prog','N','N','N','N','0','100.0','Unit'),(93,'Not_Prog','N','N','N','N','0','100.0','Unit'),(94,'Not_Prog','N','N','N','N','0','100.0','Unit'),(95,'Not_Progv','N','N','N','N','0','100.0','Unit'),(96,'Not_Prog','N','N','N','N','0','100.0','Unit'),(97,'Not_Prog','N','N','N','N','0','100.0','Unit'),(98,'Not_Prog','N','N','N','N','0','100.0','Unit');
/*!40000 ALTER TABLE `lim_s_327` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-16 16:54:29
