-------------- DATABASE CREATION --------------

USE master
GO
IF DB_ID('HerbariumDatabase') IS NOT NULL
	DROP DATABASE HerbariumDataBase
GO

CREATE DATABASE HerbariumDatabase
GO
USE HerbariumDataBase
GO

-- [Ctrl+K][Ctrl+U] To Uncomment the Selected Lines

-------------- TABLE CREATION --------------

-- Herbarium Menu
IF OBJECT_ID('tblSystemMenu', 'U') IS NOT NULL
	DROP TABLE tblSystemMenu
GO
CREATE TABLE tblSystemMenu
(
	intMenuID INT IDENTITY(1, 1) NOT NULL,
	strLevel CHAR NOT NULL,
	strMainMenu VARCHAR(255) NOT NULL,
	strSubMenu VARCHAR(255),
	strPageLocation VARCHAR(255) NOT NULL,
	strGlyphCode NVARCHAR(10),
	intAccessLevel INT NOT NULL
	CONSTRAINT pk_tblSystemMenu PRIMARY KEY(intMenuID)
)
GO

-- Taxon Species Data
IF OBJECT_ID('tblSpeciesData', 'U') IS NOT NULL
	DROP TABLE tblSpeciesData
GO
CREATE TABLE tblSpeciesData
(
	intSpeciesID INT IDENTITY(1, 1) NOT NULL,
	strDomainName VARCHAR(50) NOT NULL,
	strKingdomName VARCHAR(50) NOT NULL,
	strPhylumName VARCHAR(50) NOT NULL,
	strClassName VARCHAR(50) NOT NULL,
	strOrderName VARCHAR(50) NOT NULL,
	strFamilyName VARCHAR(50) NOT NULL,
	strGenusName VARCHAR(50) NOT NULL,
	strSpeciesName VARCHAR(50) NOT NULL,
	strCommonName VARCHAR(255) NOT NULL,
	strAuthorsName VARCHAR(255) NOT NULL
	CONSTRAINT pk_tblSpeciesData PRIMARY KEY(intSpeciesID)
)
GO

-- Taxonomic Hierarchy : Phylum
IF OBJECT_ID('tblPhylum', 'U') IS NOT NULL
	DROP TABLE tblPhylum
GO
CREATE TABLE tblPhylum
(
	intPhylumID INT IDENTITY(1, 1) NOT NULL,
	strDomainName VARCHAR(50) NOT NULL,
	strKingdomName VARCHAR(50) NOT NULL,
	strPhylumName VARCHAR(50) NOT NULL
	CONSTRAINT pk_tblPhylum PRIMARY KEY(intPhylumID)
)
GO

ALTER TABLE tblPhylum ADD CONSTRAINT df_tblPhylum_strDomainName DEFAULT 'Eukaryota' FOR strDomainName
GO
ALTER TABLE tblPhylum ADD CONSTRAINT df_tblPhylum_strKingdomName DEFAULT 'Plantae' FOR strKingdomName
GO

-- Taxonomic Hierarchy : Class
IF OBJECT_ID('tblClass', 'U') IS NOT NULL
	DROP TABLE tblClass
GO
CREATE TABLE tblClass
(
	intClassID INT IDENTITY(1, 1) NOT NULL,
	intPhylumID INT NOT NULL,
	strClassName VARCHAR(50) NOT NULL
	CONSTRAINT pk_tblClass PRIMARY KEY(intClassID),
	CONSTRAINT fk_tblClass_tblPhylum FOREIGN KEY(intPhylumID)
		REFERENCES tblPhylum(intPhylumID)
)
GO

-- Taxonomic Hierarchy : Order
IF OBJECT_ID('tblOrder', 'U') IS NOT NULL
	DROP TABLE tblOrder
GO
CREATE TABLE tblOrder
(
	intOrderID INT IDENTITY(1, 1) NOT NULL,
	intClassID INT NOT NULL,
	strOrderName VARCHAR(50) NOT NULL
	CONSTRAINT pk_tblOrder PRIMARY KEY(intOrderID),
	CONSTRAINT fk_tblOrder_tblClass FOREIGN KEY(intClassID)
		REFERENCES tblClass(intClassID)
)
GO

-- Taxonomic Hierarchy : Family
IF OBJECT_ID('tblFamily', 'U') IS NOT NULL
	DROP TABLE tblFamily
GO
CREATE TABLE tblFamily
(
	intFamilyID INT IDENTITY(1, 1) NOT NULL,
	intOrderID INt NOT NULL,
	strFamilyName VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblFamily PRIMARY KEY(intFamilyID),
	CONSTRAINT fk_tblFamily_tblOrder FOREIGN KEY(intOrderID)
		REFERENCES tblOrder(intOrderID)
)
GO

-- Taxonomic Hierarchy : Genus
IF OBJECT_ID('tblGenus', 'U') IS NOT NULL
	DROP TABLE tblGenus
GO
CREATE TABLE tblGenus
(
	intGenusID INT IDENTITY(1, 1) NOT NULL,
	intFamilyID INT NOT NULL,
	strGenusName VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblGenus PRIMARY KEY(intGenusID),
	CONSTRAINT fk_tblGenus_tblFamily FOREIGN KEY (intFamilyID)
		REFERENCES tblFamily(intFamilyID)
)
GO

-- Taxonomic Hierarchy : Species
IF OBJECT_ID('tblSpecies', 'U') IS NOT NULL
	DROP TABLE tblSpecies
GO
CREATE TABLE tblSpecies
(
	intSpeciesID INT IDENTITY(1, 1) NOT NULL,
	intGenusID INT NOT NULL,
	strSpeciesName VARCHAR(50) NOT NULL,
	strCommonName VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblSpecies PRIMARY KEY(intSpeciesID),
	CONSTRAINT fk_tblSpecies_tblGenus FOREIGN KEY(intGenusID)
		REFERENCES tblGenus(intGenusID)
)
GO

-- Author
IF OBJECT_ID('tblAuthor', 'U') IS NOT NULL
	DROP TABLE tblAuthor
GO
CREATE TABLE tblAuthor
(
	intAuthorID INT IDENTITY(1, 1) NOT NULL,
	strAuthorsName VARCHAR(255) NOT NULL,
	strSpeciesSuffix VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblAuthor PRIMARY KEY(intAuthorID)
)

-- Species Author
IF OBJECT_ID('tblSpeciesAuthor', 'U') IS NOT NULL
	DROP TABLE tblSpeciesAuthor
GO
CREATE TABLE tblSpeciesAuthor
(
	intSpeciesID INT NOT NULL,
	intAuthorID INT NOT NULL,
	CONSTRAINT pk_tblSpeciesAuthor PRIMARY KEY(intSpeciesID),
	CONSTRAINT fk_tblSpeciesAuthor_tblSpecies FOREIGN KEY(intSpeciesID)
		REFERENCES tblSpecies(intSpeciesID),
	CONSTRAINT fk_tblSpeciesAuthor_tblAuthor FOREIGN KEY(intAuthorID)
		REFERENCES tblAuthor(intAuthorID)
)
GO

-- Species Alternate Name
IF OBJECT_ID('tblSpeciesAlternateName', 'U') IS NOT NULL
	DROP TABLE tblSpeciesAlternateName 
GO
CREATE TABLE tblSpeciesAlternateName
(
	intAltNameID INT IDENTITY(1, 1) NOT NULL,
	intSpeciesID INT NOT NULL,
	strLanguage VARCHAR(255) NOT NULL,
	strAlternateName VARCHAR(255) NOT NULL,
	CONSTRAINT pk_tblSpeciesAlternateName PRIMARY KEY(intAltNameID),
	CONSTRAINT fk_tblSpeciesAlternateName_tblSpecies FOREIGN KEY(intSpeciesID)
		REFERENCES tblSpecies(intSpeciesID)
)
GO

-- Plant Types
IF OBJECT_ID('tblPlantType', 'U') IS NOT NULL
	DROP TABLE tblPlantType
GO
CREATE TABLE tblPlantType
(
	intPlantTypeID INT IDENTITY(1, 1) NOT NULL,
	strPlantTypeCode VARCHAR(5) NOT NULL,
	strPlantTypeName VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblPlantType PRIMARY KEY(intPlantTypeID)
)
GO

-- Family Box
IF OBJECT_ID('tblFamilyBox', 'U') IS NOT NULL
	DROP TABLE tblFamilyBox
GO
CREATE TABLE tblFamilyBox
(
	intBoxID INT IDENTITY(1, 1) NOT NULL,
	intFamilyID INT NOT NULL,
	intBoxLimit INT NOT NULL,
	intRackNo INT NOT NULL,
	intRackRow INT NOT NULL,
	intRackColumn INT NOT NULL,
	CONSTRAINT pk_tblFamilyBox PRIMARY KEY (intBoxID),
	CONSTRAINT fk_tblFamilyBox_tblFamily FOREIGN KEY (intFamilyID)
		REFERENCES tblFamily(intFamilyID)
)
GO

-- Country
IF OBJECT_ID('tblCountry', 'U') IS NOT NULL
	DROP TABLE tblCountry
GO
CREATE TABLE tblCountry
(
	intCountryID INT IDENTITY(1, 1) NOT NULL,
	strCountry VARCHAR(255) NOT NULL
	CONSTRAINT pk_tblCountry PRIMARY KEY(intCountryID)
)
GO

-- Region
IF OBJECT_ID('tblRegion', 'U') IS NOT NULL
	DROP TABLE tblRegion
GO
CREATE TABLE tblRegion
(
	intRegionID INT IDENTITY(1, 1) NOT NULL,
	strIsland VARCHAR(50) NOT NULL,
	strRegionCode VARCHAR(10) NOT NULL,
	strRegion VARCHAR(255) NOT NULL
	CONSTRAINT pk_tblRegion PRIMARY KEY(intRegionID)
)
GO

-- Provinces
IF OBJECT_ID('tblProvince', 'U') IS NOT NULL
	DROP TABLE tblProvince
GO
CREATE TABLE tblProvince
(
	intProvinceID INT IDENTITY(1, 1) NOT NULL,
	intRegionID INT NOT NULL,
	strProvince VARCHAR(255) NOT NULL
	CONSTRAINT pk_tblProvince PRIMARY KEY(intProvinceID),
	CONSTRAINT fk_tblProvince_tblRegion FOREIGN KEY(intRegionID)
		REFERENCES tblRegion(intRegionID)
)
GO

-- City
IF OBJECT_ID('tblCity', 'U') IS NOT NULL
	DROP TABLE tblCity
GO
CREATE TABLE tblCity
(
	intCityID INT IDENTITY(1, 1) NOT NULL,
	intProvinceID INT NOT NULL,
	strCity VARCHAR(255) NOT NULL
	CONSTRAINT pk_tblCity PRIMARY KEY(intCityID),
	CONSTRAINT fk_tblCity_tblProvince FOREIGN KEY(intProvinceID)
		REFERENCES tblProvince(intProvinceID)
)
GO

-- Locality
IF OBJECT_ID('tblLocality', 'U') IS NOT NULL
	DROP TABLE tblLocality
GO
CREATE TABLE tblLocality
(
	intLocalityID INT IDENTITY(1, 1) NOT NULL,
	intCountryID INT NOT NULL,
	strSpecificLocation VARCHAR(255),
	strShortLocation VARCHAR(255),
	strFullLocality VARCHAR(50),
	strLatitude VARCHAR(20),
	strLongtitude VARCHAR(20),
	CONSTRAINT pk_tblLocality PRIMARY KEY(intLocalityID),
	CONSTRAINT fk_tblLocality_tblCountry FOREIGN KEY(intCountryID)
		REFERENCES tblCountry(intCountryID)
)
GO

-- Philippine Locality
IF OBJECT_ID('tblPHLocality', 'U') IS NOT NULL
	DROP TABLE tblPHLocality
GO
CREATE TABLE tblPHLocality
(
	intLocalityID INT NOT NULL,
	intCityID INT NOT NULL,
	CONSTRAINT pk_tblPHLocality PRIMARY KEY(intLocalityID),
	CONSTRAINT fk_tblPHLocality_tblLocality FOREIGN KEY(intLocalityID)
		REFERENCES tblLocality(intLocalityID),
	CONSTRAINT fk_tblPHLocality_tblCity FOREIGN KEY(intCityID)
		REFERENCES tblCity(intCityID),
)
GO

-- Collector
IF OBJECT_ID('tblCollector', 'U') IS NOT NULL
	DROP TABLE tblCollector
GO
CREATE TABLE tblCollector
(
	intCollectorID INT IDENTITY(1001, 1) NOT NULL,
	strFirstname VARCHAR(50) NOT NULL,
	strMiddlename VARCHAR(50),
	strLastname VARCHAR(50) NOT NULL,
	strMiddleInitial VARCHAR(3),
	strNameSuffix VARCHAR(5),
	strHomeAddress VARCHAR(MAX) NOT NULL,
	strContactNumber VARCHAR(15) NOT NULL,
	strEmailAddress VARCHAR(255) NOT NULL,
	strAffiliation VARCHAR(100) NOT NULL,
	CONSTRAINT pk_tblCollector PRIMARY KEY(intCollectorID)
)
GO

-- Borrower
IF OBJECT_ID('tblBorrower', 'U') IS NOT NULL
	DROP TABLE tblBorrower
GO
CREATE TABLE tblBorrower 
(
	intBorrowerID INT IDENTITY(1001, 1) NOT NULL,
	strFirstname VARCHAR(50) NOT NULL,
	strMiddlename VARCHAR(50),
	strLastname VARCHAR(50) NOT NULL,
	strMiddleInitial VARCHAR(3),
	strNameSuffix VARCHAR(5),
	strHomeAddress VARCHAR(MAX) NOT NULL,
	strContactNumber VARCHAR(15) NOT NULL,
	strEmailAddress VARCHAR(255) NOT NULL,
	strAffiliation VARCHAR(100) NOT NULL,
	boolIsCollector BIT NOT NULL
	CONSTRAINT pk_tblBorrower PRIMARY KEY(intBorrowerID)
)
GO

-- Validator
IF OBJECT_ID('tblValidator', 'U') IS NOT NULL       
	DROP TABLE tblValidator
GO
CREATE TABLE tblValidator
(
	intValidatorID INT IDENTITY(1001, 1) NOT NULL,
	strFirstname VARCHAR(50) NOT NULL,
	strMiddlename VARCHAR(50),
	strLastname VARCHAR(50) NOT NULL,
	strMiddleInitial VARCHAR(3),
	strNameSuffix VARCHAR(5),
	strContactNumber VARCHAR(15) NOT NULL,
	strEmailAddress VARCHAR(255) NOT NULL,
	strInstitution VARCHAR(255) NOT NULL,
	strValidatorType VARCHAR(10) NOT NULL
	CONSTRAINT pk_tblValidator PRIMARY KEY(intValidatorID)
)
GO

-- Herbarium Staff
IF OBJECT_ID('tblHerbariumStaff', 'U') IS NOT NULL
	DROP TABLE tblHerbariumStaff
GO
CREATE TABLE tblHerbariumStaff
(
	intStaffID INT IDENTITY(1001, 1) NOT NULL,
	strFirstname VARCHAR(50) NOT NULL,
	strMiddlename VARCHAR(50),
	strLastname VARCHAR(50) NOT NULL,
	strMiddleInitial VARCHAR(3),
	strNameSuffix VARCHAR(5),
	strContactNumber VARCHAR(15) NOT NULL,
	strEmailAddress VARCHAR(255) NOT NULL,
	strRole VARCHAR(50) NOT NULL,
	strCollegeDepartment VARCHAR(100) NOT NULL,
	boolActive BIT NOT NULL
	CONSTRAINT pk_tblHerbariumStaff PRIMARY KEY(intStaffID)
)
GO

ALTER TABLE tblHerbariumStaff ADD CONSTRAINT df_tblHerbariumStaff_boolActive DEFAULT 1 FOR boolActive
GO

-- Access Accounts
IF OBJECT_ID('tblAccounts', 'U') IS NOT NULL
	DROP TABLE tblAccounts
GO
CREATE TABLE tblAccounts
(
	intStaffID INT NOT NULL,
	strUsername VARCHAR(50) NOT NULL,
	strPassword VARCHAR(50) NOT NULL,
	boolActive BIT NOT NULL
	CONSTRAINT pk_tblAccounts PRIMARY KEY(intStaffID),
	CONSTRAINT fk_tblAccounts_tblHerbariumStaff FOREIGN KEY(intStaffID)
		REFERENCES tblHerbariumStaff(intStaffID)
)

ALTER TABLE tblAccounts ADD CONSTRAINT df_tblAccounts_boolActive DEFAULT 1 FOR boolActive
GO

-- Audit Trailing
IF OBJECT_ID('tblAuditTrailing', 'U') IS NOT NULL
	DROP TABLE tblAuditTrailing
GO
CREATE TABLE tblAuditTrailing
(
	intTrailingID INT IDENTITY(1, 1) NOT NULL,
	intStaffID INT NOT NULL,
	strModule VARCHAR(50) NOT NULL,
	strTransactionDesc VARCHAR(MAX) NOT NULL,
	dateTimeStamp DATETIME NOT NULL,
	CONSTRAINT pk_tblAuditTrailing PRIMARY KEY(intTrailingID),
	CONSTRAINT fk_tblAuditTrailing_tblHerbariumStaff FOREIGN KEY (intStaffID)
		REFERENCES tblHerbariumStaff(intStaffID)
)
GO

-- Accession Number Format
IF OBJECT_ID('tblAccessionFormat', 'U') IS NOT NULL
	DROP TABLE tblAccessionFormat
GO
CREATE TABLE tblAccessionFormat
(
	intFormatID INT IDENTITY(1, 1) NOT NULL,
	strInstitutionCode VARCHAR(10) NOT NULL,
	strAccessionFormat VARCHAR(10) NOT NULL,
	strYearFormat VARCHAR(10) NOT NULL,
	CONSTRAINT pk_tblAccessionFormat PRIMARY KEY(intFormatID)
)

-- New Plant Deposit
IF OBJECT_ID('tblReceivedDeposits' ,'U') IS NOT NULL
	DROP TABLE tblReceivedDeposits
GO
CREATE TABLE tblReceivedDeposits
(
	intDepositID INT IDENTITY(1, 1) NOT NULL,
	intPlantTypeID INT NOT NULL,
	picHerbariumSheet VARBINARY(MAX),
	intCollectorID INT NOT NULL,
	intLocalityID INT NOT NULL,
	intStaffID INT NOT NULL,
	dateCollected DATE NOT NULL,
	dateDeposited DATE NOT NULL,
	strDescription VARCHAR(MAX) NOT NULL,
	strStatus VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblReceivedDeposit PRIMARY KEY(intDepositID),
	CONSTRAINT fk_tblReceivedDeposit_tblPlantType FOREIGN KEY(intPlantTypeID)
		REFERENCES tblPlantType(intPlantTypeID),
	CONSTRAINT fk_tblReceivedDeposit_tblCollector FOREIGN KEY(intCollectorID)
		REFERENCES tblCollector(intCollectorID),
	CONSTRAINT fk_tblReceivedDeposit_tblLocality FOREIGN KEY(intLocalityID)
		REFERENCES tblLocality(intLocalityID),
	CONSTRAINT fk_tblReceivedDeposit_tblHerbariumStaff FOREIGN KEY(intStaffID)
		REFERENCES tblHerbariumStaff(intStaffID)
)
GO

-- Plant Deposit
IF OBJECT_ID('tblPlantDeposit', 'U') IS NOT NULL
	DROP TABLE tblPlantDeposit
GO
CREATE TABLE tblPlantDeposit
(
	intPlantDepositID INT IDENTITY(1, 1) NOT NULL,
	intAccessionNumber INT NOT NULL,
	intPlantTypeID INT NOT NULL,
	intFormatID INT NOT NULL,
	intCollectorID INT NOT NULL,
	intLocalityID INT NOT NULL,
	intStaffID INT NOT NULL,
	dateCollected DATE NOT NULL,
	dateDeposited DATE NOT NULL,
	strDescription VARCHAR(MAX) NOT NULL,
	strStatus VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblPlantDeposit PRIMARY KEY(intPlantDepositID),
	CONSTRAINT fk_tblPlantDeposit_tblPlantType FOREIGN KEY(intPlantTypeID)
		REFERENCES tblPlantType(intPlantTypeID),
	CONSTRAINT fk_tblPlantDeposit_tblAccessionFormat FOREIGN KEY(intFormatID)
		REFERENCES tblAccessionFormat(intFormatID),
	CONSTRAINT fk_tblPlantDeposit_tblCollector FOREIGN KEY(intCollectorID)
		REFERENCES tblCollector(intCollectorID),
	CONSTRAINT fk_tblPlantDeposit_tblLocality FOREIGN KEY(intLocalityID)
		REFERENCES tblLocality(intLocalityID),
	CONSTRAINT fk_tblPlantDeposit_tblHerbariumStaff FOREIGN KEY(intStaffID)
		REFERENCES tblHerbariumStaff(intStaffID)
)
GO

-- Herbarium Sheet Picture
IF OBJECT_ID('tblHerbariumSheetPicture', 'U') IS NOT NULL
	DROP TABLE tblHerbariumSheetPicture
GO
CREATE TABLE tblHerbariumSheetPicture
(
	intPictureID INT IDENTITY(1, 1) NOT NULL,
	intPlantDepositID INT NOT NULL,
	picHerbariumSheet VARBINARY(MAX),
	strTagDescription VARCHAR(255),
	CONSTRAINT pk_tblHerbariumSheetPicture PRIMARY KEY(intPictureID),
	CONSTRAINT fk_tblHerbariumSheetPicture_tblPlantDeposit FOREIGN KEY(intPlantDepositID)
		REFERENCES tblPlantDeposit(intPlantDepositID)
)
GO

-- Further Verification Plant Deposit
IF OBJECT_ID('tblVerifyingDeposit', 'U') IS NOT NULL
	DROP TABLE tblVerifyingDeposit
GO
CREATE TABLE tblVerifyingDeposit
(
	intPlantDepositID INT NOT NULL,
	intSpeciesID INT NOT NULL,
	intReferenceDepositID INT NOT NULL,
	CONSTRAINT pk_tblVerifyingDeposit PRIMARY KEY(intPlantDepositID),
	CONSTRAINT fk_tblVerifyingDeposit_tblPlantDeposit_Org FOREIGN KEY(intPlantDepositID)
		REFERENCES tblPlantDeposit(intPlantDepositID),
	CONSTRAINT fk_tblVerifyingDeposit_tblSpecies FOREIGN KEY(intSpeciesID)
		REFERENCES tblSpecies(intSpeciesID),	
	CONSTRAINT fk_tblVerifyingDeposit_tblPlantDeposit_Dup FOREIGN KEY(intPlantDepositID)
		REFERENCES tblPlantDeposit(intPlantDepositID)
)
GO

-- Herbarium Sheet
IF OBJECT_ID('tblHerbariumSheet', 'U') IS NOT NULL
	DROP TABLE tblHerbariumSheet
GO
CREATE TABLE tblHerbariumSheet
(
	intHerbariumSheetID INT IDENTITY(1000, 1) NOT NULL,
	intPlantDepositID INT NOT NULL,
	intPlantReferenceID INT NOT NULL,
	intSpeciesID INT NOT NULL,
	intValidatorID INT NOT NULL,
	dateVerified DATE NOT NULL,
	CONSTRAINT pk_tblHerbariumSheet PRIMARY KEY(intHerbariumSheetID),
	CONSTRAINT fk_tblHerbariumSheet_tblPlantDeposit_Org FOREIGN KEY(intPlantDepositID)
		REFERENCES tblPlantDeposit(intPlantDepositID),
	CONSTRAINT fk_tblHerbariumSheet_tblPlantDeposit_Ref FOREIGN KEY(intPlantReferenceID)
		REFERENCES tblPlantDeposit(intPlantDepositID),
	CONSTRAINT fk_tblHerbariumSheet_tblSpecies FOREIGN KEY(intSpeciesID)
		REFERENCES tblSpecies(intSpeciesID),
	CONSTRAINT fk_tblHerbariumSheet_tblValidator FOREIGN KEY(intValidatorID)
		REFERENCES tblValidator(intValidatorID)
)
GO

-- Stored Herbarium Sheet
IF OBJECT_ID('tblStoredHerbarium', 'U') IS NOT NULL
	DROP TABLE tblStoredHerbarium
GO
CREATE TABLE tblStoredHerbarium
(
	intStoredSheetID INT IDENTITY(1000, 1) NOT NULL,
	intHerbariumSheetID INT NOT NULL,
	intBoxID INT NOT NULL,
	boolLoanAvailable BIT NOT NULL,
	CONSTRAINT pk_tblStoredHerbarium PRIMARY KEY(intStoredSheetID),
	CONSTRAINT fk_tblStoredHerbarium_tblHerbariumSheet FOREIGN KEY(intHerbariumSheetID)
		REFERENCES tblHerbariumSheet(intHerbariumSheetID),
	CONSTRAINT fk_tblStoredHerbarium_tblFamilyBox FOREIGN KEY(intBoxID)
		REFERENCES tblFamilyBox(intBoxID)
)

-- Loan Transaction
IF OBJECT_ID('tblPlantLoanTransaction', 'U') IS NOT NULL
	DROP TABLE tblPlantLoanTransaction
GO
CREATE TABLE tblPlantLoanTransaction
(
	intLoanID INT IDENTITY(1, 1) NOT NULL,
	intBorrowerID INT NOT NULL,
	dateLoan DATE NOT NULL,
	dateReturning DATE NOT NULL,
	dateProcessed DATETIME NOT NULL,
	dateReturned DATE,
	strPurpose VARCHAR(255) NOT NULL,
	strStatus VARCHAR(50) NOT NULL,
	CONSTRAINT pk_tblPlantLoanTransaction PRIMARY KEY(intLoanID),
	CONSTRAINT fk_tblPlantLoanTransaction_tblBorrower FOREIGN KEY(intBorrowerID)
		REFERENCES tblBorrower(intBorrowerID)
)
GO

-- Plants Deposits in Loan
IF OBJECT_ID('tblLoaningPlants', 'U') IS NOT NULL
	DROP TABLE tblLoaningPlants
GO
CREATE TABLE tblLoaningPlants
(
	intPlantLoanID INT IDENTITY(1, 1) NOT NULL,
	intLoanID INT NOT NULL,
	intHerbariumSheetID INT NOT NULL,
	boolCondition BIT,
	CONSTRAINT pk_tblLoaningPlants PRIMARY KEY(intPlantLoanID),
	CONSTRAINT fk_tblLoaningPlants_tblPlantLoanTransaction FOREIGN KEY(intLoanID)
		REFERENCES tblPlantLoanTransaction(intLoanID),
	CONSTRAINT fk_tblLoaningPlants_tblHerbariumSheet FOREIGN KEY(intHerbariumSheetID)
		REFERENCES tblHerbariumSheet(intHerbariumSheetID)
)

-- Species in Loan
IF OBJECT_ID('tblLoaningSpecies', 'U') IS NOT NULL
	DROP TABLE tblLoaningSpecies
GO
CREATE TABLE tblLoaningSpecies
(
	intSpeciesLoanID INT IDENTITY(1, 1) NOT NULL,
	intLoanID INT NOT NULL,
	intSpeciesID INT NOT NULL,
	intCopies INT NOT NULL,
	CONSTRAINT pk_tblLoaningSpecies PRIMARY KEY(intSpeciesLoanID),
	CONSTRAINT fk_tblLoaningSpecies_tblPlantLoanTransaction FOREIGN KEY(intLoanID)
		REFERENCES tblPlantLoanTransaction(intLoanID),
	CONSTRAINT fk_tblLoaningSpecies_tblSpecies FOREIGN KEY(intSpeciesID)
		REFERENCES tblSpecies(intSpeciesID)
)
GO

-------------- VIEWS CREATION --------------

-- Phylum View
IF OBJECT_ID('viewTaxonPhylum', 'V') IS NOT NULL
	DROP VIEW viewTaxonPhylum
GO
CREATE VIEW viewTaxonPhylum
AS
(
	SELECT	TP.intPhylumID, 
			CONCAT('P', FORMAT(TP.intPhylumID, '0#')) strPhylumNo, 
			TP.strDomainName, TP.strKingdomName, TP.strPhylumName
	FROM tblPhylum TP
)
GO

-- Class View
IF OBJECT_ID('viewTaxonClass', 'V') IS NOT NULL
	DROP VIEW viewTaxonClass
GO
CREATE VIEW viewTaxonClass
AS
(
	SELECT	TC.intClassID,
			CONCAT('P', FORMAT(TP.intPhylumID, '0#'), 
				   'C', FORMAT(TC.intClassID, '0#')) strClassNo,
			TP.strDomainName, TP.strKingdomName, TP.strPhylumName, TC.strClassName 
	FROM tblClass TC
		INNER JOIN tblPhylum TP ON TC.intPhylumID = TP.intPhylumID
)
GO

-- Order View
IF OBJECT_ID('viewTaxonOrder', 'V') IS NOT NULL
	DROP VIEW viewTaxonOrder
GO
CREATE VIEW viewTaxonOrder
AS
(
	SELECT	TD.intOrderID,
			CONCAT('P', FORMAT(TP.intPhylumID, '0#'), 
				   'C', FORMAT(TC.intClassID, '0#'), 
				   'O', FORMAT(TD.intOrderID, '0#')) strOrderNo,
			TP.strDomainName, TP.strKingdomName, TP.strPhylumName, TC.strClassName, TD.strOrderName
	FROM tblOrder TD
		INNER JOIN tblClass TC ON TD.intClassID = TC.intClassID
		INNER JOIN tblPhylum TP ON TC.intPhylumID = TP.intPhylumID
)
GO

-- Family View
IF OBJECT_ID('viewTaxonFamily', 'V') IS NOT NULL
	DROP VIEW viewTaxonFamily
GO
CREATE VIEW viewTaxonFamily
AS
(
	SELECT	TF.intFamilyID,
			CONCAT('P', FORMAT(TP.intPhylumID, '0#'), 
				   'C', FORMAT(TC.intClassID, '0#'), 
				   'O', FORMAT(TD.intOrderID, '0#'), 
				   'F', FORMAT(TF.intFamilyID, '0#')) strFamilyNo,
			TP.strDomainName, TP.strKingdomName, TP.strPhylumName, TC.strClassName, TD.strOrderName, TF.strFamilyName
	FROM tblFamily TF
		INNER JOIN tblOrder TD ON TF.intOrderID = TD.intOrderID
		INNER JOIN tblClass TC ON TD.intClassID = TC.intClassID
		INNER JOIN tblPhylum TP ON TC.intPhylumID = TP.intPhylumID
)
GO

-- Genus View
IF OBJECT_ID('viewTaxonGenus', 'V') IS NOT NULL
	DROP VIEW viewTaxonGenus
GO
CREATE VIEW viewTaxonGenus
AS
(
	SELECT	TG.intGenusID,
			CONCAT('P', FORMAT(TP.intPhylumID, '0#'), 
				   'C', FORMAT(TC.intClassID, '0#'), 
				   'O', FORMAT(TD.intOrderID, '0#'), 
				   'F', FORMAT(TF.intFamilyID, '0#'), 
				   'G', FORMAT(TG.intGenusID, '0#')) strGenusNo,
			TP.strDomainName, TP.strKingdomName, TP.strPhylumName, TC.strClassName, TD.strOrderName, TF.strFamilyName, TG.strGenusName
	FROM tblGenus TG 
		INNER JOIN tblFamily TF ON TG.intFamilyID = TF.intFamilyID
		INNER JOIN tblOrder TD ON TF.intOrderID = TD.intOrderID
		INNER JOIN tblClass TC ON TD.intClassID = TC.intClassID
		INNER JOIN tblPhylum TP ON TC.intPhylumID = TP.intPhylumID
)
GO

-- Species Hierarchy View
IF OBJECT_ID('viewSpeciesHierarchy', 'V') IS NOT NULL
	DROP VIEW viewSpeciesHierarchy
GO
CREATE VIEW viewSpeciesHierarchy
AS
(
	SELECT	TS.intSpeciesID,
			CONCAT('P', FORMAT(TP.intPhylumID, '0#'), 
				   'C', FORMAT(TC.intClassID, '0#'), 
				   'O', FORMAT(TD.intOrderID, '0#'), 
				   'F', FORMAT(TF.intFamilyID, '0#'), 
				   'G', FORMAT(TG.intGenusID, '0#'), 
				   'S', FORMAT(TS.intSpeciesID, '0#')) strSpeciesNo,
			TP.strDomainName, TP.strKingdomName, TP.strPhylumName, TC.strClassName, TD.strOrderName, TF.strFamilyName, TG.strGenusName, 
			TS.strSpeciesName, TS.strCommonName
	FROM tblSpecies TS
		INNER JOIN tblGenus TG ON TS.intGenusID = TG.intGenusID
		INNER JOIN tblFamily TF ON TG.intFamilyID = TF.intFamilyID
		INNER JOIN tblOrder TD ON TF.intOrderID = TD.intOrderID
		INNER JOIN tblClass TC ON TD.intClassID = TC.intClassID
		INNER JOIN tblPhylum TP ON TC.intPhylumID = TP.intPhylumID
)
GO

-- Full Species View
IF OBJECT_ID('viewTaxonSpecies', 'V') IS NOT NULL
	DROP VIEW viewTaxonSpecies
GO
CREATE VIEW viewTaxonSpecies
AS
(
	SELECT Sp.intSpeciesID, Sp.strSpeciesNo, Sp.strDomainName, Sp.strKingdomName, Sp.strPhylumName, Sp.strClassName, Sp.strOrderName, Sp.strFamilyName, 
			Sp.strGenusName, Sp.strSpeciesName, Sp.strCommonName, Au.strAuthorsName, 
			RTRIM(CONCAT(Sp.strGenusName, ' ', Sp.strSpeciesName, ' ', ISNULL(Au.strSpeciesSuffix, ''))) strScientificName,
			CAST((CASE WHEN Au.strSpeciesSuffix IS NULL THEN 0 ELSE 1 END) AS BIT) boolSpeciesIdentified
	FROM tblSpeciesAuthor SA  
		INNER JOIN tblAuthor Au ON SA.intAuthorID = Au.intAuthorID
		RIGHT JOIN viewSpeciesHierarchy Sp ON SA.intSpeciesID = Sp.intSpeciesID
)
GO

-- Species Alternate Name
IF OBJECT_ID('viewSpeciesAlternate', 'V') IS NOT NULL
	DROP VIEW viewSpeciesAlternate
GO
CREATE VIEW viewSpeciesAlternate
AS
(
	SELECT SAN.intAltNameID, TS.intSpeciesID, TS.strScientificName, TS.strCommonName, SAN.strLanguage, SAN.strAlternateName
	FROM tblSpeciesAlternateName SAN
		RIGHT JOIN viewTaxonSpecies TS ON SAN.intSpeciesID = TS.intSpeciesID 
)
GO

-- Species Alternate Collapsed
IF OBJECT_ID('viewSpeciesFullAlternate', 'V') IS NOT NULL
	DROP VIEW viewSpeciesFullAlternate
GO
CREATE VIEW viewSpeciesFullAlternate
AS
(
	SELECT intSpeciesID, strScientificName,
		'Common Name: ' + strCommonName + 
			ISNULL
			(
				CONCAT(';', 
						RTRIM
							(LTRIM
								(STUFF(( SELECT DISTINCT ';' + strLanguage + ': ' + strAlternateName FROM viewSpeciesAlternate a2 
										  WHERE a2.strScientificName = a1.strScientificName FOR XML PATH('')), 1, 1, '')
								)
							)
					   ), ''
			)
			 as strFullNomenclature
	FROM viewSpeciesAlternate a1
	GROUP BY intSpeciesID, strScientificName, strCommonName
)
GO

-- Family Box View
IF OBJECT_ID('viewFamilyBox', 'V') IS NOT NULL
	DROP VIEW viewFamilyBox
GO
CREATE VIEW viewFamilyBox
AS
(
	SELECT FB.intBoxID, CONCAT('BOX-', FORMAT(FB.intBoxID, '00#')) strBoxNumber, TF.strFamilyName, FB.intBoxLimit, FB.intRackNo, FB.intRackRow, FB.intRackColumn
	FROM tblFamilyBox FB
		INNER JOIN tblFamily TF ON FB.intFamilyID = TF.intFamilyID
) 
GO

-- Locality View
IF OBJECT_ID('viewLocality', 'V') IS NOT NULL
	DROP VIEW viewLocality
GO
CREATE VIEW viewLocality
AS
(
	SELECT Lo.intLocalityID, Co.strCountry, Re.strIsland, Re.strRegion, Pr.strProvince, Ci.strCity, Lo.strSpecificLocation, Lo.strShortLocation,
		CASE
			WHEN Co.strCountry = 'Philippines' THEN CONCAT(Lo.strSpecificLocation, ', ', Ci.strCity, ', ', Pr.strProvince, ', ', Re.strRegion, ', ', Re.strIsland)
			ELSE Lo.strFullLocality
		END strFullLocality, Lo.strLatitude, Lo.strLongtitude
	FROM tblLocality Lo
		LEFT JOIN tblPHLocality PL ON Lo.intLocalityID = PL.intLocalityID
		INNER JOIN tblCity Ci ON PL.intCityID = Ci.intCityID
		INNER JOIN tblProvince Pr ON Ci.intProvinceID = Pr.intProvinceID
		INNER JOIN tblRegion Re ON Pr.intRegionID = Re.intRegionID
		INNER JOIN tblCountry Co ON Lo.intCountryID = Co.intCountryID
)
GO

-- Collector View
IF OBJECT_ID('viewCollector', 'V') IS NOT NULL
	DROP VIEW viewCollector
GO
CREATE VIEW viewCollector
AS
(
	SELECT Co.intCollectorID, Co.strFirstname, Co.strMiddlename, Co.strLastname, Co.strMiddleInitial, Co.strNameSuffix, Co.strHomeAddress, Co.strContactNumber,
		Co.strEmailAddress, RTRIM(LTRIM(CONCAT(Co.strFirstname, ' ', Co.strLastname, ' ', Co.strNameSuffix))) strFullName, Co.strAffiliation
	FROM tblCollector Co
)
GO

-- Borrower VIew
IF OBJECT_ID('viewBorrower', 'V') IS NOT NULL
	DROP VIEW viewBorrower
GO
CREATE VIEW viewBorrower
AS
(
	SELECT Bo.intBorrowerID, Bo.strFirstname, Bo.strMiddlename, Bo.strLastname, Bo.strMiddleInitial, Bo.strNameSuffix, Bo.strHomeAddress, Bo.strContactNumber,
		Bo.strEmailAddress, RTRIM(LTRIM(CONCAT(Bo.strFirstname, ' ', Bo.strLastname, ' ', Bo.strNameSuffix))) strFullName, Bo.strAffiliation, Bo.boolIsCollector
	FROM tblBorrower Bo
)
GO

-- Validator View
IF OBJECT_ID('viewValidator', 'V') IS NOT NULL
	DROP VIEW viewValidator
GO
CREATE VIEW viewValidator
AS
(
	SELECT Va.intValidatorID, Va.strFirstname, Va.strMiddlename, Va.strLastname, Va.strMiddleInitial, Va.strNameSuffix, Va.strContactNumber,
		Va.strEmailAddress, RTRIM(LTRIM(CONCAT(Va.strFirstname, ' ', Va.strLastname, ' ', Va.strNameSuffix))) strFullName, Va.strInstitution, Va.strValidatorType
	FROM tblValidator Va
)
GO

-- Herbarium Staff View
IF OBJECT_ID('viewHerbariumStaff', 'V') IS NOT NULL
	DROP VIEW viewHerbariumStaff
GO
CREATE VIEW viewHerbariumStaff
AS
(
	SELECT St.intStaffID, St.strFirstname, St.strMiddlename, St.strLastname, St.strMiddleInitial, St.strNameSuffix, St.strContactNumber,
		St.strEmailAddress, RTRIM(LTRIM(CONCAT(St.strFirstname, ' ', St.strLastname, ' ', St.strNameSuffix))) strFullName, 
		St.strRole, St.strCollegeDepartment, St.boolActive
	FROM tblHerbariumStaff St
	WHERE St.boolActive = 1
)
GO

-- Access Accounts
IF OBJECT_ID('viewAccounts', 'V') IS NOT NULL
	DROP VIEW viewAccounts
GO
CREATE VIEW viewAccounts
AS
(
	SELECT HS.intStaffID, HS.strFullName, Ac.strUsername, Ac.strPassword, HS.strRole, Ac.boolActive
	FROM tblAccounts Ac	
		INNER JOIN viewHerbariumStaff HS ON Ac.intStaffID = HS.intStaffID
	WHERE Ac.boolActive = 1
)
GO

-- Audit Trailing View
IF OBJECT_ID('viewAuditTrailing', 'V') IS NOT NULL
	DROP VIEw viewAuditTrailing
GO
CREATE VIEW viewAuditTrailing
AS
(
	SELECT intTrailingID, HS.strFullName AS strStaff, strModule, strTransactionDesc, CONVERT(VARCHAR, dateTimeStamp, 22) AS dateTimeStamp
	FROM tblAuditTrailing [AT]
		INNER JOIN viewHerbariumStaff HS ON [AT].intStaffID = HS.intStaffID
)
GO

-- Received Deposit View
IF OBJECT_ID('viewReceivedDeposit', 'V') IS NOT NULL
	DROP VIEW viewReceivedDeposit
GO
CREATE VIEW viewReceivedDeposit
AS
(
	SELECT RD.intDepositID, CONCAT('DEP-', FORMAT(RD.intDepositID, '00000#')) strDepositNumber, RD.intPlantTypeID, 
			PT.strPlantTypeName, RD.picHerbariumSheet, Co.strFullName AS strCollector, Lo.strFullLocality, Lo.strShortLocation,
			St.strFullName AS strStaff, RD.dateCollected, RD.dateDeposited, RD.strDescription, RD.strStatus
	FROM tblReceivedDeposits RD
		INNER JOIN tblPlantType PT ON RD.intPlantTypeID = PT.intPlantTypeID
		INNER JOIN viewCollector Co ON RD.intCollectorID = Co.intCollectorID
		INNER JOIN viewLocality Lo ON RD.intLocalityID = Lo.intLocalityID
		INNER JOIN viewHerbariumStaff St ON RD.intStaffID = St.intStaffID
)
GO

-- Plant Deposit View
IF OBJECT_ID('viewPlantDeposit', 'V') IS NOT NULL
	DROP VIEW viewPlantDeposit
GO
CREATE VIEW viewPlantDeposit
AS
(
	SELECT PD.intPlantDepositID, 
			CONCAT(AF.strInstitutionCode,'-', PT.strPlantTypeCode, '-', FORMAT(PD.intAccessionNumber, AF.strAccessionFormat), '-', 
			FORMAT(YEAR(PD.dateDeposited) % POWER(10, LEN(AF.strYearFormat)), AF.strYearFormat)) strAccessionNumber, PT.strPlantTypeName,
			(CASE WHEN Lo.strCountry = 'Philippines' THEN Lo.strProvince ELSE 'Other Country' END) strProvince, 
			PD.intAccessionNumber, Co.strFullName AS strCollector, Lo.strFullLocality,
			St.strFullName AS strStaff, PD.dateCollected, PD.dateDeposited, PD.strDescription, PD.strStatus
	FROM tblPlantDeposit PD
		INNER JOIN tblPlantType PT ON PD.intPlantTypeID = PT.intPlantTypeID
		INNER JOIN tblAccessionFormat AF ON PD.intFormatID = AF.intFormatID
		INNER JOIN viewCollector Co ON PD.intCollectorID = Co.intCollectorID
		INNER JOIN viewLocality Lo ON PD.intLocalityID = Lo.intLocalityID
		INNER JOIN viewHerbariumStaff St ON PD.intStaffID = St.intStaffID
)
GO

-- Herbarium Sheet Picture View
IF OBJECT_ID('viewHerbariumPicture', 'V') IS NOT NULL
	DROP VIEW viewHerbariumPicture
GO
CREATE VIEW viewHerbariumPicture
AS
(
	SELECT HP.intPictureID, PD.strAccessionNumber, HP.picHerbariumSheet, HP.strTagDescription
	FROM tblHerbariumSheetPicture HP
		INNER JOIN viewPlantDeposit PD ON HP.intPlantDepositID = PD.intPlantDepositID
)
GO

-- Externally Verifying Plant Deposit View
IF OBJECT_ID('viewVerifyingDeposit', 'V') IS NOT NULL
	DROP VIEW viewVerifyingDeposit
GO
CREATE VIEW viewVerifyingDeposit
AS
(
	SELECT PD_A.intPlantDepositID, PD_A.strAccessionNumber, PD_B.strAccessionNumber AS strReferenceAccession, 
		TS.strFamilyName, TS.strScientificName, TS.strCommonName, PD_A.strCollector, PD_A.strFullLocality, PD_A.strStaff,  
		PD_A.dateCollected, PD_A.dateDeposited, PD_A.strDescription, PD_A.strStatus
	FROM tblVerifyingDeposit VD
		RIGHT JOIN viewPlantDeposit PD_A ON VD.intPlantDepositID = PD_A.intPlantDepositID
		INNER JOIN viewPlantDeposit PD_B ON VD.intReferenceDepositID = PD_B.intPlantDepositID
		INNER JOIN viewTaxonSpecies TS ON VD.intSpeciesID = TS.intSpeciesID
	WHERE PD_A.strStatus = 'Further Verification'
)
GO

-- Herbarium Sheet
IF OBJECT_ID('viewHerbariumSheet', 'V') IS NOT NULL
	DROP VIEW viewHerbariumSheet
GO
CREATE VIEW viewHerbariumSheet
AS
(
	SELECT HS.intHerbariumSheetID, HS.intPlantDepositID, PD_A.strAccessionNumber, 
			HS.intPlantReferenceID, PD_B.strAccessionNumber AS strReferenceAccession, 
			TS.strFamilyName, TS.strScientificName, FA.strFullNomenclature, PD_A.strCollector, 
			PD_A.strFullLocality, PD_A.strStaff, PD_A.dateCollected, PD_A.dateDeposited, HS.dateVerified,
			PD_A.strDescription, Va.strFullName AS strValidator, PD_A.strStatus
	FROM tblHerbariumSheet HS
		INNER JOIN viewPlantDeposit PD_A ON HS.intPlantDepositID = PD_A.intPlantDepositID
		INNER JOIN viewPlantDeposit PD_B ON HS.intPlantReferenceID = PD_B.intPlantDepositID
		INNER JOIN viewTaxonSpecies TS ON HS.intSpeciesID = TS.intSpeciesID
		INNER JOIN viewSpeciesFullAlternate FA ON TS.intSpeciesID = FA.intSpeciesID
		INNER JOIN viewValidator Va ON HS.intValidatorID = Va.intValidatorID
)
GO

-- Stored Herbarium
IF OBJECT_ID('viewHerbariumInventory', 'V') IS NOT NULL
	DROP VIEW viewHerbariumInventory
GO
CREATE VIEW viewHerbariumInventory
AS
(
	SELECT SH.intStoredSheetID, HS.strAccessionNumber, HS.strReferenceAccession, 
		HS.strFamilyName, HS.strScientificName, HS.strFullNomenclature, HS.strCollector, HS.strFullLocality, HS.strStaff, 
		HS.dateCollected, HS.dateDeposited, HS.strDescription, HS.strStatus, HS.strValidator, 
		HS.dateVerified, FB.strBoxNumber, SH.boolLoanAvailable
	FROM tblStoredHerbarium SH
		INNER JOIN viewHerbariumSheet HS ON SH.intHerbariumSheetID = HS.intHerbariumSheetID
		INNER JOIN viewFamilyBox FB ON SH.intBoxID = FB.intBoxID
)
GO

-- Plant Loans
IF OBJECT_ID('viewPlantLoans', 'V') IS NOT NULL
	DROP VIEW viewPlantLoans
GO
CREATE VIEW viewPlantLoans
AS
(
	SELECT PL.intLoanID, CONCAT('HB-', FORMAT(PL.intLoanID, '00000#')) as strLoanNumber, Bo.strFullName AS strBorrower, 
		PL.dateLoan, PL.dateReturning, CONCAT(CONVERT(VARCHAR, PL.dateLoan, 107), ' - ', CONVERT(VARCHAR, PL.dateReturning, 107)) as strDuration, 
		PL.dateProcessed, PL.dateReturned, PL.strPurpose, PL.strStatus
	FROM tblPlantLoanTransaction PL
		INNER JOIN viewBorrower Bo ON PL.intBorrowerID = Bo.intBorrowerID
)
GO

IF OBJECT_ID('viewSpeciesInventory', 'V') IS NOT NULL
	DROP VIEW viewSpeciesInventory
GO
CREATE VIEW viewSpeciesInventory
AS
(
	SELECT TS.strFamilyName, TS.strGenusName, TS.strScientificName, COUNT(HI.intStoredSheetID) AS intSpeciesCount
	FROM viewTaxonSpecies TS 
		LEFT JOIN viewHerbariumInventory HI ON TS.strScientificName = HI.strScientificName AND HI.boolLoanAvailable = 1
	GROUP BY TS.strFamilyName, TS.strGenusName, TS.strScientificName 
)
GO

IF OBJECT_ID('viewSpeciesLoanCount', 'V') IS NOT NULL
	DROP VIEW viewSpeciesLoanCount
GO
CREATE VIEW viewSpeciesLoanCount
AS
(
	SELECT TS.strScientificName, SUM(LS.intCopies) AS intBorrowedCount
	FROM viewTaxonSpecies TS  
		JOIN tblLoaningSpecies LS ON TS.intSpeciesID = LS.intSpeciesID 
		JOIN tblPlantLoanTransaction LT ON LT.intLoanID = LS.intLoanID AND LT.strStatus = 'Requesting'
	GROUP BY TS.strFamilyName, TS.strScientificName 
)
GO

IF OBJECT_ID('viewLoanedSpecies', 'V') IS NOT NULL
	DROP VIEW viewLoanedSpecies
GO
CREATE VIEW viewLoanedSpecies
AS
(
	SELECT LS.intSpeciesLoanID, PL.strLoanNumber, TS.strFamilyName, TS.strScientificName, LS.intCopies 
	FROM tblLoaningSpecies LS
		JOIN viewPlantLoans PL ON LS.intLoanID = PL.intLoanID
		JOIN viewTaxonSpecies TS ON LS.intSpeciesID = TS.intSpeciesID
)
GO

IF OBJECT_ID('viewLoanedSheets', 'V') IS NOT NULL
	DROP VIEW viewLoanedSheets
GO
CREATE VIEW viewLoanedSheets
AS
(
	SELECT LP.intPlantLoanID, PL.strLoanNumber, PL.strBorrower, PL.strDuration, PL.dateReturned, HS.strAccessionNumber, HS.strScientificName, HS.strStatus, LP.boolCondition
	FROM tblLoaningPlants LP
		INNER JOIN viewPlantLoans PL ON LP.intLoanID = PL.intLoanID
		INNER JOIN viewHerbariumSheet HS ON LP.intHerbariumSheetID = HS.intHerbariumSheetID
)
GO

IF OBJECT_ID('viewHerbariumSheetTrack', 'V') IS NOT NULL
	DROP VIEW viewHerbariumSheetTrack
GO
CREATE VIEW viewHerbariumSheetTrack
AS
(
	SELECT PD.strAccessionNumber, COALESCE(HS.strReferenceAccession, VD.strReferenceAccession, '') AS strReferenceAccession, 
		   COALESCE(HS.strScientificName, VD.strScientificName, '') AS strScientificName, 
		   HI.strBoxNumber, HS.strFamilyName, HS.strFullNomenclature, PD.strPlantTypeName, PD.strFullLocality, 
		   PD.strCollector, PD.strStaff, HS.strValidator, PD.dateCollected, PD.dateDeposited, HS.dateVerified, PD.strDescription, 
		   LS.strLoanNumber, LS.strBorrower, LS.strDuration, HI.boolLoanAvailable, PD.strStatus 
	FROM viewPlantDeposit PD
		LEFT JOIN viewVerifyingDeposit VD ON PD.strAccessionNumber = VD.strAccessionNumber
		LEFT JOIN viewHerbariumSheet HS ON PD.strAccessionNumber = HS.strAccessionNumber
		LEFT JOIN viewHerbariumInventory HI ON HS.strAccessionNumber = HI.strAccessionNumber
		LEFT JOIN viewLoanedSheets LS ON HI.strAccessionNumber = LS.strAccessionNumber AND LS.strStatus = 'Loaned'
)
GO
 
--------- STATIC DATA INSERTION ---------
-- Do not Overwrite!

SET NOCOUNT ON

-- System Menu
INSERT INTO tblSystemMenu(strLevel, strMainMenu, strSubMenu, strPageLocation, strGlyphCode, intAccessLevel)
VALUES ('A', 'Home',				NULL, 'HomePage',			N'',	1),
	   ('A', 'Maintenance',			NULL, 'MaintenancePage',	N'',	1),
	   ('A', 'Transaction',			NULL, 'TransactionPage',	N'',	1),
	   ('A', 'Management Tools',	NULL, 'UtilitiesPage',		N'',	1),
	   ('A', 'Queries',				NULL, 'QueriesPage',		N'',	2),
	   ('A', 'Reports',				NULL, 'ReportsPage',		N'',	2)
GO

INSERT INTO tblSystemMenu(strLevel, strMainMenu, strSubMenu, strPageLocation, intAccessLevel)
VALUES ('B', 'Maintenance',			'Taxonomic Hierarchy',	'TaxonomicHierarchyPage',	2),
       ('B', 'Maintenance',			'Species Author',		'SpeciesAuthorPage',		2),
       ('B', 'Maintenance',			'Species Basionym',		'SpeciesNomenclaturePage',	2),
       ('B', 'Maintenance',			'Plant Types',			'PlantTypePage',			2),
       ('B', 'Maintenance',			'Herbarium Boxes',		'HerbariumBoxPage',			1),
       ('B', 'Maintenance',			'Plant Locality',		'PlantLocalityPage',		1),
       ('B', 'Maintenance',			'Collector',			'CollectorPage',			1),
       ('B', 'Maintenance',			'Borrower',				'BorrowerPage',				1),
       ('B', 'Maintenance',			'External Validator',	'ExternalValidatorPage',	2),
       ('B', 'Maintenance',			'Herbarium Staff',		'HerbariumStaffPage',		3),
       ('B', 'Maintenance',			'Access Accounts',		'AccessAccountsPage',		3),
       ('B', 'Transaction',			'Plant Deposit',		'PlantDepositPage',			1),
       ('B', 'Transaction',			'Plant Receiving',		'PlantReceivingPage',		2),
       ('B', 'Transaction',			'Plant Resubmission',	'PlantResubmissionPage',	1),
       ('B', 'Transaction',			'Plant Verification',	'PlantVerificationPage',	2),
       ('B', 'Transaction',			'Plant Classification',	'PlantClassificationPage',	1),
       ('B', 'Transaction',			'Plant Loaning',		'PlantLoaningPage',			1),
       ('B', 'Management Tools',	'Herbarium Inventory',	'HerbariumInventoryPage',	1),
       ('B', 'Management Tools',	'Sheet Tracking',		'SheetTrackingPage',		1),
       ('B', 'Management Tools',	'Audit Trailing',		'AuditTrailingPage',		2)
GO

-- Species Data
INSERT INTO tblSpeciesData (strDomainName, strKingdomName, strPhylumName, strClassName, strOrderName, strFamilyName, strGenusName, strSpeciesName, strCommonName, strAuthorsName)
VALUES  ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Solanes', 'Convolvulaceae', 'Ipomoea', 'aquatica', 'Water spinach', 'Peter Forsskål'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Solanes', 'Convolvulaceae', 'Ipomoea', 'batatas', 'Sweet potato', 'Carl Linneaus, Jean-Baptiste Lamarck'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Solanes', 'Convolvulaceae', 'Ipomoea', 'triloba', 'Aiea Morning Glory', 'Carl Linneaus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Solanes', 'Convolvulaceae', 'Operculina', 'turpethum', 'Turpeth', 'Carl Linneaus, Silva Manso'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Zingiberales', 'Costaceae', 'Cheilocostus', 'speciosus', 'Wild ginger', 'Johann Gerhard König'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Acacia', 'auriculiformis', 'Acacia tree', 'George Bentham'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Albizia', 'saman', 'Rain tree', 'Ferdinand von Mueller'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Arachis', 'pintoi', 'Pinto peanut', 'Krapovickas & WC Gregory'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Bauhinia', 'purpurea', 'Orchid tree', 'Carl Linnaeus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Centrosema', 'pubescens', 'Butterfly pea', 'George Bentham'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Delonix', 'regia', 'Flame tree', 'William Jackson Hooker, Constantine Samuel Rafinesque'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Leucenia', 'leucocephala', 'White leadtree', 'Jean-Baptiste Lamarck, Hendrik de Wit'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Mimosa', 'pudica', 'Sensitive plant', 'Carl Linnaeus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Pterocarpus', 'indicus', 'Philippine mahogany', 'Carl Ludwig Willdenow'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Senna', 'alata', 'Ringworm bush', 'Carl Linnaeus, William Roxburgh'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Fabales', 'Fabaceae', 'Tamarindus', 'indica', 'Tamarind', 'Carl Linneaus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Scrophulariales', 'Linderniaceae', 'Linderia', 'crustacea', 'Malaysian False Pimpernel', 'Carl Linneaus, Ferdinand von Mueller'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Polygalales', 'Malpighiaceae', 'Malpighia', 'coccigera', 'Singaporean Holly', 'Carl Linnaeus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Sapindales', 'Meliaceae', 'Azardirachta', 'indica', 'Indian lilac', 'Adrien-Henri de Jussieu'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Sapindales', 'Meliaceae', 'Melia', 'azedarach', 'Chinaberry Tree', 'Carl Linnaeus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Sapindales', 'Meliaceae', 'Swietenia', 'macrophylla', 'Big Leaf Mahogany', 'George King'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Sapindales', 'Meliaceae', 'Sandoricum', 'koetjape', 'Santol', 'Adrien-Henri de Jussieu'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Artocarpus', 'camansi', 'Breadfruit', 'Francisco Manuel Blanco'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Artocarpus', 'heterophyllus', 'Jackfruit', 'Jean-Baptiste Lamarck'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Broussonetia', 'luzonica', 'Birch flower', 'Francisco Manuel Blanco'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Ficus', 'benjamina', 'Weeping fig', 'Carl Linnaeus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Ficus', 'cumingii', 'Fig', 'Friedrich Anton Wilheim Miquel'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Ficus', 'elastica', 'Indian rubberplant', 'William Roxburgh, Jens Wilken Hornemann'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Ficus', 'religiosa', 'Sacred fig', 'Carl Linnaeus'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Ficus', 'septica', 'Hauli tree', 'Nicolaas Laurens Burman'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Moraceae', 'Ficus', 'ulmifolia', 'isis', 'Jean-Baptiste Lamarck'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Sapindales', 'Rutaceae', 'Citrus', 'maxima', 'Pomelo', 'Nicolaas Laurens Burman, Elmer Drew Merrill'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Sapindales', 'Rutaceae', 'Citrus', 'microcarpa', 'Calamansi', 'Friedrich Georg von Burge'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Sapindales', 'Rutaceae', 'Murraya', 'paniculata', 'Kamuning', 'Carl Linnaeus, William Jack'),
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Urticales', 'Urticaceae', 'Pilea', 'microphylla', 'Artillery plant', 'Carl Linnaeus, Frederik Liebmann')
INSERT INTO tblSpeciesData (strDomainName, strKingdomName, strPhylumName, strClassName, strOrderName, strFamilyName, strGenusName, strSpeciesName, strCommonName, strAuthorsName)
VALUES  ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Codiaeum', 'variegatum', 'Garden Croton', 'Carl Linnaeus, Adrien-Henri de Jussieu'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Ricinus', 'communis', 'Castor Bean', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Macaranga', 'grandifolia', 'Coral tree', 'Johann Baptist Emanuel Pohl'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Euphorbia', 'hirta', 'Asthma plant', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Jatropha', 'integerrina', 'Peregrina', 'Nikolaus Joseph von Jacquin'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Codiaeum', 'variegatum', 'Garden Croton', 'Carl Linnaeus, Adrien-Henri de Jussieu'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Manihot', 'esculenta', 'Cassava', 'Heinrich Johann Nepomuk von Crantz'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Macaranga', 'tanarius', 'Parasol Leaf Tree', 'Carl Linnaeus, Johannes Müller Argoviensis'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Excoecaria', 'cochinchinensis', 'Blindness Tree', 'João de Loureiro'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Euphorbia', 'heterophylla', 'Kaliko Plant', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Euphorbia', 'tirucalli', 'Indiantree Spurge', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Euphorbia', 'hypericifolia', 'Baby''s-Breath Euphorbia', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Pedilanthus', 'tithymaloides', 'Redbird Flower', 'Carl Linnaeus, Pierre Antoine Poiteau'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Euphorbiales', 'Euphorbiaceae', 'Antidesma', 'bunius', 'Salamander Tree', 'Carl Linnaeus, Kurt Polycarp Joachim Sprengel'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Lamiales', 'Lamiaceae', 'Vitex', 'parviflora', 'Molave Tree', 'Antoine Laurent de Jussieu'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Lamiales', 'Lamiaceae', 'Premma', 'odorata', 'Fragrant Premma', 'Francisco Manuel Blanco'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Lamiales', 'Lamiaceae', 'Origanum', 'vulgare', 'Oregano', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Lamiales', 'Lamiaceae', 'Plectranthus', 'scutellarioides', 'Painted nettle', 'Carl Linnaeus, Robert Brown'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Lamiales', 'Lamiaceae', 'Orthosiphon', 'aristatus', 'Cat''s Whiskers', 'Carl Ludwig Blume, Friedrich Anton Wilheim Miquel'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Lamiales', 'Lamiaceae', 'Vitex', 'negundo', 'Lagundi', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Lamiales', 'Lamiaceae', 'Gmelina', 'arborea', 'Kashmir Tree', 'William Roxburgh'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Myrtales', 'Onagraceae', 'Ludwigia', 'perennis', 'Perennial Water Primrose', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Geraniales', 'Oxalidaceae', 'Averrhoa', 'bilimbi', 'Kamias', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Geraniales', 'Oxalidaceae', 'Oxalis', 'corniculata', 'Sleeping Beauty', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Caryophyllales', 'Phytolaccaceae', 'Rivina', 'humilis', 'Bloodberry', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Saccharum', 'officinarum', 'Sugarcane', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Bambusa', 'vulgaris', 'Common Bamboo', 'Heinrich Schrader'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Eleusine', 'indica', 'Goosegrass', 'Carl Linnaeus, Joseph Gaertner'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Chrysopogon', 'aciculatus', 'Amorseco', 'Anders Jahan Retzius, Carl Bernhard von Trinius'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Chloris', 'barbata', 'Purpletop Chloris', 'Olof Peter Swartz'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Dactylocenium', 'aegyptium', 'Egyptian crowfoot grass', 'Carl Linnaeus, Carl Ludwig Willdenow'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Digitaria', 'ciliaris', 'Summer Grass', 'Anders Jahan Retzius, Georg Ludwig Koeler'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Ageratum', 'conyzoides', 'Chickweed', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Eragrostis', 'amabilis', 'Feathery Eragrostis', 'Carl Linnaeus, Robert Wight, George Arnott Walker Arnott'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Chloris', 'sp.', 'Windmill Grass', ''), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Cynodon', 'dactylon', 'Wire grass', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Melinis', 'repens', 'Natal grass', 'Carl Ludwig Willdenow, Žižka'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Rottboellia', 'cochinchinensis', 'Itch grass', 'João de Loureiro'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Cenchrus', 'echinatus', 'Southern sandbur', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Cyperales', 'Poaceae', 'Saccharum', 'spontaneum', 'Wild Sugarcane', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Rubiales', 'Rubiaceae', 'Ixora', 'coccinea', 'Santan-pula', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Rubiales', 'Rubiaceae', 'Morinda', 'citrifolia', 'Noni', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Rubiales', 'Rubiaceae', 'Spermacoce', 'ocymoides', 'Purple-leaved Button Weed', 'Nicolaas Laurens Burman'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Rubiales', 'Rubiaceae', 'Hamelia', 'patens', 'Scarlet bush', 'Nikolaus Joseph von Jacquin'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Rubiales', 'Rubiaceae', 'Ixora', 'chinensis', 'Chinese Ixora', 'Jean-Baptiste Lamarck'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Rubiales', 'Rubiaceae', 'Oldenlandia', 'corymbosa', 'Flat-top mille graines', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Zingiberales', 'Maranathaceae', 'Calathea', 'majestica', 'Prayer Plant', 'Jean Jules Linden'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Zingiberales', 'Maranathaceae', 'Calathea', 'makoyana', 'Peacock Plant', 'Charles Jacques Édouard Morren'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Zingiberales', 'Maranathaceae', 'Maranta', 'arundinacea', 'Arrowroot', 'Carl Linnaeus'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Zingiberales', 'Heliconiaceae', 'Heliconia', 'psittacorum', 'Parakeet Flower', 'Carl Linnaeus the Younger'), 
        ('Eurkaryota', 'Plantae', 'Magnoliophyta', 'Magnoliopsida', 'Caryophyllales', 'Portulacaceae', 'Portulaca', 'grandiflora', 'Rose moss', 'William Jackson Hooker')
GO

-- Countries
INSERT INTO tblCountry(strCountry)
VALUES ('Afghanistan'), ('Aland Islands'), ('Albania'), ('Algeria'), ('American Samoa'), 
	   ('Andorra'), ('Angola'), ('Anguilla'), ('Antarctica'), ('Antigua and Barbuda'), 
	   ('Argentina'), ('Armenia'), ('Aruba'), ('Australia'), ('Austria'), 
	   ('Azerbaijan'), ('Bahamas'), ('Bahrain'), ('Bangladesh'), ('Barbados'), 
	   ('Belarus'), ('Belgium'), ('Belize'), ('Benin'), ('Bermuda'),
	   ('Bhutan'), ('Bolivia'), ('Bosnia and Herzegovina'), ('Botswana'), ('Bouvet Island'),
	   ('Brazil'), ('British Indian Ocean Territory'), ('Brunei Darussalam'), ('Bulgaria'), ('Burkina Paso'),
	   ('Burundi'), ('Cambodia'), ('Cameroon'), ('Canada'), ('Cape Verde'),
	   ('Cayman Islands'), ('Central African Republic'), ('Chad'), ('Chile'), ('China'),
	   ('Christmas Island'), ('Cocos (Keeling) Island'), ('Colombia'), ('Comoros'), ('Congo'),
	   ('Congo, Democratic Republic of'), ('Cook Islands'), ('Costa Rica'), ('Cote D''Ivoire'), ('Croatia'),
	   ('Cuba'), ('Cyprus'), ('Czech Republic'), ('Denmark'), ('Djibouti'),
	   ('Dominica'), ('Dominican Republic'), ('Ecuador'), ('Egypt'), ('El Salvador'),
	   ('Equatorial Guinea'), ('Eritrea'), ('Estonia'), ('Ethiopia'), ('Falkland Islands (Malvinas)'),
	   ('Faroe Islands'), ('Fiji'), ('Finland'), ('France'), ('French Guiana'),
	   ('French Polynesia'), ('French Southern Territories'), ('Gabon'), ('Gambia'), ('Georgia'),
	   ('Germany'), ('Ghana'), ('Gibraltar'), ('Greece'), ('Greenland'),
	   ('Grenada'), ('Guadaloupe'), ('Guam'), ('Guatemala'), ('Guernsey'),
	   ('Guinea'), ('Guinea-Bissau'), ('Guyana'), ('Haiti'), ('Heard Island and McDonald Islands'),
	   ('Holy See (Vatican City State)'), ('Honduras'), ('Hong Kong'), ('Hungary'), ('Iceland'),
	   ('India'), ('Indonesia'), ('Iran'), ('Iraq'), ('Ireland'),
	   ('Isle of Man'), ('Israel'), ('Italy'), ('Jamaica'), ('Japan'),
	   ('Jersey'), ('Jordan'), ('Kazakhstan'), ('Kenya'), ('Kiribati'),
	   ('Korea, North'), ('Korea, South'), ('Kuwait'), ('Kyrgyzstan'), ('Laos'),
	   ('Latvia'), ('Lebanon'), ('Lesotho'), ('Liberia'), ('Libya'),
	   ('Liechtenstein'), ('Lithuania'), ('Luxemberg'), ('Macao'), ('Macedonia'),
	   ('Madagascar'), ('Malawi'), ('Malaysia'), ('Maldives'), ('Mali'),
	   ('Malta'), ('Marshall Islands'), ('Martinique'), ('Mauritania'), ('Mauritius'),
	   ('Mayotte'), ('Mexico'), ('Micronesia'), ('Moldova'), ('Monaco'),
	   ('Mongolia'), ('Montenegro'), ('Montserrat'), ('Morocco'), ('Mozambique'),
	   ('Myanmar'), ('Namibia'), ('Nauru'), ('Nepal'), ('Netherlands'),
	   ('Netherlands Antille'), ('New Caledonia'), ('New Zealand'), ('Nicaragua'), ('Niger'),
	   ('Nigeria'), ('Niue'), ('Norfolk Island'), ('Northern Mariana Islands'), ('Norway'),
	   ('Oman'), ('Pakistan'), ('Palau'), ('Palestine'), ('Panama'), 
	   ('Papua New Guinea'), ('Paraguay'), ('Peru'), ('Philippines'), ('Pitcairn'),
	   ('Poland'), ('Portugal'), ('Puerto Rico'), ('Qatar'), ('Reunion'),
	   ('Romania'), ('Russia'), ('Rwanda'), ('Saint Barthelemy'), ('Saint Helena, Ascension and Tristan Da Cunha'),
	   ('Saint Kitts'), ('Saint Lucia'), ('Saint Martin'), ('Saint Pierre and Miquelon'), ('Saint Vincent and the Grenadines'),
	   ('Samoa'), ('San Marino'), ('Sao Tome and Principe'), ('Saudi Arabia'), ('Senegal'),
	   ('Serbia'), ('Seychelles'), ('Sierra Leone'), ('Singapore'), ('Slovakia'),
	   ('Slovenia'), ('Solomon Islands'), ('Somalia'), ('South Africa'), ('South Georgia and the South Sandwich Islands'),
	   ('Spain'), ('Sri Lanka'), ('Sudan'), ('Suriname'), ('Svalbard and Jan Mayen'),
	   ('Swaziland'), ('Sweden'), ('Switzerland'), ('Syria'), ('Taiwan'),
	   ('Tajikistan'), ('Tanzania'), ('Thailand'), ('Timor-Leste'), ('Togo'),
	   ('Tokelau'), ('Tonga'), ('Trinidad and Tobago'), ('Tunisia'), ('Turkey'),
	   ('Turkmenistan'), ('Turks and Caicos Islands'), ('Tuvalu'), ('Uganda'), ('Ukraine'),
	   ('United Arab Emirates'), ('United Kingdom'), ('United States'), ('United States Minor Outlying Islands'), ('Uruguay'),
	   ('Uzbekistan'), ('Vanuatu'), ('Vatican City'), ('Venezuela'), ('Vietnam'),
	   ('Virgin Islands (British)'), ('Virgin Islands (US)'), ('Wallis and Fortuna'), ('Western Sahara'), ('Yemen'),
	   ('Yugoslavia'), ('Zambia'), ('Zimbabwe')

-- Regions
INSERT INTO tblRegion (strIsland, strRegionCode, strRegion)
VALUES ('Luzon', 'NCR', 'National Capital Region'),
	   ('Luzon', 'CAR', 'Cordillera Administrative Region'),
	   ('Luzon', 'I', 'Ilocos Region'),
	   ('Luzon', 'II', 'Cagayan Valley'),
	   ('Luzon', 'III', 'Central Luzon'),
	   ('Luzon', 'IV-A', 'CALABARZON'),
	   ('Luzon', 'IV-B', 'MIMAROPA'),
	   ('Luzon', 'V', 'Bicol Region'),
	   ('Visayas', 'VI', 'Western Visayas'),
	   ('Visayas', 'VII', 'Central Visayas'),
	   ('Visayas', 'VIII', 'Eastern Visayas'),
	   ('Mindanao', 'IX', 'Zamboanga Peninsula'),
	   ('Mindanao', 'X', 'Northern Mindanao'),
	   ('Mindanao', 'XI', 'Davao Region'),
	   ('Mindanao', 'XII', 'SOCCSKSARGEN'),
	   ('Mindanao', 'XIII', 'Caraga Region'),
	   ('Mindanao', 'ARMM', 'Autonomous Region in Muslim Mindanao')
GO

-- Provinces
INSERT INTO tblProvince (intRegionID, strProvince)
VALUES (1, 'Metro Manila'),
	   (2, 'Abra'), (2, 'Apayao'), (2, 'Benguet'), (2, 'Ifugao'), (2, 'Kalinga'), (2, 'Mountain Province'),
	   (3, 'Ilocos Norte'), (3, 'Ilocos Sur'), (3, 'La Union'), (3, 'Pangasinan'),
	   (4, 'Batanes'), (4, 'Cagayan'), (4, 'Isabela'), (4, 'Nueva Vizcaya'), (4, 'Quirino'),
	   (5, 'Aurora'), (5, 'Bataan'), (5, 'Bulacan'), (5, 'Nueva Ecija'), (5, 'Pampanga'), (5, 'Tarlac'), (5, 'Zambales'),
	   (6, 'Batangas'), (6, 'Cavite'), (6, 'Laguna'), (6, 'Quezon'), (6, 'Rizal'),
	   (7, 'Marinduque'), (7, 'Occidental Mindoro'), (7, 'Oriental Mindoro'), (7, 'Palawan'), (7, 'Romblon'),
	   (8, 'Albay'), (8, 'Camarines Norte'), (8, 'Camarines Sur'), (8, 'Catanduanes'), (8, 'Masbate'), (8, 'Sorsogon'),
	   (9, 'Aklan'), (9, 'Antique'), (9, 'Capiz'), (9, 'Guimaras'), (9, 'Negros Occidental'), (9, 'Iloilo'),
	   (10, 'Bohol'), (10, 'Cebu'), (10, 'Negros Oriental'), (10, 'Siquijor'),
	   (11, 'Biliran'), (11, 'Eastern Samar'), (11, 'Leyte'), (11, 'Northern Samar'), (11, 'Southern Leyte'),
	   (12, 'Zamboanga del Norte'), (12, 'Zamboanga del Sur'), (12, 'Zamboanga Sibugay'),
	   (13, 'Bukidnon'), (13, 'Camiguin'), (13, 'Lanao del Norte'), (13, 'Misamis Occidental'), (13, 'Misamis Oriental'),
	   (14, 'Compostela Valley'), (14, 'Davao del Norte'), (14, 'Davao del Sur'), (14, 'Davao Occidental'), (14, 'Davao Oriental'),
	   (15, 'Cotabato'), (15, 'Saranggani'), (15, 'South Cotabato'), (15, 'Sultan Kudarat'),
	   (16, 'Agusan del Norte'), (16, 'Agusan del Sur'), (16, 'Dinagat Islands'), (16, 'Surigao del Norte'), (16, 'Surigao del Sur'),
	   (17, 'Basilan'), (17, 'Lanao del Sur'), (17, 'Maguindanao'), (17, 'Sulu'), (17, 'Tawi-Tawi')
GO

-- Cities
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (1, 'Caloocan'), (1, 'Las Piñas'), (1, 'Makati'), (1, 'Malabon'), (1, 'Mandaluyong'), (1, 'Manila'), (1, 'Marikina'), (1, 'Muntilupa'), 
	   (1, 'Navotas'), (1, 'Parañaque'), (1, 'Pasay'), (1, 'Pasig'), (1, 'Pateros'), (1, 'Quezon City'), (1, 'San Juan'), (1, 'Taguig'), (1, 'Valenzuela')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (2, 'Bangued'), (2, 'Boliney'), (2, 'Bucay'), (2, 'Bucloc'), (2, 'Daguioman'), (2, 'Danglas'), (2, 'Dolores'), (2, 'La Paz'), (2, 'Lacub'),
	   (2, 'Lagangilang'), (2, 'Lagayan'), (2, 'Langiden'), (2, 'Licuan-Baay'), (2, 'Luba'), (2, 'Malibcong'), (2, 'Manabo'), (2, 'Peñarrubia'),
	   (2, 'Pidigan'), (2, 'Pilar'), (2, 'Sallapadan'), (2, 'San Isidro'), (2, 'San Juan'), (2, 'San Quintin'), (2, 'Tayum'), (2, 'Tineg'), 
	   (2, 'Tubo'), (2, 'Villaviciosa')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (3, 'Calanasan'), (3, 'Conner'), (3, 'Flora'), (3, 'Kabugao'), (3, 'Luna'), (3, 'Pudtol'), (3, 'Santa Marcela')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (4, 'Baguio'), (4, 'Atok'), (4, 'Bakun'), (4, 'Bokod'), (4, 'Buguias'), (4, 'Itogon'), (4, 'Kabayan'), (4, 'Kapangan'), (4, 'Kibungan'),
	   (4, 'La Trinidad'), (4, 'Mankayan'), (4, 'Sablan'), (4, 'Tuba'), (4, 'Tublay')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (5, 'Aguinaldo'), (5, 'Alfonso Lista'), (5, 'Asipulo'), (5, 'Banaue'), (5, 'Hingyon'), (5, 'Hungduan'), (5, 'Kiangan'), (5, 'Lagawe'),
	   (5, 'Lamut'), (5, 'Mayoyao'), (5, 'Tinoc')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (6, 'Tabuk'), (6, 'Balbalan'), (6, 'Lubuagan'), (6, 'Pasil'), (6, 'Pinukpuk'), (6, 'Rizal'), (6, 'Tanudan'), (6, 'Tinglayan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (7, 'Barlig'), (7, 'Bauko'), (7, 'Besao'), (7, 'Bontoc'), (7, 'Natonin'), (7, 'Paracelis'), (7, 'Sabangan'), (7, 'Sadanga'),
	   (7, 'Sagada'), (7, 'Tadian')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (8, 'Batac'), (8, 'Laoag'), (8, 'Adams'), (8, 'Bacarra'), (8, 'Badoc'), (8, 'Bangui'), (8, 'Banna'), (8, 'Burgos'), (8, 'Carasi'),
	   (8, 'Currimao'), (8, 'Dingras'), (8, 'Dumalneg'), (8, 'Marcos'), (8, 'Nueva Ara'), (8, 'Pagudpud'), (8, 'Paoay'), (8, 'Pasuquin'),
	   (8, 'Piddig'), (8, 'Pinili'), (8, 'San Nicolas'), (8, 'Sarrat'), (8, 'Solsona'), (8, 'Vintar')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (9, 'Candon'), (9, 'Vigan'), (9, 'Alilem'), (9, 'Banayoyo'), (9, 'Bantay'), (9, 'Burgos'), (9, 'Cabugao'), (9, 'Caoayan'),
	   (9, 'Cervantes'), (9, 'Galimuyod'), (9, 'Gregorio Del Pilar'), (9, 'Lidlidda'), (9, 'Magsingal'), (9, 'Nagbukel'), (9, 'Narvacan'),
	   (9, 'Quirino'), (9, 'Salcedo'), (9, 'San Emilio'), (9, 'San Esteban'), (9, 'San Ildefonso'), (9, 'San Juan'), (9, 'San Vicente'),
	   (9, 'Santa'), (9, 'Santa Catalina'), (9, 'Santa Cruz'), (9, 'Santa Lucia'), (9, 'Santa Maria'), (9, 'Santiago'), (9, 'Santo Domingo'),
	   (9, 'Sigay'), (9, 'Sinait'), (9, 'Sugpon'), (9, 'Suyo'), (9, 'Tagudin')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (10, 'San Fernando'), (10, 'Agoo'), (10, 'Aringay'), (10, 'Bacnotan'), (10, 'Bagulin'), (10, 'Balaoan'), (10, 'Bangar'), (10, 'Bauang'),
	   (10, 'Burgos'), (10, 'Caba'), (10, 'Luna'), (10, 'Naguilian'), (10, 'Pugo'), (10, 'Rosario'), (10, 'San Gabriel'), (10, 'San Juan'),
	   (10, 'Santo Tomas'), (10, 'Santol'), (10, 'Sudipen'), (10, 'Tubao')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (11, 'Alaminos'), (11, 'San Carlos'), (11, 'Urdaneta'), (11, 'Dagupan'), (11, 'Agno'), (11, 'Aguilar'), (11, 'Alcala'), (11, 'Anda'),
	   (11, 'Asingan'), (11, 'Balungao'), (11, 'Bani'), (11, 'Basista'), (11, 'Bautista'), (11, 'Bayambang'), (11, 'Binalonan'), (11, 'Binmaley'),
	   (11, 'Bolinao'), (11, 'Bugallon'), (11, 'Burgos'), (11, 'Calasiao'), (11, 'Dasol'), (11, 'Infanta'), (11, 'Labrador'), (11, 'Laoac'),
	   (11, 'Lingayen'), (11, 'Mabini'), (11, 'Malasiqui'), (11, 'Manaoag'), (11, 'Mangaldan'), (11, 'Mangatarem'), (11, 'Mapandan'), (11, 'Natividad'),
	   (11, 'Pozorrubio'), (11, 'Rosales'), (11, 'San Fabian'), (11, 'San Jacinto'), (11, 'San Manuel'), (11, 'San Nicolas'), (11, 'San Quintin'), 
	   (11, 'Santa Barbarra'), (11, 'Santa Maria'), (11, 'Santo Tomas'), (11, 'Sison'), (11, 'Sual'), (11, 'Tayug'), (11, 'Umingan'), (11, 'Urbiztondo'),
	   (11, 'Villasis')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (12, 'Basco'), (12, 'Itbayat'), (12, 'Ivana'), (12, 'Mahatao'), (12, 'Sabtang'), (12, 'Uyugan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (13, 'Tuguegarao'), (13, 'Abulug'), (13, 'Alcala'), (13, 'Allacapan'), (13, 'Amulung'), (13, 'Aparri'), (13, 'Baggao'), (13, 'Ballesteros'),
	   (13, 'Buguey'), (13, 'Calayan'), (13, 'Camalaniugan'), (13, 'Claveria'), (13, 'Enrile'), (13, 'Gattaran'), (13, 'Gonzaga'), (13, 'Iguig'),
	   (13, 'Lal-lo'), (13, 'Lasam'), (13, 'Pamplona'), (13, 'Peñablanca'), (13, 'Piat'), (13, 'Rizal'), (13, 'Sanchez-Mira'), (13, 'Santa Ana'),
	   (13, 'Santa Praxedes'), (13, 'Santa Teresita'), (13, 'Santo Niño'), (13, 'Solana'), (13, 'Tuao')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (14, 'Cauayan'), (14, 'Ilagan'), (14, 'Santiago'), (14, 'Alicia'), (14, 'Angadanan'), (14, 'Aurora'), (14, 'Benito Soliven'), (14, 'Burgos'),
	   (14, 'Cabagan'), (14, 'Cabanatuan'), (14, 'Cordon'), (14, 'Delfin Albano'), (14, 'Dinapigue'), (14, 'Divilacan'), (14, 'Echague'), (14, 'Gamu'),
	   (14, 'Jones'), (14, 'Luna'), (14, 'Maconacon'), (14, 'Mallig'), (14, 'Naguilian'), (14, 'Palanan'), (14, 'Quezon'), (14, 'Quirino'), (14, 'Ramon'),
	   (14, 'Reina Mercedes'), (14, 'Roxas'), (14, 'San Agustin'), (14, 'San Guillermo'), (14, 'San Isidro'), (14, 'San Manuel'), (14, 'San Mariano'),
	   (14, 'San Mateo'), (14, 'San Pablo'), (14, 'Santa Maria'), (14, 'Santo Tomas'), (14, 'Tumauini')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (15, 'Alfonso Castañeda'), (15, 'Ambaguio'), (15, 'Aritao'), (15, 'Bagabag'), (15, 'Bambang'), (15, 'Bayombong'), (15, 'Diadi'), (15, 'Dupax del Norte'),
	   (15, 'Dupax del Sur'), (15, 'Kasibu'), (15, 'Kayapa'), (15, 'Quezon'), (15, 'Santa Fe'), (15, 'Solano'), (15, 'Villaverde')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (16, 'Aglipay'), (16, 'Cabarroguis'), (16, 'Diffun'), (16, 'Maddela'), (16, 'Nagtipunan'), (16, 'Saguday')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (17, 'Baler'), (17, 'Casiguran'), (17, 'Dilasag'), (17, 'Dinalungan'), (17, 'Dingalan'), (17, 'Dipaculao'), (17, 'Maria Aurora'), (17, 'San Luis')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (18, 'Balanga'), (18, 'Abucay'), (18, 'Bagac'), (18, 'Dinalupihan'), (18, 'Hermosa'), (18, 'Limay'), (18, 'Mariveles'), (18, 'Morong'), (18, 'Orani'),
	   (18, 'Orion'), (18, 'Pilar'), (18, 'Samal')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (19, 'Malolos'), (19, 'Meycauayan'), (19, 'San Jose del Monte'), (19, 'Angat'), (19, 'Balagtas'), (19, 'Baliuag'), (19, 'Bocaue'), (19, 'Bulakan'),
	   (19, 'Bustos'), (19, 'Calumpit'), (19, 'Doña Remedios Trinidad'), (19, 'Guiguinto'), (19, 'Hagonoy'), (19, 'Marilao'), (19, 'Norzagaray'), (19, 'Obando'),
	   (19, 'Pandi'), (19, 'Paombong'), (19, 'Plaridel'), (19, 'Pulilan'), (19, 'San Ildefonso'), (19, 'San Miguel'), (19, 'San Rafael'), (19, 'Santa Maria')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (20, 'Cabanatuan'), (20, 'Gapan'), (20, 'Muñoz'), (20, 'Palayan'), (20, 'San Jose'), (20, 'Aliaga'), (20, 'Bongabon'), (20, 'Cabiao'), (20, 'Carranglan'),
	   (20, 'Cuyapo'), (20, 'Gabaldon'), (20, 'General Mamerto Natividad'), (20, 'General Tinio'), (20, 'Guimba'), (20, 'Jaen'), (20, 'Laur'), (20, 'Licab'),
	   (20, 'Llanera'), (20, 'Lupao'), (20, 'Nampicuan'), (20, 'Pantabangan'), (20, 'Peñaranda'), (20, 'Quezon'), (20, 'Rizal'), (20, 'San Antonio'),
	   (20, 'San Isidro'), (20, 'San Leonardo'), (20, 'Santa Rosa'), (20, 'Santo Domingo'), (20, 'Talavera'), (20, 'Talugtug'), (20, 'Zaragoza')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (21, 'Mabalacat'), (21, 'San Fernando'), (21, 'Angeles'), (21, 'Apalit'), (21, 'Arayat'), (21, 'Bacolor'), (21, 'Candaba'), (21, 'Floridablanca'),
	   (21, 'Guagua'), (21, 'Lubao'), (21, 'Macabebe'), (21, 'Magalang'), (21, 'Masantol'), (21, 'Mexico'), (21, 'Minalin'), (21, 'Porac'), (21, 'San Luis'),
	   (21, 'San Simon'), (21, 'Santa Ana'), (21, 'Santa Rita'), (21, 'Santo Tomas'), (21, 'Sasmuan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (22, 'Tarlac City'), (22, 'Anao'), (22, 'Bamban'), (22, 'Camiling'), (22, 'Capas'), (22, 'Concepcion'), (22, 'Gerona'), (22, 'La Paz'), (22, 'Mayantoc'),
	   (22, 'Moncada'), (22, 'Paniqui'), (22, 'Pura'), (22, 'Ramos'), (22, 'San Clemente'), (22, 'San Jose'), (22, 'San Manuel'), (22, 'Santa Ignacia'), (22, 'Victoria')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (23, 'Olongapo'), (23, 'Botolan'), (23, 'Cabangan'), (23, 'Candelaria'), (23, 'Castillejos'), (23, 'Iba'), (23, 'Masinloc'), (23, 'Palauig'), (23, 'San Antonio'),
	   (23, 'San Felipe'), (23, 'San Marcelino'), (23, 'San Narciso'), (23, 'Santa Cruz'), (23, 'Subic')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (24, 'Batangas City'), (24, 'Lipa'), (24, 'Tanauan'), (24, 'Agoncillo'), (24, 'Alitagtag'), (24, 'Balayan'), (24, 'Balete'), (24, 'Bauan'), (24, 'Calaca'),
	   (24, 'Calatagan'), (24, 'Cuenca'), (24, 'Ibaan'), (24, 'Laurel'), (24, 'Lemery'), (24, 'Lian'), (24, 'Lobo'), (24, 'Mabini'), (24, 'Malvar'), (24, 'Mataas na Kahoy'),
	   (24, 'Nasugbu'), (24, 'Padre Garcia'), (24, 'Rosario'), (24, 'San Jose'), (24, 'San Juan'), (24, 'San Luis'), (24, 'San Nicolas'), (24, 'San Pascual'), (24, 'Santa Teresita'),
	   (24, 'Santo Tomas'), (24, 'Taal'), (24, 'Talisay'), (24, 'Taysan'), (24, 'Tingloy'), (24, 'Tuy')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (25, 'Bacoor'), (25, 'Cavite City'), (25, 'Dasmariñas'), (25, 'General Trias'), (25, 'Imus'), (25, 'Tagaytay'), (25, 'Trece Martires'), (25, 'Alfonso'), (25, 'Amadeo'),
	   (25, 'Carmona'), (25, 'General Emilio Aguinaldo'), (25, 'General Mariano Alvarez'), (25, 'Indang'), (25, 'Kawit'), (25, 'Magallanes'), (25, 'Maragondon'), (25, 'Mendez'),
	   (25, 'Naic'), (25, 'Noveleta'), (25, 'Rosario'), (25, 'Silang'), (25, 'Tanza'), (25, 'Ternate')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (26, 'Biñan'), (26, 'Cabuyao'), (26, 'Calamba'), (26, 'San Pablo'), (26, 'San Pedro'), (26, 'Santa Rosa'), (26, 'Alaminos'), (26, 'Bay'), (26, 'Calauan'), (26, 'Cavinti'),
	   (26, 'Famy'), (26, 'Kalayaan'), (26, 'Liliw'), (26, 'Los Baños'), (26, 'Luisiana'), (26, 'Lumban'), (26, 'Mabitac'), (26, 'Magdalena'), (26, 'Majayjay'), (26, 'Nagcarlan'),
	   (26, 'Paete'), (26, 'Pagsanjan'), (26, 'Pakil'), (26, 'Pangil'), (26, 'Pila'), (26, 'Rizal'), (26, 'Santa Cruz'), (26, 'Santa Maria'), (26, 'Siniloan'), (26, 'Victoria')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (27, 'Tayabas'), (27, 'Lucena'), (27, 'Agdangan'), (27, 'Alabat'), (27, 'Atimonan'), (27, 'Buenavista'), (27, 'Burdeos'), (27, 'Calauag'), (27, 'Candelaria'), (27, 'Catanauan'),
	   (27, 'Dolores'), (27, 'General Luna'), (27, 'General Nakar'), (27, 'Guinayangan'), (27, 'Gumaca'), (27, 'Infanta'), (27, 'Jomalig'), (27, 'Lopez'), (27, 'Lucban'), (27, 'Macalelon'),
	   (27, 'Mauban'), (27, 'Mulanay'), (27, 'Padre Burgos'), (27, 'Pagbilao'), (27, 'Panukulan'), (27, 'Patnanungan'), (27, 'Perez'), (27, 'Pitogo'), (27, 'Plaridel'), (27, 'Polillo'),
	   (27, 'Quezon'), (27, 'Real'), (27, 'Sampaloc'), (27, 'San Andres'), (27, 'San Antonio'), (27, 'San Francisco'), (27, 'San Narciso'), (27, 'Sariaya'), (27, 'Tagkawayan'), (27, 'Tiaong'),
	   (27, 'Unisan'), (27, 'Aglipay'), (27, 'Cabarroguis'), (27, 'Diffun'), (27, 'Maddela'), (27, 'Nagtipunan'), (27, 'Saguday') 
INSERT INTO tblCity (intProvinceID, strCity) 
VALUES (28, 'Antipolo'), (28, 'Angono'), (28, 'Baras'), (28, 'Binangonan'), (28, 'Cainta'), (28, 'Cardona'), (28, 'Jalajala'), (28, 'Morong'), (28, 'Pililla'), (28, 'Rodriguez'), (28, 'San Mateo'),
	   (28, 'Tanay'), (28, 'Taytay'), (28, 'Teresa')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (29, 'Boac'), (29, 'Buenavista'), (29, 'Gasan'), (29, 'Mogpog'), (29, 'Santa Cruz'), (29, 'Torrijos')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (30, 'Abra de Ilog'), (30, 'Calintaan'), (30, 'Looc'), (30, 'Lubang'), (30, 'Magsaysay'), (30, 'Mamburao'), (30, 'Paluan'), (30, 'Rizal'), (30, 'Sablayan'), (30, 'San Jose'), (30, 'Santa Cruz')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (31, 'Calapan'), (31, 'Baco'), (31, 'Bamgsud'), (31, 'Bongabong'), (31, 'Bulalacao'), (31, 'Gloria'), (31, 'Mansalay'), (31, 'Naujan'), (31, 'Pinamalayan'), (31, 'Pola'), (31, 'Puerto Galera'),
	   (31, 'Roxas'), (31, 'San Teodoro'), (31, 'Socorro'), (31, 'Victoria')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (32, 'Puerto Princesa'), (32, 'Aborlan'), (32, 'Agutaya'), (32, 'Araceli'), (32, 'Balabac'), (32, 'Bataraza'), (32, 'Brooke''s Point'), (32, 'Busuanga'), (32, 'Cagayancillo'), (32, 'Coron'),
	   (32, 'Culion'), (32, 'Cuyo'), (32, 'Dumaran'), (32, 'El Nido'), (32, 'Kalayaan'), (32, 'Linapacan'), (32, 'Magsaysay'), (32, 'Narra'), (32, 'Quezon'), (32, 'Rizal'), (32, 'Roxas'), (32, 'San Vicente'),
	   (32, 'Sofronio Española'), (32, 'Taytay')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (33, 'Alcantara'), (33, 'Banton'), (33, 'Cajidiocan'), (33, 'Calatrava'), (33, 'Concepcion'), (33, 'Corcuera'), (33, 'Ferrol'), (33, 'Looc'), (33, 'Magdiwang'), (33, 'Odiongan'), (33, 'Romblon'),
	   (33, 'San Agustin'), (33, 'San Andres'), (33, 'San Fernando'), (33, 'San Jose'), (33, 'Santa Fe'), (33, 'Santa Maria')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (34, 'Legazpi'), (34, 'Ligao'), (34, 'Tabaco'), (34, 'Bacacay'), (34, 'Camalig'), (34, 'Daraga'), (34, 'Guinobatan'), (34, 'Jovellar'), (34, 'Libon'), (34, 'Malilipot'), (34, 'Malinao'), (34, 'Manito'),
	   (34, 'Oas'), (34, 'Pio Duran'), (34, 'Polangui'), (34, 'Rapu-rapu'), (34, 'Santo Domingo'), (34, 'Tiwi')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (35, 'Basud'), (35, 'Capalonga'), (35, 'Daet'), (35, 'Jose Panganiban'), (35, 'Labo'), (35, 'Mercedes'), (35, 'Paracale'), (35, 'San Lorenzo Luis'), (35, 'San Vicente'), (35, 'Santa Elena'), (35, 'Talisay'),
	   (35, 'Vinzons')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (36, 'Iriga'), (36, 'Naga'), (36, 'Baao'), (36, 'Balatan'), (36, 'Bato'), (36, 'Bombon'), (36, 'Buhi'), (36, 'Bula'), (36, 'Cabusao'), (36, 'Calabanga'), (36, 'Camaligan'), (36, 'Canaman'), (36, 'Caramoan'),
	   (36, 'Del Gallego'), (36, 'Gainza'), (36, 'Garchitorena'), (36, 'Goa'), (36, 'Lagonoy'), (36, 'Libmanan'), (36, 'Lupi'), (36, 'Magarao'), (36, 'Milaor'), (36, 'Minalabac'), (36, 'Nabua'), (36, 'Ocampo'),
	   (36, 'Pamplona'), (36, 'Pasacao'), (36, 'Pili'), (36, 'Presentacion'), (36, 'Ragay'), (36, 'Sagñay'), (36, 'San Fernando'), (36, 'San Jose'), (36, 'Sipocot'), (36, 'Siruma'), (36, 'Tigaon'), (36, 'Tinambac')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (37, 'Bagamanoc'), (37, 'Baras'), (37, 'Bato'), (37, 'Caramoran'), (37, 'Gigmoto'), (37, 'Pandan'), (37, 'Panganiban'), (37, 'San Andres'), (37, 'San Miguel'), (37, 'Viga'), (37, 'Virac')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (38, 'Masbate City'), (38, 'Aroroy'), (38, 'Baleno'), (38, 'Balud'), (38, 'Batuan'), (38, 'Cataingan'), (38, 'Cawayan'), (38, 'Claveria'), (38, 'Dimasalang'), (38, 'Esperanza'), (38, 'Mandaon'), (38, 'Milagros'),
	   (38, 'Mobo'), (38, 'Monreal'), (38, 'Palanas'), (38, 'Pio V. Corpuz'), (38, 'Placer'), (38, 'San Fernando'), (38, 'San Jacinto'), (38, 'San Pascual'), (38, 'Uson')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (39, 'Sorsogon City'), (39, 'Barcelona'), (39, 'Bulan'), (39, 'Bulusan'), (39, 'Casiguran'), (39, 'Castilla'), (39, 'Donsol'), (39, 'Gubat'), (39, 'Irosin'), (39, 'Juban'), (39, 'Magallanes'), (39, 'Matnog'),
	   (39, 'Pilar'), (39, 'Prieto Diaz'), (39, 'Santa Magdalena')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (40, 'Altavas'), (40, 'Balete'), (40, 'Banga'), (40, 'Batan'), (40, 'Buruanga'), (40, 'Ibajay'), (40, 'Kalibo'), (40, 'Lezo'), (40, 'Libacao'), (40, 'Madalag'), (40, 'Makato'), (40, 'Malay'), (40, 'Malinao'),
	   (40, 'Nabas'), (40, 'New Washington'), (40, 'Numancia'), (40, 'Tangalan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (41, 'Anini-y'), (41, 'Barbaza'), (41, 'Belison'), (41, 'Bugasong'), (41, 'Caluya'), (41, 'Culasi'), (41, 'Hamtic'), (41, 'Laua-an'), (41, 'Libertad'), (41, 'Pandan'), (41, 'Patnongon'), (41, 'San Jose de Buenavista'),
	   (41, 'San Remigio'), (41, 'Sebaste'), (41, 'Sibalom'), (41, 'Tibiao'), (41, 'Tobias Fornier'), (41, 'Valderrama')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (42, 'Roxas City'), (42, 'Cuartero'), (42, 'Dao'), (42, 'Dumalag'), (42, 'Dumarao'), (42, 'Ivisan'), (42, 'Jamindan'), (42, 'Maayon'), (42, 'Mambusao'), (42, 'Panay'), (42, 'Panitan'), (42, 'Pilar'), (42, 'Pontevedra'),
	   (42, 'President Roxas'), (42, 'Sapian'), (42, 'Sigma'), (42, 'Tapaz')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (43, 'Buenavista'), (43, 'Jordan'), (43, 'Nueva Valencia'), (43, 'San Lorenzo'), (43, 'Sibunag')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (44, 'Bago'), (44, 'Cadiz'), (44, 'Escalante'), (44, 'Himamaylan'), (44, 'Kabankalan'), (44, 'La Carlota'), (44, 'Sagay'), (44, 'San Carlos'), (44, 'Silay'), (44, 'Sipalay'), (44, 'Talisay'), (44, 'Victorias'), (44, 'Bacolod'),
	   (44, 'Binalbagan'), (44, 'Calatrava'), (44, 'Candoni'), (44, 'Cauayan'), (44, 'Enrique B. Magalona'), (44, 'Hinigaran'), (44, 'Hinoba-an'), (44, 'Ilog'), (44, 'Isabela'), (44, 'La Castellana'), (44, 'Manapla'), (44, 'Moises Padilla'),
	   (44, 'Murcia'), (44, 'Pontevedra'), (44, 'Pulupandan'), (44, 'Salvador Benedicto'), (44, 'San Enrique'), (44, 'Toboso'), (44, 'Valladolid')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (45, 'Passi'), (45, 'Iloilo City'), (45, 'Ajuy'), (45, 'Alimodian'), (45, 'Anilao'), (45, 'Badiangan'), (45, 'Balasan'), (45, 'Banate'), (45, 'Barotac Nuevo'), (45, 'Barotac Viejo'), (45, 'Batad'), (45, 'Bingawan'), (45, 'Cabatuan'),
	   (45, 'Calinog'), (45, 'Carles'), (45, 'Concepcion'), (45, 'Dingle'), (45, 'Dueñas'), (45, 'Dumangas'), (45, 'Estancia'), (45, 'Guimbal'), (45, 'Igbaras'), (45, 'Janiuay'), (45, 'Lambunao'), (45, 'Leganes'), (45, 'Lemery'),
	   (45, 'Leon'), (45, 'Maasin'), (45, 'Miagao'), (45, 'Mina'), (45, 'New Lucena'), (45, 'Oton'), (45, 'Pavia'), (45, 'Pototan'), (45, 'San Dionisio'), (45, 'San Enrique'), (45, 'San Joaquin'), (45, 'San Miguel'), (45, 'San Rafael'),
	   (45, 'Santa Barbara'), (45, 'Sara'), (45, 'Tigbauan'), (45, 'Tubungan'), (45, 'Zarraga')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (46, 'Tagbilaran'), (46, 'Alburquerque'), (46, 'Alicia'), (46, 'Anda'), (46, 'Antequera'), (46, 'Baclayon'), (46, 'Balilihan'), (46, 'Batuan'), (46, 'Bien Unido'), (46, 'Bilar'), (46, 'Buenavista'), (46, 'Calape'), (46, 'Candijay'),
	   (46, 'Carmen'), (46, 'Catigbian'), (46, 'Clarin'), (46, 'Corella'), (46, 'Cortes'), (46, 'Dagohoy'), (46, 'Danao'), (46, 'Dauis'), (46, 'Dimiao'), (46, 'Duero'), (46, 'Garcia Hernandez'), (46, 'Getafe'), (46, 'Guindulman'),
	   (46, 'Inabanga'), (46, 'Jagna'), (46, 'Lila'), (46, 'Loay'), (46, 'Loboc'), (46, 'Loon'), (46, 'Mabini'), (46, 'Maribojoc'), (46, 'Panglao'), (46, 'Pilar'), (46, 'President Carlos P. Garcia'), (46, 'Sagbayan'), (46, 'San Isidro'),
	   (46, 'San Miguel'), (46, 'Sevilla'), (46, 'Sierra Bullones'), (46, 'Sikatuna'), (46, 'Talibon'), (46, 'Trinidad'), (46, 'Tubigon'), (46, 'Ubay'), (46, 'Valencia')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (47, 'Bogo'), (47, 'Carcar'), (47, 'Danao'), (47, 'Naga'), (47, 'Talisay'), (47, 'Toledo'), (47, 'Cebu City'), (47, 'Lapu-lapu'), (47, 'Mandaue'), (47, 'Alcantara'), (47, 'Alcoy'), (47, 'Alegria'), (47, 'Aloguinsan'), (47, 'Argao'),
	   (47, 'Asturias'), (47, 'Badian'), (47, 'Balamban'), (47, 'Bantayan'), (47, 'Barili'), (47, 'Boljoon'), (47, 'Borbon'), (47, 'Carmen'), (47, 'Catmon'), (47, 'Compostela'), (47, 'Consolacion'), (47, 'Cordova'), (47, 'Daanbantayan'),
	   (47, 'Dalaguete'), (47, 'Dumanjug'), (47, 'Ginatilan'), (47, 'Liloan'), (47, 'Madridejos'), (47, 'Malabuyoc'), (47, 'Medellin'), (47, 'Minglanilla'), (47, 'Moalboal'), (47, 'Oslob'), (47, 'Pilar'), (47, 'Pinamungajan'), (47, 'Poro'),
	   (47, 'Ronda'), (47, 'Samboan'), (47, 'San Fernando'), (47, 'San Francisco'), (47, 'San Remigio'), (47, 'Santa Fe'), (47, 'Santander'), (47, 'Sibonga'), (47, 'Sogod'), (47, 'Tabogon'), (47, 'Tabuelan'), (47, 'Tuburan'), (47, 'Tudela')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (48, 'Bais'), (48, 'Bayawan'), (48, 'Canlaon'), (48, 'Dumaguete'), (48, 'Guihulngan'), (48, 'Tanjay'), (48, 'Amlan'), (48, 'Ayungon'), (48, 'Bacong'), (48, 'Basay'), (48, 'Bindoy'), (48, 'Dauin'), (48, 'Jimalalud'), (48, 'La Libertad'),
	   (48, 'Mabinay'), (48, 'Manjuyod'), (48, 'Pamplona'), (48, 'San Jose'), (48, 'Santa Catalina'), (48, 'Siaton'), (48, 'Sibulan'), (48, 'Tayasan'), (48, 'Valencia'), (48, 'Vallehermoso'), (48, 'Zamboanguita')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (49, 'Enrique Villanueva'), (49, 'Larena'), (49, 'Lazi'), (49, 'Maria'), (49, 'San Juan'), (49, 'Siquijor')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (50, 'Almeria'), (50, 'Biliran'), (50, 'Cabucgayan'), (50, 'Caibiran'), (50, 'Culaba'), (50, 'Kawayan'), (50, 'Maripipi'), (50, 'Naval')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (51, 'Borongan'), (51, 'Arteche'), (51, 'Balangiga'), (51, 'Balangkayan'), (51, 'Can-avid'), (51, 'Dolores'), (51, 'General MacArthur'), (51, 'Giporlos'), (51, 'Guiuan'), (51, 'Hernani'), (51, 'Jipapad'), (51, 'Lawaan'), (51, 'Llorente'),
	   (51, 'Maslog'), (51, 'Maydolong'), (51, 'Mercedes'), (51, 'Oras'), (51, 'Quinapondan'), (51, 'Salcedo'), (51, 'San Julian'), (51, 'San Policarpo'), (51, 'Sulat'), (51, 'Taft')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (52, 'Baybay'), (52, 'Tacloban'), (52, 'Ormoc'), (52, 'Abuyog'), (52, 'Alangalang'), (52, 'Albuera'), (52, 'Babatngon'), (52, 'Barugo'), (52, 'Bato'), (52, 'Burauen'), (52, 'Calubian'), (52, 'Capoocan'), (52, 'Carigara'), (52, 'Dagami'),
	   (52, 'Dulag'), (52, 'Hilongos'), (52, 'Hindang'), (52, 'Inopacan'), (52, 'Isabel'), (52, 'Jaro'), (52, 'Javier'), (52, 'Julita'), (52, 'Kananga'), (52, 'La Paz'), (52, 'Leyte'), (52, 'MacArthur'), (52, 'Mahaplag'), (52, 'Matag-ob'),
	   (52, 'Matalom'), (52, 'Mayorga'), (52, 'Merida'), (52, 'Palo'), (52, 'Palompon'), (52, 'Pastrana'), (52, 'San Isidro'), (52, 'San Miguel'), (52, 'Santa Fe'), (52, 'Tabango'), (52, 'Tabontabon'), (52, 'Tanauan'), (52, 'Tolosa'),
	   (52, 'Tunga'), (52, 'Villaba')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (53, 'Allen'), (53, 'Biri'), (53, 'Bobon'), (53, 'Capul'), (53, 'Catarman'), (53, 'Catubig'), (53, 'Gamay'), (53, 'Laoang'), (53, 'Lapinig'), (53, 'Las Navas'), (53, 'Lavezares'), (53, 'Lope de Vega'), (53, 'Mapanas'), (53, 'Mondragon'),
	   (53, 'Palapag'), (53, 'Pambujan'), (53, 'Rosario'), (53, 'San Antonio'), (53, 'San Isidro'), (53, 'San Jose'), (53, 'San Roque'), (53, 'San Vicente'), (53, 'Silvino Lobos'), (53, 'Victoria')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (54, 'Maasin'), (54, 'Anahawan'), (54, 'Bontoc'), (54, 'Hinunangan'), (54, 'Hinundayan'), (54, 'Libagon'), (54, 'Liloan'), (54, 'Limasawa'), (54, 'Macrohon'), (54, 'Malitbog'), (54, 'Padre Burgos'), (54, 'Pintuyan'), (54, 'Saint Bernard'),
	   (54, 'San Francisco'), (54, 'San Juan'), (54, 'San Ricardo'), (54, 'Silago'), (54, 'Sogod'), (54, 'Tomas Oppus')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (55, 'Dapitan'), (55, 'Dipolog'), (55, 'Baliguian'), (55, 'Godod'), (55, 'Gutalac'), (55, 'Jose Dalman'), (55, 'Kalawit'), (55,' Katipunan'), (55, 'La Libertad'), (55, 'Labason'), (55, 'Leon B. Postigo'), (55, 'Liloy'), (55, 'Manukan'),
	   (55, 'Mutia'), (55, 'Piñan'), (55, 'Polanco'), (55, 'President Manuel A. Roxas'), (55, 'Rizal'), (55, 'Salug'), (55, 'Sergio Osmeña Sr'), (55, 'Siayan'), (55, 'Sibuco'), (55, 'Sibutad'), (55, 'Sindangan'), (55, 'Siocon'), (55, 'Sirawai'), (55, 'Tampilisan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (56, 'Pagadian'), (56, 'Zamboanga City'), (56, 'Aurora'), (56, 'Bayog'), (56, 'Dimataling'), (56, 'Dinas'), (56, 'Dumalinao'), (56, 'Dumingag'), (56, 'Guipos'), (56, 'Josefina'), (56, 'Kumalarang'), (56, 'Labangan'), (56, 'Lakewood'), (56, 'Lapuyan'),
	   (56, 'Mahayag'), (56, 'Margosatubig'), (56, 'Midsalip'), (56, 'Molave'), (56, 'Pitogo'), (56, 'Ramon Magsaysay'), (56, 'San Miguel'), (56, 'San Pablo'), (56, 'Sominot'), (56, 'Tabina'), (56, 'Tambulig'), (56, 'Tigbao'), (56, 'Tukuran'), (56, 'Vincenzo A. Sagun')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (57, 'Alicia'), (57, 'Buug'), (57, 'Diplahan'), (57, 'Imelda'), (57, 'Ipil'), (57, 'Kabasalan'), (57, 'Mabuhay'), (57, 'Malangas'), (57, 'Naga'), (57, 'Olutanga'), (57, 'Payao'), (57, 'Roseller Lim'), (57, 'Siay'), (57, 'Talusan'), (57, 'Titay'), (57, 'Tungawan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (58, 'Malaybalay'), (58, 'Valencia'), (58, 'Baungon'), (58, 'Cabanglasan'), (58, 'Damulog'), (58, 'Dangcagan'), (58, 'Don Carlos'), (58, 'Impasugong'), (58, 'Kadingilan'), (58, 'Kalilangan'), (58, 'Kibawe'), (58, 'Kitaotao'), (58, 'Lantapan'), (58, 'Libona'),
	   (58, 'Malitbog'), (58, 'Manolo Fortich'), (58, 'Maramag'), (58, 'Pangantucan'), (58, 'Quezon'), (58, 'San Fernando'), (58, 'Sumilao'), (58, 'Talakag')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (59, 'Catarman'), (59, 'Guinsiliban'), (59, 'Mahinog'), (59, 'Mambajao'), (59, 'Sagay')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (60, 'Iligan'), (60, 'Bacolod'), (60, 'Baloi'), (60, 'Baroy'), (60, 'Kapatagan'), (60, 'Kauswagan'), (60, 'Kolambugan'), (60, 'Lala'), (60, 'Linamon'), (60, 'Magsaysay'), (60, 'Maigo'), (60, 'Matungao'), (60, 'Munai'), (60, 'Nunungan'), (60, 'Pantao Ragat'),
	   (60, 'Pantar'), (60, 'Poona Piagapo'), (60, 'Salvador'), (60, 'Sapad'), (60, 'Sultan Naga Dimaporo'), (60, 'Tagoloan'), (60, 'Tangcal'), (60, 'Tubod')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (61, 'Oroquieta'), (61, 'Ozamiz'), (61, 'Tangub'), (61, 'Aloran'), (61, 'Baliangao'), (61, 'Bonifacio'), (61, 'Calamba'), (61, 'Clarin'), (61, 'Concepcion'), (61, 'Don Victoriano Chiongbian'), (61, 'Jimenez'), (61, 'Lopez Jaena'), (61, 'Panaon'), (61, 'Plaridel'),
	   (61, 'Sapang Dalaga'), (61, 'Sinacaban'), (61, 'Tudela')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (62, 'El Salvador'), (62, 'Gingoog'), (62, 'Cagayan de Oro'), (62, 'Alubijid'), (62, 'Balingasag'), (62, 'Balingoan'), (62, 'Binuangan'), (62, 'Claveria'), (62, 'Gitagum'), (62, 'Initao'), (62, 'Jasaan'), (62, 'Kinoguitan'), (62, 'Lagonglong'), (62, 'Laguindingan'),
	   (62, 'Libertad'), (62, 'Lugait'), (62, 'Magsaysay'), (62, 'Manticao'), (62, 'Medina'), (62, 'Naawan'), (62, 'Opol'), (62, 'Salay'), (62, 'Sugbongcogon'), (62, 'Tagoloan'), (62, 'Talisayan'), (62, 'Villanueva')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (63, 'Compostela'), (63, 'Laak'), (63, 'Mabini'), (63, 'Maco'), (63, 'Maragusan'), (63, 'Mawab'), (63, 'Monkayo'), (63, 'Montevista'), (63, 'Nabunturan'), (63, 'New Bataan'), (63, 'Pantukan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (64, 'Panabo'), (64, 'Samal'), (64, 'Tagum'), (64, 'Asuncion'), (64, 'Braulio E. Dujali'), (64, 'Carmen'), (64, 'Kapalong'), (64, 'New Corella'), (64, 'San Isidro'), (64, 'Santo Tomas'), (64, 'Talaingod')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (65, 'Digos'), (65, 'Davao City'), (65, 'Bansalan'), (65, 'Hagonoy'), (65, 'Kiblawan'), (65, 'Magsaysay'), (65, 'Malalag'), (65, 'Matanao'), (65, 'Padada'), (65, 'Santa Cruz'), (65, 'Sulop')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (66, 'Don Marcelino'), (66, 'Jose Abad Santos'), (66, 'Malita'), (66, 'Santa Maria'), (66, 'Sarangani')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (67, 'Mati'), (67, 'Baganga'), (67, 'Banaybanay'), (67, 'Boston'), (67, 'Caraga'), (67, 'Cateel'), (67, 'Governor Generoso'), (67, 'Lupon'), (67, 'Manay'), (67, 'San Isidro'), (67, 'Tarragona')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (68, 'Kidapawan'), (68, 'Alamada'), (68, 'Aleosan'), (68, 'Antipas'), (68, 'Arakan'), (68, 'Banisilan'), (68, 'Carmen'), (68, 'Kabacan'), (68, 'Libungan'), (68, 'M''lang'), (68, 'Magpet'),
	   (68, 'Makilala'), (68, 'Matalam'), (68, 'Midsayap'), (68, 'Pigcawayan'), (68, 'Pikit'), (68, 'President Roxas'), (68, 'Tulunan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (69, 'Alabel'), (69, 'Glan'), (69, 'Kiamba'), (69, 'Maasim'), (69, 'Maitum'), (69, 'Malapatan'), (69, 'Malungon')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (70, 'Koronadal'), (70, 'General Santos'), (70, 'Banga'), (70, 'Lake Sebu'), (70, 'Norala'), (70, 'Polomolok'), (70, 'Santo Niño'), (70, 'Surallah'), (70, 'T''Boli'), (70, 'Tampakan'), (70, 'Tantangan'), (70, 'Tupi')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (71, 'Tacurong'), (71, 'Bagumbayan'), (71, 'Columbio'), (71, 'Esperanza'), (71, 'Isulan'), (71, 'Kalamansig'), (71, 'Lambayong'), (71, 'Lebak'), (71, 'Lutayan'), (71, 'Palimbang'), (71, 'President Quirino'), (71, 'Senator Ninoy Aquino')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (72, 'Cabadbaran'), (72, 'Butuan'), (72, 'Buenavista'), (72, 'Carmen'), (72, 'Jabonga'), (72, 'Kitcharao'), (72, 'Las Nieves'), (72, 'Magallanes'), (72, 'Nasipit'), (72, 'Remedios T. Romualdez'), (72, 'Santiago'), (72, 'Tubay')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (73, 'Bayugan'), (73, 'Bunawan'), (73, 'Esperanza'), (73, 'La Paz'), (73, 'Loreto'), (73, 'Prosperidad'), (73, 'Rosario'), (73, 'San Francisco'), (73, 'San Luis'), (73, 'Santa Josefa'), (73, 'Sibagat'),
	   (73, 'Talacogon'), (73, 'Trento'), (73, 'Veruela')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (74, 'Basilisa'), (74, 'Cagdianao'), (74, 'Dinagat'), (74, 'Libio'), (74, 'Loreto'), (74, 'San Jose'), (74, 'Tubajon')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (75, 'Surigao City'), (75, 'Alegria'), (75, 'Bacuag'), (75, 'Burgos'), (75, 'Claver'), (75, 'Dapa'), (75, 'Del Carmen'), (75, 'General Luna'), (75, 'Gigaquit'), (75, 'Mainit'), (75, 'Malimono'), (75, 'Pilar'), (75, 'Placer'), (75, 'San Benito'),
	   (75, 'San Francisco'), (75, 'San Isidro'), (75, 'Santa Monica'), (75, 'Sison'), (75, 'Socorro'), (75, 'Tagana-an'), (75, 'Tubod')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (76, 'Bislig'), (76, 'Tandag'), (76, 'Barobo'), (76, 'Bayabas'), (76, 'Cagwait'), (76, 'Cantilan'), (76, 'Carmen'), (76, 'Carrascal'), (76, 'Cortes'), (76, 'Hinatuan'), (76, 'Lanuza'), (76, 'Lianga'), (76, 'Lingig'), (76, 'Madrid'),
	   (76, 'Marihatag'), (76, 'San Agustin'), (76, 'San Miguel'), (76, 'Tagbina'), (76, 'Tago')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (77, 'Isabela City'), (77, 'Lamitan'), (77, 'Akbar'), (77, 'Al-Barka'), (77, 'Hadji Mohammad Ajul'), (77, 'Hadji Muhtamad'), (77, 'Lantawan'), (77, 'Maluso'), (77, 'Sumisip'), (77, 'Tabuan-Lasa'), (77, 'Tipo-Tipo'), (77, 'Tuburan'), (77, 'Ungkaya Pukan')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (78, 'Marawi'), (78, 'Amai Manabilang'), (78, 'Bacolod-Kalawi'), (78, 'Balabagan'), (78, 'Balindong'), (78, 'Bayang'), (78, 'Binidayan'), (78, 'Buadiposo-Buntong'), (78, 'Bubong'), (78, 'Butig'), (78, 'Calanogas'), (78, 'Ditsaan-Ramain'), (78, 'Ganassi'),
       (78, 'Kapai'), (78, 'Kapatagan'), (78, 'Lumba-Bayabao'), (78, 'Lumbaca-Unayan'), (78, 'Lumbatan'), (78, 'Lumbayanague'), (78, 'Madalum'), (78, 'Madamba'), (78, 'Maguing'), (78, 'Malabang'), (78, 'Marantao'), (78, 'Marogong'), (78, 'Masiu'), (78, 'Mulondo'),
	   (78, 'Pagayawan'), (78, 'Piagapo'), (78, 'Picong'), (78, 'Poona Bayabao'), (78, 'Pualas'), (78, 'Saguiaran'), (78, 'Sultan Dumalondong'), (78, 'Tagoloan II'), (78, 'Tamparan'), (78, 'Taraka'), (78, 'Tubaran'), (78, 'Tugaya'), (78, 'Wao')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (79, 'Cotabato City'), (79, 'Ampatuan'), (79, 'Barira'), (79, 'Buldon'), (79, 'Buluan'), (79, 'Datu Abdullah Sangki'), (79, 'Datu Anggal Midtimbang'), (79, 'Datu Blah T. Sinsuat'), (79, 'Datu Hoffer Ampatuan'), (79, 'Datu Montawal'), (79, 'Datu Odin Sinsuat'),
	   (79, 'Datu Paglas'), (79, 'Datu Piang'), (79, 'Datu Salibo'), (79, 'Datu Saudi-Ampatuan'), (79, 'Datu Unsay'), (79, 'General Salipada K. Pendatun'), (79, 'Guindulungan'), (79, 'Kabuntalan'), (79, 'Mamasapano'), (79, 'Mangudadatu'), (79, 'Matanog'), (79, 'Northern Kabuntalan'),
	   (79, 'Pagalungan'), (79, 'Paglat'), (79, 'Pandag'), (79, 'Parang'), (79, 'Rajah Buayan'), (79, 'Shariff Aguak'), (79, 'Shariff Saydona Mustapha'), (79, 'South Upi'), (79, 'Sultan Kudarat'), (79, 'Sultan Mastura'), (79, 'Sultan na Barongis'), (79, 'Sultan Sumagka'), (79, 'Talayan'), (79, 'Upi')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (80, 'Banguingui'), (80, 'Hadji Panglima Tahi'), (80, 'Indanan'), (80, 'Jolo'), (80, 'Kalingalan Caluang'), (80, 'Lugus'), (80, 'Luuk'), (80, 'Maimbung'), (80, 'Old Panamao'), (80, 'Omar'), (80, 'Pandami'), (80, 'Panglima Estino'), (80, 'Pangutaran'), (80, 'Parang'), (80, 'Pata'),
	   (80, 'Patikul'), (80, 'Siasi'), (80, 'Talipao'), (80, 'Tapul')
INSERT INTO tblCity (intProvinceID, strCity)
VALUES (81, 'Bongao'), (81, 'Languyan'), (81, 'Mapun'), (81, 'Panglima Sugala'), (81, 'Sapa-sapa'), (81, 'Sibutu'), (81, 'Simunul'), (81, 'Sitangkai'), (81, 'South Ubian'), (81, 'Tandubas'), (81, 'Turtle Islands')


-- Others
INSERT INTO tblAccessionFormat (strInstitutionCode, strAccessionFormat, strYearFormat) VALUES ('PUPH', '0000#', '0#')

-------------- END OF FILE --------------
