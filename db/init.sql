/*
--將既有 YieldReturnDb 資料庫移除的指令碼
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'YieldReturnDb'
GO

USE [master]
GO

ALTER DATABASE [YieldReturnDb]
	SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

USE [master]
GO

DROP DATABASE [YieldReturnDb]
GO
*/

/*
    建立 YieldReturnDb 範例資料庫需要的資料表與預設資料內容
*/
CREATE DATABASE [YieldReturnDb]
GO

/*
	此設定與 Azure SQL Database 相同
	https://blogs.msdn.microsoft.com/sqlcat/2013/12/26/be-aware-of-the-difference-in-isolation-levels-if-porting-an-application-from-windows-azure-sql-db-to-sql-server-in-windows-azure-virtual-machine/
*/

--啟用 SNAPSHOT_ISOLATION
ALTER DATABASE [YieldReturnDb]
	SET ALLOW_SNAPSHOT_ISOLATION ON
GO

--啟用 READ_COMMITTED_SNAPSHOT
ALTER DATABASE [YieldReturnDb]
	SET READ_COMMITTED_SNAPSHOT ON
	WITH ROLLBACK IMMEDIATE
GO

USE [YieldReturnDb]
GO

CREATE TABLE [dbo].[SalesOrderDetailFromAdventureWorks2017]
(
	[SalesOrderID]				INT			NOT NULL,
	[SalesOrderDetailID]			INT IDENTITY(1,1)	NOT NULL,
	[CarrierTrackingNumber]			NVARCHAR(25)		NULL,
	[OrderQty]				SMALLINT		NOT NULL,
	[ProductID]				INT			NOT NULL,
	[SpecialOfferID]			INT			NOT NULL,
	[UnitPrice]				MONEY			NOT NULL,
	[UnitPriceDiscount]			MONEY			NOT NULL,
	[LineTotal]				NUMERIC(38, 6)		NOT NULL,
	[rowguid]				UNIQUEIDENTIFIER	NOT NULL,
	[ModifiedDate]				DATETIME		NOT NULL
)
GO


