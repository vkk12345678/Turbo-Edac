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
-- Table structure for table `tb_perf`
--

DROP TABLE IF EXISTS `tb_perf`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_perf` (
  `N` int(11) NOT NULL,
  `Cn` int(11) DEFAULT NULL,
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_perf`
--

LOCK TABLES `tb_perf` WRITE;
/*!40000 ALTER TABLE `tb_perf` DISABLE KEYS */;
INSERT INTO `tb_perf` VALUES (0,0,'E_Speed','r/min'),(1,1,'E_Torque','Nm'),(2,36,'T_FuelIn','°C'),(3,34,'RT_WaterIn','°C'),(4,35,'RT_WaterOut','°C'),(5,42,'T_LubOil','°C'),(6,43,'T_AirInlet','°C'),(7,12,'T1_CompIn','°C'),(8,38,'T2_CompOut','°C'),(9,39,'T2A_IntOut','°C'),(10,40,'T3_TurbIn','°C'),(11,41,'T4_TurbOut','°C'),(12,10,'T_Dbt','°C'),(13,11,'T_Wbt','°C'),(14,44,'T_Ambient','°C'),(15,9,'P_Luboil','bar'),(16,31,'P1_CompIn','bar'),(17,32,'P2_CompOut','bar'),(18,33,'P2A_IntOut','bar'),(19,20,'P3','bar'),(20,28,'P4_ExBack','bar'),(21,19,'P_Ambient','bar'),(22,113,'F_Flow','kg/hr'),(23,4,'SFC_TM','Sec');
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

-- Dump completed on 2019-03-18 16:02:09
