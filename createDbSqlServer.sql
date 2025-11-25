
CREATE TABLE grupos_sociales (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    region VARCHAR(100),
    puntos INT DEFAULT 0,
    nivel INT DEFAULT 1,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE runners (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50),
    dni VARCHAR(20) UNIQUE,
    correo VARCHAR(100) UNIQUE NOT NULL,
    contraseña VARCHAR(255) NOT NULL,
    valido BOOLEAN DEFAULT TRUE,
    grupo_id INT,
    FOREIGN KEY (grupo_id) REFERENCES grupos_sociales(id) ON DELETE SET NULL
);


CREATE TABLE clasificaciones (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(50) NOT NULL,
    visible BOOLEAN DEFAULT TRUE,
    fecha_creacion DATETIME DEFAULT CURRENT_TIMESTAMP,
    runner_id INT NOT NULL, 
    FOREIGN KEY (runner_id) REFERENCES runners(id) ON DELETE CASCADE
);

CREATE TABLE recorridos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    kilometros DECIMAL(10, 2) NOT NULL, 
    calorias_quemadas INT,
    nombre VARCHAR(100), 
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP,
    comentario TEXT,
    runner_id INT NOT NULL, 
    FOREIGN KEY (runner_id) REFERENCES runners(id) ON DELETE CASCADE
);

CREATE TABLE ventajas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT
);

CREATE TABLE runner_ventajas (
    runner_id INT,
    ventaja_id INT,
    fecha_obtencion DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (runner_id, ventaja_id),
    FOREIGN KEY (runner_id) REFERENCES runners(id) ON DELETE CASCADE,
    FOREIGN KEY (ventaja_id) REFERENCES ventajas(id) ON DELETE CASCADE
);