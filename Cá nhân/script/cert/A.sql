/*---------------------------------------------------------- 
MASV: 18120397
HO TEN: NGUYEN DANG HONG HUY
LAB: 03 
NGAY: 06/05/2021
----------------------------------------------------------*/ 
USE [master]

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'QLSV')
BEGIN
	DROP DATABASE QLSV
END;

CREATE DATABASE QLSV;
