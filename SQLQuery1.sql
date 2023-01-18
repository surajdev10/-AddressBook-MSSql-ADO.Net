--ADD TO TABLE
CREATE PROCEDURE SPAddNewAddressBook(
@First_name VARCHAR(225),
@Last_name VARCHAR(225),
@Address VARCHAR(225),
@City VARCHAR(225),
@State VARCHAR(225),
@Zip INT,
@Phone_number BIGINT,
@Email VARCHAR(225),
@Type VARCHAR(50)
)
AS BEGIN
INSERT INTO AddressBookTable VALUES(@First_name,@Last_name,@Address,@City,@State,@Zip,@Phone_number,@Email,@Type)
END

--RETRIVE DATA
CREATE PROCEDURE SPRetrieveAllDetails
AS BEGIN 
SELECT * FROM AddressBookTable
END
--UPDATE DATA
CREATE PROCEDURE SPUpdateDataInDB(
@First_name VARCHAR(225),
@Last_name VARCHAR(225),
@Address VARCHAR(225),
@Phone_number BIGINT
)
AS BEGIN
UPDATE AddressBookTable SET Last_name=@Last_name,Address=@Address,Phone_number=@Phone_number WHERE First_name=@First_name
END

--Delete
CREATE PROCEDURE SPDeleteDataFromDB(
@First_name VARCHAR(30)
)
AS BEGIN
DELETE FROM AddressBookTable WHERE First_name=@First_name
END