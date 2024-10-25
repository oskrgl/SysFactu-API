-- Insert data into the 'categoria' table
INSERT INTO categoria (idcategoria, nombre, descripcion, estado) VALUES
(NEWID(), 'Lácteos', 'Descripción de lácteos', 1),
(NEWID(), 'Carnes', 'Descripción de carnes', 1);

-- Insert data into the 'proveedor' table
INSERT INTO proveedor (idproveedor, nombre, nombre_contacto, telefono_fijo, telefono_celilar, correo, direccion, estado, fecha_r) VALUES
(NEWID(), 'Proveedor 1', 'Contacto 1', '1234567890', '0987654321', 'contacto1@proveedor.com', 'Dirección 1', NULL, NULL),
(NEWID(), 'Proveedor 2', 'Contacto 2', '1234567890', '0987654321', 'contacto2@proveedor.com', 'Dirección 2', NULL, NULL),
(NEWID(), 'Proveedor 3', 'Contacto 3', '1234567890', '0987654321', 'contacto3@proveedor.com', 'Dirección 3', NULL, NULL);

-- Insert data into the 'sucursal' table
INSERT INTO sucursal (idsucursal, nombre, direccion, telefono) VALUES
(NEWID(), 'Sucursal 1', 'Dirección Sucursal 1', '1234567890'),
(NEWID(), 'Sucursal 2', 'Dirección Sucursal 2', '1234567890'),
(NEWID(), 'Sucursal 3', 'Dirección Sucursal 3', '1234567890');

-- Insert data into the 'area' table
INSERT INTO area (idarea, nombre, descripcion) VALUES
(NEWID(), 'Área 1', 'Descripción de área 1'),
(NEWID(), 'Área 2', 'Descripción de área 2'),
(NEWID(), 'Área 3', 'Descripción de área 3');

-- Insert data into the 'articulo' table
INSERT INTO articulo (idarticulo, idcategoria, idproveedor, idsucursal, idarea, codigo, nombre, precio_venta, costo, precio, ganancia, stock, descripcion, fecha_vencimiento, imagen, estado) VALUES
(NEWID(), (SELECT TOP 1 idcategoria FROM categoria), (SELECT TOP 1 idproveedor FROM proveedor), (SELECT TOP 1 idsucursal FROM sucursal), (SELECT TOP 1 idarea FROM area), '001', 'Artículo 1', 100.00, 60.00, 75.00, 25.00, 10, 'Descripción de artículo 1', NULL, NULL, 1),
(NEWID(), (SELECT TOP 1 idcategoria FROM categoria), (SELECT TOP 1 idproveedor FROM proveedor), (SELECT TOP 1 idsucursal FROM sucursal), (SELECT TOP 1 idarea FROM area), '002', 'Artículo 2', 200.00, 120.00, 150.00, 50.00, 20, 'Descripción de artículo 2', NULL, NULL, 1),
(NEWID(), (SELECT TOP 1 idcategoria FROM categoria), (SELECT TOP 1 idproveedor FROM proveedor), (SELECT TOP 1 idsucursal FROM sucursal), (SELECT TOP 1 idarea FROM area), '003', 'Artículo 3', 300.00, 180.00, 225.00, 75.00, 30, 'Descripción de artículo 3', NULL, NULL, 1);

-- Insert data into the 'stock' table
INSERT INTO stock (idstock, idarticulo, idsucursal, cantidad) VALUES
(NEWID(), (SELECT TOP 1 idarticulo FROM articulo), (SELECT TOP 1 idsucursal FROM sucursal), 50),
(NEWID(), (SELECT TOP 1 idarticulo FROM articulo), (SELECT TOP 1 idsucursal FROM sucursal), 100),
(NEWID(), (SELECT TOP 1 idarticulo FROM articulo), (SELECT TOP 1 idsucursal FROM sucursal), 150);

-- Insert data into the 'persona' table
INSERT INTO persona (idpersona, tipo_persona, nombre, tipo_documento, num_documento, direccion, telefono, email, sexo, edad, estado, tipo, telefono_contacto, nombre_contacto, email_contacto, nrc, fcf, ccf) VALUES
(NEWID(), 'Cliente', 'Persona 1', 'DUI', '12345678-9', 'Dirección 1', '1234567890', 'persona1@dominio.com', 'M', '1980-01-01', NULL, NULL, '1234567890', 'Contacto 1', 'contacto1@dominio.com', 'NRC1', 'FCF1', 'CCF1'),
(NEWID(), 'Cliente', 'Persona 2', 'DUI', '98765432-1', 'Dirección 2', '1234567890', 'persona2@dominio.com', 'F', '1990-02-02', NULL, NULL, '1234567890', 'Contacto 2', 'contacto2@dominio.com', 'NRC2', 'FCF2', 'CCF2'),
(NEWID(), 'Proveedor', 'Persona 3', 'DUI', '12345678-0', 'Dirección 3', '1234567890', 'persona3@dominio.com', 'M', '1985-03-03', NULL, NULL, '1234567890', 'Contacto 3', 'contacto3@dominio.com', 'NRC3', 'FCF3', 'CCF3');

-- Insert data into the 'rol' table
INSERT INTO rol (idrol, nombre, descripcion, estado) VALUES
(NEWID(), 'Administrador', 'Rol de administrador', 1),
(NEWID(), 'Vendedor', 'Rol de vendedor', 1),
(NEWID(), 'Cliente', 'Rol de cliente', 1);

-- Insert data into the 'usuario' table
ALTER TABLE usuario ALTER COLUMN password varbinary(64);
-- Insertar datos de prueba en la tabla 'usuario' utilizando HASHBYTES
INSERT INTO usuario (idusuario, idrol, nombre, tipo_documento, num_documento, direccion, telefono, email, password, estado) VALUES
(NEWID(), (SELECT idrol FROM rol WHERE nombre = 'Administrador'), 'Usuario Admin', 'DUI', '12345678-9', 'Dirección Admin', '1234567890', 'admin@dominio.com', HASHBYTES('SHA2_256', 'password1'), 1),
(NEWID(), (SELECT idrol FROM rol WHERE nombre = 'Vendedor'), 'Usuario Vendedor', 'DUI', '98765432-1', 'Dirección Vendedor', '1234567890', 'vendedor@dominio.com', HASHBYTES('SHA2_256', 'password2'), 1),
(NEWID(), (SELECT idrol FROM rol WHERE nombre = 'Cliente'), 'Usuario Cliente', 'DUI', '11223344-5', 'Dirección Cliente', '1234567890', 'cliente@dominio.com', HASHBYTES('SHA2_256', 'password3'), 1);


-- Insert data into the 'ingreso' table
INSERT INTO ingreso (idingreso, idproveedor, idusuario, idsucursal, tipo_comprobante, serie_comprobante, num_comprobante, fecha, impuesto, total, estado) VALUES
(NEWID(), (SELECT TOP 1 idproveedor FROM proveedor), (SELECT TOP 1 idusuario FROM usuario), (SELECT TOP 1 idsucursal FROM sucursal), 'Factura', 'A', '00001', GETDATE(), 15.00, 1000.00, 'Pagado'),
(NEWID(), (SELECT TOP 1 idproveedor FROM proveedor), (SELECT TOP 1 idusuario FROM usuario), (SELECT TOP 1 idsucursal FROM sucursal), 'Factura', 'A', '00002', GETDATE(), 15.00, 2000.00, 'Pagado'),
(NEWID(), (SELECT TOP 1 idproveedor FROM proveedor), (SELECT TOP 1 idusuario FROM usuario), (SELECT TOP 1 idsucursal FROM sucursal), 'Factura', 'A', '00003', GETDATE(), 15.00, 3000.00, 'Pagado');

-- Insert data into the 'detalle_ingreso' table
INSERT INTO detalle_ingreso (iddetalle_ingreso, idingreso, idarticulo, cantidad, precio) VALUES
(NEWID(), (SELECT TOP 1 idingreso FROM ingreso), (SELECT TOP 1 idarticulo FROM articulo), 10, 100.00),
(NEWID(), (SELECT TOP 1 idingreso FROM ingreso), (SELECT TOP 1 idarticulo FROM articulo), 20, 200.00),
(NEWID(), (SELECT TOP 1 idingreso FROM ingreso), (SELECT TOP 1 idarticulo FROM articulo), 30, 300.00);

-- Insertar datos de prueba en la tabla 'venta'
INSERT INTO venta (idventa, idcliente, idusuario, idsucursal, tipo_comprobante, serie_comprobante, num_comprobante, fecha_hora, impuesto, total, estado) VALUES
(NEWID(), (SELECT TOP 1 idpersona FROM persona), (SELECT TOP 1 idusuario FROM usuario), (SELECT TOP 1 idsucursal FROM sucursal), 'Factura', 'A', '00001', GETDATE(), 13.00, 150.00, 'Pagado'),
(NEWID(), (SELECT TOP 1 idpersona FROM persona WHERE sexo = 'M'), (SELECT TOP 1 idusuario FROM usuario), (SELECT TOP 1 idsucursal FROM sucursal), 'Boleta', 'B', '00002', GETDATE(), 18.00, 200.00, 'Pendiente'),
(NEWID(), (SELECT TOP 1 idpersona FROM persona WHERE sexo = 'F'), (SELECT TOP 1 idusuario FROM usuario WHERE telefono = '1234567890'), (SELECT TOP 1 idsucursal FROM sucursal WHERE telefono = '1234567890'), 'Factura', 'C', '00003', GETDATE(), 15.00, 300.00, 'Pagado');

-- Insertar datos de prueba en la tabla 'detalle_venta'
INSERT INTO detalle_venta (iddetalle_venta, idventa, idarticulo, cantidad, precio, descuento) VALUES
(NEWID(), (SELECT TOP 1 idventa FROM venta), (SELECT TOP 1 idarticulo FROM articulo), 5, 15.00, 1.50),
(NEWID(), (SELECT TOP 1 idventa FROM venta WHERE tipo_comprobante = 'Boleta'), (SELECT TOP 1 idarticulo FROM articulo WHERE nombre = 'Artículo 1'), 10, 20.00, 2.00),
(NEWID(), (SELECT TOP 1 idventa FROM venta WHERE tipo_comprobante = 'Factura'), (SELECT TOP 1 idarticulo FROM articulo WHERE nombre = 'Artículo 2'), 15, 25.00, 2.50);
