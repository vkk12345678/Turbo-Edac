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
-- Table structure for table `tb_std`
--

DROP TABLE IF EXISTS `tb_std`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_std` (
  `ParameterNo` int(11) NOT NULL DEFAULT '0',
  `ParameterName` varchar(50) DEFAULT NULL,
  `MinVal` varchar(10) DEFAULT NULL,
  `MaxVal` varchar(10) DEFAULT NULL,
  `Unit` varchar(20) DEFAULT NULL,
  `ShortName` varchar(50) DEFAULT NULL,
  `Marked` tinyint(1) DEFAULT NULL,
  `Minip` varchar(50) DEFAULT NULL,
  `Maxip` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ParameterNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_std`
--

LOCK TABLES `tb_std` WRITE;
/*!40000 ALTER TABLE `tb_std` DISABLE KEYS */;
INSERT INTO `tb_std` VALUES (0,'Engine Revolutions','0','10000','r/min','E_Speed',1,'0','10'),(1,'Serial Instrument','0','1000','Nm','E_Torque',1,'0','10'),(2,'Serial Instrument','0','100.0','Unit','SFC_RESET',1,'0','10'),(3,'Serial Instrument','0','600.0','g','L_Weight',1,'0','10'),(4,'Serial Instrument','0','999.9','sec','SFC_Time',1,'0','10'),(5,'Serial Instrument','0','600.0','g','F_Weight',1,'0','10'),(6,'Serial Instrument','0','200.0','°C','Not_Prog',1,'0','10'),(7,'Serial Instrument','0','200.0','°C','Not_Prog',1,'0','10'),(8,'Serial Instrument','0','10.00','mbar','Not_Prog',1,'0','10'),(9,'Serial Instrument','0','10.00','bar','P_Luboil',1,'0','10'),(10,'ADAM Module -1.1','0','1000','°C','T_Dbt',1,'0','10'),(11,'ADAM Module -1.2','0','1000','°C','T_Wbt',1,'0','10'),(12,'ADAM Module -1.3','0','1000','°C','T1_CompIn',1,'0','10'),(13,'ADAM Module -1.4','0','1000','°C','T_Spare1',1,'0','10'),(14,'ADAM Module -1.5','0','1000','°C','Temp5',1,'0','10'),(15,'ADAM Module -1.6','0','1000','°C','Temp6',1,'0','10'),(16,'ADAM Module -1.7','0','1000','°C','Temp7',1,'0','10'),(17,'ADAM Module -1.8','0','1000','°C','Temp8',1,'0','10'),(18,'ADAM Module -2.1','0','10.00','bar','P1',1,'0','10'),(19,'ADAM Module -2.2','0.850','1.200','bar','P2_Ambient',1,'0','10'),(20,'ADAM Module -2.3','0','6.000','bar','P3',1,'0','10'),(21,'ADAM Module -2.4','0','1.000','bar','P4',1,'0','10'),(22,'ADAM Module -2.5','0','10.00','bar','P5',1,'0','10'),(23,'ADAM Module -2.6','0','10.00','bar','P6',1,'0','10'),(24,'ADAM Module -2.7','0','10.00','bar','P7',1,'0','10'),(25,'ADAM Module -2.8','0','10.00','bar','P8',1,'0','10'),(26,'Gantner Module -3.1','0','4.000','bar','Press_01',1,'0','10'),(27,'Gantner Module -3.2','0','4.000','bar','Press_02',1,'0','10'),(28,'Gantner Module -3.3','0','4.000','bar','P4_ExBack',1,'0','10'),(29,'Gantner Module -3.4','0','4.000','bar','Press_04',1,'0','10'),(30,'Gantner Module -4.1','0','4.000','bar','P_Spare',1,'0','10'),(31,'Gantner Module -4.2','0','1.600','bar','P1_CompIn',1,'0','10'),(32,'Gantner Module -4.3','0','4.000','bar','P2_CompOut',1,'0','10'),(33,'Gantner Module -4.4','0','4.000','bar','P2A_IntOut',1,'0','10'),(34,'Gantner Module -4.5','0','200.0','°C','RT_WaterIn',1,'0','10'),(35,'Gantner Module -4.6','0','200.0','°C','RT_WaterOut',1,'0','10'),(36,'Gantner Module -4.7','0','200.0','°C','T_FuelIn',1,'0','10'),(37,'Gantner Module -4.8','0','200.0','°C','R_Spare_01',1,'0','10'),(38,'Gantner Module -5.1','0','1000','°C','T2_CompOut',1,'0','10'),(39,'Gantner Module -5.2','0','1000','°C','T2A_IntOut',1,'0','10'),(40,'Gantner Module -5.3','0','1000','°C','T3_TurbIn',1,'0','10'),(41,'Gantner Module -5.4','0','1000','°C','T4_TurbOut',1,'0','10'),(42,'Gantner Module -5.5','0','1000','°C','T_LubOil',1,'0','10'),(43,'Gantner Module -5.6','0','1000','°C','T_AirInlet',1,'0','10'),(44,'Gantner Module -5.7','0','1000','°C','T_Ambient',1,'0','10'),(45,'Gantner Module -5.8','0','1000','°C','Temp_08',1,'0','10'),(46,'Analog Input-1','0','75.00','lpm','BlowBy',1,'0','10'),(47,'Analog Input-2','0','400000','rpm','TurboSpeed',1,'0','10'),(48,'Analog Input-3','0','22.65','kg/hr','Air_Flow',1,'0','10'),(49,'Analog Input-4','0','10000','rpm','A_Speed',1,'0','10'),(50,'Analog Input-5','0','1000','Nm','A_Torque',1,'0','10'),(51,'Analog Input-6','0','100.0','Unit','Ana_7',1,'0','10'),(52,'Analog Input-7','0','100.0','Unit','Ana_8',1,'0','10'),(53,'Analog Input-8','0','100.0','Unit','Not_Prog',0,'0','10'),(54,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(55,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(56,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(57,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(58,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(59,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(60,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(61,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(62,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(63,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(64,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(65,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(66,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(67,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(68,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(69,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(70,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(71,'Analog Input1','0','150','lpm','BlowBy ',0,'0','10'),(72,'Analog Input2','0','50000','rpm','T_Speed',0,'0','10'),(73,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(74,'Not_Prog','0','100.0','Unit','Not_Progv',0,'0','10'),(75,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(76,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(77,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(78,'Not_Prog','0','100.0','Unit','Not_Prog',0,'0','10'),(79,'Not_Prog','0','100','unit','Not_Prog',1,'0','10'),(80,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(81,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(82,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(83,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(84,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(85,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(86,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(87,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(88,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(89,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(90,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(91,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(92,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(93,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(94,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(95,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(96,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(97,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(98,'Not_Prog','0','100','Unit','Not_Prog',1,'0','10'),(99,'Not Prog','0','100','Unit','Not_Prog',1,'0','10'),(100,'Not Prog','0','100','Unit','Not_Prog',1,'0','10'),(101,'Calculated Parameter','0','100','FSN','Smoke',1,'0','10'),(102,'Calculated Parameter','0','100','lpm','Blowby',1,'0','10'),(103,'Calculated Parameter','0','100','g','SFC_Wt',1,'0','10'),(104,'Calculated Parameter','0','100','sec','F_Time',1,'0','10'),(105,'Calculated Parameter','0','100','***','C_Factor',1,'0','10'),(106,'Calculated Parameter','0','100','Nm','Avg_Trq',1,'0','10'),(107,'Calculated Parameter','0','100','kW','Power',1,'0','10'),(108,'Calculated Parameter','0','100','g/kw.hr','SFC',1,'0','10'),(109,'Calculated Parameter','0','100','mm³/str/Cyln','Inj_Qty',1,'0','10'),(110,'Calculated Parameter','0','100','Nm','C_torque',1,'0','10'),(111,'Calculated Parameter','0','100','kW','C_Power',1,'0','10'),(112,'Calculated Parameter','0','100','ho/kw.hr','C_SFC',1,'0','10'),(113,'Calculated Parameter','0','100','kg/hr','F_Flow',1,'0','10'),(114,'Calculated Parameter','0','100','l/hr','F_Flow',1,'0','10'),(115,'Calculated Parameter','0','100','hp','Power',1,'0','10'),(116,'Calculated Parameter','0','100','hp','C_Power',1,'0','10'),(117,'Calculated Parameter','0','100','g/hp.hr','SFC',1,'0','10'),(118,'Calculated Parameter','0','100','g/hp.hr','C_SFC',1,'0','10'),(119,'Calculated Parameter','0','100','bar','bmep',1,'0','10'),(120,'Calculated Parameter','0','100','%','Rel_hum',1,'0','10'),(121,'Calculated Parameter','0','100','bar','C_bmep',1,'0','10'),(122,'Calculated Parameter','0','100','***','Log_Tm',1,'0','10'),(123,'Calculated Parameter','0','100','***','Start_Tm',1,'0','10'),(124,'Calculated Parameter','0','100','***','Tol_Hrs',1,'0','10'),(125,'Calculated Parameter','0','100','***','Alarm',NULL,NULL,NULL);
/*!40000 ALTER TABLE `tb_std` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-18 16:01:37
