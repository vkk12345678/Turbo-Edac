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
-- Table structure for table `tb_endu`
--

DROP TABLE IF EXISTS `tb_endu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_endu` (
  `N` int(11) NOT NULL DEFAULT '0',
  `Cn` int(11) DEFAULT NULL,
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_endu`
--

LOCK TABLES `tb_endu` WRITE;
/*!40000 ALTER TABLE `tb_endu` DISABLE KEYS */;
INSERT INTO `tb_endu` VALUES (0,0,'E_Speed','rpm'),(1,1,'E_Torque','Nm'),(2,7,'P_LubOil','bar'),(3,16,'P_ExBk','bar'),(4,17,'P_BIC','bar'),(5,18,'P_AIC','bar'),(6,19,'P_AirInDepr','mbar'),(7,6,'T_Luboil','°C'),(8,10,'T_WtrOut','°C'),(9,11,'T_AirIn','°C'),(10,12,'T_BIC','°C'),(11,13,'T_Exhaust','°C'),(12,20,'T_EBT','°C'),(13,72,'Blby','lpm'),(14,104,'F_Time','Secs'),(15,71,'Air Flow','ltr/min'),(16,105,'C_Factor','***'),(17,111,'C_Power','kW'),(18,112,'C_SFC','g/kW.Hr'),(19,109,'Inj_Qty','mm^3/str/Cyln'),(20,113,'F_Flow','kg/hr'),(21,119,'bmep','bar'),(22,47,'TurboSpeed','rpm'),(23,122,'Log_Tm','***'),(24,100,'Not_Prog','Unit'),(25,100,'Not_Prog','Unit'),(26,100,'Not_Prog','Unit'),(27,100,'Not_Prog','Unit'),(28,100,'Not_Prog','Unit'),(29,100,'Not_Prog','Unit');
/*!40000 ALTER TABLE `tb_endu` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-16 16:54:09
