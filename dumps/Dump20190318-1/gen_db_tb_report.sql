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
-- Table structure for table `tb_report`
--

DROP TABLE IF EXISTS `tb_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_report` (
  `N` int(11) NOT NULL DEFAULT '0',
  `Cn` int(11) DEFAULT '0',
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_report`
--

LOCK TABLES `tb_report` WRITE;
/*!40000 ALTER TABLE `tb_report` DISABLE KEYS */;
INSERT INTO `tb_report` VALUES (0,0,'E_Speed','rpm'),(1,1,'E_Torque','Nm'),(2,4,'F_Time','s'),(3,6,'T_Fuel','°C'),(4,10,'T_WtrIn','°C'),(5,10,'T_WtrOut','°C'),(6,11,'T_LuvOil','°C'),(7,12,'T_AirIn','°C'),(8,0,'T_1','°C'),(9,100,'T_2','°C'),(10,0,'T_2A','°C'),(11,66,'T_3','°C'),(12,104,'T_4','°C'),(13,12,'T_Dbt','°C'),(14,39,'T_Wbt','°C'),(15,100,'P_Oil','bar'),(16,31,'P_1','bar'),(17,3,'P_2','bar'),(18,100,'P_2A','bar'),(19,100,'P_3','bar'),(20,29,'P_3A','bar'),(21,29,'P_4','bar'),(22,100,'P_Ambt','bar'),(23,100,'F_Cons.','g/s'),(24,100,'Second Row','************'),(25,100,'E_Speed','rpm'),(26,100,'E_Torque','Nm'),(27,100,'Power','kW'),(28,100,'SFC','g/kW'),(29,100,'C.F','**'),(30,100,'C.Power','kW'),(31,100,'C_SFC','g/kw'),(32,100,'Smoke','N%'),(33,100,'Smoke','m-1');
/*!40000 ALTER TABLE `tb_report` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-18 16:02:08
