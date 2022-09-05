USE [master]
GO
/****** Object:  Database [Ventas]    Script Date: 4/09/2022 23:45:15 ******/
CREATE DATABASE [Ventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Ventas', FILENAME = N'E:\ARCHIVO 2021\BASEW DE DATOS\Ventas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Ventas_log', FILENAME = N'E:\ARCHIVO 2021\BASEW DE DATOS\Ventas_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Ventas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Ventas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Ventas] SET RECOVERY FULL 
GO
ALTER DATABASE [Ventas] SET  MULTI_USER 
GO
ALTER DATABASE [Ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Ventas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Ventas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Ventas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Ventas', N'ON'
GO
ALTER DATABASE [Ventas] SET QUERY_STORE = OFF
GO
USE [Ventas]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 4/09/2022 23:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NULL,
	[ApellidoPaterno] [varchar](150) NULL,
	[ApallidoMaterno] [varchar](150) NULL,
	[RazonSocial] [varchar](250) NULL,
	[IdTipoDocumento] [int] NULL,
	[NumeroDocumento] [varchar](15) NULL,
	[FechaNacimiento] [datetime] NULL,
	[IndActivo] [bit] NULL,
	[IdUsuarioRegistro] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdUsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 4/09/2022 23:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[CodigoPedido] [varchar](15) NULL,
	[MontoSubTotal] [decimal](18, 2) NULL,
	[MontoIGV] [decimal](18, 2) NULL,
	[MontoTotal] [decimal](18, 2) NULL,
	[Descripcion] [varchar](500) NULL,
	[EstadoPedido] [varchar](50) NULL,
	[IndActivo] [bit] NULL,
	[IdUsuarioRegistro] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdUsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PedidoDetalle]    Script Date: 4/09/2022 23:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PedidoDetalle](
	[IdPedidoDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[MontoUnitario] [decimal](17, 0) NULL,
	[MontoSubTotal] [decimal](17, 2) NULL,
	[MontoIGV] [decimal](17, 2) NULL,
	[MontoTotal] [decimal](17, 2) NULL,
	[IndActivo] [bit] NULL,
	[IdUsuarioRegistro] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdUsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_PedidoDetalle] PRIMARY KEY CLUSTERED 
(
	[IdPedidoDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 4/09/2022 23:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [varchar](15) NULL,
	[NombreProducto] [varchar](150) NULL,
	[Descripcion] [varchar](250) NULL,
	[Imagen] [varchar](250) NULL,
	[IndActivo] [bit] NULL,
	[IdUsuarioRegistro] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdUsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguridad]    Script Date: 4/09/2022 23:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguridad](
	[IdSeguridad] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NULL,
	[NombreUsuario] [varchar](100) NULL,
	[Contrasena] [varchar](200) NULL,
	[Rol] [varchar](15) NULL,
	[IndActivo] [bit] NULL,
	[IdUsuarioRegistro] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdUsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Seguridad] PRIMARY KEY CLUSTERED 
(
	[IdSeguridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 4/09/2022 23:45:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta] [varchar](150) NULL,
	[Contrasena] [varchar](200) NULL,
	[NombreUsuario] [varchar](250) NULL,
	[IdRol] [int] NULL,
	[IndActivo] [bit] NULL,
	[IdUsuarioRegistro] [int] NULL,
	[FechaRegistro] [datetime] NULL,
	[IdUsuarioModificacion] [int] NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((1)) FOR [IndActivo]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((0)) FOR [IdUsuarioRegistro]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT ((0)) FOR [IdUsuarioModificacion]
GO
ALTER TABLE [dbo].[Producto] ADD  DEFAULT (getdate()) FOR [FechaModificacion]
GO
ALTER TABLE [dbo].[Seguridad] ADD  CONSTRAINT [DF_Seguridad_IndActivo]  DEFAULT ((1)) FOR [IndActivo]
GO
ALTER TABLE [dbo].[Seguridad] ADD  CONSTRAINT [DF_Seguridad_IdUsuarioRegistro]  DEFAULT ((0)) FOR [IdUsuarioRegistro]
GO
ALTER TABLE [dbo].[Seguridad] ADD  CONSTRAINT [DF_Seguridad_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Seguridad] ADD  CONSTRAINT [DF_Seguridad_IdUsuarioModificacion]  DEFAULT ((0)) FOR [IdUsuarioModificacion]
GO
ALTER TABLE [dbo].[Seguridad] ADD  CONSTRAINT [DF_Seguridad_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_IndActivo]  DEFAULT ((1)) FOR [IndActivo]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_IdUsuarioRegistro]  DEFAULT ((0)) FOR [IdUsuarioRegistro]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaRegistro]  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_IdUsuarioModificacion]  DEFAULT ((0)) FOR [IdUsuarioModificacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_FechaModificacion]  DEFAULT (getdate()) FOR [FechaModificacion]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente1] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente1]
GO
ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PedidoDetalle_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([IdPedido])
GO
ALTER TABLE [dbo].[PedidoDetalle] CHECK CONSTRAINT [FK_PedidoDetalle_Pedido]
GO
ALTER TABLE [dbo].[PedidoDetalle]  WITH CHECK ADD  CONSTRAINT [FK_PedidoDetalle_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[PedidoDetalle] CHECK CONSTRAINT [FK_PedidoDetalle_Producto]
GO
USE [master]
GO
ALTER DATABASE [Ventas] SET  READ_WRITE 
GO
