ALTER PROCEDURE MiProcedimientoAlmacenado
@xml_usuarios XML,
@xml_compras XML,
@xml_itemsIva XML
AS
BEGIN 

	DECLARE @usuarios TABLE(
		Id INT,
		Nombre VARCHAR(MAX)
	)
	
	DECLARE @compras TABLE (
		Usuario INT,
		Producto INT,
		Valor DECIMAL(14,2)
	)

	DECLARE @itemsIva TABLE(
		IdProducto INT,
		Porcentaje DECIMAL(14,2)
	)


	INSERT INTO @usuarios
	SELECT  
	Id = T.Item.query('./Id').value('.', 'INT'),
	Nombre = T.Item.query('./Nombre').value('.', 'VARCHAR(MAX)')
	FROM   @xml_usuarios.nodes('Data/Usuario') AS T(Item)

	INSERT INTO @compras
	SELECT  
	Usuario = T.Item.query('./Usuario').value('.', 'INT'),
	Producto = T.Item.query('./Producto').value('.', 'INT'),
	Valor = T.Item.query('./Valor').value('.', 'DECIMAL(14,2)')
	FROM   @xml_compras.nodes('Data/Item') AS T(Item)

	INSERT INTO @itemsIva
	SELECT  
	IdProducto = T.Item.query('./IdProducto').value('.', 'INT'),
	Porcentaje = T.Item.query('./Porcentaje').value('.', 'DECIMAL(14,2)')
	FROM   @xml_itemsIva.nodes('Data/Producto') AS T(Item)

	SELECT U.Id ,U.Nombre,Valortotal = ISNULL( SUM(C.Valor),0),  Iva= isnull(SUM( C.Valor * I.Porcentaje),0)
	FROM @usuarios U
	LEFT JOIN @compras C ON C.Usuario = U.Id
	LEFT JOIN @itemsIva I ON I.IdProducto = C.Producto
	GROUP BY U.Id, U.Nombre

END 