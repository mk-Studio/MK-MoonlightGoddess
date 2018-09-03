


CREATE TRIGGER [dbo].[T_InfoCurrency]
ON dbo.MK_Info_Currency
FOR INSERT,UPDATE,DELETE
AS
BEGIN
	 --新增
    IF (EXISTS(SELECT  1 FROM Inserted) AND  NOT  EXISTS(SELECT 1 FROM Deleted))
    BEGIN  
		INSERT dbo.MK_Type_DataDictionary( ID, DataLabelID ,DataTypeName, ShowMark, CreateUser ,CreateDate)
		SELECT ID
		,'B95165EF-AEED-46E5-8966-90BE7BFDDAB4'
		,CurrencyName
		,ShowMark
		,CreateUser
		,CreateDate 
		FROM Inserted
	END                          
           
    --删除
    IF (NOT EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
       DELETE FROM MK_Type_DataDictionary 
	   WHERE ID IN (SELECT ID FROM Deleted)
    END 
                        
    --更新
    IF (EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
        IF UPDATE(CurrencyName) OR UPDATE(ShowMark)
		BEGIN
		    UPDATE MK_Type_DataDictionary SET DataTypeName = a.CurrencyName,ShowMark = a.ShowMark
			FROM Inserted a 
			WHERE MK_Type_DataDictionary.ID = a.ID
		END
    END 
END


CREATE TRIGGER [dbo].[T_InfoSupplier]
ON dbo.MK_Info_Supplier
FOR INSERT,UPDATE,DELETE
AS
BEGIN
	 --新增
    IF (EXISTS(SELECT  1 FROM Inserted) AND  NOT  EXISTS(SELECT 1 FROM Deleted))
    BEGIN  
		INSERT dbo.MK_Type_DataDictionary( ID ,DataLabelID ,DataTypeName,ShowMark,CreateUser ,CreateDate)
		SELECT 
		ID
		,'2F05D790-928C-4305-84BC-5FDD6485B852'
		,Inserted.SupplierName
		,ShowMark
		,CreateUser
		,CreateDate 
		FROM Inserted
	END                          
           
    --删除
    IF (NOT EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
       DELETE FROM MK_Type_DataDictionary 
	   WHERE ID IN (SELECT ID FROM Deleted)
    END 
                        
    --更新
    IF (EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
        IF UPDATE(SupplierName) OR UPDATE(ShowMark)
		BEGIN
		    UPDATE MK_Type_DataDictionary SET DataTypeName = a.SupplierName,ShowMark = a.ShowMark
			FROM Inserted a 
			WHERE MK_Type_DataDictionary.ID = a.ID
		END
    END 
END



CREATE TRIGGER [dbo].[T_InfoWuLiuCompany]
ON dbo.MK_Info_WuLiuCompany
FOR INSERT,UPDATE,DELETE
AS
BEGIN
	 --新增
    IF (EXISTS(SELECT  1 FROM Inserted) AND  NOT  EXISTS(SELECT 1 FROM Deleted))
    BEGIN  
		INSERT dbo.MK_Type_DataDictionary( ID ,DataLabelID ,DataTypeName,ShowMark,CreateUser ,CreateDate)
		SELECT 
		ID
		,'52AEA76A-E82C-4C44-A2B4-C78962732CE4'
		,Inserted.Name
		,ShowMark
		,CreateUser
		,CreateDate 
		FROM Inserted
	END                          
           
    --删除
    IF (NOT EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
       DELETE FROM MK_Type_DataDictionary 
	   WHERE ID IN (SELECT ID FROM Deleted)
    END 
                        
    --更新
    IF (EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
        IF UPDATE(Name) OR UPDATE(ShowMark)
		BEGIN
		    UPDATE MK_Type_DataDictionary SET DataTypeName = a.Name ,ShowMark = a.ShowMark
			FROM Inserted a 
			WHERE MK_Type_DataDictionary.ID = a.ID
		END
    END 
END



CREATE TRIGGER [dbo].[T_InfoWuLiao]
ON [dbo].[MK_Info_WuLiao]
FOR INSERT,UPDATE,DELETE
AS
BEGIN
	 --新增
    IF (EXISTS(SELECT  1 FROM Inserted) AND  NOT  EXISTS(SELECT 1 FROM Deleted))
    BEGIN  
		 INSERT dbo.MK_Type_DataDictionary( ID ,DataLabelID ,DataTypeName,CreateUser ,CreateDate)
		 SELECT 
		 Inserted.ID
		 ,'B2D64303-C9BA-425A-B20A-3BC774EF341E'
		 ,(Inserted.ShangPinName +' '+Inserted.GuiGe)
		 ,Inserted.CreateUser
		 ,Inserted.CreateDate 
		 FROM Inserted
	END                          
           
    --删除
    IF (NOT EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
       DELETE FROM MK_Type_DataDictionary 
	   WHERE ID IN (SELECT ID FROM Deleted)
    END 
                        
    --更新
    IF (EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
        IF UPDATE(ShangPinName) OR UPDATE(GuiGe) OR UPDATE(ShowMark)
		BEGIN
		    UPDATE MK_Type_DataDictionary SET DataTypeName = (a.ShangPinName +' '+a.GuiGe),ShowMark = a.ShowMark
			FROM Inserted a 
			WHERE MK_Type_DataDictionary.ID = a.ID
		END
    END 
END



CREATE TRIGGER [dbo].[T_TypeWuLiao]
ON dbo.MK_Type_WuLiao
FOR INSERT,UPDATE,DELETE
AS
BEGIN
	 --新增
    IF (EXISTS(SELECT  1 FROM Inserted) AND  NOT  EXISTS(SELECT 1 FROM Deleted))
    BEGIN  
		INSERT dbo.MK_Type_DataDictionary( ID ,DataLabelID ,DataTypeName,ShowMark,CreateUser ,CreateDate)
		SELECT 
		ID
		,'10FF5516-3CB1-4ABE-AF9C-33282B53F4EF'
		,WuLiaoTypeName
		,ShowMark
		,CreateUser
		,CreateDate 
		FROM Inserted
	END                          
           
    --删除
    IF (NOT EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
       DELETE FROM MK_Type_DataDictionary 
	   WHERE ID IN (SELECT ID FROM Deleted)
    END 
                        
    --更新
    IF (EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
        IF UPDATE(WuLiaoTypeName) OR UPDATE(ShowMark)
		BEGIN
		    UPDATE MK_Type_DataDictionary SET DataTypeName = a.WuLiaoTypeName ,ShowMark = a.ShowMark
			FROM Inserted a 
			WHERE MK_Type_DataDictionary.ID = a.ID
		END
    END 
END



CREATE TRIGGER [dbo].[T_TypeWuLiuYeWu]
ON dbo.MK_Type_WuLiuYeWu
FOR INSERT,UPDATE,DELETE
AS
BEGIN
	 --新增
    IF (EXISTS(SELECT  1 FROM Inserted) AND  NOT  EXISTS(SELECT 1 FROM Deleted))
    BEGIN  
		INSERT dbo.MK_Type_DataDictionary( ID ,DataLabelID ,DataTypeName,ShowMark,CreateUser ,CreateDate)
		SELECT 
		ID
		,'D3A3E9B3-9E6B-44F8-883C-D692084B0296'
		,YeWuType
		,ShowMark
		,CreateUser
		,CreateDate 
		FROM Inserted
	END                          
           
    --删除
    IF (NOT EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
       DELETE FROM MK_Type_DataDictionary 
	   WHERE ID IN (SELECT ID FROM Deleted)
    END 
                        
    --更新
    IF (EXISTS(SELECT 1 FROM Inserted) AND  EXISTS(SELECT 1 FROM Deleted))
    BEGIN 
        IF UPDATE(YeWuType) OR UPDATE(ShowMark)
		BEGIN
		    UPDATE MK_Type_DataDictionary SET DataTypeName = a.YeWuType ,ShowMark = a.ShowMark
			FROM Inserted a 
			WHERE MK_Type_DataDictionary.ID = a.ID
		END
    END 
END
