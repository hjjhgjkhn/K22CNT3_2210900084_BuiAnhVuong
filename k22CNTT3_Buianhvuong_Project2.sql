
CREATE DATABASE K22CNT3_Buianhvuong_Project2;
use K22CNT3_Buianhvuong_Project2;
GO

CREATE TABLE KHACH_HANG (
    Ma_KH INT PRIMARY KEY IDENTITY,
    Ten_KH VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    SDT VARCHAR(15),
    Dia_chi VARCHAR(255),
    Mat_khau VARCHAR(255) NOT NULL
);

CREATE TABLE DANH_MUC (
    Ma_DM INT PRIMARY KEY IDENTITY,
    Ten_DM VARCHAR(100) NOT NULL
);

CREATE TABLE SAN_PHAM (
    Ma_SP INT PRIMARY KEY IDENTITY,
    Ten_SP VARCHAR(255) NOT NULL,
    Gia DECIMAL(10, 2) NOT NULL,
    Mo_ta TEXT,
    So_luong INT NOT NULL,
    Ma_DM INT,
    FOREIGN KEY (Ma_DM) REFERENCES DANH_MUC(Ma_DM)
);

CREATE TABLE GIO_HANG (
    Ma_GH INT PRIMARY KEY IDENTITY,
    Ma_KH INT,
    Ngay_tao DATE NOT NULL,
    FOREIGN KEY (Ma_KH) REFERENCES KHACH_HANG(Ma_KH)
);

CREATE TABLE CHI_TIET_GH (
    Ma_GH INT,
    Ma_SP INT,
    So_luong INT NOT NULL,
    PRIMARY KEY (Ma_GH, Ma_SP),
    FOREIGN KEY (Ma_GH) REFERENCES GIO_HANG(Ma_GH),
    FOREIGN KEY (Ma_SP) REFERENCES SAN_PHAM(Ma_SP)
);

CREATE TABLE DON_HANG (
    Ma_DH INT PRIMARY KEY IDENTITY,
    Ma_KH INT,
    Ngay_dat DATE NOT NULL,
    Tong_tien DECIMAL(10, 2) NOT NULL,
    Trang_thai VARCHAR(50) NOT NULL,
    FOREIGN KEY (Ma_KH) REFERENCES KHACH_HANG(Ma_KH)
);

CREATE TABLE CHI_TIET_DH (
    Ma_DH INT,
    Ma_SP INT,
    So_luong INT NOT NULL,
    Don_gia DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (Ma_DH, Ma_SP),
    FOREIGN KEY (Ma_DH) REFERENCES DON_HANG(Ma_DH),
    FOREIGN KEY (Ma_SP) REFERENCES SAN_PHAM(Ma_SP)
);

CREATE TABLE QUAN_TRI (
    Ma_QL INT PRIMARY KEY IDENTITY,
    Ten_QL VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Mat_khau VARCHAR(255) NOT NULL
);

INSERT INTO KHACH_HANG (Ten_KH, Email, SDT, Dia_chi, Mat_khau)
VALUES
    ('Nguyen Van A', 'a@example.com', '0901234567', 'Hà Nội', 'password1'),
    ('Tran Thi B', 'b@example.com', '0902345678', 'Hồ Chí Minh', 'password2'),
    ('Le Minh C', 'c@example.com', '0903456789', 'Đà Nẵng', 'password3'),
    ('Pham Lan D', 'd@example.com', '0904567890', 'Cần Thơ', 'password4'),
    ('Nguyen Thi E', 'e@example.com', '0905678901', 'Huế', 'password5');

-- Thêm 5 bản ghi vào bảng DANH_MUC
INSERT INTO DANH_MUC (Ten_DM)
VALUES
    ('Điện Thoại'),
    ('Laptop'),
    ('Máy Tính Bảng'),
    ('Phụ Kiện'),
    ('Thiết Bị Gia Dụng');

-- Thêm 5 bản ghi vào bảng SAN_PHAM
INSERT INTO SAN_PHAM (Ten_SP, Gia, Mo_ta, So_luong, Ma_DM)
VALUES
    ('iPhone 14', 22999.00, 'Điện thoại Apple', 50, 1),
    ('MacBook Air M1', 17999.00, 'Laptop Apple', 30, 2),
    ('Samsung Galaxy Tab S7', 12000.00, 'Máy tính bảng Samsung', 20, 3),
    ('Tai nghe AirPods', 5999.00, 'Tai nghe Bluetooth Apple', 100, 4),
    ('Máy xay sinh tố Philips', 1500.00, 'Máy xay sinh tố', 75, 5);

-- Thêm 5 bản ghi vào bảng GIO_HANG
INSERT INTO GIO_HANG (Ma_KH, Ngay_tao)
VALUES
    (1, '2024-11-01'),
    (2, '2024-11-02'),
    (3, '2024-11-03'),
    (4, '2024-11-04'),
    (5, '2024-11-05');

-- Thêm 5 bản ghi vào bảng CHI_TIET_GH
INSERT INTO CHI_TIET_GH (Ma_GH, Ma_SP, So_luong)
VALUES
    (1, 1, 2),
    (1, 3, 1),
    (2, 2, 1),
    (3, 4, 3),
    (4, 5, 1);

-- Thêm 5 bản ghi vào bảng DON_HANG
INSERT INTO DON_HANG (Ma_KH, Ngay_dat, Tong_tien, Trang_thai)
VALUES
    (1, '2024-11-01', 45998.00, 'Đang xử lý'),
    (2, '2024-11-02', 17999.00, 'Đã giao'),
    (3, '2024-11-03', 11997.00, 'Đang xử lý'),
    (4, '2024-11-04', 1500.00, 'Hủy bỏ'),
    (5, '2024-11-05', 5999.00, 'Đang xử lý');

-- Thêm 5 bản ghi vào bảng CHI_TIET_DH
INSERT INTO CHI_TIET_DH (Ma_DH, Ma_SP, So_luong, Don_gia)
VALUES
    (1, 1, 2, 22999.00),
    (1, 3, 1, 12000.00),
    (2, 2, 1, 17999.00),
    (3, 4, 3, 5999.00),
    (4, 5, 1, 1500.00);

-- Thêm 5 bản ghi vào bảng QUAN_TRI
INSERT INTO QUAN_TRI (Ten_QL, Email, Mat_khau)
VALUES
    ('Nguyen Quang X', 'qx@example.com', 'admin123'),
    ('Le Thanh Y', 'ty@example.com', 'admin456'),
    ('Pham Minh Z', 'mz@example.com', 'admin789'),
    ('Tran Quang W', 'qw@example.com', 'admin321'),
    ('Nguyen Thi U', 'tu@example.com', 'admin654');

DROP TABLE IF EXISTS CHI_TIET_DH;
DROP TABLE IF EXISTS CHI_TIET_GH;
DROP TABLE IF EXISTS DON_HANG;
DROP TABLE IF EXISTS GIO_HANG;
DROP TABLE IF EXISTS SAN_PHAM;
DROP TABLE IF EXISTS DANH_MUC;
DROP TABLE IF EXISTS KHACH_HANG;
DROP TABLE IF EXISTS QUAN_TRI;

SELECT * FROM KHACH_HANG;
SELECT * FROM DANH_MUC;
SELECT * FROM SAN_PHAM;
SELECT * FROM GIO_HANG;
SELECT * FROM CHI_TIET_GH;
SELECT * FROM DON_HANG;
SELECT * FROM CHI_TIET_DH;
SELECT * FROM QUAN_TRI;