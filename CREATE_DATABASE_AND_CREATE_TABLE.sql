CREATE DATABASE db_FMS
GO
USE db_FMS
GO

CREATE TABLE FACE(
    _Face_id VARCHAR(10) NOT NULL,
    _Face1 VARCHAR(15) NOT NULL,
    _Face2 VARCHAR(15) NOT NULL,
    _Face3 VARCHAR(15) NOT NULL,
    _Face4 VARCHAR(15) NOT NULL,
    CONSTRAINT PK_Face_id PRIMARY KEY(_Face_id)
)
GO

CREATE TABLE DEPARTMENT(
    _Department_id VARCHAR(10) NOT NULL,
    _Department_Name NVARCHAR(100) NOT NULL,
	_Department_Phone VARCHAR(10),
	_Department_Address NVARCHAR(100),
    CONSTRAINT PK_Department_id PRIMARY KEY(_Department_id)
)

GO

CREATE TABLE STAFF(
    _Staff_id VARCHAR(10) NOT NULL,
    _Staff_name NVARCHAR(30) NOT NULL,
    _Birthday DATE,
    _Gender BIT,
    _Identity_card VARCHAR(12),
    _Position NVARCHAR(20),
    _phone_number VARCHAR(10),
    _Ward NVARCHAR(20),
    _District NVARCHAR(20),
    _City NVARCHAR(20),
    _Department_id VARCHAR(10),
    _Face_id VARCHAR(10),
    CONSTRAINT PK_Staff_id PRIMARY KEY(_Staff_id),
    CONSTRAINT FK_Department_id FOREIGN KEY(_Department_id) REFERENCES DEPARTMENT(_Department_id),
    CONSTRAINT FK_Face_id FOREIGN KEY(_Face_id) REFERENCES Face(_Face_id)
)
GO

CREATE TABLE LOGIN(
    _Username VARCHAR(20) NOT NULL,
    _Password VARCHAR(20) NOT NULL,
    _Staff_id VARCHAR(10) NOT NULL,
    _Role INT NOT NULL,
    CONSTRAINT PK_Username PRIMARY KEY(_Username),
    CONSTRAINT FK_Staff_id FOREIGN KEY(_Staff_id) REFERENCES STAFF(_Staff_id)
)
GO

CREATE TABLE SPLIT_TIME(
    _Shift_id VARCHAR(10) NOT NULL,
    _Shift_name VARCHAR(10) NOT NULL,
    _Time_in varchar(20) NOT NULL,
    _Time_out DATE NOT NULL,
    CONSTRAINT PK__Shift_id PRIMARY KEY (_Shift_id)
)

GO

CREATE TABLE MENU(
    _Food_id VARCHAR(10) NOT NULL,
    _Food_name NVARCHAR(20) NOT NULL,
    _Description INT,
	_Imagefood varchar(100)
    CONSTRAINT PK_Food_id PRIMARY KEY(_Food_id)
)
alter table MENU
alter column _Description int

GO

CREATE TABLE ORDERS(
    _Order_id int Identity(1,1) NOT NULL,
    _Food_id VARCHAR(10) NOT NULL,
	_Staff_id VARCHAR(10) NOT NULL,
	_Shift_id varchar(10),
    _Order_date DATE,
    CONSTRAINT PK_Order_id PRIMARY KEY(_Order_id),
    CONSTRAINT FK_Food_id FOREIGN KEY(_Food_id) REFERENCES MENU(_Food_id),
	CONSTRAINT FK_OR_staff_id FOREIGN KEY(_Staff_id) REFERENCES STAFF(_Staff_id),
	CONSTRAINT FK_OR_shift_id FOREIGN KEY(_Shift_id) REFERENCES SPLIT_TIME(_Shift_id)
)
GO

CREATE TABLE SPLIT_SHIFTS(
    _Shift_id VARCHAR(10) NOT NULL,
    _Staff_id VARCHAR(10) NOT NULL,
	_day date,
    CONSTRAINT FK_Shift_id FOREIGN KEY(_Shift_id) REFERENCES SPLIT_TIME(_Shift_id),
    CONSTRAINT FK_Staff_id_SS FOREIGN KEY(_Staff_id) REFERENCES STAFF(_Staff_id)
)
GO

CREATE TABLE INGREDIENT(
    _Material_id VARCHAR(10) NOT NULL,
    _Material_name NVARCHAR(20) NOT NULL,
    _Quantity_I INT ,
    _Unit varchar(50) ,
    CONSTRAINT PK_Material_id PRIMARY KEY(_Material_id)
)
GO

CREATE TABLE SUPPLIER(
    _Supplier_id VARCHAR(10) NOT NULL,
    _Supplier_name NVARCHAR(50) NOT NULL,
	_Supplier_phone VARCHAR(11) ,
	_Supplier_address NVARCHAR(50),
    _Material_id VARCHAR(10) ,
    _Quantity_S INT ,
    _Unit varchar(20),
    CONSTRAINT PK_Supplier_id PRIMARY KEY(_Supplier_id),
    CONSTRAINT FK_Material_id FOREIGN KEY (_Material_id) REFERENCES INGREDIENT(_Material_id)
)
select * from Staff
