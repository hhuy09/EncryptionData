/*---------------------------------------------------------- 
MASV: 18120397 - 18120399 - 18120423
HO TEN CAC THANH VIEN NHOM: 
	Nguyễn Đặng Hồng Huy
	Phạm Đức Huy
	Trịnh Tấn Khoa
LAB: 03 - NHOM 
NGAY: 28/04/2021
----------------------------------------------------------*/ 
USE [master]

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'QLSV')
BEGIN
	DROP DATABASE QLSV
END;

CREATE DATABASE QLSV;
