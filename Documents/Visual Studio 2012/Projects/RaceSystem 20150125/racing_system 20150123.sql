-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 22, 2015 at 07:48 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `racing_system`
--
CREATE DATABASE IF NOT EXISTS `racing_system` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `racing_system`;

-- --------------------------------------------------------

--
-- Table structure for table `appl_settings`
--

CREATE TABLE IF NOT EXISTS `appl_settings` (
  `rfid_address` varchar(20) NOT NULL,
  `rfid_comport` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `appl_settings`
--

INSERT INTO `appl_settings` (`rfid_address`, `rfid_comport`) VALUES
('192.168.1.134', '');

-- --------------------------------------------------------

--
-- Table structure for table `drivers`
--

CREATE TABLE IF NOT EXISTS `drivers` (
  `driver_id` int(11) NOT NULL AUTO_INCREMENT,
  `team_id` varchar(11) DEFAULT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `contact_no` varchar(11) DEFAULT NULL,
  `address` text,
  `gender` varchar(6) NOT NULL,
  `birthdate` date DEFAULT NULL,
  `age` varchar(11) DEFAULT NULL,
  `vehicle_model` varchar(11) DEFAULT NULL,
  `plate_no` varchar(11) DEFAULT NULL,
  `license_no` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`driver_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `event_class`
--

CREATE TABLE IF NOT EXISTS `event_class` (
  `class_id` int(11) NOT NULL AUTO_INCREMENT,
  `event_id` int(11) NOT NULL,
  `class_name` varchar(100) NOT NULL,
  `description` text,
  PRIMARY KEY (`class_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `event_drivers`
--

CREATE TABLE IF NOT EXISTS `event_drivers` (
  `event_id` varchar(11) DEFAULT NULL,
  `session_id` varchar(11) DEFAULT NULL,
  `driver_id` varchar(11) DEFAULT NULL,
  `rfid_no` varchar(11) DEFAULT NULL,
  `class_id` varchar(11) DEFAULT NULL,
  `vehicle_model` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `event_sessions`
--

CREATE TABLE IF NOT EXISTS `event_sessions` (
  `session_id` int(11) NOT NULL AUTO_INCREMENT,
  `session_name` varchar(100) NOT NULL,
  `race_type` varchar(100) NOT NULL,
  `description` text,
  `status` varchar(20) DEFAULT NULL,
  `date` date NOT NULL,
  `class_id` int(11) NOT NULL,
  `event_id` int(11) DEFAULT NULL,
  `distance` int(11) DEFAULT NULL,
  `lap_number` int(11) NOT NULL,
  `time` int(11) DEFAULT NULL,
  `schedule_time` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`session_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `lap_records`
--

CREATE TABLE IF NOT EXISTS `lap_records` (
  `lap_record_id` int(11) NOT NULL AUTO_INCREMENT,
  `session_id` int(11) NOT NULL,
  `lap_number` int(11) NOT NULL,
  `rfid_no` int(11) NOT NULL,
  `lap_time` float NOT NULL,
  `best_lap_time` float NOT NULL,
  `position` int(11) NOT NULL,
  `lap_speed` float NOT NULL,
  `best_lap_speed` float NOT NULL,
  PRIMARY KEY (`lap_record_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `race_events`
--

CREATE TABLE IF NOT EXISTS `race_events` (
  `event_id` int(11) NOT NULL AUTO_INCREMENT,
  `event_name` varchar(100) NOT NULL,
  `place` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`event_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `rfid_list`
--

CREATE TABLE IF NOT EXISTS `rfid_list` (
  `rfid_no` int(11) NOT NULL AUTO_INCREMENT,
  `rfid_tag_no` varchar(100) NOT NULL,
  PRIMARY KEY (`rfid_no`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `team`
--

CREATE TABLE IF NOT EXISTS `team` (
  `team_id` int(11) NOT NULL AUTO_INCREMENT,
  `team_name` varchar(100) NOT NULL,
  `vehicle_type` varchar(100) NOT NULL,
  PRIMARY KEY (`team_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
