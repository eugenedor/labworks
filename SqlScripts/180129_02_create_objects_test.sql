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
-- ������� ������ � ������� dbo.CT_CATEGORY
--
SET IDENTITY_INSERT dbo.CT_CATEGORY ON
GO

INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (1, N'ElectricTool', N'������������������', 1, '2019-05-26 00:05:57.257')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (2, N'AccElectricTool', N'���������� ��� ������������������', 2, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (3, N'HandTool', N'������ ����������', 3, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (4, N'FixingTool', N'����������� ���������� ', 4, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (5, N'ConstructionTool', N'���������� ��� �������������', 5, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (6, N'MeasuringTool', N'������������-����������� ����������', 6, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (7, N'HouseholdTool', N'������������� ����������', 7, '2019-05-26 00:05:57.267')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (8, N'Wrench', N'������� �����', 8, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (9, N'Hammer', N'�������', 9, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (10, N'Screw-driver', N'��������', 10, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (11, N'Saw', N'����', 11, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (12, N'Workplace', N'�� ��� �������� �����', 12, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (13, N'MiniWash', N'���������', 13, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (14, N'VacuumCleaner', N'��������', 14, '2019-05-26 00:05:57.270')
INSERT dbo.CT_CATEGORY(CategoryId, Code, Name, Ord, DateLoad) VALUES (15, N'Quillwort', N'����������', 15, '2019-05-26 00:05:57.270')
GO

SET IDENTITY_INSERT dbo.CT_CATEGORY OFF
GO

--
-- ������ Identity �������� ��� dbo.CT_CATEGORY
--
DBCC CHECKIDENT('dbo.CT_CATEGORY', RESEED, 15) WITH NO_INFOMSGS
GO

--
-- ������� ������ � ������� dbo.SK_EQUIPMENT
--
SET IDENTITY_INSERT dbo.SK_EQUIPMENT ON
GO

INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (1, 1, N'Vibrgrinder', N'������������ ������������ ������', N'Vibration grinder', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (2, 1, N'Screwdriver', N'����������', N'Screwdriver', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (3, 1, N'Drill', N'�����', N'Drill', 3, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (4, 1, N'Fretsaw', N'������', N'Fret saw', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (5, 1, N'Puncher', N'����������', N'Puncher', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (6, 1, N'Circularsaw', N'����������� ����', N'Circular saw', 6, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (7, 1, N'Hairdryer', N'���', N'Hair dryer', 7, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (8, 1, N'Grinder', N'���������������� ������', N'Grinder', 8, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (9, 1, N'Millingcutter', N'������', N'Milling cutter', 9, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (10, 1, N'Electroplane', N'��������������', N'Electroplane', 10, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (11, 1, N'Engraver', N'������', N'Engraver', 11, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (12, 2, N'Sawing', N'�����', N'Sawing', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (13, 2, N'Mill', N'�����', N'Mill', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (14, 2, N'Disk', N'����', N'Disk', 3, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (15, 2, N'Sverlo', N'������', N'Drill', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (16, 2, N'Boer', N'���', N'Boer', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (17, 3, N'Nippers', N'�������', N'Nippers', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (18, 3, N'Pincers', N'�����', N'Pincers', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (19, 3, N'Combpliers', N'���������', N'Combination pliers', 3, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (20, 3, N'Napilniks', N'���������', N'Files', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (21, 3, N'Scimetal', N'������� �� �������', N'Scissors on metal', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (22, 3, N'Chisel', N'��������', N'Chisel', 6, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (23, 3, N'Plane', N'�������', N'Plane', 7, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (24, 4, N'Rivets', N'�����������', N'Rivets', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (25, 4, N'Gluegun', N'������� ��������', N'Glue gun', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (26, 4, N'Stapler', N'�������', N'Stapler', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (27, 4, N'Clamp', N'���������', N'Clamp', 4, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (28, 5, N'Construction', N'���������������� ������', N'Construction work', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (29, 5, N'Painting', N'�������� ������', N'Painting work', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (30, 5, N'Tiled', N'��������� ������', N'Tiled work', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (31, 5, N'Pipe', N'������� ������', N'Pipe work', 4, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (32, 5, N'Gunssealant', N'��������� ��� ���������', N'Guns for sealant', 5, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (33, 5, N'Glasscutter', N'���������', N'Glass-cutter', 6, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (34, 6, N'Roulette', N'�������', N'Roulette', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (35, 6, N'Level', N'�������', N'Level', 2, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (36, 7, N'Knife', N'��� ������������', N'Construction knives', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (37, 7, N'Pricker', N'����', N'Pricker', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (38, 8, N'Wrench', N'������� ����', N'Wrench', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (39, 8, N'Pipewrench', N'������� ����', N'Pipe wrench', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (40, 8, N'Knob', N'�������', N'Knob', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (41, 8, N'Graggers', N'��������', N'Graggers', 4, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (42, 8, N'Hexagon', N'������������', N'Hexagon', 5, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (43, 9, N'Hammer', N'�������', N'Hammer', 1, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (44, 9, N'Tooth', N'������', N'Tooth', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (45, 9, N'Mallet', N'������', N'Mallet', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (46, 9, N'Sledgehammer', N'�������', N'Sledgehammer', 4, 1)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (47, 9, N'Nailcatcher', N'��������', N'Nail-catcher', 5, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (48, 10, N'Dielscrew', N'��������������� ��������', N'Dielectric screw-driver', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (49, 10, N'Crossscrew', N'��������� ��������', N'Cross screw-driver', 2, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (50, 10, N'Shlitsscrew', N'�������� ��������', N'Shlitsevy screw-driver', 3, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (51, 11, N'Woodsaw', N'���� �� ������', N'Wood saw', 1, 0)
INSERT dbo.SK_EQUIPMENT(EquipmentId, CategoryId, Code, Name, NameExtra, Ord, IsActive) VALUES (52, 11, N'Metalsaw', N'���� �� �������123456', N'Metal saw', 2, 0)
GO

SET IDENTITY_INSERT dbo.SK_EQUIPMENT OFF
GO

--
-- ������ Identity �������� ��� dbo.SK_EQUIPMENT
--
DBCC CHECKIDENT('dbo.SK_EQUIPMENT', RESEED, 52) WITH NO_INFOMSGS
GO