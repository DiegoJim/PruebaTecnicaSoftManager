-- Obtener los ID_CLIENTE de los clientes que tienen la clasificación "BAJO"
DECLARE @clientesBajo TABLE (
  ID_CLIENTE INT
);

INSERT INTO @clientesBajo (ID_CLIENTE)
SELECT ID_CLIENTE
FROM CLIENTES
WHERE CLASE = 'BAJO';

-- Eliminar los registros de los clientes "BAJO" de la tabla VENTAS
DELETE FROM VENTAS
WHERE ID_CLIENTE IN (SELECT ID_CLIENTE FROM @clientesBajo);

-- Eliminar los registros de los clientes "BAJO" de la tabla CLIENTES
DELETE FROM CLIENTES
WHERE ID_CLIENTE IN (SELECT ID_CLIENTE FROM @clientesBajo);