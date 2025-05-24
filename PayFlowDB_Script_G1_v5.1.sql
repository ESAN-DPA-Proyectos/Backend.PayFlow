-- =========================================
-- SCRIPT CREACION DE BD PAYFLOW
-- Objetivo: Estructura final con múltiples roles, notificaicones y origen de transacciones
-- =========================================

CREATE DATABASE PayFlowDB;
GO
USE PayFlowDB;
GO

-- =========================================
-- TABLA: Roles
-- =========================================
CREATE TABLE Roles (
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(255)
);

-- =========================================
-- TABLA: Usuarios
-- =========================================
CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    DNI CHAR(8) NOT NULL,
    Correo NVARCHAR(100) UNIQUE NOT NULL,
    Usuario NVARCHAR(100),
	ContrasenaHash NVARCHAR(255) NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado NVARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT CHK_Usuarios_Estado CHECK (Estado IN ('Activo', 'Inactivo'))
);

-- =========================================
-- TABLA INTERMEDIA: UsuarioRoles
-- Relación muchos a muchos entre Usuarios y Roles
-- =========================================
CREATE TABLE UsuarioRoles (
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    IdRol INT FOREIGN KEY REFERENCES Roles(IdRol),
    PRIMARY KEY (IdUsuario, IdRol)
);

-- =========================================
-- TABLA: Fondos
-- =========================================
CREATE TABLE Fondos (
    IdFondo INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    AportePorAsociado DECIMAL(10,2),
    Meta MONEY,
    SaldoActual MONEY DEFAULT 0,
    Estado NVARCHAR(20) DEFAULT 'Activo'
);

-- =========================================
-- TABLA: Transacciones
-- OrigenRol para identificar el contexto de la acción
-- =========================================
CREATE TABLE Transacciones (
    IdTransaccion INT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(20) CHECK (Tipo IN ('Deposito', 'Retiro')) NOT NULL,
    Monto MONEY NOT NULL,
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Estado NVARCHAR(20) CHECK (Estado IN ('Pendiente', 'Procesado', 'Rechazado')) NOT NULL,
    MetodoPago NVARCHAR(30),
    BeneficiarioNombre NVARCHAR(150),
    CuentaBeneficiario NVARCHAR(50),
    Concepto NVARCHAR(255),
    Referencia NVARCHAR(50),
    Comprobante NVARCHAR(255),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    IdFondo INT FOREIGN KEY REFERENCES Fondos(IdFondo),
    OrigenRol NVARCHAR(50) -- Para indicar si actuó como Aportante, Gestor, etc.
);

-- =========================================
-- TABLA: Historial de Validaciones
-- =========================================
CREATE TABLE HistorialValidaciones (
    IdHistorial INT PRIMARY KEY IDENTITY(1,1),
    IdTransaccion INT FOREIGN KEY REFERENCES Transacciones(IdTransaccion),
    TipoValidacion NVARCHAR(20) CHECK (TipoValidacion IN ('Manual', 'Automatica')) NOT NULL,
    Resultado NVARCHAR(20) CHECK (Resultado IN ('Valido', 'No Valido')),
    Observacion NVARCHAR(255),
    FechaValidacion DATETIME DEFAULT GETDATE(),
    ValidadoPor INT FOREIGN KEY REFERENCES Usuarios(IdUsuario)
);

-- =========================================
-- TABLA: Seguimiento de Transacción
-- =========================================
CREATE TABLE SeguimientoTransaccion (
    IdSeguimiento INT PRIMARY KEY IDENTITY(1,1),
    IdTransaccion INT FOREIGN KEY REFERENCES Transacciones(IdTransaccion),
    Hito NVARCHAR(50),
    FechaHora DATETIME,
    Estado NVARCHAR(20)
);

-- =========================================
-- TABLA: Notificaciones
-- =========================================
CREATE TABLE Notificaciones (
    IdNotificacion INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    IdTransaccion INT FOREIGN KEY REFERENCES Transacciones(IdTransaccion),
    TipoNotificacion NVARCHAR(50) NOT NULL,
    Mensaje NVARCHAR(255),
    Estado NVARCHAR(20) DEFAULT 'Pendiente',
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- =========================================
-- TABLA: Historial de Sesiones
-- =========================================
CREATE TABLE HistorialSesiones (
    IdSesion INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
    FechaHora DATETIME DEFAULT GETDATE(),
    TipoAcceso NVARCHAR(50),
    DireccionIP NVARCHAR(45)
);

-- =========================================
-- ROLES
-- =========================================
INSERT INTO Roles (Nombre, Descripcion)
VALUES
('Aportante', 'Registra aportes, visualiza saldos y su propio historial.'),
('Gestor de Actividad', 'Solicita retiros para fines del fondo.'),
('Administrador de Fondos', 'Autoriza retiros, valida comprobantes y gestiona usuarios.'),
('Externo', 'Solo consulta información.');
GO
