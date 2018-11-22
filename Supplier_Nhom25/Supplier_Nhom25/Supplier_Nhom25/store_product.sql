create proc sp_LoadSupplier
as
begin
	select * from Suppliers
end
go 
CREATE PROC sp_FindIDMax
as
begin
	select max(SupplierID) from Suppliers
end
go 
alter proc sp_AddSupplier
@cpn varchar(255), @ctn varchar(255), @ctt varchar(255), @adr nvarchar(255), @cty varchar(50), @region varchar(20), @ptc varchar(30), @country varchar(20), @phone varchar(30), @fax varchar(30), @hmp NTEXT
as
BEGIN
INSERT INTO dbo.Suppliers
        ( CompanyName ,
          ContactName ,
          ContactTitle ,
          Address ,
          City ,
          Region ,
          PostalCode ,
          Country ,
          Phone ,
          Fax ,
          HomePage
        )
VALUES  ( @cpn , -- CompanyName - nvarchar(40)
          @ctn, -- ContactName - nvarchar(30)
          @ctt, -- ContactTitle - nvarchar(30)
          @adr , -- Address - nvarchar(60)
          @cty , -- City - nvarchar(15)
          @region, -- Region - nvarchar(15)
          @ptc , -- PostalCode - nvarchar(10)
          @country , -- Country - nvarchar(15)
		  @phone , -- Phone - nvarchar(24)
          @fax , -- Fax - nvarchar(24)
          @hmp  -- HomePage - ntext
        )
end
go
create proc sp_DeleteSupplier
@id int
as
begin
	DELETE dbo.Suppliers WHERE SupplierID = @id
end
GO 
create proc sp_UpdateSupplier
@id INT,@cpn varchar(255), @ctn varchar(255), @ctt varchar(255), @adr nvarchar(255), @cty varchar(50), @region varchar(20), @ptc varchar(30), @country varchar(20), @phone varchar(30), @fax varchar(30), @hmp NTEXT
as
begin
	UPDATE dbo.Suppliers SET CompanyName = @cpn, ContactName = @ctn, ContactTitle = @ctt, Address =@adr, City = @cty, Region = @region, PostalCode = @ptc, Country = @country, Phone = @phone, Fax = @fax, HomePage = @hmp WHERE SupplierID = @id
end
go 