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
INSERT INTO `tb_scrn` VALUES ('1.1',0,'E_Speed','r/min',0),('1.2',1,'E_Torque','Nm',1),('1.3',2,'SFC_RESET','Unit',2),('1.4',3,'L_Weight','g',3),('1.5',4,'SFC_Time','sec',4),('1.6',5,'F_Weight','g',5),('1.7',100,'Not_Prog','Unit',6),('1.8',100,'Not_Prog','Unit',7),('2.1',10,'T_Dbt','°C',8),('2.2',11,'T_Wbt','°C',9),('2.3',12,'T_WtrOut','°C',10),('2.4',13,'Temp4','°C',11),('2.5',14,'Temp5','°C',12),('2.6',15,'Temp6','°C',13),('2.7',16,'Temp7','°C',14),('2.8',17,'Temp8','°C',15),('3.1',18,'P1','bar',16),('3.2',19,'P_Atms','bar',17),('3.3',20,'P3','mbar',18),('3.4',21,'P4','bar',19),('3.5',22,'P5','bar',20),('3.6',23,'P6','bar',21),('3.7',24,'P7','bar',22),('3.8',25,'P8','bar',23),('4.1',26,'Temp9','°C',24),('4.2',27,'Temp10','°C',25),('4.3',28,'Temp11','°C',26),('4.4',29,'Temp12','°C',27),('4.5',30,'Temp13','°C',28),('4.6',31,'Temp14','°C',29),('4.7',32,'Temp15','°C',30),('4.8',33,'Temp16','°C',31),('5.1',34,'Ambient Temp','°C',32),('5.2',35,'R2','°C',33),('5.3',36,'R3','°C',34),('5.4',37,'R4','°C',35),('5.5',38,'P9','bar',36),('5.6',39,'P10','bar',37),('5.7',40,'P11','bar',38),('5.8',41,'P12','bar',39),('6.6',43,'P14','bar',40),('6.7',43,'P14','bar',41),('7.1',44,'P15','bar',42),('7.2',46,'P12','bar',43),('7.3',47,'P13','bar',44),('7.4',48,'P14','bar',45),('7.5',49,'P15','bar',46),('7.6',50,'P16','bar',47),('7.7',100,'Not_Prog','Unit',48),('8.1',100,'Not_Prog','Unit',49),('8.2',100,'Not_Prog','Unit',50),('8.3',100,'Not_Prog','Unit',51),('8.4',100,'Not_Prog','Unit',52),('8.5',100,'Not_Prog','Unit',53),('8.6',100,'Not_Prog','Unit',54),('8.7',100,'Not_Prog','Unit',55),('9.1',100,'Not_Prog','Unit',56),('9.2',100,'Not_Prog','Unit',57),('9.3',100,'Not_Prog','Unit',58),('9.4',100,'Not_Prog','Unit',59),('9.5',100,'Not_Prog','Unit',60),('9.6',100,'Not_Prog','Unit',61),('9.7',100,'Not_Prog','Unit',62),('10.1',100,'Not_Prog','Unit',63),('10.2',100,'Not_Prog','Unit',64),('10.3',100,'Not_Prog','Unit',65),('10.4',100,'Not_Prog','Unit',66),('10.5',100,'Not_Prog','Unit',67),('10.6',100,'Not_Prog','Unit',68),('10.7',100,'Not_Prog','Unit',69);
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

-- Dump completed on 2018-11-21  9:55:47
