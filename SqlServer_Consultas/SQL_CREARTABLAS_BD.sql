CREATE DATABASE PruebaTecnica


USE PruebaTecnica

-- Crear tabla PRODUCTOS
CREATE TABLE PRODUCTOS (
  CODIGO_PRODUCTO INT PRIMARY KEY NOT NULL,
  DESC_PRODUCTO VARCHAR(100)
);

-- Crear tabla DEPARTAMENTO
CREATE TABLE DEPARTAMENTO (
  CODIGO_DPTO INT PRIMARY KEY NOT NULL,
  DESCRIPCI�N_DPTO VARCHAR(100)
);

-- Crear tabla CIUDAD
CREATE TABLE CIUDAD (
  COD_CIUDAD INT PRIMARY KEY NOT NULL,
  CODIGO_DPTO INT NOT NULL,
  DESCRIPCION_CIUDAD VARCHAR(100),
  FOREIGN KEY (CODIGO_DPTO) REFERENCES DEPARTAMENTO (C�DIGO_DPTO)
);

-- Crear tabla USUARIOS
CREATE TABLE USUARIOS (
  CODIGO_USUARIO INT PRIMARY KEY NOT NULL,
  USUARIO VARCHAR(100),
  CLAVE VARCHAR(100)
);

-- Crear tabla CLIENTES
CREATE TABLE CLIENTES (
  ID_CLIENTE INT PRIMARY KEY NOT NULL,
  TIPO_IDENTIFICACION VARCHAR(50),
  NUMERO_IDENTIFICACION VARCHAR(50),
  NOMBRES VARCHAR(100),
  APELLIDOS VARCHAR(100),
  CARGO VARCHAR(100),
  MAIL VARCHAR(100),
  DIRECCION VARCHAR(100),
  TELEFONO VARCHAR(20),
  CODIGO_CIUDAD INT NOT NULL,
  CODIGO_USUARIO INT,
  FOREIGN KEY (CODIGO_CIUDAD) REFERENCES CIUDAD (COD_CIUDAD),
  FOREIGN KEY (CODIGO_USUARIO) REFERENCES USUARIOS (CODIGO_USUARIO)
);

-- Crear tabla VENTAS
CREATE TABLE VENTAS (
  ID_CLIENTE INT PRIMARY KEY NOT NULL,
  COD_CIUDAD INT NOT NULL,
  CODIGO_PRODUCTO INT NOT NULL,
  FECHA_VENTA DATE,
  VALOR_VENTA DECIMAL(10, 2),
  CANTIDAD_PRODUCTO INT,
  FOREIGN KEY (ID_CLIENTE) REFERENCES CLIENTES (ID_CLIENTE),
  FOREIGN KEY (COD_CIUDAD) REFERENCES CIUDAD (COD_CIUDAD),
  FOREIGN KEY (CODIGO_PRODUCTO) REFERENCES PRODUCTOS (CODIGO_PRODUCTO)
);