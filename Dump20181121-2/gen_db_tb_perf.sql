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
-- Table structure for table `tb_perf`
--

DROP TABLE IF EXISTS `tb_perf`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_perf` (
  `N` int(11) DEFAULT NULL,
  `Cn` int(11) DEFAULT NULL,
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_perf`
--

LOCK TABLES `tb_perf` WRITE;
/*!40000 ALTER TABLE `tb_perf` DISABLE KEYS */;
INSERT INTO `tb_perf` VALUES (0,0,'E_Speed','r/min'),(1,1,'E_Torque','Nm'),(2,6,'T_Luboil','°C'),(3,10,'T_WtrOut','°C'),(4,13,'T_Exhaust','°C'),(5,11,'T_AirIn','°C'),(6,20,'T_EBT','°C'),(7,21,'T_WtrIn','°C'),(8,22,'T_FuelIn','°C'),(9,16,'P_ExBk','bar'),(10,19,'P_AirInDepr','mbar'),(11,17,'P_BIC','bar'),(12,18,'P_AIC','bar'),(13,7,'P_LubOil','bar'),(14,119,'bmep','bar'),(15,115,'A_Power','hp'),(16,116,'C_Power','hp'),(17,111,'C_Power','kW'),(18,72,'Blby','lpm'),(19,104,'F_Time','Secs');
/*!40000 ALTER TABLE `tb_perf` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-11-21  9:55:45
