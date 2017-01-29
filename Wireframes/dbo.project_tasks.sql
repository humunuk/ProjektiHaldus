CREATE TABLE [dbo].[project_tasks]
(
	[project_task_id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [project_id] INT NOT NULL,
	[name] VARCHAR(MAX) NOT NULL,
    [description] VARCHAR(MAX) NOT NULL, 
    [worker_name] VARCHAR(MAX) NOT NULL, 
    [start_date_time] DATETIME NOT NULL, 
    [end_date_time] DATETIME NOT NULL, 
    [time_spent] TIME NOT NULL
	CONSTRAINT [FK_project_tasks_projects] FOREIGN KEY (project_id) REFERENCES [projects]([project_id])
)
