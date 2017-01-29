CREATE TABLE [dbo].[projects]
(
	[project_id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [name] VARCHAR(MAX) NOT NULL, 
    [description] VARCHAR(MAX) NOT NULL, 
    [manager_name] VARCHAR(MAX) NOT NULL, 
    [created_at] DATETIME NOT NULL
)
