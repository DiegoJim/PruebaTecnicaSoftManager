/****** Script for SelectTopNRows command from SSMS  ******/
SELECT A.[ID_CLIENTE]
      ,B.NOMBRES
	  ,B.APELLIDOS
      ,[FECHA_VENTA]
      ,C.DESC_PRODUCTO
      ,[VALOR_VENTA]
  FROM [PruebaTecnica].[dbo].[VENTAS] A
  JOIN [dbo].[CLIENTES] B ON A.ID_CLIENTE = B.ID_CLIENTE 
  JOIN [dbo].[PRODUCTOS] C ON A.CODIGO_PRODUCTO = C.CODIGO_PRODUCTO
  WHERE FECHA_VENTA BETWEEN '2010-10-01' AND '2010-12-31'

