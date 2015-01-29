-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 29, 2015 at 10:11 PM
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=11 ;

--
-- Dumping data for table `drivers`
--

INSERT INTO `drivers` (`driver_id`, `team_id`, `name`, `email`, `contact_no`, `address`, `gender`, `birthdate`, `age`, `vehicle_model`, `plate_no`, `license_no`) VALUES
(1, '2', 'testa', 'testa@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(2, '2', 'testb', 'testb@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(3, '2', 'testc', 'testc@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(4, '2', 'testd', 'testd@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(5, '2', 'teste', 'teste@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(6, '2', 'testf', 'testf@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(7, '2', 'testg', 'testg@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(8, '2', 'testh', 'testh@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(9, '2', 'testi', 'testi@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2'),
(10, '2', 'testj', 'testj@test.com', '09292929292', '123', 'Male', '2015-01-06', '2', '2', '2', '2');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `event_class`
--

INSERT INTO `event_class` (`class_id`, `event_id`, `class_name`, `description`) VALUES
(1, 1, 'class', 'class');

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

--
-- Dumping data for table `event_drivers`
--

INSERT INTO `event_drivers` (`event_id`, `session_id`, `driver_id`, `rfid_no`, `class_id`, `vehicle_model`) VALUES
('1', '', '1', '1', '1', '2'),
('1', '', '2', '2', '1', '2'),
('1', '', '3', '3', '1', '2'),
('1', '', '4', '4', '1', '2'),
('1', '', '5', '5', '1', '2');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `event_sessions`
--

INSERT INTO `event_sessions` (`session_id`, `session_name`, `race_type`, `description`, `status`, `date`, `class_id`, `event_id`, `distance`, `lap_number`, `time`, `schedule_time`) VALUES
(7, 'sessioasdfasdfasdfsadfsdfsadfsadfsdfsfsadfasdfn', 'session', NULL, NULL, '2015-01-30', 1, 1, 123, 2, 22, '2:00 PM');

-- --------------------------------------------------------

--
-- Table structure for table `lap_records`
--

CREATE TABLE IF NOT EXISTS `lap_records` (
  `lap_record_id` int(11) NOT NULL AUTO_INCREMENT,
  `session_id` int(11) NOT NULL,
  `lap_number` int(11) NOT NULL,
  `rfid_no` int(11) NOT NULL,
  `total_time` float NOT NULL,
  `lap_time` float NOT NULL,
  `best_lap_time` float NOT NULL,
  `position` int(11) NOT NULL,
  `lap_speed` float NOT NULL,
  `best_lap_speed` float NOT NULL,
  PRIMARY KEY (`lap_record_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=455 ;

--
-- Dumping data for table `lap_records`
--

INSERT INTO `lap_records` (`lap_record_id`, `session_id`, `lap_number`, `rfid_no`, `total_time`, `lap_time`, `best_lap_time`, `position`, `lap_speed`, `best_lap_speed`) VALUES
(450, 7, 1, 5, 7.02, 7.02, 7.02, 1, 17.52, 17.52),
(451, 7, 1, 3, 10.3, 10.3, 10.3, 2, 11.94, 11.94),
(452, 7, 1, 1, 11.42, 11.42, 11.42, 3, 10.77, 10.77),
(453, 7, 1, 2, 12.21, 12.21, 12.21, 4, 10.07, 10.07),
(454, 7, 1, 4, 16.77, 16.77, 16.77, 5, 7.33, 7.33);

-- --------------------------------------------------------

--
-- Table structure for table `race_events`
--

CREATE TABLE IF NOT EXISTS `race_events` (
  `event_id` int(11) NOT NULL AUTO_INCREMENT,
  `event_name` varchar(100) NOT NULL,
  `place` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`event_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `race_events`
--

INSERT INTO `race_events` (`event_id`, `event_name`, `place`) VALUES
(1, 'event', 'event');

-- --------------------------------------------------------

--
-- Table structure for table `rfid_list`
--

CREATE TABLE IF NOT EXISTS `rfid_list` (
  `rfid_no` int(11) NOT NULL AUTO_INCREMENT,
  `rfid_tag_no` varchar(100) NOT NULL,
  PRIMARY KEY (`rfid_no`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `rfid_list`
--

INSERT INTO `rfid_list` (`rfid_no`, `rfid_tag_no`) VALUES
(1, 'E2001027680901010380E766'),
(2, 'E2001027680901300380E6F2'),
(3, 'E2001027680901280380E6FA'),
(4, 'E2001027680901180380E722'),
(5, 'E2001027680901310380E6EE');

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
