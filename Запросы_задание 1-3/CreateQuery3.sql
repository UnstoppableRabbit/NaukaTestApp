CREATE TABLE Provider(
ProviderID INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(150) NOT NULL
)

CREATE TABLE ReceiptOrder(
OrderNum INT IDENTITY(1,1) PRIMARY KEY,
OrderDate DATETIME not null,
DeliveryContract NVARCHAR(200) NOT NULL , --предполагается что хранится адрес или ссылка на реальный договор поставки
ProviderID int not null foreign key references Provider(ProviderID),
TotalPrice MONEY NOT NULL
)

Create index IX_RecOrder_OrDate
on ReceiptOrder(OrderDate)

CREATE TABLE Warehouse(
WarehouseID INT IDENTITY(1,1) PRIMARY KEY,
Address NVARCHAR(150) NOT NULL
)

CREATE TABLE Product(
ProductNumber INT IDENTITY(1,1) PRIMARY KEY,
Description NVARCHAR(1000) NOT NULL,
Cost MONEY NOT NULL,
Name NVARCHAR(100)
)

Create index IX_Prod_Cost
on Product(Cost)

CREATE TABLE ReceiptOrder_Product (
ID INT IDENTITY(1,1) PRIMARY KEY,
OrderNum int not null foreign key references ReceiptOrder(OrderNum),
Quantity INT NOT NULL,
WarehouseID INT NOT NULL FOREIGN KEY REFERENCES Warehouse(WarehouseID),
ProductNumber INT NOT NULL FOREIGN KEY REFERENCES Product(ProductNumber),
)