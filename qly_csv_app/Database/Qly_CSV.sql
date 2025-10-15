CREATE DATABASE QuanLy_CSV;

USE QuanLy_CSV;

CREATE TABLE Khoa (
    khoa_id INT PRIMARY KEY IDENTITY(1,1),
    ten_khoa NVARCHAR(255) NOT NULL
);

CREATE TABLE Nganh (
    nganh_id INT PRIMARY KEY IDENTITY(1,1),
    ten_nganh NVARCHAR(255) NOT NULL,
    khoa_id INT,
    FOREIGN KEY (khoa_id) REFERENCES Khoa(khoa_id) ON DELETE CASCADE
);

CREATE TABLE KhoaHoc (
    khoa_hoc_id INT PRIMARY KEY IDENTITY(1,1),
    ten_khoa_hoc NVARCHAR(255) NOT NULL,
    nam_bat_dau INT,
    nam_ket_thuc INT,
    nganh_id INT,
    FOREIGN KEY (nganh_id) REFERENCES Nganh(nganh_id) ON DELETE CASCADE
);

CREATE TABLE CuuSV (
    CSV_id INT PRIMARY KEY IDENTITY(1,1),
    Ten NVARCHAR(255) NOT NULL,
    NgaySinh DATE,
    MSSV VARCHAR(20) UNIQUE NOT NULL,
    DC NVARCHAR(MAX),
    email VARCHAR(255) UNIQUE,
    phone VARCHAR(10),
    khoa_hoc_id INT,
    FOREIGN KEY (khoa_hoc_id) REFERENCES KhoaHoc(khoa_hoc_id) ON DELETE SET NULL
);

CREATE TABLE [User] (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(255) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    role_type NVARCHAR(100) CHECK (role_type IN (N'admin', N'Cựu sinh viên', N'giảng viên')) NOT NULL,
    is_active BIT DEFAULT 1,
    CSV_id INT NULL,
    FOREIGN KEY (CSV_id) REFERENCES CuuSV(CSV_id) ON DELETE SET NULL
);

CREATE TABLE Job (
    job_id INT PRIMARY KEY IDENTITY(1,1),
    ViTri NVARCHAR(255) NOT NULL,
    CTY NVARCHAR(255),
    achievements NVARCHAR(MAX),
    start_date DATE,
    CSV_id INT,
    FOREIGN KEY (CSV_id) REFERENCES CuuSV(CSV_id) ON DELETE CASCADE
);

CREATE TABLE Event (
    event_id INT PRIMARY KEY IDENTITY(1,1),
    event_name NVARCHAR(255) NOT NULL,
    event_date DATE,
    so_luong_tham_gia INT DEFAULT 0,
    description NVARCHAR(MAX)
);

CREATE TABLE Participation (
    participation_id INT PRIMARY KEY IDENTITY(1,1),
    CSV_id INT,
    event_id INT,
    participation_date DATE,
    feedback NVARCHAR(MAX),
    status NVARCHAR(10) CHECK (status IN (N'Được mời', N'Chấp nhận', N'Từ chối')) DEFAULT N'Được mời',
    FOREIGN KEY (CSV_id) REFERENCES CuuSV(CSV_id),
    FOREIGN KEY (event_id) REFERENCES Event(event_id)
);

CREATE TABLE Contribution (
    contribution_id INT PRIMARY KEY IDENTITY(1,1),
    CSV_id INT,
    contribution_type NVARCHAR(10) CHECK (contribution_type IN (N'Tiền', N'khác')) NOT NULL,
    amount DECIMAL(10,2),
    contribution_date DATE,
    details NVARCHAR(MAX),
    FOREIGN KEY (CSV_id) REFERENCES CuuSV(CSV_id),
);

GO
-- 1. TRIGGER: Tự động tạo tài khoản User khi thêm cựu sinh viên mới
CREATE TRIGGER trg_CuuSV_CreateUser
ON CuuSV
AFTER INSERT
AS
BEGIN
    INSERT INTO [User] (username, password, role_type, is_active, CSV_id)
    SELECT 
        i.email,
        'CSV123', -- Mật khẩu mặc định
        N'Cựu sinh viên',
        1,
        i.CSV_id
    FROM inserted i
    WHERE i.email IS NOT NULL;
END;
GO

-- 2. TRIGGER: Kiểm tra tuổi khi thêm/cập nhật cựu sinh viên
CREATE TRIGGER trg_CuuSV_CheckAge
ON CuuSV
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted 
        WHERE DATEDIFF(YEAR, NgaySinh, GETDATE()) < 22
    )
    BEGIN
        RAISERROR('Tuổi của cựu sinh viên phải từ 22 tuổi!', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

-- 3. TRIGGER: Kiểm tra năm tốt nghiệp hợp lệ
CREATE TRIGGER trg_KhoaHoc_ValidateYear
ON KhoaHoc
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted 
        WHERE nam_bat_dau >= nam_ket_thuc
    )
    BEGIN
        RAISERROR('Năm bắt đầu phải nhỏ hơn năm kết thúc!', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

-- 4. TRIGGER: Cập nhật số lượng tham gia khi có thay đổi
CREATE TRIGGER trg_Participation_UpdateEventCount
ON Participation
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    -- Cập nhật số lượng tham gia cho các sự kiện bị ảnh hưởng
    UPDATE Event 
    SET so_luong_tham_gia = (
        SELECT COUNT(*) 
        FROM Participation p 
        WHERE p.event_id = Event.event_id 
        AND p.status = N'Chấp nhận'
    )
    WHERE event_id IN (
        SELECT ISNULL(i.event_id, d.event_id)
        FROM (SELECT event_id FROM inserted) i
        FULL OUTER JOIN (SELECT event_id FROM deleted) d
        ON i.event_id = d.event_id
    );
END;
GO

-- 5. TRIGGER: Kiểm tra email hợp lệ khi thêm/cập nhật cựu sinh viên
CREATE TRIGGER trg_CuuSV_ValidateEmail
ON CuuSV
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted 
        WHERE email IS NOT NULL 
        AND email NOT LIKE '%_@__%.__%'
    )
    BEGIN
        RAISERROR('Email không đúng định dạng!', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

-- 6. TRIGGER: Kiểm tra ngày bắt đầu công việc hợp lệ
CREATE TRIGGER trg_Job_ValidateStartDate
ON Job
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted i
        INNER JOIN CuuSV c ON i.CSV_id = c.CSV_id
        WHERE i.start_date < c.NgaySinh 
    )
    BEGIN
        RAISERROR('Ngày bắt đầu công việc không hợp lệ!', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

-- 7. TRIGGER: Kiểm tra số điện thoại hợp lệ (10 số và bắt đầu bằng 0)
CREATE TRIGGER trg_CuuSV_ValidatePhone
ON CuuSV
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM inserted 
        WHERE phone IS NOT NULL 
        AND (
            LEN(phone) != 10 
            OR phone NOT LIKE '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
            OR phone NOT LIKE '[0-9]%'
        )
    )
    BEGIN
        RAISERROR('Số điện thoại phải có đúng 10 chữ số và bắt đầu bằng số 0!', 16, 1);
        ROLLBACK TRANSACTION;
    END;
END;
GO

-- 8. TRIGGER: Xóa tài khoản User khi xóa cựu sinh viên
CREATE TRIGGER trg_CuuSV_DeleteUser
ON CuuSV
AFTER DELETE
AS
BEGIN
    -- Xóa tài khoản User có liên kết với cựu sinh viên bị xóa
    DELETE FROM [User]
    WHERE CSV_id IN (SELECT CSV_id FROM deleted)
    AND role_type = N'Cựu sinh viên';
    
    -- Log thông tin (tùy chọn)
    IF @@ROWCOUNT > 0
    BEGIN
        PRINT 'Đã xóa tài khoản User tương ứng với cựu sinh viên bị xóa.';
    END
END;
GO

--9. trigger: Không được mời 1 cựu sinh viên tham gia nhiều hơn 1 sự kiện trong 1 ngày
DROP TRIGGER IF EXISTS trg_Participation_OneEventPerDay;
GO

--CREATE TRIGGER trg_Participation_OneEventPerDay
--ON Participation
--AFTER INSERT, UPDATE
--AS
--BEGIN
    -- Kiểm tra xem có cựu sinh viên nào được mời tham gia nhiều hơn 1 sự kiện trong cùng 1 ngày không
    -- Chỉ kiểm tra với các sự kiện có ngày tổ chức trùng nhau
    --IF EXISTS (
        --SELECT CSV_id, event_date
        --FROM Participation p
        --INNER JOIN Event e ON p.event_id = e.event_id
        --WHERE EXISTS (
            --SELECT 1
            --FROM inserted i
            --INNER JOIN Event ie ON i.event_id = ie.event_id
            --WHERE i.CSV_id = p.CSV_id 
            --AND ie.event_date = e.event_date
        --)
        --GROUP BY CSV_id, event_date
        --HAVING COUNT(DISTINCT p.event_id) > 1
    --)
    --BEGIN
    --    RAISERROR(N'Một cựu sinh viên không được mời tham gia nhiều hơn 1 sự kiện trong cùng 1 ngày!', 16, 1);
    --    ROLLBACK TRANSACTION;
  --  END;
--END;
GO
-- trgger: 

CREATE TRIGGER trg_Participation_OneAcceptedEventPerDay
ON Participation
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Chỉ kiểm tra khi có thay đổi status thành 'Chấp nhận'
    IF EXISTS (SELECT 1 FROM inserted WHERE status = N'Chấp nhận')
    BEGIN
        -- Kiểm tra xem có cựu sinh viên nào chấp nhận nhiều hơn 1 sự kiện 
        -- diễn ra trong cùng 1 ngày không
        IF EXISTS (
            SELECT p.CSV_id, e.event_date
            FROM Participation p
            INNER JOIN Event e ON p.event_id = e.event_id
            WHERE p.CSV_id IN (
                SELECT DISTINCT i.CSV_id 
                FROM inserted i 
                WHERE i.status = N'Chấp nhận'
            )
            AND p.status = N'Chấp nhận'  -- Chỉ đếm các sự kiện đã chấp nhận
            GROUP BY p.CSV_id, e.event_date
            HAVING COUNT(DISTINCT p.event_id) > 1
        )
        BEGIN
            RAISERROR(N'Lỗi: Một cựu sinh viên chỉ được chấp nhận tham gia 1 sự kiện trong cùng 1 ngày!', 16, 1);
            ROLLBACK TRANSACTION;
        END;
    END;
END;
GO

--Xóa dữ liệu bảng
DELETE FROM Participation;
DELETE FROM Contribution;
DELETE FROM Job;
DELETE FROM [User];
DELETE FROM CuuSV;
DELETE FROM Event;
DELETE FROM KhoaHoc;
DELETE FROM Nganh;
DELETE FROM Khoa;

GO
--Xóa trigger
DROP TRIGGER IF EXISTS trg_CuuSV_CreateUser;
DROP TRIGGER IF EXISTS trg_CuuSV_CheckAge;
DROP TRIGGER IF EXISTS trg_KhoaHoc_ValidateYear;
DROP TRIGGER IF EXISTS trg_Participation_UpdateEventCount;
DROP TRIGGER IF EXISTS trg_CuuSV_ValidateEmail;
DROP TRIGGER IF EXISTS trg_Job_ValidateStartDate;
DROP TRIGGER IF EXISTS trg_CuuSV_ValidatePhone;
DROP TRIGGER IF EXISTS trg_CuuSV_DeleteUser;

GO

-- Xóa foreign key constraint trước
ALTER TABLE Contribution 
DROP CONSTRAINT FK_Contribution_Event;

-- Xóa cột event_id
ALTER TABLE Contribution 
DROP COLUMN event_id;

-- THÊM DỮ LIỆU
GO

-- Thêm Khoa
INSERT INTO Khoa (ten_khoa) VALUES 
(N'Công nghệ thông tin'),
(N'Kinh tế');

-- Thêm Ngành
INSERT INTO Nganh (ten_nganh, khoa_id) VALUES 
(N'Công nghệ phần mềm', 1),
(N'Hệ thống thông tin', 1),
(N'Khoa học máy tính', 1),
(N'An toàn thông tin', 1),
(N'Trí tuệ nhân tạo', 1),
(N'Quản trị kinh doanh', 2);

-- Thêm Khóa học 
INSERT INTO KhoaHoc (ten_khoa_hoc, nam_bat_dau, nam_ket_thuc, nganh_id) VALUES 
(N'K19CNPM', 2019, 2023, 1),    -- Khóa cũ
(N'K20HTTT', 2020, 2024, 2);    -- Khóa cũ

--thêm mới---------------
INSERT INTO Nganh (ten_nganh, khoa_id) VALUES 
(N'Khoa học máy tính', 1),
(N'An toàn thông tin', 1),
(N'Trí tuệ nhân tạo', 1);

INSERT INTO KhoaHoc (ten_khoa_hoc, nam_bat_dau, nam_ket_thuc, nganh_id) VALUES 
(N'K64CNPM', 2020, 2024, 1),    -- Công nghệ phần mềm
(N'K64HTTT', 2020, 2024, 2),    -- Hệ thống thông tin  
(N'K64KHMT', 2020, 2024, 3),    -- Khoa học máy tính
(N'K64ATTT', 2020, 2024, 4),    -- An toàn thông tin
(N'K64TTNT', 2020, 2024, 5),    -- Trí tuệ nhân tạo

(N'K63CNPM', 2019, 2023, 1),    -- Công nghệ phần mềm
(N'K63HTTT', 2019, 2023, 2),    -- Hệ thống thông tin  
(N'K63KHMT', 2019, 2023, 3),    -- Khoa học máy tính
(N'K63ATTT', 2019, 2023, 4),    -- An toàn thông tin
(N'K63TTNT', 2019, 2023, 5),    -- Trí tuệ nhân tạo

(N'K62CNPM', 2018, 2022, 1),    -- Công nghệ phần mềm
(N'K62HTTT', 2018, 2022, 2),    -- Hệ thống thông tin  
(N'K62KHMT', 2018, 2022, 3),    -- Khoa học máy tính
(N'K62ATTT', 2018, 2022, 4),    -- An toàn thông tin
(N'K62TTNT', 2018, 2022, 5);    -- Trí tuệ nhân tạo

-- Thêm Cựu sinh viên
INSERT INTO CuuSV (Ten, NgaySinh, MSSV, DC, email, phone, khoa_hoc_id) VALUES 
(N'Nguyễn Văn An', '2000-05-15', 'SV19001', N'123 Đường ABC, Hà Nội', 'nguyenvanan@gmail.com', '0987654321', 1);

-- Thêm tài khoản Admin (không liên kết với cựu sinh viên)
INSERT INTO [User] (username, password, role_type, is_active, CSV_id) VALUES 
('admin@system.com', 'admin123', N'admin', 1, NULL);

-- Kiểm tra dữ liệu đã thêm
SELECT 'Tài khoản Admin:' AS [Loại];
SELECT user_id, username, role_type, is_active, CSV_id 
FROM [User] 
WHERE role_type = N'admin';

SELECT 'Tài khoản Cựu sinh viên:' AS [Loại];
SELECT u.user_id, u.username, u.role_type, u.is_active, c.Ten AS [Tên cựu sinh viên]
FROM [User] u
INNER JOIN CuuSV c ON u.CSV_id = c.CSV_id
WHERE u.role_type = N'Cựu sinh viên';

SELECT 'Thông tin Cựu sinh viên:' AS [Thông tin];
SELECT c.CSV_id, c.Ten, c.MSSV, c.email, c.phone, 
       k.ten_khoa_hoc, n.ten_nganh, kh.ten_khoa
FROM CuuSV c
LEFT JOIN KhoaHoc k ON c.khoa_hoc_id = k.khoa_hoc_id
LEFT JOIN Nganh n ON k.nganh_id = n.nganh_id
LEFT JOIN Khoa kh ON n.khoa_id = kh.khoa_id;

delete from [User] where user_id = 11

select * from Participation

select * from CuuSV

select * from [User]

select * from Contribution


GO
--Xóa bảng
DROP TABLE IF EXISTS Participation;
DROP TABLE IF EXISTS Contribution;
DROP TABLE IF EXISTS Job;
DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS CuuSV;
DROP TABLE IF EXISTS Event;
DROP TABLE IF EXISTS KhoaHoc;
DROP TABLE IF EXISTS Nganh;
DROP TABLE IF EXISTS Khoa;