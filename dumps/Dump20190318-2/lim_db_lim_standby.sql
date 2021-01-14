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
-- Table structure for table `lim_standby`
--

DROP TABLE IF EXISTS `lim_standby`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `lim_standby` (
  `Pn` float NOT NULL,
  `ParameterName` varchar(30) DEFAULT NULL,
  `Lower1` varchar(8) DEFAULT NULL,
  `Low1` varchar(8) DEFAULT NULL,
  `High1` varchar(8) DEFAULT NULL,
  `Higher1` varchar(8) DEFAULT NULL,
  `MinV` varchar(8) DEFAULT NULL,
  `MaxV` varchar(8) DEFAULT NULL,
  `Unit` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Pn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lim_standby`
--

LOCK TABLES `lim_standby` WRITE;
/*!40000 ALTER TABLE `lim_standby` DISABLE KEYS */;
INSERT INTO `lim_standby` VALUES (0,'E_Speed','N','N','N','N','0','10000','r/min'),(1,'E_Torque','N','N','N','N','0','500.0','Nm'),(2,'SFC_RESET','N','N','N','N','0','100.0','Unit'),(3,'L_Weight','N','N','N','N','0','600.0','g'),(4,'SFC_Time','N','N','N','N','0','999.9','sec'),(5,'F_Weight','N','N','N','N','0','600.0','g'),(6,'Not_Prog','N','N','N','N','0','200.0','°C'),(7,'Not_Prog','N','N','N','N','0','200.0','°C'),(8,'Not_Prog','N','N','N','N','800','1200','mbar'),(9,'P_Luboil','N','A01.20','N','N','0','10.00','bar'),(10,'T_Dbt','N','N','N','N','0','1000','°C'),(11,'T_Wbt','N','N','N','N','0','1000','°C'),(12,'T_WtrOut','N','N','N','N','0','1000','°C'),(13,'Temp4','N','N','N','N','0','1000','°C'),(14,'Temp5','N','N','N','N','0','1000','°C'),(15,'Temp6','N','N','N','N','0','1000','°C'),(16,'Temp7','N','N','N','N','0','1000','°C'),(17,'Temp8','N','N','N','N','0','1000','°C'),(18,'P1','N','N','N','N','0','2.000','bar'),(19,'P_Atms','N','N','N','N','0.800','1.200','bar'),(20,'P3','N','N','N','N','0','6.000','bar'),(21,'P4','N','N','N','N','0','1.000','bar'),(22,'P5','N','N','N','N','0','10.00','bar'),(23,'P6','N','N','N','N','0','10.00','bar'),(24,'P7','N','N','N','N','0','10.00','bar'),(25,'P8','N','N','N','N','0','1000','bar'),(26,'Press_01','N','N','N','N','0','4.000','bar'),(27,'Press_02','N','N','N','N','0','4.000','bar'),(28,'Press_03','N','N','N','N','0','4.000','bar'),(29,'Press_04','N','N','N','N','0','4.000','bar'),(30,'Press_05','N','N','N','N','0','4.000','bar'),(31,'Press_06','N','N','N','N','0','1.600','bar'),(32,'Press_07','N','N','N','N','0','4.000','bar'),(33,'Press_08','N','N','N','N','0','4.000','bar'),(34,'R_WtrIn','N','N','N','N','0','200.0','°C'),(35,'R_WtrOut','N','N','A075.0','N','0','200.0','°C'),(36,'RTD_03','N','N','N','N','0','200.0','°C'),(37,'RTD_04','N','N','N','N','0','200.0','°C'),(38,'Temp_01','N','N','N','N','0','1000','°C'),(39,'Temp_02','N','N','N','N','0','1000','°C'),(40,'Temp_03','N','N','N','N','0','1000','°C'),(41,'Temp_04','N','N','N','N','0','1000','°C'),(42,'Temp_05','N','N','N','N','0','1000','°C'),(43,'Temp_06','N','N','N','N','0','1000','°C'),(44,'Temp_07','N','N','N','N','0','1000','°C'),(45,'Temp_08','N','N','N','N','0','1000','°C'),(46,'Turbo_Speed','N','N','N','N','0','500000','rpm'),(47,'Air Flow','N','N','N','N','0','10.00','kg/hr'),(48,'Not_Prog','N','N','N','N','0','10.00','bar'),(49,'Not_Prog','N','N','N','N','0','10.00','bar'),(50,'Not_Prog','N','N','N','N','0','1000','kg/hr'),(51,'Not_Prog','N','N','N','N','0','100.0','Unit'),(52,'Not_Prog','N','N','N','N','0','100.0','Unit'),(53,'Not_Prog','N','N','N','N','0','100.0','Unit'),(54,'Not_Prog','N','N','N','N','0','100.0','Unit'),(55,'Not_Prog','N','N','N','N','0','100.0','Unit'),(56,'Not_Prog','N','N','N','N','0','100.0','Unit'),(57,'Not_Prog','N','N','N','N','0','100.0','Unit'),(58,'Not_Prog','N','N','N','N','0','100.0','Unit'),(59,'Not_Prog','N','N','N','N','0','100.0','Unit'),(60,'Not_Prog','N','N','N','N','0','100.0','Unit'),(61,'Not_Prog','N','N','N','N','0','100.0','Unit'),(62,'Not_Prog','N','N','N','N','0','100.0','Unit'),(63,'Not_Prog','N','N','N','N','0','100.0','Unit'),(64,'Not_Prog','N','N','N','N','0','100.0','Unit'),(65,'Not_Prog','N','N','N','N','0','100.0','Unit'),(66,'Not_Prog','N','N','N','N','0','100.0','Unit'),(67,'Not_Prog','N','N','N','N','0','100.0','Unit'),(68,'Not_Prog','N','N','N','N','0','100.0','Unit'),(69,'Not_Prog','N','N','N','N','0','100.0','Unit'),(70,'Not_Prog','N','N','N','N','0','100.0','Unit'),(71,'Not_Prog','N','N','N','N','0','100.0','Unit'),(72,'Not_Prog','N','N','N','N','0','100.0','Unit'),(73,'Not_Prog','N','N','N','N','0','100.0','Unit'),(74,'Not_Progv','N','N','N','N','0','100.0','Unit'),(75,'Not_Prog','N','N','N','N','0','100.0','Unit'),(76,'Not_Prog','N','N','N','N','0','100.0','Unit'),(77,'Not_Prog','N','N','N','N','0','100.0','Unit'),(78,'Not_Prog','N','N','N','N','0','100.0','Unit'),(79,'Not_Prog','N','N','N','N','0','100','unit'),(80,'Not_Prog','N','N','N','N','0','100','Unit'),(81,'Not_Prog','N','N','N','N','0','100','Unit'),(82,'Not_Prog','N','N','N','N','0','100','Unit'),(83,'Not_Prog','N','N','N','N','0','100','Unit'),(84,'Not_Prog','N','N','N','N','0','100','Unit'),(85,'Not_Prog','N','N','N','N','0','100','Unit'),(86,'Not_Prog','N','N','N','N','0','100','Unit'),(87,'Not_Prog','N','N','N','N','0','100','Unit'),(88,'Not_Prog','N','N','N','N','0','100','Unit'),(89,'Not_Prog','N','N','N','N','0','100','Unit'),(90,'Not_Prog','N','N','N','N','0','100','Unit'),(91,'Not_Prog','N','N','N','N','0','100','Unit'),(92,'Not_Prog','N','N','N','N','0','100','Unit'),(93,'Not_Prog','N','N','N','N','0','100','Unit'),(94,'Not_Prog','N','N','N','N','0','100','Unit'),(95,'Not_Prog','N','N','N','N','0','100','Unit'),(96,'Not_Prog','N','N','N','N','0','100','Unit'),(97,'Not_Prog','N','N','N','N','0','100','Unit'),(98,'Not_Prog','N','N','N','N','0','100','Unit');
/*!40000 ALTER TABLE `lim_standby` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-18 16:02:24
