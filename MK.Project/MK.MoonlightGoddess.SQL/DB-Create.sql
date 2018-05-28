
/*
���ݿⴴ��
--ʹ��T-SQL��䴴����MK_MoonlightGoddess�����ݿ⼰ɾ�����ݿ⡣
--�����ļ���Ϊ��MK_MoonlightGoddess.mdf����ʼ��СΪ5MB�����Ϊunlimited��������ʽΪ10%��
--��־�ļ��ĳ�ʼ��СΪ1MB�����ΪMaxMB��������ʽΪ1MB�������ļ�����־�ļ��������e�̸�Ŀ¼�¡�
*/
create database MK_MoonlightGoddess
on(
   name       = MK_MoonlightGoddess,                                             -- ���ݿ�����
   size       = 5MB,                                                          -- ���ݿ��ʼ��С
   maxsize    = unlimited,													  -- ���ݿ�����С
   filename   = 'E:\SQLSERVERDB\DataBaseCollection\MK_MoonlightGoddess.mdf',     -- ���ݿ�·����ַ
   filegrowth = 10%                                                           -- ���ݿ�������ʽ
)
--��־�ļ�
log
 on(
   name       =MK_MoonlightGoddess_log,                                          -- ���ݿ���־����
   size       =1MB,                                                           -- ���ݿ���־��ʼ��С
   maxsize    =unlimited,                                                     -- ���ݿ���־����С
   filename   ='E:\SQLSERVERDB\DataBaseCollection\MK_MoonlightGoddess.ldf',      -- ���ݿ���־·����ַ
   filegrowth =1MB                                                            -- ���ݿ���־������ʽ
)
GO
 
/*
����
*/
--�������
CREATE TABLE MK_Type_WuLiao(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	WuLiaoTypeName NVARCHAR(50),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * ��������', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_WuLiao', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ΨһID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'WuLiaoTypeName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiao', 'COLUMN', N'CreateDate'
GO
--����MK_Type_WuLiao��Ĭ�ϲ�������
INSERT MK_Type_WuLiao(WuLiaoTypeName,CreateUser,CreateDate) VALUES
(N'�����Ʒ','System','2018-05-20'),
(N'�ڿƼ���Ʒ','System','2018-05-20'),
(N'ũ�����Ʒ','System','2018-05-20'),
(N'�����Ʒ','System','2018-05-20'),
(N'���ϲ�Ʒ','System','2018-05-20'),
(N'��е�����Ʒ','System','2018-05-20')
--����MK_Type_WuLiao������
CREATE NONCLUSTERED INDEX IX_MK_Type_WuLiao_CreateDate ON dbo.MK_Type_WuLiao(CreateDate DESC)


--���Ͼ�����Ϣ
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
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * ���Ͼ�����Ϣ', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_WuLiao', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'��Ʒ���[ID��GUID��]', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��������ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'WuLiaoTypeID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��Ʒ����', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'ShangPinName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'���', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'GuiGe'
GO
EXEC sp_addextendedproperty N'MS_Description', N'���ر��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'HaiGuanNo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ͼƬ·��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'WuLiaoImagePath'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiao', 'COLUMN', N'CreateDate'
GO
--����MK_Info_WuLiao��Ĭ�ϲ�������
INSERT MK_Info_WuLiao(WuLiaoTypeID,ShangPinName,GuiGe,HaiGuanNo,WuLiaoImagePath,CreateUser,CreateDate) VALUES
('CED180AC-6003-4436-B09D-3428B3FD4B66',N'С��8',N'256G','No001','','System','2018-05-20'),
('CED180AC-6003-4436-B09D-3428B3FD4B66',N'С��7',N'256G','No001','','System','2018-05-20'),
('CED180AC-6003-4436-B09D-3428B3FD4B66',N'HUAWEI-P20',N'256G','No001','','System','2018-05-20'),
('F06AB1E8-468A-41DD-A1A3-0AE4D7D7C286',N'PCIE-512G',N'S','No002','','System','2018-05-20'),
('F06AB1E8-468A-41DD-A1A3-0AE4D7D7C286',N'PCIE-256G',N'S','No002','','System','2018-05-20'),
('F06AB1E8-468A-41DD-A1A3-0AE4D7D7C286',N'PCIE-128G',N'S','No002','','System','2018-05-20')
--����MK_Info_WuLiao������
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiao_CreateDate ON dbo.MK_Info_WuLiao(CreateDate DESC)
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiao_ShowMark ON dbo.MK_Info_WuLiao(ShowMark)
CREATE NONCLUSTERED INDEX IX_MK_Info_WuLiao_ShangPinName ON dbo.MK_Info_WuLiao(ShangPinName)


--��Ӧ����Ϣ
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
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * ��Ӧ����Ϣ', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Supplier', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'��Ӧ��ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��Ӧ������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'SupplierName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ϵ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'LianXiRen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ϵʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'LianXiFangShi'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ַ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'Address'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier', 'COLUMN', N'CreateDate'
GO
--����MK_Info_WuLiao��Ĭ�ϲ�������

--����MK_Info_WuLiao������
CREATE NONCLUSTERED INDEX IX_MK_Info_Supplier_CreateDate ON dbo.MK_Info_Supplier(CreateDate DESC)
CREATE NONCLUSTERED INDEX IX_MK_Info_Supplier_ShowMark ON dbo.MK_Info_Supplier(ShowMark)
CREATE NONCLUSTERED INDEX IX_MK_Info_Supplier_ShangPinName ON dbo.MK_Info_Supplier(SupplierName)


--��Ӧ����������������Ʒ��Ϣ
CREATE TABLE MK_Info_Supplier_WuLiao(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	SupplierID NVARCHAR(36),
	ShangPinID NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * ��Ӧ����������������Ʒ��Ϣ', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Supplier_WuLiao', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'��Ӧ������ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��Ӧ��ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'SupplierShangPinID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��Ʒ��ϢID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'SupplierName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Supplier_WuLiao', 'COLUMN', N'CreateDate'
GO
SELECT ID,SupplierID,ShangPinID,ShowMark,CreateUser,CreateDate FROM MK_Info_Supplier_WuLiao
--����MK_Info_Supplier_WuLiao��Ĭ�ϲ�������

--����MK_Info_Supplier_WuLiao������


--������˾ҵ��ά��
CREATE TABLE MK_Type_WuLiuYeWu(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	YeWuType NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * ������˾ҵ��ά��', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_WuLiuYeWu', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'ҵ��ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ҵ������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'YeWuType'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_WuLiuYeWu', 'COLUMN', N'CreateDate'
GO


--������˾ά��
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
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * ������˾ά��', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_WuLiu', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'������˾ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'ҵ��ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'YeWuID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ϵ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'LianXiRen'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ϵʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'LianXiFangShi'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ַ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'Address'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_WuLiu', 'COLUMN', N'CreateDate'
GO


--�ұ�
CREATE TABLE MK_Info_Currency(
	ID NVARCHAR(36) PRIMARY KEY DEFAULT NEWID() NOT NULL,
	CurrencyName NVARCHAR(30),
	CurrencyCode NVARCHAR(30),
	Remark NVARCHAR(255),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * �ұ�', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Currency', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'�ұ�ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CurrencyName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'���ִ���', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CurrencyCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'˵��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Currency', 'COLUMN', N'CreateDate'
GO


--�û���Ϣ
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
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * �û�', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_User', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'�û�ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'�û���', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'UserName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'Passwor'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������˾ҵ��ά��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'WuLiuYeWuID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ȩ����', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'PowerGroupID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ĭ������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'DefaultLanguage'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_User', 'COLUMN', N'CreateDate'
GO
INSERT INTO dbo.MK_Info_User
(
    ID,
    UserName,
    Passwor,
    WuLiuYeWuID,
    PowerGroupID,
    ShowMark,
    CreateUser,
    CreateDate
)
VALUES
(   NEWID(),      -- ID - nvarchar(36)
    N'mk',      -- UserName - nvarchar(30)
    N'123',      -- Passwor - nvarchar(30)
    N'1',      -- WuLiuYeWuID - nvarchar(36)
    N'1',      -- PowerGroupID - nvarchar(36)
    'Y',       -- ShowMark - char(1)
    N'mk',      -- CreateUser - nvarchar(30)
    GETDATE() -- CreateDate - datetime
)

--Ȩ����
CREATE TABLE MK_Info_PowerGroup(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerGroupName NVARCHAR(30),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * Ȩ����', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_PowerGroup', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ȩ����ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ȩ������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'PowerGroupName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerGroup', 'COLUMN', N'CreateDate'
GO

--Ȩ�ޱ�(�˵�)
CREATE TABLE MK_Type_Power(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerName  NVARCHAR(30),
	MenuAddress NVARCHAR(255),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
	Notes NVARCHAR(100),
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * Ȩ��', N'SCHEMA', N'dbo', N'TABLE', N'MK_Type_Power', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ȩ��ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ȩ����', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'PowerName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'�˵���ַ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'MenuAddress'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'CreateDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ע', 'SCHEMA', N'dbo', 'TABLE', N'MK_Type_Power', 'COLUMN', N'Notes'
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
(   NEWID(),       -- ID - nvarchar(36)
    N'����',       -- PowerName - nvarchar(30)
	N'../Quanxian/Index',
    'Y',        -- ShowMark - char(1)
    N'mk',       -- CreateUser - nvarchar(30)
    GETDATE(), -- CreateDate - datetime
    N'��������'        -- Notes - nvarchar(100)
)

--����(�˵�-����)
CREATE TABLE MK_Info_Features(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerID NVARCHAR(36),
	FeaturesName NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * ����', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_Features', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'�˵�ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'PowerID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'FeaturesName'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_Features', 'COLUMN', N'CreateDate'
GO

--Ȩ�޷����
CREATE TABLE MK_Info_PowerAllot(
	ID NVARCHAR(36)PRIMARY KEY DEFAULT NEWID() NOT NULL,
	PowerGroupID NVARCHAR(36),
	PowerID NVARCHAR(36),
	ShowMark CHAR(1) DEFAULT 'Y',
	CreateUser NVARCHAR(30),
	CreateDate DATETIME,
)
EXEC sp_addextendedproperty N'MS_Description', N'MK_MoonlightGoddess * Ȩ�޷���', N'SCHEMA', N'dbo', N'TABLE', N'MK_Info_PowerAllot', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ID��GUID��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'ID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ȩ����ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'PowerGroupID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Ȩ��ID', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'PowerID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'��ʾ��ʶ', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'ShowMark'
GO
EXEC sp_addextendedproperty N'MS_Description', N'������', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'CreateUser'
GO
EXEC sp_addextendedproperty N'MS_Description', N'����ʱ��', 'SCHEMA', N'dbo', 'TABLE', N'MK_Info_PowerAllot', 'COLUMN', N'CreateDate'
GO