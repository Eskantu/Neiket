USE [master]
GO
/****** Object:  Database [Neitek]    Script Date: 8/21/2024 12:53:40 PM ******/
CREATE DATABASE [Neitek]
GO
USE [Neitek]
GO
/****** Object:  Table [dbo].[Tareas]    Script Date: 8/21/2024 12:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tareas](
	[PkTarea] [int] IDENTITY(1,1) NOT NULL,
	[NombreTarea] [varchar](80) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[Completada] [bit] NOT NULL,
	[FkMeta] [int] NOT NULL,
	[Importante] [bit] NOT NULL,
 CONSTRAINT [PK_Tareas] PRIMARY KEY CLUSTERED 
(
	[PkTarea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Metas]    Script Date: 8/21/2024 12:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Metas](
	[PkMeta] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](80) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
 CONSTRAINT [PK_Metas] PRIMARY KEY CLUSTERED 
(
	[PkMeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MetasView]    Script Date: 8/21/2024 12:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MetasView]
AS
WITH Tareas AS (SELECT COUNT(FkMeta) AS TotalTareasByMeta, FkMeta
                                  FROM      dbo.Tareas AS Tareas_1
                                  GROUP BY FkMeta), TareasCompletas(TareasCompletasByMeta, FKMeta) AS
    (SELECT COUNT(FkMeta) AS TotalTareasByMeta, FkMeta
     FROM      dbo.Tareas AS Tareas_2
     WHERE   (Completada = 1)
     GROUP BY FkMeta)
    SELECT M.PkMeta, M.Nombre, M.FechaCreacion, ISNULL(T.TotalTareasByMeta, 0) AS TotalTareasByMeta, ISNULL(TC.TareasCompletasByMeta, 0) AS Completas, CASE WHEN TC.TareasCompletasByMeta = 0 AND 
                      T .TotalTareasByMeta = 0 THEN 0 ELSE ISNULL((CAST(TC.TareasCompletasByMeta AS DECIMAL) / CAST(T .TotalTareasByMeta AS Decimal) * 100), 0) END AS Porcentaje
    FROM     dbo.Metas AS M FULL OUTER JOIN
                      Tareas AS T ON T.FkMeta = M.PkMeta FULL OUTER JOIN
                      TareasCompletas AS TC ON TC.FKMeta = M.PkMeta
GO
/****** Object:  StoredProcedure [dbo].[GetGoals]    Script Date: 8/21/2024 12:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario escalante
-- Create date: 8/20/2024
-- Description:	Get Goals
-- =============================================
CREATE PROCEDURE [dbo].[GetGoals]
AS
BEGIN

	SET NOCOUNT ON;

    SELECT PkMeta,
           Nombre,
           FechaCreacion FROM dbo.Metas
END
GO
/****** Object:  StoredProcedure [dbo].[GetTask]    Script Date: 8/21/2024 12:53:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mario escalante
-- Create date: 8/20/2024
-- Description:	Get Task by FkMeta
-- =============================================
CREATE PROCEDURE [dbo].[GetTask]
@FkGoal INT
AS
BEGIN

	SET NOCOUNT ON;

    SELECT PkTarea,
           NombreTarea,
           FechaCreacion,
           Completada,
		   Importante,
           FkMeta FROM dbo.Tareas WHERE FkMeta = @FkGoal
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "T"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 126
               Right = 512
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TC"
            Begin Extent = 
               Top = 7
               Left = 560
               Bottom = 126
               Right = 819
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "M"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MetasView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MetasView'
GO
USE [master]
GO
ALTER DATABASE [Neitek] SET  READ_WRITE 
GO
