CREATE DATABASE  IF NOT EXISTS `tl_s2301171_rza` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `tl_s2301171_rza`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: ND-COMPSCI    Database: tl_s2301171_rza
-- ------------------------------------------------------
-- Server version	8.0.29

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `attractions`
--

DROP TABLE IF EXISTS `attractions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `attractions` (
  `attractionID` int NOT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `Price` float DEFAULT NULL,
  PRIMARY KEY (`attractionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attractions`
--

LOCK TABLES `attractions` WRITE;
/*!40000 ALTER TABLE `attractions` DISABLE KEYS */;
INSERT INTO `attractions` VALUES (1,'Admission - Adult (16+)',19.99),(2,'Admission - Child (6-15)',14.99),(3,'Admission - Senior (65+)',17.99),(4,'Admission - Student',17.99),(5,'Admission - Under 6s',0),(6,'Admission - Disabled Adult (16+)',14.99),(7,'Admission - Disabled Child (6-15)',9.99),(8,'Admission - Disabled Senior (65+)',11.99),(9,'Admission - Disabled Student',11.99),(10,'Admission - Disabled Carer',8),(11,'Premium Membership - Adult (16+)',140),(12,'Premium Membership - Child (6-15)',130),(13,'Premium Membership - Senior (65+)',130),(14,'Premium Membership - Student',130),(15,'Premium Membership - Disabled Adult (16+)',140),(16,'Premium Membership -  Disabled Child (6-15)',130),(17,'Premium Membership - Disabled Senior (65+)',130),(18,'Premium Membership -  Disabled Student',130),(19,'Standard Membership - Adult (16+)',82),(20,'Standard Membership - Child (6-15)',70),(21,'Standard Membership - Senior (65+)',74),(22,'Standard Membership - Student',70),(23,'Standard Membership - Disabled Adult (16+)',82),(24,'Standard Membership -  Disabled Child (6-15)',70),(25,'Standard Membership - Disabled Senior (65+)',74),(26,'Standard Membership - Disabled Student',70),(27,'Little Tiger Membership',0);
/*!40000 ALTER TABLE `attractions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customers` (
  `customerID` int NOT NULL AUTO_INCREMENT,
  `username` varchar(20) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `firstName` varchar(20) DEFAULT NULL,
  `lastName` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `postcode` varchar(10) DEFAULT NULL,
  `phoneNumber` char(11) DEFAULT NULL,
  `dateOfBirth` date DEFAULT NULL,
  `employee` tinyint(1) DEFAULT NULL,
  `employeeID` varchar(45) DEFAULT NULL,
  `loyaltyPoints` int DEFAULT NULL,
  PRIMARY KEY (`customerID`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `phoneNumber` (`phoneNumber`),
  UNIQUE KEY `employeeID_UNIQUE` (`employeeID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,'BobMarle','Hello_234','Matt','grab','hello@gmail.com','id23 Ud2','23345698656','2007-02-15',NULL,NULL,NULL),(2,'guttenmann','jolojolo123','Olek','Grzegorczyk','dupa@gmail.com','LS10 3DA','07783458998','2002-02-22',NULL,NULL,NULL),(3,'smegmalord','mattysmells','Harry','Smarker','gibjohnadmin@gmail.com.co.uk','LS15 7HE','07483245038','2300-01-26',NULL,NULL,NULL);
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eduvisits`
--

DROP TABLE IF EXISTS `eduvisits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eduvisits` (
  `schoolName` varchar(50) DEFAULT NULL,
  `stageOfEdu` varchar(20) DEFAULT NULL,
  `dayOfVisit` date DEFAULT NULL,
  `quantityOfStudents` int DEFAULT NULL,
  `quantityOfStaff` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eduvisits`
--

LOCK TABLES `eduvisits` WRITE;
/*!40000 ALTER TABLE `eduvisits` DISABLE KEYS */;
/*!40000 ALTER TABLE `eduvisits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `keystage`
--

DROP TABLE IF EXISTS `keystage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `keystage` (
  `keystageID` int NOT NULL,
  `keystageName` varchar(45) NOT NULL,
  PRIMARY KEY (`keystageID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `keystage`
--

LOCK TABLES `keystage` WRITE;
/*!40000 ALTER TABLE `keystage` DISABLE KEYS */;
INSERT INTO `keystage` VALUES (1,'KS1');
/*!40000 ALTER TABLE `keystage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `progress`
--

DROP TABLE IF EXISTS `progress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `progress` (
  `customerID` int NOT NULL,
  `ks1_maths` int NOT NULL DEFAULT '0',
  `quizID` int NOT NULL,
  PRIMARY KEY (`quizID`,`customerID`),
  KEY `proressfk1_idx` (`customerID`),
  CONSTRAINT `progressfk2` FOREIGN KEY (`quizID`) REFERENCES `quiz` (`quizID`),
  CONSTRAINT `proressfk1` FOREIGN KEY (`customerID`) REFERENCES `customers` (`customerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `progress`
--

LOCK TABLES `progress` WRITE;
/*!40000 ALTER TABLE `progress` DISABLE KEYS */;
/*!40000 ALTER TABLE `progress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `questionsID` int NOT NULL,
  `question` varchar(100) NOT NULL,
  `answer1` varchar(45) NOT NULL,
  `answer2` varchar(45) NOT NULL,
  `answer3` varchar(45) NOT NULL,
  `answer4` varchar(45) NOT NULL,
  `finalanswer` varchar(45) NOT NULL,
  `quizID` int NOT NULL,
  PRIMARY KEY (`questionsID`),
  KEY `questionfk1_idx` (`quizID`),
  CONSTRAINT `questionfk1` FOREIGN KEY (`quizID`) REFERENCES `quiz` (`quizID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
INSERT INTO `questions` VALUES (1,'What is 5 + 7?','10','12','14','11','2',1),(2,'What is 9 * 6?','52','54','56','48','2',1),(3,'What is 15 - 4?','12','10','11','9','3',1),(4,'What is 8 / 2?','6','4','5','3','2',1),(5,'What is 3^3?','27','30','24','21','1',1),(6,'What is the square root of 49?','6','8','7','9','3',1),(7,'What is 100 / 4?','20','30','25','28','3',1),(8,'What is 11 + 14?','26','24','25','23','3',1),(9,'What is 7 * 8?','54','56','58','60','2',1),(10,'What is 45 - 19?','27','26','25','28','2',1);
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quiz`
--

DROP TABLE IF EXISTS `quiz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `quiz` (
  `quizID` int NOT NULL,
  `subjectID` int NOT NULL,
  `keystageID` int NOT NULL,
  PRIMARY KEY (`quizID`),
  KEY `quizfk1_idx` (`subjectID`),
  CONSTRAINT `quizfk1` FOREIGN KEY (`subjectID`) REFERENCES `subject` (`subjectID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quiz`
--

LOCK TABLES `quiz` WRITE;
/*!40000 ALTER TABLE `quiz` DISABLE KEYS */;
INSERT INTO `quiz` VALUES (1,1,1),(2,1,1),(3,1,1);
/*!40000 ALTER TABLE `quiz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roombookings`
--

DROP TABLE IF EXISTS `roombookings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roombookings` (
  `customerID` int NOT NULL,
  `roomNumber` int NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date DEFAULT NULL,
  PRIMARY KEY (`customerID`,`roomNumber`,`startDate`),
  KEY `roomNumber` (`roomNumber`),
  CONSTRAINT `roombookings_ibfk_1` FOREIGN KEY (`customerID`) REFERENCES `customers` (`customerID`),
  CONSTRAINT `roombookings_ibfk_2` FOREIGN KEY (`roomNumber`) REFERENCES `rooms` (`roomNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roombookings`
--

LOCK TABLES `roombookings` WRITE;
/*!40000 ALTER TABLE `roombookings` DISABLE KEYS */;
/*!40000 ALTER TABLE `roombookings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `roomNumber` int NOT NULL,
  `capacity` int DEFAULT NULL,
  `roomType` varchar(20) DEFAULT NULL,
  `vacancy` tinyint(1) DEFAULT NULL,
  `disabilityAccesible` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`roomNumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subject` (
  `subjectID` int NOT NULL,
  `subjectName` varchar(45) NOT NULL,
  PRIMARY KEY (`subjectID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
INSERT INTO `subject` VALUES (1,'Mathematics');
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket`
--

DROP TABLE IF EXISTS `ticket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticket` (
  `ticketID` int NOT NULL AUTO_INCREMENT,
  `attractionID` int NOT NULL,
  `ticketbookingID` int NOT NULL,
  PRIMARY KEY (`ticketID`),
  KEY `ticket_fk1_idx` (`attractionID`),
  KEY `ticket_fk2_idx` (`ticketbookingID`),
  CONSTRAINT `ticket_fk1` FOREIGN KEY (`attractionID`) REFERENCES `attractions` (`attractionID`),
  CONSTRAINT `ticket_fk2` FOREIGN KEY (`ticketbookingID`) REFERENCES `ticketbooking` (`ticketbookingID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket`
--

LOCK TABLES `ticket` WRITE;
/*!40000 ALTER TABLE `ticket` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticket` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticketbooking`
--

DROP TABLE IF EXISTS `ticketbooking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ticketbooking` (
  `ticketbookingID` int NOT NULL AUTO_INCREMENT,
  `customerID` int NOT NULL,
  `date` date NOT NULL,
  `dateBooked` date NOT NULL,
  PRIMARY KEY (`ticketbookingID`),
  KEY `ticketbooking_fk1_idx` (`customerID`),
  CONSTRAINT `ticketbooking_fk1` FOREIGN KEY (`customerID`) REFERENCES `customers` (`customerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticketbooking`
--

LOCK TABLES `ticketbooking` WRITE;
/*!40000 ALTER TABLE `ticketbooking` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticketbooking` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-03-07 12:28:42
