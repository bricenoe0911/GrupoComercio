USE [Comercio]
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarSucursales]    Script Date: 10/04/2017 1:03:54 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ListarSucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ListarSucursales]
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarOrdenPago]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ListarOrdenPago]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ListarOrdenPago]
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarBancos]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ListarBancos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ListarBancos]
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Eliminar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Eliminar]
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarxIdSucursal]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_BuscarxIdSucursal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_BuscarxIdSucursal]
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarxId]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_BuscarxId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_BuscarxId]
GO
/****** Object:  StoredProcedure [dbo].[SP_AdministrarSucursal]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_AdministrarSucursal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_AdministrarSucursal]
GO
/****** Object:  StoredProcedure [dbo].[SP_Administrar]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Administrar]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Administrar]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sucursales_Banco]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sucursales]'))
ALTER TABLE [dbo].[Sucursales] DROP CONSTRAINT [FK_Sucursales_Banco]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesPago_Sucursales]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesPago]'))
ALTER TABLE [dbo].[OrdenesPago] DROP CONSTRAINT [FK_OrdenesPago_Sucursales]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesPago_EstadoOrdenPago]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesPago]'))
ALTER TABLE [dbo].[OrdenesPago] DROP CONSTRAINT [FK_OrdenesPago_EstadoOrdenPago]
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sucursales]') AND type in (N'U'))
DROP TABLE [dbo].[Sucursales]
GO
/****** Object:  Table [dbo].[OrdenesPago]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenesPago]') AND type in (N'U'))
DROP TABLE [dbo].[OrdenesPago]
GO
/****** Object:  Table [dbo].[EstadoOrdenPago]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstadoOrdenPago]') AND type in (N'U'))
DROP TABLE [dbo].[EstadoOrdenPago]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 10/04/2017 1:03:55 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banco]') AND type in (N'U'))
DROP TABLE [dbo].[Banco]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banco]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Banco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Direccion] [varchar](200) NULL,
	[FechaRegistro] [datetime] NULL,
	[Eliminado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadoOrdenPago]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstadoOrdenPago]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EstadoOrdenPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdenesPago]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdenesPago]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrdenesPago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursal] [int] NULL,
	[Monto] [decimal](10, 6) NULL,
	[Moneda] [varchar](10) NULL,
	[Estado] [int] NULL,
	[FechaPago] [datetime] NULL,
 CONSTRAINT [PK__OrdenesP__3214EC07015D6496] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sucursales]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sucursales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdBanco] [int] NULL,
	[Nombre] [varchar](200) NULL,
	[Direccion] [varchar](200) NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Banco] ON 

GO
INSERT [dbo].[Banco] ([Id], [Nombre], [Direccion], [FechaRegistro], [Eliminado]) VALUES (1, N'Banco3', N'Demo4', CAST(N'2017-04-10 01:36:23.783' AS DateTime), 1)
GO
INSERT [dbo].[Banco] ([Id], [Nombre], [Direccion], [FechaRegistro], [Eliminado]) VALUES (2, N'Banco', N'Demo', CAST(N'2017-04-10 01:37:47.117' AS DateTime), 0)
GO
INSERT [dbo].[Banco] ([Id], [Nombre], [Direccion], [FechaRegistro], [Eliminado]) VALUES (3, N'ads', N'asda', CAST(N'2017-04-10 01:38:16.577' AS DateTime), 1)
GO
INSERT [dbo].[Banco] ([Id], [Nombre], [Direccion], [FechaRegistro], [Eliminado]) VALUES (4, N'huijhj', N'jkkjhllk', CAST(N'2017-04-10 01:41:38.180' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Banco] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoOrdenPago] ON 

GO
INSERT [dbo].[EstadoOrdenPago] ([Id], [Descripcion]) VALUES (1, N'Pagada')
GO
INSERT [dbo].[EstadoOrdenPago] ([Id], [Descripcion]) VALUES (2, N'Declinada')
GO
INSERT [dbo].[EstadoOrdenPago] ([Id], [Descripcion]) VALUES (3, N'Fallida')
GO
INSERT [dbo].[EstadoOrdenPago] ([Id], [Descripcion]) VALUES (4, N'Anulada')
GO
SET IDENTITY_INSERT [dbo].[EstadoOrdenPago] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdenesPago] ON 

GO
INSERT [dbo].[OrdenesPago] ([Id], [IdSucursal], [Monto], [Moneda], [Estado], [FechaPago]) VALUES (1, 1, CAST(25.630000 AS Decimal(10, 6)), N'SOL', 1, CAST(N'2017-04-10 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OrdenesPago] ([Id], [IdSucursal], [Monto], [Moneda], [Estado], [FechaPago]) VALUES (2, 1, CAST(35.200000 AS Decimal(10, 6)), N'SOL', 3, CAST(N'2017-04-10 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OrdenesPago] ([Id], [IdSucursal], [Monto], [Moneda], [Estado], [FechaPago]) VALUES (3, 1, CAST(25.800000 AS Decimal(10, 6)), N'DOL', 2, CAST(N'2017-04-10 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OrdenesPago] ([Id], [IdSucursal], [Monto], [Moneda], [Estado], [FechaPago]) VALUES (4, 2, CAST(125.000000 AS Decimal(10, 6)), N'SOL', 1, CAST(N'2017-04-10 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OrdenesPago] ([Id], [IdSucursal], [Monto], [Moneda], [Estado], [FechaPago]) VALUES (5, 2, CAST(253.700000 AS Decimal(10, 6)), N'SOL', 1, CAST(N'2017-04-10 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OrdenesPago] ([Id], [IdSucursal], [Monto], [Moneda], [Estado], [FechaPago]) VALUES (6, 2, CAST(124.250000 AS Decimal(10, 6)), N'SOL', 3, CAST(N'2017-04-10 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[OrdenesPago] ([Id], [IdSucursal], [Monto], [Moneda], [Estado], [FechaPago]) VALUES (7, 2, CAST(210.250000 AS Decimal(10, 6)), N'DOL', 2, CAST(N'2017-04-10 00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[OrdenesPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

GO
INSERT [dbo].[Sucursales] ([Id], [IdBanco], [Nombre], [Direccion], [FechaRegistro]) VALUES (1, 2, N'dfdfdfg', N'fghhgjhgjghj', CAST(N'2017-04-10 04:29:56.297' AS DateTime))
GO
INSERT [dbo].[Sucursales] ([Id], [IdBanco], [Nombre], [Direccion], [FechaRegistro]) VALUES (2, 2, N'dfgdgdf', N'gfhfghfghfg', CAST(N'2017-04-10 04:34:14.973' AS DateTime))
GO
INSERT [dbo].[Sucursales] ([Id], [IdBanco], [Nombre], [Direccion], [FechaRegistro]) VALUES (3, 2, N'ggggg', N'hhhhhhhhhhh', CAST(N'2017-04-10 04:36:08.207' AS DateTime))
GO
INSERT [dbo].[Sucursales] ([Id], [IdBanco], [Nombre], [Direccion], [FechaRegistro]) VALUES (4, 2, N'gggggg', N'hhhhhhhjjj', CAST(N'2017-04-10 04:38:10.817' AS DateTime))
GO
INSERT [dbo].[Sucursales] ([Id], [IdBanco], [Nombre], [Direccion], [FechaRegistro]) VALUES (5, 2, N'jhdsdssss', N'rrrrrr', CAST(N'2017-04-10 04:40:58.167' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesPago_EstadoOrdenPago]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesPago]'))
ALTER TABLE [dbo].[OrdenesPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesPago_EstadoOrdenPago] FOREIGN KEY([Estado])
REFERENCES [dbo].[EstadoOrdenPago] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesPago_EstadoOrdenPago]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesPago]'))
ALTER TABLE [dbo].[OrdenesPago] CHECK CONSTRAINT [FK_OrdenesPago_EstadoOrdenPago]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesPago_Sucursales]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesPago]'))
ALTER TABLE [dbo].[OrdenesPago]  WITH CHECK ADD  CONSTRAINT [FK_OrdenesPago_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OrdenesPago_Sucursales]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrdenesPago]'))
ALTER TABLE [dbo].[OrdenesPago] CHECK CONSTRAINT [FK_OrdenesPago_Sucursales]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sucursales_Banco]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sucursales]'))
ALTER TABLE [dbo].[Sucursales]  WITH CHECK ADD  CONSTRAINT [FK_Sucursales_Banco] FOREIGN KEY([IdBanco])
REFERENCES [dbo].[Banco] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Sucursales_Banco]') AND parent_object_id = OBJECT_ID(N'[dbo].[Sucursales]'))
ALTER TABLE [dbo].[Sucursales] CHECK CONSTRAINT [FK_Sucursales_Banco]
GO
/****** Object:  StoredProcedure [dbo].[SP_Administrar]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Administrar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Administrar] AS' 
END
GO
ALTER Procedure [dbo].[SP_Administrar]
(
 @Id int,
 @Nombre varchar(200),
 @Direccion varchar(200)
)
As
Begin
	
	Declare @vId int

	If(@Id=0)
	Begin

		Insert Into Banco (Nombre,Direccion,FechaRegistro,Eliminado)
					values (@Nombre,@Direccion,GETUTCDATE(),0)

		Set @vId=(Select SCOPE_IDENTITY())
	End
	Else
	Begin

		Update Banco
			Set
				Nombre=@Nombre,
				Direccion=@Direccion
			Where Id=@Id

		Set @vId=@Id
	End

	Select @vId
End
GO
/****** Object:  StoredProcedure [dbo].[SP_AdministrarSucursal]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_AdministrarSucursal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_AdministrarSucursal] AS' 
END
GO
ALTER Procedure [dbo].[SP_AdministrarSucursal]
(
 @Id int,
 @IdBanco int,
 @Nombre varchar(200),
 @Direccion varchar(200)
)
As
Begin
	
	Declare @vId int

	If(@Id=0)
	Begin

		Insert Into Sucursales(IdBanco,Nombre,Direccion,FechaRegistro)
					values (@IdBanco,@Nombre,@Direccion,GETUTCDATE())

		Set @vId=(Select SCOPE_IDENTITY())
	End
	Else
	Begin

		Update Sucursales
			Set
				IdBanco=@IdBanco,
				Nombre=@Nombre,
				Direccion=@Direccion
			Where Id=@Id

		Set @vId=@Id
	End

	Select @vId

End
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarxId]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_BuscarxId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_BuscarxId] AS' 
END
GO
ALTER Procedure [dbo].[SP_BuscarxId]
(
 @Id int
)
As
Begin

	Select Id,Nombre,Direccion,FechaRegistro From Banco Where Id=@Id

End
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarxIdSucursal]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_BuscarxIdSucursal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_BuscarxIdSucursal] AS' 
END
GO
ALTER Procedure [dbo].[SP_BuscarxIdSucursal]
(
 @Id int
)
As
Begin

	Select Id,IdBanco,Nombre,Direccion,FechaRegistro From Sucursales Where Id=@Id

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Eliminar]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_Eliminar] AS' 
END
GO
ALTER Procedure [dbo].[SP_Eliminar]
(
 @Id int
)
As
Begin
	
	Update Banco Set Eliminado=1 Where Id=@Id

End
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarBancos]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ListarBancos]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ListarBancos] AS' 
END
GO
ALTER Procedure [dbo].[SP_ListarBancos]
As
Begin

	Select Id,Nombre,Direccion,FechaRegistro From Banco
	Where Eliminado=0

End
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarOrdenPago]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ListarOrdenPago]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ListarOrdenPago] AS' 
END
GO
ALTER Procedure [dbo].[SP_ListarOrdenPago]
(
	@tipoMoneda varchar(10)
)
As
Begin
	
	Select op.Id,b.Id IdBanco,b.Nombre NombreBanco,s.id IdSucursal,s.Nombre NombreSucursal,Monto,Moneda,Estado IdEstado,eop.Descripcion DescripcionEstado,FechaPago 
	From OrdenesPago op
	Inner Join Sucursales s On s.Id=op.IdSucursal
	Inner JOin Banco b On s.IdBanco=b.Id
	Inner Join EstadoOrdenPago eop On eop.Id=op.Estado
	Where op.Moneda=@tipoMoneda

End
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarSucursales]    Script Date: 10/04/2017 1:03:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ListarSucursales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ListarSucursales] AS' 
END
GO
ALTER Procedure [dbo].[SP_ListarSucursales]
(
 @IdBanco int
)
As
Begin
	
	Select Id,IdBanco,Nombre,Direccion,FechaRegistro From Sucursales Where IdBanco=@IdBanco

End
GO
