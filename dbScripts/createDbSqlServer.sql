CREATE DATABASE IF NOT EXISTS RunnerDB;
USE RunnerDB;

CREATE TABLE IF NOT EXISTS grupos_sociales (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    region VARCHAR(100),
    puntos INT DEFAULT 0,
    nivel INT DEFAULT 1,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS runners (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50),
    dni VARCHAR(20) UNIQUE,
    correo VARCHAR(100) UNIQUE NOT NULL,
    contrasena VARCHAR(255) NOT NULL,
    valido BOOLEAN DEFAULT TRUE,
    grupo_id INT,
    FOREIGN KEY (grupo_id) REFERENCES grupos_sociales(id) ON DELETE SET NULL
);

CREATE TABLE IF NOT EXISTS clasificaciones (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(50) NOT NULL,
    visible BOOLEAN DEFAULT TRUE,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    runner_id INT NOT NULL, 
    FOREIGN KEY (runner_id) REFERENCES runners(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS recorridos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    kilometros DECIMAL(10, 2) NOT NULL, 
    calorias_quemadas INT,
    nombre VARCHAR(100), 
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    comentario TEXT,
    runner_id INT NOT NULL, 
    FOREIGN KEY (runner_id) REFERENCES runners(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS ventajas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT
);


INSERT IGNORE INTO grupos_sociales (id, nombre, region, puntos, nivel) VALUES 
(1,'Runners Madrid', 'Madrid', 150, 3),
(2,'Team Barcelona', 'Barcelona', 100, 2),
(3,'Valencia Runners', 'Valencia', 80, 2),
(4,'Sevilla Runners', 'Sevilla', 60, 1),
(5,'Bilbao Fleet', 'Bilbao', 40, 1),
(6,'Granada Fast', 'Granada', 30, 1);

INSERT IGNORE INTO runners (id, nombre, apellido, dni, correo, contrasena, valido, grupo_id) VALUES 
(1,'Carlos', 'López', '12345678A', 'carlos@email.com', 'pass123', TRUE, 1),
(2,'María', 'González', '87654321B', 'maria@email.com', 'pass123', TRUE, 2),
(3,'Juan', 'Martínez', '11111111C', 'juan@email.com', 'pass123', TRUE, 1),
(4,'Ana', 'Santos', '22222222D', 'ana@email.com', 'pass123', TRUE, 3),
(5,'Luis', 'Pérez', '33333333E', 'luis@email.com', 'pass123', TRUE, 2),
(6,'Sofía', 'Ramírez', '44444444F', 'sofia@email.com', 'pass123', TRUE, 4),
(7,'Miguel', 'Torres', '55555555G', 'miguel@email.com', 'pass123', TRUE, 5),
(8,'Lucía', 'Hernández', '66666666H', 'lucia@email.com', 'pass123', TRUE, 6),
(9,'Diego', 'Ruiz', '77777777I', 'diego@email.com', 'pass123', TRUE, 1),
(10,'Elena', 'Vega', '88888888J', 'elena@email.com', 'pass123', TRUE, 2);

INSERT IGNORE INTO clasificaciones (id, titulo, visible, runner_id) VALUES 
(1,'Maratón Completa', TRUE, 1),
(2,'Media Maratón', TRUE, 2),
(3,'10K Challenge', TRUE, 3),
(4,'Trail Runner', TRUE, 4),
(5,'Cros Country', TRUE, 5);

INSERT IGNORE INTO recorridos (id, kilometros, calorias_quemadas, nombre, comentario, runner_id) VALUES 
(1,10.5, 750, 'Parque Central', 'Excelente día para correr', 1),
(2,8.3, 600, 'Ruta Costera', 'Muy bonito el paisaje', 2),
(3,5.0, 400, 'Entreno matinal', 'Rutina de calentamiento', 3),
(4,15.2, 1100, 'Cima de la Sierra', 'Desafiante y bonito', 4),
(5,3.5, 220, 'Paseo urbano', 'Recorrido corto', 5);

INSERT IGNORE INTO ventajas (id, nombre, descripcion) VALUES 
(1,'Descuento Tienda', 'Descuento 20% en equipamiento deportivo'),
(2,'Acceso VIP', 'Acceso a eventos exclusivos'),
(3,'Entrenamiento Personal', 'Sesión gratis con entrenador personal'),
(4,'Sesiones Grupales', 'Entrenamientos semanales en grupo'),
(5,'Kits de Carrera', 'Kit con dorsal y camiseta en eventos');

SELECT * FROM grupos_sociales;
SELECT * FROM runners;
SELECT * FROM clasificaciones;
SELECT * FROM recorridos;
SELECT * FROM ventajas;