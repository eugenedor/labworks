USE [Test]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CT_CATEGORY](
	[CategoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Ord] [int] NULL,
	[DateLoad] [datetime] NULL,
 CONSTRAINT [PK_CT_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SK_EQUIPMENT](
	[EquipmentId] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[NameExtra] [nvarchar](500) NULL,
	[Ord] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SK_EQUIPMENT] PRIMARY KEY CLUSTERED 
(
	[EquipmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SK_EQUIPMENT]  WITH NOCHECK ADD  CONSTRAINT [FK_SK_EQUIPMENT_CT_CATEGORY] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CT_CATEGORY] ([CategoryId])
GO

ALTER TABLE [dbo].[SK_EQUIPMENT] CHECK CONSTRAINT [FK_SK_EQUIPMENT_CT_CATEGORY]
GO

--
-- Вставка данных в таблицу dbo.CT_CATEGORY
--
SET IDENTITY_INSERT dbo.CT_CATEGORY ON
GO

INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (1, N'ElectricTool', N'Электроинструменты', 1, '2019-05-26 00:05:57.257')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (2, N'AccElectricTool', N'Аксессуары для электроинструмента', 2, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (3, N'HandTool', N'Ручной инструмент', 3, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (4, N'FixingTool', N'Фиксирующий инструмент ', 4, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (5, N'ConstructionTool', N'Инструмент для строительства', 5, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (6, N'MeasuringTool', N'Измерительно-разметочный инструмент', 6, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (7, N'HouseholdTool', N'Хозяйственный инструмент', 7, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (8, N'Wrench', N'Гаечные ключи', 8, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (9, N'Hammer', N'Молотки', 9, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (10, N'Screw-driver', N'Отвертки', 10, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (11, N'Saw', N'Пилы', 11, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (12, N'Workplace', N'Всё для рабочего места', 12, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (13, N'MiniWash', N'Минимойки', 13, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (14, N'VacuumCleaner', N'Пылесосы', 14, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (15, N'Quillwort', N'Расходники', 15, '2019-05-26 00:05:57.270')
GO

SET IDENTITY_INSERT dbo.CT_CATEGORY OFF
GO

--
-- Задать Identity значение для dbo.CT_CATEGORY
--
DBCC CHECKIDENT('dbo.CT_CATEGORY', RESEED, 15) WITH NO_INFOMSGS
GO

--
-- Вставка данных в таблицу dbo.SK_EQUIPMENT
--
SET IDENTITY_INSERT dbo.SK_EQUIPMENT ON
GO

INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (1, 1, N'Vibrgrinder', N'Вибрационная шлифовальная машина', N'Vibration grinder', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (2, 1, N'Screwdriver', N'Шуруповерт', N'Screwdriver', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (3, 1, N'Drill', N'Дрель', N'Drill', 3, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (4, 1, N'Fretsaw', N'Лобзик', N'Fret saw', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (5, 1, N'Puncher', N'Перфоратор', N'Puncher', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (6, 1, N'Circularsaw', N'Циркулярная пила', N'Circular saw', 6, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (7, 1, N'Hairdryer', N'Фен', N'Hair dryer', 7, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (8, 1, N'Grinder', N'Углошлифовальная машина', N'Grinder', 8, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (9, 1, N'Millingcutter', N'Фрезер', N'Milling cutter', 9, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (10, 1, N'Electroplane', N'Электрорубанок', N'Electroplane', 10, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (11, 1, N'Engraver', N'Гравер', N'Engraver', 11, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (12, 2, N'Sawing', N'Пилка', N'Sawing', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (13, 2, N'Mill', N'Фреза', N'Mill', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (14, 2, N'Disk', N'Диск', N'Disk', 3, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (15, 2, N'Sverlo', N'Сверло', N'Drill', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (16, 2, N'Boer', N'Бур', N'Boer', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (17, 3, N'Nippers', N'Кусачки', N'Nippers', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (18, 3, N'Pincers', N'Клещи', N'Pincers', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (19, 3, N'Combpliers', N'Пассатижи', N'Combination pliers', 3, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (20, 3, N'Napilniks', N'Напильник', N'Files', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (21, 3, N'Scimetal', N'Ножницы по металлу', N'Scissors on metal', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (22, 3, N'Chisel', N'Стамеска', N'Chisel', 6, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (23, 3, N'Plane', N'Рубанок', N'Plane', 7, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (24, 4, N'Rivets', N'Заклепочник', N'Rivets', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (25, 4, N'Gluegun', N'Клеевой пистолет', N'Glue gun', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (26, 4, N'Stapler', N'Степлер', N'Stapler', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (27, 4, N'Clamp', N'Струбцина', N'Clamp', 4, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (28, 5, N'Construction', N'Общестроительная работа', N'Construction work', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (29, 5, N'Painting', N'Малярная работа', N'Painting work', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (30, 5, N'Tiled', N'Плиточная работа', N'Tiled work', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (31, 5, N'Pipe', N'Трубная работа', N'Pipe work', 4, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (32, 5, N'Gunssealant', N'Пистолеты для герметика', N'Guns for sealant', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (33, 5, N'Glasscutter', N'Стеклорез', N'Glass-cutter', 6, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (34, 6, N'Roulette', N'Рулетка', N'Roulette', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (35, 6, N'Level', N'Уровень', N'Level', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (36, 7, N'Knife', N'Нож строительный', N'Construction knives', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (37, 7, N'Pricker', N'Шило', N'Pricker', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (38, 8, N'Wrench', N'Гаечный ключ', N'Wrench', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (39, 8, N'Pipewrench', N'Трубный ключ', N'Pipe wrench', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (40, 8, N'Knob', N'Головка', N'Knob', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (41, 8, N'Graggers', N'Трещотка', N'Graggers', 4, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (42, 8, N'Hexagon', N'Шестигранник', N'Hexagon', 5, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (43, 9, N'Hammer', N'Молоток', N'Hammer', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (44, 9, N'Tooth', N'Зубило', N'Tooth', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (45, 9, N'Mallet', N'Киянка', N'Mallet', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (46, 9, N'Sledgehammer', N'Кувалда', N'Sledgehammer', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (47, 9, N'Nailcatcher', N'Гвоздодёр', N'Nail-catcher', 5, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (48, 10, N'Dielscrew', N'Диэлектрическая отвертка', N'Dielectric screw-driver', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (49, 10, N'Crossscrew', N'Крестовая отвертка', N'Cross screw-driver', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (50, 10, N'Shlitsscrew', N'Шлицевая отвертка', N'Shlitsevy screw-driver', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (51, 11, N'Woodsaw', N'Пилы по дереву', N'Wood saw', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (52, 11, N'Metalsaw', N'Пилы по металлу123456', N'Metal saw', 2, 0)
GO

SET IDENTITY_INSERT dbo.SK_EQUIPMENT OFF
GO

--
-- Задать Identity значение для dbo.SK_EQUIPMENT
--
DBCC CHECKIDENT('dbo.SK_EQUIPMENT', RESEED, 52) WITH NO_INFOMSGS
GO