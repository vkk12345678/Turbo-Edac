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
-- Table structure for table `tb_scrn`
--

DROP TABLE IF EXISTS `tb_scrn`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_scrn` (
  `Pn` varchar(50) DEFAULT NULL,
  `Cn` int(11) DEFAULT '0',
  `PName` varchar(50) DEFAULT NULL,
  `Unit` varchar(50) DEFAULT NULL,
  `N` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`N`),
  UNIQUE KEY `N_UNIQUE` (`N`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_scrn`
--

LOCK TABLES `tb_scrn` WRITE;
/*!40000 ALTER TABLE `tb_scrn` DISABLE KEYS */;
INSERT INTO `tb_scrn` VALUES ('1.1',46,'BlowBy','lpm',0),('1.2',47,'TurboSpeed','rpm',1),('1.3',48,'Air_Flow','kg/cm^2',2),('1.4',49,'A_Speed','rpm',3),('1.5',50,'A_Torque','Nm',4),('1.6',100,'Not_Prog','Unit',5),('1.7',101,'Smoke','FSN',6),('1.8',100,'Not_Prog','Unit',7),('2.1',10,'T_Dbt','°C',8),('2.2',11,'T_Wbt','°C',9),('2.3',12,'T1_CompIn','°C',10),('2.4',13,'T_Spare1','°C',11),('2.5',14,'Temp5','°C',12),('2.6',15,'Temp6','°C',13),('2.7',16,'Temp7','°C',14),('2.8',17,'Temp8','°C',15),('3.1',18,'P1','bar',16),('3.2',19,'P2_Ambient','mbar',17),('3.3',20,'P3','bar',18),('3.4',21,'P4','bar',19),('3.5',22,'P5','bar',20),('3.6',23,'P6','bar',21),('3.7',24,'P7','bar',22),('3.8',25,'P8','bar',23),('4.1',26,'Press_01','bar',24),('4.2',27,'Press_02','bar',25),('4.3',28,'P4_ExBack','bar',26),('4.4',29,'Press_04','bar',27),('4.5',30,'P_Spare','bar',28),('4.6',31,'P1_CompIn','bar',29),('4.7',32,'P2_CompOut','bar',30),('4.8',33,'P2A_IntOut','bar',31),('5.1',34,'RT_WaterIn','°C',32),('5.2',35,'RT_WaterOut','°C',33),('5.3',36,'T_FuelIn','°C',34),('5.4',37,'R_Spare_01','°C',35),('5.5',100,'Not_Prog','Unit',36),('5.6',100,'Not_Prog','Unit',37),('5.7',100,'Not_Prog','Unit',38),('5.8',100,'Not_Prog','Unit',39),('6.1',38,'T2_CompOut','°C',40),('6.2',39,'T2A_IntOut','°C',41),('6.3',40,'T3_TurbIn','°C',42),('6.4',41,'T4_TurbOut','°C',43),('6.5',42,'T_LubOil','°C',44),('6.6',43,'T_AirInlet','°C',45),('6.7',44,'T_Ambient','°C',46),('6.8',45,'Temp_08','°C',47),('7.7',100,'Not_Prog','Unit',48),('8.1',100,'Not_Prog','Unit',49),('8.2',100,'Not_Prog','Unit',50),('8.3',100,'Not_Prog','Unit',51),('8.4',100,'Not_Prog','Unit',52),('8.5',100,'Not_Prog','Unit',53),('8.6',100,'Not_Prog','Unit',54),('8.7',100,'Not_Prog','Unit',55),('9.1',100,'Not_Prog','Unit',56),('9.2',100,'Not_Prog','Unit',57),('9.3',100,'Not_Prog','Unit',58),('9.4',100,'Not_Prog','Unit',59),('9.5',100,'Not_Prog','Unit',60),('9.6',100,'Not_Prog','Unit',61),('9.7',100,'Not_Prog','Unit',62),('10.1',100,'Not_Prog','Unit',63),('10.2',100,'Not_Prog','Unit',64),('10.3',100,'Not_Prog','Unit',65),('10.4',100,'Not_Prog','Unit',66),('10.5',100,'Not_Prog','Unit',67),('10.6',100,'Not_Prog','Unit',68),('10.7',100,'Not_Prog','Unit',69);
/*!40000 ALTER TABLE `tb_scrn` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-18 16:01:44
