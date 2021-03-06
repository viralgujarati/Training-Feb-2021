USE master

CREATE TABLE ACCOUNTONE
(
ACCOUNTNUMBER INT PRIMARY KEY,
NAME NVARCHAR(50)
)


INSERT INTO ACCOUNTONE
VALUES(1020,'VIRAL')

INSERT INTO ACCOUNTONE
VALUES(1090,'RAHUL')


CREATE TABLE ACCOUNT(
ACCOUNTNUMBER INT FOREIGN KEY REFERENCES ACCOUNTONE(ACCOUNTNUMBER),
AMOUNT MONEY NOT NULL)


INSERT INTO ACCOUNT
VALUES(1020,500)

INSERT INTO ACCOUNT
VALUES(1090,1000)




--Detroit Bank need to implement the transaction whenever the amount is transferred from one account to the another account.

ALTER PROCEDURE AMOUNTTRANSFER1
@FROMACCOUNT INT, @TOACOUNTONE INT,@AMTTRANS MONEY

AS
SET NOCOUNT ON 
BEGIN TRANSACTION 

IF @FROMACCOUNT NOT IN (SELECT ACCOUNTNUMBER FROM ACCOUNTONE) OR @TOACOUNTONE NOT IN (SELECT ACCOUNTNUMBER FROM ACCOUNTONE)
BEGIN
PRINT 'FAILED'
END 

BEGIN

UPDATE ACCOUNT SET AMOUNT = AMOUNT - @AMTTRANS WHERE ACCOUNTNUMBER = @FROMACCOUNT
UPDATE ACCOUNT SET AMOUNT = AMOUNT + @AMTTRANS WHERE ACCOUNTNUMBER = @TOACOUNTONE
END 

COMMIT TRANSACTION 
SET NOCOUNT OFF 

GO

--ACCOUNT 1020 TO 1090 RS 500
EXEC AMOUNTTRANSFER1 1090,1020,5100
GO

SELECT * FROM ACCOUNTONE
SELECT * FROM ACCOUNT


