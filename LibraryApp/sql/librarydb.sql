-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Máj 22. 16:33
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `librarydb`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `books`
--

CREATE TABLE `books` (
  `konyvid` int(11) NOT NULL,
  `cim` varchar(70) NOT NULL,
  `szerzo` varchar(34) NOT NULL,
  `kiadaseve` int(11) NOT NULL,
  `isbn` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `books`
--

INSERT INTO `books` (`konyvid`, `cim`, `szerzo`, `kiadaseve`, `isbn`) VALUES
(1, 'A Gyűrűk Ura', 'J.R.R. Tolkien', 1954, '2147483647'),
(2, 'Harry Potter és a bölcsek köve', 'J.K. Rowling', 1997, '2147483647'),
(3, 'Az Alkimista', 'Paulo Coelho', 1988, '2147483647'),
(4, 'Bűn és bűnhődés', 'Fyodor Dostoevsky', 1866, '2147483647'),
(5, 'A Hitchhikers Guide to the Galaxy', 'Douglas Adams', 1979, '2147483647'),
(6, '1984', 'George Orwell', 1949, '2147483647'),
(7, 'A Hobbit', 'J.R.R. Tolkien', 1937, '2147483647');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `loans`
--

CREATE TABLE `loans` (
  `kolcsonzesid` int(11) NOT NULL,
  `tagid` int(11) NOT NULL,
  `konyvid` int(11) NOT NULL,
  `kolcsonzesdatuma` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `tagid` int(11) NOT NULL,
  `nev` varchar(40) NOT NULL,
  `permission` int(2) NOT NULL,
  `email` varchar(60) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`tagid`, `nev`, `permission`, `email`, `password`) VALUES
(1, 'admin', 1, 'a', '123'),
(16, 'b', 0, 'b', '123');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`konyvid`);

--
-- A tábla indexei `loans`
--
ALTER TABLE `loans`
  ADD PRIMARY KEY (`kolcsonzesid`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`tagid`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `books`
--
ALTER TABLE `books`
  MODIFY `konyvid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT a táblához `loans`
--
ALTER TABLE `loans`
  MODIFY `kolcsonzesid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `tagid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
