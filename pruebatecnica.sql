-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 30, 2023 at 11:55 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pruebatecnica`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_actualizarBelong` (IN `_idBelong` INT, IN `_hotel` INT)   UPDATE belongs SET belongs.hotel = _hotel WHERE belongs.idBelong = _idBelong$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_editarHabitacion` (IN `_idRoom` INT, IN `_description` VARCHAR(200), IN `_price` INT, IN `_roomType` INT, IN `_state` INT)   UPDATE room SET room.description = _description, room.price = _price, room.roomType = _roomType, room.state = _state WHERE room.idRoom = _idRoom$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_editarHotel` (IN `_idHotel` INT, IN `_description` VARCHAR(200), IN `_price` INT, IN `_state` INT, IN `_name` VARCHAR(200))   UPDATE hotels SET hotels.name = _name, hotels.description = _description, hotels.price = _price, hotels.state = _state WHERE hotels.idHotel = _idHotel$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_eliminarTaxe` (IN `_idTaxe` INT)   DELETE FROM taxes WHERE taxes.idTaxes = _idTaxe$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_ingresoUsuario` (IN `_document` INT, IN `_password` VARCHAR(50))   SELECT * FROM agent WHERE agent.document = _document AND agent.password = _password$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_insertarBelong` (IN `_idRoom` INT, IN `_idHotel` INT)   INSERT INTO belongs VALUES('', _idRoom, _idHotel)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_insertarHabitacion` (IN `_idRoom` INT, IN `_description` VARCHAR(200), IN `_price` INT, IN `_roomType` INT, IN `_state` INT)   INSERT INTO room VALUES(_idRoom, _description, _price, _roomType, _state)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_insertarHotel` (IN `_idHotel` INT, IN `_name` VARCHAR(200), IN `_description` VARCHAR(200), IN `_price` INT, IN `_agent` INT, IN `_state` INT)   INSERT INTO hotels VALUES(_idHotel, _name, _description, _price, _agent, _state)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_insertarImpuesto` (IN `_idRoom` INT, IN `_idType` INT)   INSERT INTO taxes VALUES('',_idRoom,_idType)$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_listarEstado` ()   SELECT * FROM states$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_listarHabitaciones` ()   SELECT room.idRoom, hotels.idHotel, hotels.name AS Hotel_name, room.description, room.price, room.roomType, roomtype.nameRoomType, room.state, states.stateName,belongs.idBelong FROM belongs INNER JOIN hotels ON hotels.idHotel = belongs.hotel INNER JOIN room ON room.idRoom = belongs.room INNER JOIN roomtype ON roomtype.idRoomType = room.roomType INNER JOIN states ON states.idState = room.state$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_listarHoteles` ()   SELECT idHotel, name FROM hotels$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_listarTaxes` ()   SELECT taxes.idTaxes, taxes.room, taxes.taxesType, taxestype.taxesTypeName FROM taxes INNER JOIN taxestype ON taxestype.idtaxesType = taxes.taxesType$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_listarTipoHabit` ()   SELECT * FROM roomtype$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_registrarAgente` (IN `_name` VARCHAR(45), IN `_lastName` VARCHAR(50), IN `_document` INT, IN `_password` VARCHAR(45))   BEGIN
                                    INSERT INTO agent VALUES('',_name,_lastName,_document,_password);
                                    END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_seleccionarHotel` (IN `_idHotel` INT)   SELECT * FROM hotels WHERE hotels.idHotel = _idHotel$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_validarRegistroAgent` (IN `_document` INT)   SELECT * FROM agent WHERE document = _document$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_validarTaxes` (IN `_idRoom` INT, IN `_idType` INT)   SELECT * FROM taxes WHERE taxes.room = _idRoom AND taxes.taxesType = _idType$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SP_visualizarHoteles` ()   SELECT hotels.idHotel, hotels.name, hotels.description, hotels.price, hotels.agent, states.stateName as states, hotels.state as idState FROM hotels INNER JOIN states ON states.idState = hotels.state$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `agent`
--

CREATE TABLE `agent` (
  `idUser` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `lastName` varchar(50) DEFAULT NULL,
  `document` int(11) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `agent`
--

INSERT INTO `agent` (`idUser`, `name`, `lastName`, `document`, `password`) VALUES
(1, 'Miguel', 'Orozzco', 1036392014, '123'),
(5, 'Santiago', 'Giraldo', 21423423, '1234'),
(6, 'Juan Andres', 'Giraldo Caña', 12345, '123');

-- --------------------------------------------------------

--
-- Table structure for table `belongs`
--

CREATE TABLE `belongs` (
  `idBelong` int(11) NOT NULL,
  `room` int(11) DEFAULT NULL,
  `hotel` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `belongs`
--

INSERT INTO `belongs` (`idBelong`, `room`, `hotel`) VALUES
(1, 1, 2),
(2, 12, 1),
(3, 123, 1);

-- --------------------------------------------------------

--
-- Table structure for table `hotels`
--

CREATE TABLE `hotels` (
  `idHotel` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` varchar(45) DEFAULT NULL,
  `price` varchar(50) DEFAULT NULL,
  `agent` int(11) DEFAULT NULL,
  `state` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hotels`
--

INSERT INTO `hotels` (`idHotel`, `name`, `description`, `price`, `agent`, `state`) VALUES
(1, 'Hotel Miamar de los altos', 'FincaHotel', '1000000', 1, 2),
(2, 'Hotel de las Villas', 'Hotel Playa', '1200000', 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `idRoom` int(11) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `price` int(11) DEFAULT NULL,
  `roomType` int(11) DEFAULT NULL,
  `state` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`idRoom`, `description`, `price`, `roomType`, `state`) VALUES
(1, 'Habitacion para parejas', 1000000, 2, 1),
(12, 'Habitacion grande con espacio de sobra', 1200000, 4, 2),
(123, 'Hotel de las Villas', 1000000, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `roomtype`
--

CREATE TABLE `roomtype` (
  `idRoomType` int(11) NOT NULL,
  `nameRoomType` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `roomtype`
--

INSERT INTO `roomtype` (`idRoomType`, `nameRoomType`) VALUES
(1, 'INDIVIDUAL'),
(2, 'DOBLE'),
(3, 'QUEEN'),
(4, 'KING');

-- --------------------------------------------------------

--
-- Table structure for table `states`
--

CREATE TABLE `states` (
  `idState` int(11) NOT NULL,
  `stateName` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `states`
--

INSERT INTO `states` (`idState`, `stateName`) VALUES
(1, 'ACTIVO'),
(2, 'INACTIVO');

-- --------------------------------------------------------

--
-- Table structure for table `taxes`
--

CREATE TABLE `taxes` (
  `idTaxes` int(11) NOT NULL,
  `room` int(11) DEFAULT NULL,
  `taxesType` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `taxes`
--

INSERT INTO `taxes` (`idTaxes`, `room`, `taxesType`) VALUES
(7, 1, 1),
(9, 1, 3);

-- --------------------------------------------------------

--
-- Table structure for table `taxestype`
--

CREATE TABLE `taxestype` (
  `idtaxesType` int(11) NOT NULL,
  `taxesTypeName` varchar(50) DEFAULT NULL,
  `porcent` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `taxestype`
--

INSERT INTO `taxestype` (`idtaxesType`, `taxesTypeName`, `porcent`) VALUES
(1, 'IVA', 0.19),
(2, 'RETENCION FUENTE', 0.19),
(3, 'IMPUESTO ADICIONAL', 0.14);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `agent`
--
ALTER TABLE `agent`
  ADD PRIMARY KEY (`idUser`);

--
-- Indexes for table `belongs`
--
ALTER TABLE `belongs`
  ADD PRIMARY KEY (`idBelong`),
  ADD KEY `room` (`room`),
  ADD KEY `hotel` (`hotel`);

--
-- Indexes for table `hotels`
--
ALTER TABLE `hotels`
  ADD PRIMARY KEY (`idHotel`),
  ADD KEY `agent` (`agent`),
  ADD KEY `state` (`state`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`idRoom`),
  ADD KEY `roomType` (`roomType`),
  ADD KEY `state` (`state`);

--
-- Indexes for table `roomtype`
--
ALTER TABLE `roomtype`
  ADD PRIMARY KEY (`idRoomType`);

--
-- Indexes for table `states`
--
ALTER TABLE `states`
  ADD PRIMARY KEY (`idState`);

--
-- Indexes for table `taxes`
--
ALTER TABLE `taxes`
  ADD PRIMARY KEY (`idTaxes`),
  ADD KEY `room` (`room`),
  ADD KEY `taxesType` (`taxesType`);

--
-- Indexes for table `taxestype`
--
ALTER TABLE `taxestype`
  ADD PRIMARY KEY (`idtaxesType`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `agent`
--
ALTER TABLE `agent`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `belongs`
--
ALTER TABLE `belongs`
  MODIFY `idBelong` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `hotels`
--
ALTER TABLE `hotels`
  MODIFY `idHotel` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `room`
--
ALTER TABLE `room`
  MODIFY `idRoom` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=124;

--
-- AUTO_INCREMENT for table `roomtype`
--
ALTER TABLE `roomtype`
  MODIFY `idRoomType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `states`
--
ALTER TABLE `states`
  MODIFY `idState` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `taxes`
--
ALTER TABLE `taxes`
  MODIFY `idTaxes` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `taxestype`
--
ALTER TABLE `taxestype`
  MODIFY `idtaxesType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `belongs`
--
ALTER TABLE `belongs`
  ADD CONSTRAINT `belongs_ibfk_1` FOREIGN KEY (`room`) REFERENCES `room` (`idRoom`),
  ADD CONSTRAINT `belongs_ibfk_2` FOREIGN KEY (`hotel`) REFERENCES `hotels` (`idHotel`);

--
-- Constraints for table `hotels`
--
ALTER TABLE `hotels`
  ADD CONSTRAINT `hotels_ibfk_1` FOREIGN KEY (`agent`) REFERENCES `agent` (`idUser`),
  ADD CONSTRAINT `hotels_ibfk_2` FOREIGN KEY (`state`) REFERENCES `states` (`idState`);

--
-- Constraints for table `room`
--
ALTER TABLE `room`
  ADD CONSTRAINT `room_ibfk_1` FOREIGN KEY (`roomType`) REFERENCES `roomtype` (`idRoomType`),
  ADD CONSTRAINT `room_ibfk_2` FOREIGN KEY (`state`) REFERENCES `states` (`idState`);

--
-- Constraints for table `taxes`
--
ALTER TABLE `taxes`
  ADD CONSTRAINT `taxes_ibfk_1` FOREIGN KEY (`room`) REFERENCES `room` (`idRoom`),
  ADD CONSTRAINT `taxes_ibfk_2` FOREIGN KEY (`taxesType`) REFERENCES `taxestype` (`idtaxesType`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
