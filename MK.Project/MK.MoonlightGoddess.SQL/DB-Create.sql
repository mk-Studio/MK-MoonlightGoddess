
/*
数据库创建
--使用T-SQL语句创建“MK_MoonlightGoddess”数据库及删除数据库。
--数据文件名为：MK_MoonlightGoddess.mdf，初始大小为5MB，最大为unlimited，增长方式为10%；
--日志文件的初始大小为1MB，最大为MaxMB，增长方式为1MB。数据文件和日志文件均存放在e盘根目录下。
*/
create database MK_MoonlightGoddess
on(
   name       = MK_MoonlightGoddess,                                             -- 数据库名称
   size       = 5MB,                                                          -- 数据库初始大小
   maxsize    = unlimited,													  -- 数据库最大大小
   filename   = 'E:\SQLSERVERDB\DataBaseCollection\MK_MoonlightGoddess.mdf',     -- 数据库路径地址
   filegrowth = 10%                                                           -- 数据库增长方式
)
--日志文件
log
 on(
   name       =MK_MoonlightGoddess_log,                                          -- 数据库日志名称
   size       =1MB,                                                           -- 数据库日志初始大小
   maxsize    =unlimited,                                                     -- 数据库日志最大大小
   filename   ='E:\SQLSERVERDB\DataBaseCollection\MK_MoonlightGoddess.ldf',      -- 数据库日志路径地址
   filegrowth =1MB                                                            -- 数据库日志增长方式
)
GO
 
/*
表创建
*/
--物料类别
CREATE TABLE MK_Type_WuLiao(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	WuLiaoTypeName NVARCHAR(50),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 物料类别表', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_WuLiao', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'唯一ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'物料类型名称', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'WuLiaoTypeName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'CreateDate'
GO
INSERT MK_Type_WuLiao(WuLiaoTypeName,CreateUser,CreateDate) VALUES
(N'数码产品','System','2018-05-20'),
(N'黑科技产品','System','2018-05-20'),
(N'农作物产品','System','2018-05-20'),
(N'生活产品','System','2018-05-20'),
(N'饮料产品','System','2018-05-20'),
(N'机械零件产品','System','2018-05-20')

--物料具体信息
CREATE TABLE MK_Info_WuLiao(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	WuLiaoTypeID NVARCHAR(36),
	ShangPinName NVARCHAR(50),
	GuiGe NVARCHAR(30),
	HaiGuanNo NVARCHAR(50),
	WuLiaoImagePath NVARCHAR(50),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 物料具体信息', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_WuLiao', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品编号[ID【GUID】]', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'物料类型ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'WuLiaoTypeID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品名称', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'ShangPinName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'规格', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'GuiGe'
GO
EXEC sp_addextendedproperty N'MS_Description', N'海关编号', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'HaiGuanNo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'物料图片路径', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'WuLiaoImagePath'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'CreateDate'
GO

--供应商信息
CREATE TABLE MK_Info_Supplier(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	SupplierShangPinID NVARCHAR(36),
	SupplierName NVARCHAR(50),
	LianXiRen NVARCHAR(30),
	LianXiFangShi NVARCHAR(50),
	Address NVARCHAR(255),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 供应商信息', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Supplier', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'供应商ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'供应商商品ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'SupplierShangPinID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'供应商名称', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'SupplierName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'LianXiRen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'LianXiFangShi'
GO
EXEC sp_addextendedproperty N'MS_Description', N'地址', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'Address'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'CreateDate'
GO

--供应商所生产的物料商品信息
CREATE TABLE MK_Info_Supplier_WuLiao(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	SupplierID NVARCHAR(36),
	ShangPinID NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 供应商所生产的物料商品信息', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Supplier_WuLiao', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'供应商ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'供应商商品ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'SupplierShangPinID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'供应商名称', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'SupplierName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'LianXiRen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'LianXiFangShi'
GO
EXEC sp_addextendedproperty N'MS_Description', N'地址', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'Address'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'CreateDate'
GO


--物流公司业务维护
CREATE TABLE MK_Type_WuLiuYeWu(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	YeWuType NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 物流公司业务维护', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_WuLiuYeWu', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'业务ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'业务类型', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'YeWuType'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'CreateDate'
GO


--物流公司维护
CREATE TABLE MK_Info_WuLiu(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	YeWuID NVARCHAR(36),
	Name NVARCHAR(50),
	LianXiRen NVARCHAR(30),
	LianXiFangShi NVARCHAR(50),
	Address NVARCHAR(255),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 物流公司维护', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_WuLiu', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'物流公司ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'业务ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'YeWuID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'LianXiRen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'LianXiFangShi'
GO
EXEC sp_addextendedproperty N'MS_Description', N'地址', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'Address'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'CreateDate'
GO


--币别
CREATE TABLE MK_Info_Currency(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	CurrencyName NVARCHAR(30),
	CurrencyCode NVARCHAR(30),
	Remark NVARCHAR(255),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 币别', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Currency', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'币别ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'币制', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CurrencyName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'币种代号', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CurrencyCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'说明', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CreateDate'
GO



CREATE TABLE MK_Info_User(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	UserName NVARCHAR(30) NOT NULL,
	Passwor NVARCHAR(30) NOT NULL,
	WuLiuYeWuID NVARCHAR(36),
	PowerGroupID NVARCHAR(36),
	DefaultLanguage NVARCHAR(30) DEFAULT 'ChineseSimplified',
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 用户', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_User', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'用户ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'用户名', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'UserName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'密码', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'Passwor'
GO
EXEC sp_addextendedproperty N'MS_Description', N'物流公司业务维护', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'WuLiuYeWuID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限组', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'PowerGroupID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'默认语言', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'DefaultLanguage'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'CreateDate'
GO

CREATE TABLE MK_Info_PowerGroup(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerGroupName NVARCHAR(30),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 权限组', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_PowerGroup', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限组ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限组名', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'PowerGroupName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'CreateDate'
GO

CREATE TABLE MK_Type_Power(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerName  NVARCHAR(30),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
	Notes NVARCHAR(100),
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 权限', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_Power', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限名', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'PowerName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'CreateDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'备注', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'Notes'
GO

CREATE TABLE MK_Info_PowerAllot(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerGroupID NVARCHAR(36),
	PowerID NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 权限分配', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_PowerAllot', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'分配ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限组ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'PowerGroupID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'PowerID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'CreateDate'
GO