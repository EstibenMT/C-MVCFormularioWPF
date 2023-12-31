USE [SupportTechEstibenMontoyaM1]
GO
/****** Object:  Table [dbo].[areas]    Script Date: 3/12/2023 9:34:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[areas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[personal]    Script Date: 3/12/2023 9:34:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[personal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[especialidad] [varchar](50) NOT NULL,
	[fechaIngreso] [date] NOT NULL,
	[horario] [varchar](50) NOT NULL,
	[documento] [varchar](20) NOT NULL,
	[mail] [varchar](100) NOT NULL,
	[whats] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seguimientos]    Script Date: 3/12/2023 9:34:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seguimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idTicket] [int] NOT NULL,
	[idPersonal] [int] NOT NULL,
	[seguimiento] [varchar](max) NOT NULL,
	[estado] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tickets]    Script Date: 3/12/2023 9:34:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tickets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[idArea] [int] NOT NULL,
	[departamento] [varchar](50) NOT NULL,
	[asunto] [varchar](50) NULL,
	[descripcion] [varchar](max) NOT NULL,
	[prioridad] [varchar](30) NOT NULL,
	[reporta] [varchar](50) NOT NULL,
	[puesto] [varchar](50) NULL,
	[nivel] [varchar](50) NOT NULL,
	[whatsapp] [varchar](20) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[comentarios] [varchar](100) NULL,
	[sucursal] [varchar](50) NULL,
	[idUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 3/12/2023 9:34:49 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](100) NOT NULL,
	[pass] [varchar](max) NOT NULL,
	[nivel] [varchar](30) NOT NULL,
	[estado] [varchar](20) NOT NULL,
	[idPersonal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[areas] ON 

INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (1, N'Ventas')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (2, N'Mercadeo ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (3, N'Producción ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (4, N'Tesorería')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (5, N'Recursos humanos ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (6, N'Contabilidad ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (7, N'Operaciones')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (8, N'Administración ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (9, N'Investigación ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (10, N'Dirección ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (11, N'Desarrollo ')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (12, N'Servicio al cliente')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (13, N'Logística')
INSERT [dbo].[areas] ([Id], [descripcion]) VALUES (14, N'Compras ')
SET IDENTITY_INSERT [dbo].[areas] OFF
GO
SET IDENTITY_INSERT [dbo].[personal] ON 

INSERT [dbo].[personal] ([Id], [nombre], [apellidos], [especialidad], [fechaIngreso], [horario], [documento], [mail], [whats]) VALUES (1, N'Estiben', N'Montoya', N'Desarrollador', CAST(N'2023-10-03' AS Date), N'8:00 am - 5:00 pm', N'123456789', N'Est@gmail.com', N'3134850999')
INSERT [dbo].[personal] ([Id], [nombre], [apellidos], [especialidad], [fechaIngreso], [horario], [documento], [mail], [whats]) VALUES (3, N'Leidy', N'zapata', N'Soporte', CAST(N'2023-11-30' AS Date), N'8:00 am - 5:00 pm', N'101722282', N'leidy@gmail.com', N'3125879999')
INSERT [dbo].[personal] ([Id], [nombre], [apellidos], [especialidad], [fechaIngreso], [horario], [documento], [mail], [whats]) VALUES (4, N'Angel', N'Taborda', N'Tecnico', CAST(N'2023-12-09' AS Date), N'9 am - 9 pm', N'100123456789', N'angel@gmail.com', N'3135559998')
SET IDENTITY_INSERT [dbo].[personal] OFF
GO
SET IDENTITY_INSERT [dbo].[seguimientos] ON 

INSERT [dbo].[seguimientos] ([Id], [idTicket], [idPersonal], [seguimiento], [estado]) VALUES (1, 4, 4, N'mantenimeinto', N'Terminado')
SET IDENTITY_INSERT [dbo].[seguimientos] OFF
GO
SET IDENTITY_INSERT [dbo].[tickets] ON 

INSERT [dbo].[tickets] ([Id], [idArea], [departamento], [asunto], [descripcion], [prioridad], [reporta], [puesto], [nivel], [whatsapp], [fecha], [comentarios], [sucursal], [idUsuario]) VALUES (1, 1, N'Analisis', N'Mantenimiento', N'Mantenimiento de equipos', N'Urgente', N'Estiben M', N'Lider', N'Operativo', N'3225845852', CAST(N'2023-12-02T00:00:00.000' AS DateTime), N'', N'', 1)
INSERT [dbo].[tickets] ([Id], [idArea], [departamento], [asunto], [descripcion], [prioridad], [reporta], [puesto], [nivel], [whatsapp], [fecha], [comentarios], [sucursal], [idUsuario]) VALUES (3, 1, N'Compras', N'Daño', N'Daño en red electrica', N'Urgente', N'Andres', N'Gerente', N'Administrativo', N'3134988774', CAST(N'2023-12-02T00:00:00.000' AS DateTime), N'', N'Las americas', 1)
INSERT [dbo].[tickets] ([Id], [idArea], [departamento], [asunto], [descripcion], [prioridad], [reporta], [puesto], [nivel], [whatsapp], [fecha], [comentarios], [sucursal], [idUsuario]) VALUES (4, 7, N'Administrativo', N'Daño de luz', N'Red de internet', N'Baja', N'Estiben', N'Lider', N'Operativo', N'3134859887', CAST(N'2023-12-02T00:00:00.000' AS DateTime), N'pa ya pa ya', N'Laureles', 2)
SET IDENTITY_INSERT [dbo].[tickets] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([Id], [login], [pass], [nivel], [estado], [idPersonal]) VALUES (1, N'Estiben', N'2994', N'Admin', N'Activo', 1)
INSERT [dbo].[usuarios] ([Id], [login], [pass], [nivel], [estado], [idPersonal]) VALUES (2, N'Leidy', N'2295', N'Tecnico', N'Activo', 3)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
ALTER TABLE [dbo].[seguimientos]  WITH CHECK ADD  CONSTRAINT [FK_seguimientos_personal] FOREIGN KEY([idPersonal])
REFERENCES [dbo].[personal] ([Id])
GO
ALTER TABLE [dbo].[seguimientos] CHECK CONSTRAINT [FK_seguimientos_personal]
GO
ALTER TABLE [dbo].[seguimientos]  WITH CHECK ADD  CONSTRAINT [FK_seguimientos_tickets] FOREIGN KEY([idTicket])
REFERENCES [dbo].[tickets] ([Id])
GO
ALTER TABLE [dbo].[seguimientos] CHECK CONSTRAINT [FK_seguimientos_tickets]
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD  CONSTRAINT [FK_tickets_areas] FOREIGN KEY([idArea])
REFERENCES [dbo].[areas] ([Id])
GO
ALTER TABLE [dbo].[tickets] CHECK CONSTRAINT [FK_tickets_areas]
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD  CONSTRAINT [FK_tickets_usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuarios] ([Id])
GO
ALTER TABLE [dbo].[tickets] CHECK CONSTRAINT [FK_tickets_usuarios]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_personal] FOREIGN KEY([idPersonal])
REFERENCES [dbo].[personal] ([Id])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_personal]
GO
