-- Crear tabla VENTA

CREATE TABLE VENTA (

    id_venta INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    fecha DATE NOT NULL,

    monto FLOAT NOT NULL,

    estado NVARCHAR(50) NOT NULL CHECK (estado IN ('procesando', 'aceptada', 'entregada')),

    numero_factura NVARCHAR(255) NOT NULL,

    usuario_id INT NOT NULL,

    direccion_id INT NOT NULL

);



-- Crear tabla USUARIO

CREATE TABLE USUARIO (

    id_usuario INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    nombre NVARCHAR(255) NOT NULL,

    apellido NVARCHAR(255) NOT NULL,

    telefono NVARCHAR(255) NOT NULL,

    tipo_usuario NVARCHAR(50) NOT NULL CHECK (tipo_usuario IN ('admin', 'cliente'))

);



-- Crear tabla CARRITO

CREATE TABLE CARRITO (

    id_carrito INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    cantidad INT NOT NULL,

    producto_id INT NOT NULL,

    cliente_id INT NOT NULL

);



-- Crear tabla AUTENTICACION

CREATE TABLE AUTENTICACION (

    id_autenticacion INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    email NVARCHAR(255) NOT NULL,

    clave NVARCHAR(255) NOT NULL,

    usuario_id INT NOT NULL

);



-- Crear tabla CATEGORIA

CREATE TABLE CATEGORIA (

    producto_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    categoria NVARCHAR(255) NOT NULL

);



-- Crear tabla PROVEEDOR

CREATE TABLE PROVEEDOR (

    id_proveedor INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    nombre NVARCHAR(255) NOT NULL,

    telefono NVARCHAR(255) NOT NULL,

    direccion_id INT NOT NULL

);



-- Crear tabla DIRECCION

CREATE TABLE DIRECCION (

    id_direccion INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    calle NVARCHAR(255) NOT NULL,

    altura INT NOT NULL,

    departamento NVARCHAR(255),

    barrio NVARCHAR(255) NOT NULL,

    localidad NVARCHAR(255) NOT NULL

);



-- Crear tabla PRODUCTO

CREATE TABLE PRODUCTO (

    id_producto INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    nombre NVARCHAR(255) NOT NULL,

    descripcion NVARCHAR(255) NOT NULL,

    precio FLOAT NOT NULL,

    stock INT NOT NULL,

    proveedor_id INT NOT NULL

);



-- Crear tabla HISTORIAL

CREATE TABLE HISTORIAL (

    id_historial INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

    usuario_id INT NOT NULL,

    venta_id INT NOT NULL

);



-- Agregar las claves foráneas

ALTER TABLE HISTORIAL

    ADD CONSTRAINT FK_historial_usuario FOREIGN KEY (usuario_id) REFERENCES USUARIO(id_usuario);



ALTER TABLE VENTA

    ADD CONSTRAINT FK_venta_usuario FOREIGN KEY (usuario_id) REFERENCES USUARIO(id_usuario);



ALTER TABLE PRODUCTO

    ADD CONSTRAINT FK_producto_categoria FOREIGN KEY (id_producto) REFERENCES CATEGORIA(producto_id);



ALTER TABLE CARRITO

    ADD CONSTRAINT FK_carrito_cliente FOREIGN KEY (cliente_id) REFERENCES USUARIO(id_usuario);



ALTER TABLE VENTA

    ADD CONSTRAINT FK_venta_direccion FOREIGN KEY (direccion_id) REFERENCES DIRECCION(id_direccion);



ALTER TABLE CARRITO

    ADD CONSTRAINT FK_carrito_producto FOREIGN KEY (producto_id) REFERENCES PRODUCTO(id_producto);



ALTER TABLE AUTENTICACION

    ADD CONSTRAINT FK_autenticacion_usuario FOREIGN KEY (usuario_id) REFERENCES USUARIO(id_usuario);



ALTER TABLE HISTORIAL

    ADD CONSTRAINT FK_historial_venta FOREIGN KEY (venta_id) REFERENCES VENTA(id_venta);



ALTER TABLE PRODUCTO

    ADD CONSTRAINT FK_producto_proveedor FOREIGN KEY (proveedor_id) REFERENCES PROVEEDOR(id_proveedor);



ALTER TABLE PROVEEDOR

    ADD CONSTRAINT FK_proveedor_direccion FOREIGN KEY (direccion_id) REFERENCES DIRECCION(id_direccion);