/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [ID_CLIENTE]
      ,[NOMBRES]
      ,[APELLIDOS]
      ,[DIRECCION]
      ,[TELEFONO]
      ,B.DESCRIPCION_CIUDAD
      ,C.USUARIO
  FROM [PruebaTecnica].[dbo].[CLIENTES] A
  JOIN [dbo].[CIUDAD] B ON A.CODIGO_CIUDAD = B.COD_CIUDAD
  JOIN [dbo].[USUARIOS] C ON A.CODIGO_USUARIO = C.CODIGO_USUARIO