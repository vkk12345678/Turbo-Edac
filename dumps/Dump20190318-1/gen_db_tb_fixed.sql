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
-- Table structure for table `tb_fixed`
--

DROP TABLE IF EXISTS `tb_fixed`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_fixed` (
  `N` int(11) NOT NULL DEFAULT '0',
  `Cn` int(11) DEFAULT '0',
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_fixed`
--

LOCK TABLES `tb_fixed` WRITE;
/*!40000 ALTER TABLE `tb_fixed` DISABLE KEYS */;
INSERT INTO `tb_fixed` VALUES (0,0,'E_Speed','rpm'),(1,1,'E_Torque','Nm'),(2,6,'P_WtrIn','bar'),(3,18,'P_FuelIn','bar'),(4,7,'P_LubOil','bar'),(5,7,'T_WtrOut','°C'),(6,11,'T_Exhaust','°C'),(7,6,'T_LubOil','°C'),(8,10,'T_DryBulb','°C'),(9,11,'T_WetBulb','°C'),(10,19,'P_Atms','bar'),(11,120,'Rel_Hum','%'),(12,3,'SFC_Wt','g'),(13,4,'SFC_Time','s'),(14,72,'Blowby','lpm'),(15,100,'Not_Prog','lpm'),(16,100,'Lambda','Unit'),(17,71,'Temp_Pid1','°C'),(18,100,'Temp_Pid2','°C'),(19,100,'A_FuelWt','g'),(20,100,'Not_Prog','g'),(21,100,'Not_Prog','Unit'),(22,100,'Not_Prog','Unit'),(23,100,'Not_Prog','Unit'),(24,100,'Not_Prog','Unit'),(25,100,'Not_Prog','Unit'),(26,100,'Not_Prog','Unit'),(27,100,'Not_Prog','Unit'),(28,100,'Not_Prog','Unit'),(29,100,'Not_Prog','Unit'),(30,100,'Not_Prog','Unit');
/*!40000 ALTER TABLE `tb_fixed` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-18 16:02:10
