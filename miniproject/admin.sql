use mini_project

-- Create the Trains table
CREATE TABLE Trains (
    TrainNo INT PRIMARY KEY,                -- Unique train number
    TrainName VARCHAR(50) NOT NULL,         -- Name of the train
    first_class_total INT,                  -- Total first-class berths
    first_class_available INT,              -- Available first-class berths
    second_class_total INT,                 -- Total second-class berths
    second_class_available INT,             -- Available second-class berths
    sleeper_class_total INT,                -- Total sleeper-class berths
    sleeper_class_available INT,            -- Available sleeper-class berths
    Source VARCHAR(50) NOT NULL,            -- Starting station
    Destination VARCHAR(50) NOT NULL,       -- Ending station
    IsActive BIT DEFAULT 1                  -- Train availability status
);
 select * from Trains

CREATE OR ALTER PROCEDURE SP_AddTrains
    @TrainNo INT,
    @TrainName NVARCHAR(50),
    @first_class_total INT,
    @first_class_available INT,
    @second_class_total INT,
    @second_class_available INT,
    @sleeper_class_total INT,
    @sleeper_class_available INT,
    @Source VARCHAR(50),
    @Destination VARCHAR(50)
AS
BEGIN
    -- Check if the train already exists
    IF EXISTS (SELECT * FROM Trains WHERE TrainNo = @TrainNo)
    BEGIN
        --PRINT 'Train already exists.';
		raiserror('train already exists',16,1);
        RETURN;
    END
 
    -- Validate available seats
    IF (@first_class_available > @first_class_total OR
        @second_class_available > @second_class_total OR
        @sleeper_class_available > @sleeper_class_total)
    BEGIN
        --PRINT 'Available seats cannot exceed total seats.';
		raiserror('availability seats cannot exceed total seats',16,2);
        RETURN;
    END
 
    -- Insert the train
    INSERT INTO Trains (
        TrainNo, TrainName, first_class_total, first_class_available,
        second_class_total, second_class_available, sleeper_class_total,
        sleeper_class_available, Source, Destination, IsActive)
    VALUES (
        @TrainNo, @TrainName, @first_class_total, @first_class_available,
        @second_class_total, @second_class_available, @sleeper_class_total,
        @sleeper_class_available, @Source, @Destination, 1);
 
    PRINT 'Train added successfully.';
END;
 

insert into trains values(18323,'godavari express',50,50,200,100,240,40,'godavari','bnglr',1)

--CREATE OR ALTER PROCEDURE SP_ModifyTrainDetailss
--    @TrainNo INT,
--    @TrainName NVARCHAR(50),
--    @first_class_total INT,
--    @first_class_available INT,
--    @second_class_total INT,
--    @second_class_available INT,
--    @sleeper_class_total INT,
--    @sleeper_class_available INT,
--    @Source VARCHAR(50),
--    @Destination VARCHAR(50)
--AS
--BEGIN
--    -- Check if the train exists
--    IF EXISTS (SELECT 1 FROM Trains WHERE TrainNo = @TrainNo)
--    BEGIN
--        -- Update the train details
--        UPDATE Trains
--        SET TrainName = @TrainName,
--            first_class_total = @first_class_total,
--            first_class_available = @first_class_available,
--            second_class_total = @second_class_total,
--            second_class_available = @second_class_available,
--            sleeper_class_total = @sleeper_class_total,
--            sleeper_class_available = @sleeper_class_available,
--            Source = @Source,
--            Destination = @Destination
--        WHERE TrainNo = @TrainNo;
 
--        PRINT 'Train details updated successfully.';
--    END
--    ELSE
--    BEGIN
--        PRINT 'Train not found.';
--    END
--END;

	`

CREATE or ALTER PROCEDURE sp_DeleteTrain
   @TrainNo INT
AS
BEGIN
   IF NOT EXISTS (SELECT 1 FROM Trains WHERE TrainNo = @TrainNo)
   BEGIN
       RAISERROR ('Train nothing found.', 16, 1);
       RETURN;
   END
   UPDATE Trains
   SET IsActive = 0
   WHERE TrainNo = @TrainNo;
END;

CREATE OR ALTER PROCEDURE sp_ShowAllTrains
AS
BEGIN
    SELECT
        TrainNo,
        TrainName,
        first_class_total,
        first_class_available,
        second_class_total,
        second_class_available,
        sleeper_class_total,
        sleeper_class_available,
        Source,
        Destination,
        IsActive
    FROM Trains
	WHERE IsActive=1;

END;

CREATE OR ALTER PROCEDURE SP_ModifyTrainDetail
    @TrainNo INT,
    @TrainName NVARCHAR(50),
    @first_class_total INT,
    @first_class_available INT,
    @second_class_total INT,
    @second_class_available INT,
    @sleeper_class_total INT,
    @sleeper_class_available INT,
    @Source VARCHAR(50),
    @Destination VARCHAR(50)
	
AS
BEGIN
    -- Check if the train exists
    IF NOT EXISTS (SELECT 1 FROM Trains WHERE TrainNo = @TrainNo)
    BEGIN
        RAISERROR ('Train does not exist.', 16, 1);
        RETURN;
    END
 
    -- Validate available seats
    IF (@first_class_available > @first_class_total OR
        @second_class_available > @second_class_total OR
        @sleeper_class_available > @sleeper_class_total)
    BEGIN
        RAISERROR ('Available seats cannot exceed total seats.', 16, 1);
        RETURN;
    END
 
    -- Update the train details
    UPDATE Trains
    SET
        TrainName = @TrainName,
        first_class_total = @first_class_total,
        first_class_available = @first_class_available,
        second_class_total = @second_class_total,
        second_class_available = @second_class_available,
        sleeper_class_total = @sleeper_class_total,
        sleeper_class_available = @sleeper_class_available,
        Source = @Source,
        Destination = @Destination,
		IsActive = 1
    WHERE TrainNo = @TrainNo;
 
    PRINT 'Train details updated successfully.';
END;
 select * from trains