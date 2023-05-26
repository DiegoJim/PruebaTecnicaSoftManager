-- Agregar columna CLASE a la tabla CLIENTES
ALTER TABLE CLIENTES
ADD CLASE VARCHAR(50);

-- Actualizar la columna CLASE seg�n las ventas
UPDATE CLIENTES
SET CLASE = 'ALTO'
WHERE ID_CLIENTE IN (
  SELECT ID_CLIENTE
  FROM VENTAS
  WHERE VALOR_VENTA >= 200000
);

UPDATE CLIENTES
SET CLASE = 'MEDIO'
WHERE ID_CLIENTE IN (
  SELECT ID_CLIENTE
  FROM VENTAS
  WHERE VALOR_VENTA >= 100000 AND VALOR_VENTA < 200000
);

UPDATE CLIENTES
SET CLASE = 'BAJO'
WHERE ID_CLIENTE IN (
  SELECT ID_CLIENTE
  FROM VENTAS
  WHERE VALOR_VENTA < 100000
);