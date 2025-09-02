/********************* ROLES **********************/

CREATE ROLE RDB$ADMIN;
/********************* UDFS ***********************/

/****************** GENERATORS ********************/

/******************** DOMAINS *********************/

CREATE DOMAIN SEC$KEY
 AS Varchar(63)
 NOT NULL
 COLLATE UTF8;
CREATE DOMAIN SEC$NAME_PART
 AS Varchar(32)
 NOT NULL
 COLLATE UTF8;
CREATE DOMAIN SEC$USER_NAME
 AS Varchar(63)
 NOT NULL
 COLLATE UTF8;
CREATE DOMAIN SEC$VALUE
 AS Varchar(255)
 NOT NULL
 COLLATE UTF8;
/******************* PROCEDURES ******************/

/******************** TABLES **********************/

CREATE TABLE TASKS
(
  TASKID Integer NOT NULL,
  TITLE Varchar(255) NOT NULL,
  DESCRIPTION Varchar(1000),
  STATUS Varchar(50),
  CREATEDBY Varchar(100),
  ASSIGNEDTO Varchar(100),
  CREATEDAT Timestamp DEFAULT CURRENT_TIMESTAMP,
  UPDATEDAT Timestamp,
  PRIMARY KEY (TASKID)
);
CREATE TABLE "Tasks"
(
  "Id" Char(16) CHARACTER SET OCTETS NOT NULL,
  "Title" Blob sub_type 1 NOT NULL,
  "Description" Varchar(1000),
  "Status" Blob sub_type 1 NOT NULL,
  "CreateBy" Blob sub_type 1 NOT NULL,
  "AssignedTo" Blob sub_type 1,
  "CreateDate" Timestamp DEFAULT CURRENT_TIMESTAMP NOT NULL,
  "UpdateDate" Timestamp NOT NULL,
  CONSTRAINT "PK_Tasks" PRIMARY KEY ("Id")
);
CREATE TABLE "__EFMigrationsHistory"
(
  "MigrationId" Varchar(150) NOT NULL,
  "ProductVersion" Varchar(32) NOT NULL,
  CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);
/********************* VIEWS **********************/

/******************* EXCEPTIONS *******************/

/******************** TRIGGERS ********************/


ALTER TABLE TASKS ADD 
  CHECK (Status IN ('To Do', 'In Progress', 'Done'));
GRANT RDB$ADMIN TO SYSDBA WITH ADMIN OPTION;
GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON TASKS TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON "Tasks" TO  SYSDBA WITH GRANT OPTION;

GRANT DELETE, INSERT, REFERENCES, SELECT, UPDATE
 ON "__EFMigrationsHistory" TO  SYSDBA WITH GRANT OPTION;

