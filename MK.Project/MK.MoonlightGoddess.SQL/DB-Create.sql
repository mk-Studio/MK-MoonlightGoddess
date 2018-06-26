
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
--创建MK_Type_WuLiao的默认测试数据
INSERT MK_Type_WuLiao(WuLiaoTypeName,CreateUser,CreateDate) VALUES
(N'数码产品','System','2018-05-20'),
(N'黑科技产品','System','2018-05-20'),
(N'农作物产品','System','2018-05-20'),
(N'生活产品','System','2018-05-20'),
(N'饮料产品','System','2018-05-20'),
(N'机械零件产品','System','2018-05-20')
--创建MK_Type_WuLiao的索引
CREATE NONCLUSTERED INDEX IX_MK_Type_WuLiao_CreateDate ON dbo.MK_Type_WuLiao(CreateDate DESC)


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
--创建MK_Info_WuLiao的默认测试数据
INSERT MK_Info_WuLiao(WuLiaoTypeID,ShangPinName,GuiGe,HaiGuanNo,WuLiaoImagePath,CreateUser,CreateDate) VALUES
('CED180AC-6003-4436-B09D-3428B3FD4B66',N'小米8',N'256G','No001','','System','2018-05-20'),
('CED180AC-6003-4436-B09D-3428B3FD4B66',N'小米7',N'256G','No001','','System','2018-05-20'),
('CED180AC-6003-4436-B09D-3428B3FD4B66',N'HUAWEI-P20',N'256G','No001','','System','2018-05-20'),
('F06AB1E8-468A-41DD-A1A3-0AE4D7D7C286',N'PCIE-512G',N'S','No002','','System','2018-05-20'),
('F06AB1E8-468A-41DD-A1A3-0AE4D7D7C286',N'PCIE-256G',N'S','No002','','System','2018-05-20'),
('F06AB1E8-468A-41DD-A1A3-0AE4D7D7C286',N'PCIE-128G',N'S','No002','','System','2018-05-20')
--创建MK_Info_WuLiao的索引
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiao_CreateDate ON dbo.MK_Info_WuLiao(CreateDate DESC)
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiao_ShowMark ON dbo.MK_Info_WuLiao(ShowMark)
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiao_ShangPinName ON dbo.MK_Info_WuLiao(ShangPinName)


--供应商信息
CREATE TABLE MK_Info_Supplier(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
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
--创建MK_Info_WuLiao的默认测试数据

--创建MK_Info_WuLiao的索引
CREATE NONCLUSTERED INDEX IX_MK_Info_Supplier_CreateDate ON dbo.MK_Info_Supplier(CreateDate DESC)
CREATE NONCLUSTERED INDEX IX_MK_Info_Supplier_ShowMark ON dbo.MK_Info_Supplier(ShowMark)
CREATE NONCLUSTERED INDEX IX_MK_Info_Supplier_ShangPinName ON dbo.MK_Info_Supplier(SupplierName)


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
EXEC sp_addextendedproperty N'MS_Description', N'供应商物料ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'供应商ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'SupplierShangPinID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'商品信息ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'SupplierName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'CreateDate'
GO
SELECT ID,SupplierID,ShangPinID,ShowMark,CreateUser,CreateDate FROM MK_Info_Supplier_WuLiao
--创建MK_Info_Supplier_WuLiao的默认测试数据

--创建MK_Info_Supplier_WuLiao的索引


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
--创建MK_Info_WuLiao的索引
CREATE NONCLUSTERED INDEX IX_MK_Type_WuLiuYeWu_CreateDate ON dbo.MK_Type_WuLiuYeWu(CreateDate DESC)
CREATE NONCLUSTERED INDEX IX_MK_Type_WuLiuYeWu_ShowMark ON dbo.MK_Type_WuLiuYeWu(ShowMark)
CREATE NONCLUSTERED INDEX IX_MK_Type_WuLiuYeWu_YeWuType ON dbo.MK_Type_WuLiuYeWu(YeWuType)


--物流公司维护
CREATE TABLE MK_Info_WuLiuCompany(
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
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 物流公司维护', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_WuLiuCompany', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'物流公司ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'业务ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'YeWuID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'LianXiRen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'联系方式', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'LianXiFangShi'
GO
EXEC sp_addextendedproperty N'MS_Description', N'地址', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'Address'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiuCompany', 'COLUMN', N'CreateDate'
GO
--创建MK_Info_WuLiao的索引
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiuCompany_CreateDate ON dbo.MK_Info_WuLiuCompany(CreateDate DESC)
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiuCompany_ShowMark ON dbo.MK_Info_WuLiuCompany(ShowMark)
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiuCompany_Name ON dbo.MK_Info_WuLiuCompany(Name)

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
--创建MK_Info_WuLiao的索引
CREATE NONCLUSTERED INDEX IX_MK_Info_Currency_CreateDate ON dbo.MK_Info_Currency(CreateDate DESC)
CREATE NONCLUSTERED INDEX IX_MK_Info_Currency_ShowMark ON dbo.MK_Info_Currency(ShowMark)
CREATE NONCLUSTERED INDEX IX_MK_Info_Currency_CurrencyName ON dbo.MK_Info_Currency(CurrencyName)


--用户信息
CREATE TABLE MK_Info_User(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	UserName NVARCHAR(30) NOT NULL,
	Password NVARCHAR(30) NOT NULL,
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
EXEC sp_addextendedproperty N'MS_Description', N'密码', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'Password'
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

INSERT INTO dbo.MK_Info_User
(
    ID,
    UserName,
    Password,
    WuLiuYeWuID,
    PowerGroupID,
    ShowMark,
    CreateUser,
    CreateDate
)
VALUES
(NEWID(),  N'mk',N'123',N'1', N'1', 'Y', N'mk', GETDATE()),
(NEWID(),  N'kevin',N'123',N'1', N'1', 'Y', N'mk', GETDATE())

--权限组
CREATE TABLE MK_Info_PowerGroup(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	OnID NVARCHAR(36),
	PowerGroupName NVARCHAR(30),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 权限组', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_PowerGroup', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限组ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'上级ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'OnID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限组名', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'PowerGroupName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'CreateDate'
GO

INSERT INTO dbo.MK_Info_PowerGroup
(
    ID,
	OnID,
    PowerGroupName,
    ShowMark,
    CreateUser,
    CreateDate
)
VALUES
(  '00000000-0000-0000-0000-000000000000','00000000-0000-0000-0000-000000000001', N'权限组','Y', N'mk',GETDATE()),
(  NEWID(),'00000000-0000-0000-0000-000000000000', N'营业部','Y', N'mk',GETDATE()) ,
(  NEWID(),'00000000-0000-0000-0000-000000000000', N'销售部','Y', N'mk',GETDATE()) 
CREATE NONCLUSTERED INDEX IX_MK_Info_PowerGroup_CreateDate ON dbo.MK_Info_PowerGroup(CreateDate)


--权限表(菜单)
CREATE TABLE MK_Type_Power(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	NavigationID  NVARCHAR(36),
	PowerName  NVARCHAR(30),
	MenuAddress NVARCHAR(255),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
	Notes NVARCHAR(100),
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 权限', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_Power', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'导航ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'NavigationID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限名', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'PowerName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'菜单地址', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'MenuAddress'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'CreateDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'备注', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'Notes'
GO

INSERT INTO dbo.MK_Type_Power
(
    ID,
    PowerName,
	MenuAddress,
    ShowMark,
    CreateUser,
    CreateDate,
    Notes
)
VALUES
(   NEWID(),N'申请',N'../Quanxian/Index', 'Y',   N'mk',GETDATE(),N'物料申请'),
(   NEWID(),N'审批',N'../Shenhe/Index', 'Y',   N'mk',GETDATE(),N'物料审批')


--权限分配表
CREATE TABLE MK_Info_PowerAllot(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerGroupID NVARCHAR(36),
	PowerID NVARCHAR(36),
	Status NVARCHAR(2) DEFAULT '0',
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
EXEC sp_addextendedproperty N'MS_Description', N'权限标识:0-无权限，1-有权限', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'Status'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'CreateDate'
GO



--功能(菜单功能)
CREATE TABLE MK_Info_Features(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerID NVARCHAR(36),
	FeaturesName NVARCHAR(36),
	DataType  NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)

EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 功能', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Features', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'功能ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'菜单ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'PowerID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'功能名称', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'FeaturesName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'数据类型名', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'DataType'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'CreateDate'
GO

--功能清单
CREATE TABLE MK_Type_FunctionList(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	FeaturesID NVARCHAR(36),
	PowerAllotID  NVARCHAR(36),
	Status NVARCHAR(2) DEFAULT '0',
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * 功能清单', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_FunctionList', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_FunctionList', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'功能ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_FunctionList', 'COLUMN', N'FeaturesID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限分配ID【GUID】', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_FunctionList', 'COLUMN', N'PowerAllotID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'权限标识:0-无权限，1-有权限', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'Status'
GO
EXEC sp_addextendedproperty N'MS_Description', N'显示标识', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建人', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'CreateDate'
GO