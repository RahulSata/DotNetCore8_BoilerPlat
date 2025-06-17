-- This is not used for migration, Just script to execute in ssms before project load
CREATE TABLE Doctor  (
    DoctorId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Specialization NVARCHAR(100),
    Phone NVARCHAR(20),
	CreatedDate DateTime NOT NULL DEFAULT GETDATE(),
	UpdatedDate DateTime
);