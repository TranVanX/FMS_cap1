INSERT INTO DEPARTMENT VALUES
('KT','Accountant','0123456789',N'phòng 601,Tầng6'),
('HR','Human Resouces','0123456789',N'phòng 306,Tầng3'),
('CS','Customer Service','0123456789',N'phòng 201,Tầng2'),
('MKT','Marketing','0123456789',N'phòng 701,Tầng7');

Insert INTO STAFF(_Staff_id,_Staff_name,_Birthday,_Gender,_Identity_card,_Position,_phone_number,_Ward,_District,_City, _Department_id) values
('001',N'Trần Văn Nhân','2001-6-23',1,'201853227','Developer','0123456789',N'Khuê Trung',N'Cẩm Lệ',N'Đà Nẵng','MKT'),
('002',N'Phan Anh Tuấn','2001-7-23',1,'201853228','backend engineer','0123456789',N'Khuê Trung',N'Cẩm Lệ',N'Bình Định','HR'),
('003',N'Huỳnh Đức Huy','2001-8-23',1,'201853229','Developer','0123456789',N'Khuê Trung',N'Liên Chiểu',N'Quảng Nam','CS'),
('004',N'Châu Ngọc Huy','2001-9-23',1,'201853226','front engineer','0123456789',N'Khuê Trung',N'Hải Châu',N'Đà Nẵng','KT')

Insert into LOGIN values
('nhan001','1','001',1),
('tuan001','1','002',2),
('hhuy001','1','003',3),
('chuy001','1','004',4)

INSERT INTO SPLIT_TIME
VALUES ('S01', 'Ca sang', '7:00 AM', '12:00 AM'),
('S02', 'Ca chieu', '12:00 AM', '5:00 PM'),
('S03', 'Ca toi', '6:00 PM', '10:00 PM');


INSERT INTO MENU(_Food_id,_Food_name)
VALUES ('F01', 'Com Thit Kho Trung'),
('F02', 'Com Suon Ram Man'),
('F03', 'Com Thit Kho Cai'),
('F04', 'Com Ga Kho Sa Ot'),
('F05', 'Com Ga Chien Mam')

INSERT INTO ORDERS
VALUES ('OD01', 'F02', '2022-11-12'),
('OD02', 'F01', '2022-11-13'),
('OD03', 'F04', '2022-11-14'),
('OD04', 'F05', '2022-11-14'),
('OD05', 'F07', '2022-11-14'),
('OD06', 'F07', '2022-11-13'),
('OD07', 'F10', '2022-11-12'),
('OD08', 'F09', '2022-11-14'),
('OD09', 'F04', '2022-11-14'),
('OD10', 'F03', '2022-11-14');


INSERT INTO SPLIT_SHIFTS
VALUES ('S01', 'ST01', 'OD01'), 
('S04', 'ST02', 'OD02'), 
('S05', 'ST03', 'OD03'), 
('S06', 'ST04', 'OD04'), 
('S08', 'ST04', 'OD05'), 
('S02', 'ST02', 'OD06'), 
('S03', 'ST01', 'OD07'), 
('S07', 'ST03', 'OD08'), 
('S09', 'ST05', 'OD09'), 
('S10', 'ST05', 'OD10'); 


INSERT INTO INGREDIENT
VALUES ('MA01', 'Trung Ga', 100, 'Kg'),
('MA02', 'Ca', 100,'Kg'), 
('MA03', 'Ga', 50,'Con'), 
('MA04', 'Dau Hu', 20,'Kg'), 
('MA05', 'Cai Muoi', 20,'Kg'), 
('MA06', 'Thit Bo', 100,'Kg'), 
('MA07', 'Thit Heo', 100,'Kg'), 
('MA08', 'Gia Do', 20,'Kg'), 
('MA09', 'Ot', 10,'Kg'), 
('MA10', 'Ca Chua', 20,'Kg'); 


INSERT INTO SUPPLIER
VALUES ('SL01', 'Bao Nguyen Food','0123456789',N'36 hoang diệu','MA01', 100, 'Kg'),
('SL02', 'Bao Nguyen Food','0123456789',N'36 hoang diệu','MA02', 100, 'Kg'),
('SL03', 'Bao Nguyen Food','0123456789',N'36 hoang diệu','MA03', 50, 'Con'),
('SL04', 'Bao Nguyen Food','0123456789',N'36 hoang diệu','MA06', 100, 'Kg'),
('SL05', 'Bao Nguyen Food','0123456789',N'36 hoang diệu','MA07', 100, 'Kg'),
('SL06', 'NongPro','0123456789',N'36 hoang diệu','MA04', 20, 'Kg'),
('SL07', 'NongPro','0123456789',N'36 hoang diệu','MA05', 20, 'Kg'),
('SL08', 'NongPro','0123456789',N'36 hoang diệu','MA08', 20, 'Kg'),
('SL09', 'NongPro','0123456789',N'36 hoang diệu','MA09', 10, 'Kg'),
('SL10', 'NongPro','0123456789',N'36 hoang diệu','MA10', 20, 'Kg');