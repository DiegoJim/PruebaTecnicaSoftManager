--INSERTAR REGISTROS EN PRODUCTOS
INSERT INTO [dbo].[PRODUCTOS]
           ([CODIGO_PRODUCTO]
           ,[DESC_PRODUCTO])
     VALUES
           (1
           ,'PRODUCTO 1')

--INSERTAR DEPARTAMENTO
INSERT INTO [dbo].[DEPARTAMENTO]
           ([CODIGO_DPTO]
           ,[DESCRIPCIÓN_DPTO])
     VALUES
           (1
           ,'BOGOTÁ')

---INSERTAR EN CIUDAD
INSERT INTO [dbo].[CIUDAD]
           ([COD_CIUDAD]
           ,[CODIGO_DPTO]
           ,[DESCRIPCION_CIUDAD])
     VALUES
           (1
           ,1
           ,'BOGOTÁ')

--INSERTAR EN USUARIOS
INSERT INTO [dbo].[USUARIOS]
           ([CODIGO_USUARIO]
           ,[USUARIO]
           ,[CLAVE])
     VALUES
           (1
           ,'djimenez'
           ,'Temporal1*')

--INSERTAR EN CLIENTES
INSERT INTO [dbo].[CLIENTES]
           ([ID_CLIENTE]
           ,[TIPO_IDENTIFICACION]
           ,[NUMERO_IDENTIFICACION]
           ,[NOMBRES]
           ,[APELLIDOS]
           ,[CARGO]
           ,[MAIL]
           ,[DIRECCION]
           ,[TELEFONO]
           ,[CODIGO_CIUDAD]
           ,[CODIGO_USUARIO])
     VALUES
           (1
           ,'CEDULA DE CIUDADANIA'
           ,'123456789'
           ,'PAOLA'
           ,'SOTO'
           ,'ADMIN'
           ,'PRUEBA@GMAIL.COM'
           ,'APTO PRUEBA'
           ,'3024345609'
           ,1
           ,1)


--VENTAS
INSERT INTO [dbo].[VENTAS]
           ([ID_CLIENTE]
           ,[COD_CIUDAD]
           ,[CODIGO_PRODUCTO]
           ,[FECHA_VENTA]
           ,[VALOR_VENTA]
           ,[CANTIDAD_PRODUCTO])
     VALUES
           (1
           ,1
           ,1
           ,GETDATE()
           ,30000000
           ,2)



