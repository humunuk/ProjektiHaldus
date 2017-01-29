using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektiHaldus.Domain;

namespace ProjektiHaldus.BusinessObjects
{
    public class ProjectBo
    {
        private readonly TimeSpan _totalTimeSpent;
        public string Name { get; set; }
        public string Description { get; set; }
        public string ManagerName { get; set; }
        public System.DateTime CreatedAt { get; set; }

        public int ProjectId { get; }

        public TimeSpan TotalTimeSpent => _totalTimeSpent;

        public ObservableCollection<ProjectTaskBo> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        private ObservableCollection<ProjectTaskBo> _tasks;

        public ProjectBo(project project)
        {
            if (project != null)
            {
                ProjectId = project.project_id;
                Name = project.name;
                Description = project.description;
                ManagerName = project.manager_name;
                CreatedAt = project.created_at;

                _totalTimeSpent = new TimeSpan();
                Tasks = new ObservableCollection<ProjectTaskBo>();
                foreach (var project_task in project.project_tasks)
                {
                    _totalTimeSpent += project_task.time_spent;
                    ProjectTaskBo taskBo = new ProjectTaskBo(project_task);
                    Tasks.Add(taskBo);
                }
            }
        }

        public project ParseDomain()
        {
            project project = new project()
            {
                name = Name,
                description = Description,
                manager_name = ManagerName,
                created_at = DateTime.Now
            };

            return project;
        }
    }
}
