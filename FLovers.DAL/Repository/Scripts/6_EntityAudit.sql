use FLovers;
go

/* This script is to capture database changes (Database Audit) but has the advantage */
/* of storing more information about the author (other than triggers or SQLAudit) */
create table AuditEvents(
	Id int primary key identity(1,1) not null,
	EventType varchar(200),
	DatabaseName varchar(100),
	TableName varchar(200),
	PrimaryKey int,
	CrudAction varchar(100),
	StartDate DateTime,
	EndDate DateTime,
	Duration int,
	IdChangedBy int,
	Username varchar(50),
	IdBranch int,
	BranchName varchar(200),
	IpAddress varchar(50),
	ObjectAfterChanges varchar(max),
	IsValid bit,
	ValidationResults varchar(max),
	CrudResult int,
	IsSuccess bit, 
	UserAgent varchar(200),
	Browser varchar(200),
	BrowserVersion varchar(200),
	Environment varchar(max)
)
go

create table EntityAuditEvents(
	Id int primary key identity(1,1) not null,
	IdAuditEvent int,
	ColumnName varchar(200),
	OriginalValue varchar(max),
	NewValue varchar(max)
)
go

ALTER TABLE [dbo].EntityAuditEvents  WITH CHECK ADD  CONSTRAINT [FK_AuditEvents_EntityAuditEvents] FOREIGN KEY(IdAuditEvent)
REFERENCES [dbo].AuditEvents (Id)  NOT FOR REPLICATION
GO

create table CustomAuditEvents(
	Id int primary key identity(1,1) not null,
	IdAuditEvent int,
)
go

ALTER TABLE [dbo].CustomAuditEvents  WITH CHECK ADD  CONSTRAINT [FK_AuditEvents_CustomAuditEvents] FOREIGN KEY(IdAuditEvent)
REFERENCES [dbo].AuditEvents (Id)  NOT FOR REPLICATION
GO