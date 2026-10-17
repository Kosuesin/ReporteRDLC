-- =============================================================
-- Script: reportes_pae.sql
-- Base de datos para la práctica PrintDocument + PrintPreviewDialog
-- Ejecutar en HeidiSQL / DBeaver / consola de MariaDB
-- =============================================================
CREATE DATABASE IF NOT EXISTS reportes_pae
  CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE reportes_pae;

DROP TABLE IF EXISTS alumnos;
CREATE TABLE alumnos (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    carnet     VARCHAR(12)  NOT NULL UNIQUE,
    nombres    VARCHAR(60)  NOT NULL,
    apellidos  VARCHAR(60)  NOT NULL,
    carrera    VARCHAR(60)  NOT NULL,
    promedio   DECIMAL(5,2) NOT NULL
);

-- 60 registros: suficientes para generar 2 páginas en tamaño Carta
INSERT INTO alumnos (carnet, nombres, apellidos, carrera, promedio) VALUES
('2025-1000U', 'Lucía Andrea', 'Espinoza Sandino', 'Ingeniería Industrial', 84.22),
('2023-1017U', 'Luis Ángel', 'Picado Somarriba', 'Ingeniería en Sistemas', 82.50),
('2022-1034U', 'Carlos Miguel', 'Aráuz Jarquín', 'Ingeniería Electrónica', 97.50),
('2023-1051U', 'Nicole Paola', 'Chavarría Herrera', 'Ingeniería Electrónica', 70.42),
('2023-1068U', 'José Wilmer', 'González Jarquín', 'Ingeniería Electrónica', 70.84),
('2023-1085U', 'Sofía Valeria', 'Lanuza Centeno', 'Ingeniería Electrónica', 76.54),
('2025-1102U', 'Valeria María', 'Moreno Martínez', 'Ingeniería Civil', 81.39),
('2023-1119U', 'Roberto Kevin', 'Rocha Vargas', 'Ingeniería Electrónica', 78.09),
('2022-1136U', 'Bryan Ángel', 'Rodríguez Zeledón', 'Ingeniería Civil', 80.82),
('2023-1153U', 'Ernesto Francisco', 'Gutiérrez González', 'Ingeniería en Sistemas', 83.16),
('2023-1170U', 'Daniela Ana', 'Lanuza Herrera', 'Ingeniería Civil', 79.43),
('2022-1187U', 'Sofía María', 'Blandón Vargas', 'Ingeniería en Computación', 76.90),
('2025-1204U', 'José Wilmer', 'Altamirano Aráuz', 'Ingeniería en Computación', 89.10),
('2023-1221U', 'Óscar Miguel', 'González Talavera', 'Ingeniería Industrial', 88.02),
('2024-1238U', 'Erick Wilmer', 'González Gutiérrez', 'Ingeniería Electrónica', 78.52),
('2022-1255U', 'Jorge Luis', 'Zeledón Espinoza', 'Ingeniería en Sistemas', 97.70),
('2024-1272U', 'Óscar Kevin', 'Gutiérrez Vargas', 'Ingeniería Civil', 80.81),
('2023-1289U', 'Carlos Jorge', 'Lanuza Herrera', 'Ingeniería en Sistemas', 86.84),
('2025-1306U', 'Camila Valeria', 'Hernández Lanuza', 'Ingeniería Electrónica', 73.80),
('2023-1323U', 'Karla Nicole', 'Hernández Mendoza', 'Ingeniería Electrónica', 76.99),
('2023-1340U', 'Luis Roberto', 'Herrera Cerda', 'Ingeniería Industrial', 94.70),
('2024-1357U', 'Erick José', 'Rodríguez López', 'Ingeniería en Computación', 90.72),
('2025-1374U', 'Gabriela Daniela', 'Centeno Jarquín', 'Ingeniería Civil', 84.56),
('2022-1391U', 'Luis Jorge', 'Somarriba Cerda', 'Ingeniería Civil', 75.95),
('2025-1408U', 'Roberto José', 'Martínez Castillo', 'Ingeniería Industrial', 76.97),
('2023-1425U', 'Luis Kevin', 'Úbeda Picado', 'Ingeniería en Sistemas', 80.14),
('2023-1442U', 'Sofía Nicole', 'Talavera Obando', 'Ingeniería Electrónica', 70.98),
('2022-1459U', 'Óscar Juan', 'Obando Mendoza', 'Ingeniería en Sistemas', 86.75),
('2024-1476U', 'Óscar Carlos', 'Talavera Mendoza', 'Ingeniería en Computación', 97.98),
('2022-1493U', 'Óscar Miguel', 'Úbeda Talavera', 'Ingeniería en Computación', 92.21),
('2022-1510U', 'Sofía Ana', 'Moreno Somarriba', 'Ingeniería Industrial', 96.44),
('2025-1527U', 'Ernesto Óscar', 'Lanuza Gutiérrez', 'Ingeniería Industrial', 86.32),
('2024-1544U', 'Carlos Wilmer', 'Herrera Rodríguez', 'Ingeniería Industrial', 90.39),
('2025-1561U', 'Jessica Paola', 'Obando Lanuza', 'Ingeniería Industrial', 82.95),
('2024-1578U', 'Miguel Ángel', 'Picado Gutiérrez', 'Ingeniería Electrónica', 72.46),
('2025-1595U', 'Jorge Roberto', 'Rodríguez Somarriba', 'Ingeniería Civil', 95.10),
('2023-1612U', 'Gabriela Karla', 'Moreno Chavarría', 'Ingeniería Electrónica', 74.75),
('2023-1629U', 'Nicole Valeria', 'Somarriba Jarquín', 'Ingeniería Civil', 81.33),
('2023-1646U', 'Fátima Nicole', 'Blandón Aráuz', 'Ingeniería en Computación', 80.76),
('2024-1663U', 'Fátima Karla', 'Hernández Somarriba', 'Ingeniería en Sistemas', 89.91),
('2025-1680U', 'Lucía Karla', 'Rodríguez Altamirano', 'Ingeniería Civil', 95.92),
('2024-1697U', 'Daniela Nicole', 'Picado Somarriba', 'Ingeniería Electrónica', 82.67),
('2022-1714U', 'Ernesto José', 'Castillo Espinoza', 'Ingeniería Civil', 85.98),
('2023-1731U', 'Nicole Mariela', 'Lanuza Gutiérrez', 'Ingeniería Industrial', 82.74),
('2023-1748U', 'Ángel Ernesto', 'Castillo Rivera', 'Ingeniería en Sistemas', 97.55),
('2024-1765U', 'Óscar Carlos', 'Herrera Cerda', 'Ingeniería en Sistemas', 89.17),
('2022-1782U', 'Ernesto Óscar', 'Castillo Pérez', 'Ingeniería Industrial', 84.98),
('2024-1799U', 'Luis Jorge', 'Castillo Vargas', 'Ingeniería Electrónica', 89.52),
('2023-1816U', 'Erick Ernesto', 'Aráuz Obando', 'Ingeniería en Sistemas', 81.49),
('2022-1833U', 'Karla Valeria', 'Altamirano González', 'Ingeniería Industrial', 85.40),
('2022-1850U', 'Valeria Sofía', 'Herrera González', 'Ingeniería en Sistemas', 75.97),
('2024-1867U', 'Ana Gabriela', 'Cerda Aráuz', 'Ingeniería Civil', 95.48),
('2025-1884U', 'Juan Miguel', 'Martínez López', 'Ingeniería Civil', 85.41),
('2022-1901U', 'Valeria María', 'González Aráuz', 'Ingeniería Industrial', 92.40),
('2023-1918U', 'Miguel Juan', 'Moreno Aráuz', 'Ingeniería Industrial', 74.16),
('2022-1935U', 'Jessica Valeria', 'Lanuza Obando', 'Ingeniería en Computación', 82.30),
('2023-1952U', 'Lucía Paola', 'Cerda Herrera', 'Ingeniería Electrónica', 84.40),
('2023-1969U', 'Gabriela Nicole', 'Zeledón Espinoza', 'Ingeniería Civil', 93.82),
('2022-1986U', 'Camila Valeria', 'González Blandón', 'Ingeniería Electrónica', 70.14),
('2025-2003U', 'María Andrea', 'López Picado', 'Ingeniería Electrónica', 92.43);

SELECT COUNT(*) AS total FROM alumnos;
