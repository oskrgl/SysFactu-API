USE [SysFactuDB]
GO

CREATE TABLE categoria (
    idcategoria uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    nombre varchar(50) NOT NULL UNIQUE,
    descripcion varchar(256) NULL,
    estado bit DEFAULT 1
);



--TRUNCATE TABLE proveedor;
--DELETE FROM proveedor;
CREATE TABLE proveedor (
    idproveedor uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    nombre varchar(50) NOT NULL UNIQUE,
    nombre_contacto varchar(50) NULL,  -- Ahora es opcional
    telefono_fijo varchar(10) NULL,    -- Ahora es opcional
    telefono_celular varchar(10) NULL, -- Ahora es opcional
    correo varchar(50) NULL,           -- Ahora es opcional
    direccion text NULL,               -- Ahora es opcional
    estado varchar(255) NULL DEFAULT 'activo',  -- Estado por defecto en 'activo'
    fecha_r datetime DEFAULT GETDATE()  -- Fecha de registro por defecto en la fecha de hoy
);

CREATE TABLE sucursal (
    idsucursal uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    nombre varchar(100) NOT NULL,
    direccion varchar(100) NOT NULL,
    telefono varchar(10) NOT NULL
);

CREATE TABLE articulo (
    idarticulo uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    codigo varchar(50) NULL,
    tipo varchar(50) NOT NULL DEFAULT 'Unidad',
    nombre varchar(100) NOT NULL UNIQUE,
    precio_venta decimal(11,2) NOT NULL,
    costo decimal(11,2) NOT NULL,
    precio decimal(11,2) NOT NULL,
    ganancia decimal(11,2) NOT NULL,
    stock integer NOT NULL,
    descripcion varchar(256) NULL,
    fecha_vencimiento datetime NULL DEFAULT NULL,
    imagen varchar(MAX) NULL,
    estado bit DEFAULT 1
);

CREATE TABLE ArticuloCategoria (
    idarticuloCategoria uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    idarticulo uniqueidentifier NOT NULL,
    idcategoria uniqueidentifier NOT NULL,
    cantidad integer NOT NULL,
    FOREIGN KEY (idarticulo) REFERENCES articulo(idarticulo),
    FOREIGN KEY (idcategoria) REFERENCES categoria(idcategoria)
);


CREATE TABLE ArticuloComponente (
    idArticuloPadre uniqueidentifier NOT NULL,
    idArticuloHijo uniqueidentifier NOT NULL,
    cantidad integer NOT NULL,
    PRIMARY KEY (idArticuloPadre, idArticuloHijo),
    FOREIGN KEY (idArticuloPadre) REFERENCES articulo(idarticulo),
    FOREIGN KEY (idArticuloHijo) REFERENCES articulo(idarticulo)
);

CREATE TABLE stock (
    idstock uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    idarticulo uniqueidentifier NOT NULL,
    idsucursal uniqueidentifier NOT NULL,
    cantidad integer NOT NULL,
    FOREIGN KEY (idarticulo) REFERENCES articulo(idarticulo),
    FOREIGN KEY (idsucursal) REFERENCES sucursal(idsucursal)
);

CREATE TABLE persona (
    idpersona uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    tipo_persona varchar(20) NOT NULL,
    nombre varchar(100) NOT NULL,
    tipo_documento varchar(20) NULL,
    num_documento varchar(20) NULL,
    direccion varchar(70) NULL,
    telefono varchar(20) NULL,
    email varchar(50) NULL UNIQUE,
    sexo varchar(10) NULL,
    edad date NULL,
    estado tinyint NULL DEFAULT NULL,
    tipo tinyint NULL DEFAULT NULL,
    telefono_contacto varchar(10) NULL,
    nombre_contacto varchar(100) NULL,
    email_contacto varchar(100) NULL,
    nrc varchar(20) NULL,
    fcf varchar(20) NULL,
    ccf varchar(20) NULL
);

CREATE TABLE rol (
    idrol uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    nombre varchar(30) NOT NULL,
    descripcion varchar(100) NULL,
    estado bit DEFAULT 1
);

CREATE TABLE usuario (
    idusuario uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    idrol uniqueidentifier NOT NULL,
    nombre varchar(100) NOT NULL,
    tipo_documento varchar(20) NULL,
    num_documento varchar(20) NULL,
    direccion varchar(70) NULL,
    telefono varchar(20) NULL,
    email varchar(50) NOT NULL,
    password varbinary(64) NOT NULL,
    estado bit DEFAULT 1,
    FOREIGN KEY (idrol) REFERENCES rol(idrol)
);

CREATE TABLE ingreso (
    idingreso uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    idproveedor uniqueidentifier NOT NULL,
    idusuario uniqueidentifier NOT NULL,
    idsucursal uniqueidentifier NOT NULL,
    tipo_comprobante varchar(20) NOT NULL,
    serie_comprobante varchar(7) NULL,
    num_comprobante varchar (10) NOT NULL,
    fecha datetime NOT NULL,
    impuesto decimal (4,2) NOT NULL,
    total decimal (11,2) NOT NULL,
    estado varchar(20) NOT NULL,
    FOREIGN KEY (idproveedor) REFERENCES proveedor (idproveedor),
    FOREIGN KEY (idusuario) REFERENCES usuario (idusuario),
    FOREIGN KEY (idsucursal) REFERENCES sucursal (idsucursal)
);

CREATE TABLE detalle_ingreso (
    iddetalle_ingreso uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    idingreso uniqueidentifier NOT NULL,
    idarticulo uniqueidentifier NOT NULL,
    cantidad integer NOT NULL,
    precio decimal(11,2) NOT NULL,
    FOREIGN KEY (idingreso) REFERENCES ingreso (idingreso) ON DELETE CASCADE,
    FOREIGN KEY (idarticulo) REFERENCES articulo (idarticulo)
);

CREATE TABLE venta (
    idventa uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    idcliente uniqueidentifier NOT NULL,
    idusuario uniqueidentifier NOT NULL,
    idsucursal uniqueidentifier NOT NULL,
    tipo_comprobante varchar(20) NOT NULL,
    serie_comprobante varchar(7) NULL,
    num_comprobante varchar(10) NOT NULL,
    fecha_hora datetime NOT NULL,
    impuesto decimal(4,2) NOT NULL,
    total decimal(11,2) NOT NULL,
    estado varchar(20) NOT NULL,
    FOREIGN KEY (idcliente) REFERENCES persona (idpersona),
    FOREIGN KEY (idusuario) REFERENCES usuario (idusuario),
    FOREIGN KEY (idsucursal) REFERENCES sucursal (idsucursal)
);

CREATE TABLE detalle_venta (
    iddetalle_venta uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    idventa uniqueidentifier NOT NULL,
    idarticulo uniqueidentifier NOT NULL,
    cantidad integer NOT NULL,
    precio decimal(11,2) NOT NULL,
    descuento decimal(11,2) NOT NULL,
    FOREIGN KEY (idventa) REFERENCES venta (idventa) ON DELETE CASCADE,
    FOREIGN KEY (idarticulo) REFERENCES articulo (idarticulo)
);


create PROCEDURE sp_validar_login
    @Email VARCHAR(50),
    @Password VARCHAR(50)
	AS
BEGIN    
	-- Obtener la contraseña hash almacenada
	select 
		u.[idusuario] as IdUsuario
		,u.[idrol] as IdRol
		,u.[nombre] as Nombre
		,u.[tipo_documento] as TipoDocumento
		,u.[num_documento] as NumDocumento
		,u.[direccion] as Direccion
		,u.[telefono] as Telefono
		,u.[email] as Email
		,u.[estado] as Estado
		,r.[nombre] as Rol
	from [dbo].[usuario] u
	inner join rol r on u.idrol = r.idrol
	where u.[email] = @Email and u.[password] = HASHBYTES('SHA2_256', @Password)
END;

create PROCEDURE sp_InsertarProveedor
    @IdProveedor UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(50),
    @NombreContacto NVARCHAR(50) = NULL,
    @TelefonoFijo NVARCHAR(10) = NULL,
    @TelefonoCelular NVARCHAR(10) = NULL,
    @Correo NVARCHAR(50) = NULL,
    @Estado NVARCHAR(50) = NULL, 
    @FechaRegistro datetime = NULL, 
    @Direccion NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nombre ya existe
    IF EXISTS (SELECT 1 FROM proveedor WHERE nombre = @Nombre)
    BEGIN
        -- Devolver mensaje de error si el nombre ya existe
        THROW 50001, 'El nombre ya existe, no se puede duplicar.', 1;
    END


    INSERT INTO proveedor (idproveedor, nombre, nombre_contacto, telefono_fijo, telefono_celular, correo, direccion, estado, fecha_r)
    VALUES (@IdProveedor, @Nombre, @NombreContacto, @TelefonoFijo, @TelefonoCelular, @Correo, @Direccion, @Estado, @FechaRegistro);

	select 
		[idproveedor] as IdProveedor
		,[nombre] as Nombre
		,[nombre_contacto] as NombreContacto
		,[telefono_fijo] as TelefonoFijo
		,[telefono_celular] as TelefonoCelular
		,[correo] as Correo
		,[direccion] as Direccion
		,[estado] as Estado
		,[fecha_r] as FechaRegistro
	FROM proveedor
	where [idproveedor] = @IdProveedor
END;

create PROCEDURE sp_getProveedores
AS
BEGIN
    
    -- Obtener la contraseña hash almacenada
    select 
		[idproveedor] as IdProveedor
		,[nombre] as Nombre
		,[nombre_contacto] as NombreContacto
		,[telefono_fijo] as TelefonoFijo
		,[telefono_celular] as TelefonoCelular
		,[correo] as Correo
		,[direccion] as Direccion
		,[estado] as Estado
		,[fecha_r] as FechaRegistro
	FROM proveedor
END;

create PROCEDURE sp_UpdateProveedo
    @IdProveedor UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(50),
    @NombreContacto NVARCHAR(50) = NULL,
    @TelefonoFijo NVARCHAR(10) = NULL,
    @TelefonoCelular NVARCHAR(10) = NULL,
    @Correo NVARCHAR(50) = NULL,
    @Estado NVARCHAR(50) = NULL, 
    @FechaRegistro datetime = NULL, 
    @Direccion NVARCHAR(MAX) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nombre ya existe en otro proveedor
    IF EXISTS (SELECT 1 FROM proveedor WHERE nombre = @Nombre AND idproveedor <> @IdProveedor)
    BEGIN
        -- Devolver mensaje de error si el nombre ya existe
        THROW 50001, 'El nombre ya existe, no se puede duplicar.', 1;
    END

    -- Actualizar proveedor existente
    UPDATE proveedor
    SET
        nombre = @Nombre,
        nombre_contacto = @NombreContacto,
        telefono_fijo = @TelefonoFijo,
        telefono_celular = @TelefonoCelular,
        correo = @Correo,
        direccion = @Direccion,
        estado = @Estado
    WHERE idproveedor = @IdProveedor;

    -- Devolver los detalles del proveedor actualizado
    SELECT
        idproveedor AS IdProveedor,
        nombre AS Nombre,
        nombre_contacto AS NombreContacto,
        telefono_fijo AS TelefonoFijo,
        telefono_celular AS TelefonoCelular,
        correo AS Correo,
        direccion AS Direccion,
        estado AS Estado,
        fecha_r AS FechaRegistro
    FROM proveedor
    WHERE idproveedor = @IdProveedor;
END;

create PROCEDURE sp_InsertarCategoria
    @idCategoria UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(256) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nombre ya existe
    IF EXISTS (SELECT 1 FROM categoria WHERE nombre = @Nombre)
    BEGIN
        -- Devolver mensaje de error si el nombre ya existe
        THROW 50001, 'El nombre ya existe, no se puede duplicar.', 1;
    END


    INSERT INTO categoria (idcategoria, nombre, descripcion)
    VALUES (@idCategoria, @Nombre, @Descripcion);

	select 
		[idcategoria] as idCategoria
		,[nombre] as Nombre
		,[descripcion] as Descripcion
	FROM categoria
	where [idcategoria] = @idCategoria
END;


create PROCEDURE sp_getCategoria
AS
BEGIN
    
    select 
		[idcategoria] as idCategoria
		,[nombre] as Nombre
		,[descripcion] as Descripcion
	FROM categoria
END;

create PROCEDURE sp_UpdateCategoria
    @idCategoria UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(256) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nombre ya existe en otro proveedor
    IF EXISTS (SELECT 1 FROM categoria WHERE nombre = @Nombre AND idcategoria <> @idCategoria)
    BEGIN
        -- Devolver mensaje de error si el nombre ya existe
        THROW 50001, 'El nombre ya existe, no se puede duplicar.', 1;
    END

    -- Actualizar proveedor existente
    UPDATE categoria
    SET
        nombre = @Nombre,
        descripcion = @Descripcion
    WHERE idcategoria = @idCategoria;

    -- Devolver los detalles del proveedor actualizado
    select 
		[idcategoria] as idCategoria
		,[nombre] as Nombre
		,[descripcion] as Descripcion
	FROM categoria
    WHERE idcategoria = @idCategoria;
END;


--idsucursal uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
--    nombre varchar(100) NOT NULL,
--    direccion varchar(100) NOT NULL,
--    telefono varchar(10) NOT NULL

create PROCEDURE sp_InsertarSucursal
    @IdSucursal UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(10) = NULL,
    @Direccion NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nombre ya existe
    IF EXISTS (SELECT 1 FROM sucursal WHERE nombre = @Nombre)
    BEGIN
        -- Devolver mensaje de error si el nombre ya existe
        THROW 50001, 'El nombre ya existe, no se puede duplicar.', 1;
    END


    INSERT INTO sucursal (idsucursal, nombre, telefono, direccion)
    VALUES (@IdSucursal, @Nombre, @Telefono, @Direccion);

	select 
		[idsucursal] as IdSucursal
		,[nombre] as Nombre
		,[telefono] as Telefono
		,[direccion] as Direccion
	FROM sucursal
	where [idsucursal] = @IdSucursal
END;


create PROCEDURE sp_getSucursal
AS
BEGIN
    
    select 
		[idsucursal] as IdSucursal
		,[nombre] as Nombre
		,[telefono] as Telefono
		,[direccion] as Direccion
	FROM sucursal
END;

create PROCEDURE sp_UpdateSucursal
    @IdSucursal UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(100),
    @Telefono NVARCHAR(10) = NULL,
    @Direccion NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si el nombre ya existe en otro proveedor
    IF EXISTS (SELECT 1 FROM sucursal WHERE nombre = @Nombre AND idsucursal <> @IdSucursal)
    BEGIN
        -- Devolver mensaje de error si el nombre ya existe
        THROW 50001, 'El nombre ya existe, no se puede duplicar.', 1;
    END

    -- Actualizar proveedor existente
    UPDATE sucursal
    SET
        nombre = @Nombre,
        telefono = @Telefono,
        direccion = @Direccion
    WHERE idsucursal = @IdSucursal;

    -- Devolver los detalles del proveedor actualizado
    select 
		[idsucursal] as IdSucursal
		,[nombre] as Nombre
		,[telefono] as Telefono
		,[direccion] as Direccion
	FROM sucursal
    WHERE [idsucursal] = @IdSucursal;
END;