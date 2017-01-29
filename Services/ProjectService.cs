using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjektiHaldus.BusinessObjects;
using ProjektiHaldus.Domain;

namespace ProjektiHaldus.Services
{
    class ProjectService
    {
        public static ObservableCollection<ProjectBo> GetAllProjects()
        {
            ObservableCollection<ProjectBo> projects = new ObservableCollection<ProjectBo>();
            var projectsList = FetchAllProjects();

            foreach (var projectBo in projectsList)
            {
                projects.Add(projectBo);
            }

            return projects;
        }

        private static List<ProjectBo> FetchAllProjects()
        {
            using (Domain.ProjectManagementEntities db = new ProjectManagementEntities())
            {
                return db.projects.Include("project_tasks").OrderBy(x => x.created_at).ToList().Select(x => new ProjectBo(x)).ToList();
            }
        }

        public static bool SaveNewProject(project project)
        {
            using (Domain.ProjectManagementEntities db = new ProjectManagementEntities())
            {
                int doesProjectExists = db.projects.Count(x => x.name == project.name);

                if (doesProjectExists == 0)
                {
                    db.projects.Add(project);
                    db.SaveChanges();
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void DeleteProject(int projectId)
        {
            using (Domain.ProjectManagementEntities db = new ProjectManagementEntities())
            {
                project project = db.projects.First(x => x.project_id == projectId);
                if (project != null)
                {
                    db.projects.Remove(project);
                    db.SaveChanges();
                }
            }
        }

        public static ObservableCollection<ProjectBo> SearchProjects(string searchString)
        {
            ObservableCollection<ProjectBo> projects = new ObservableCollection<ProjectBo>();
            var projectsList = FindProjects(searchString);

            foreach (var projectBo in projectsList)
            {
                projects.Add(projectBo);
            }

            return projects;
        }

        private static List<ProjectBo> FindProjects(string searchString)
        {
            using (Domain.ProjectManagementEntities db = new ProjectManagementEntities())
            {
                return db.projects.Include("project_tasks").Where(x => x.name.Contains(searchString)).ToList().Select(x => new ProjectBo(x)).ToList();
            }
        }

        public static void UpdateProjectAndTasks(ProjectBo projectBo, ObservableCollection<ProjectTaskBo> tasks)
        {
            project project = FindProject(projectBo.ProjectId);

            if (project != null)
            {
                using (Domain.ProjectManagementEntities db = new ProjectManagementEntities())
                {
                    project.name = projectBo.Name;
                    project.description = projectBo.Description;
                    project.manager_name = projectBo.ManagerName;

                    db.Database.ExecuteSqlCommand("Delete project_tasks where project_id = {0}", project.project_id);

                    foreach (ProjectTaskBo task in tasks)
                    {
                        project_tasks taskEntity = task.ParseDomain();
                        taskEntity.project_id = project.project_id;
                        db.project_tasks.Add(taskEntity);
                    }

                    db.SaveChanges();
                }
            }
        }

        private static project FindProject(int projectId)
        {
            using (Domain.ProjectManagementEntities db = new ProjectManagementEntities())
            {
                return db.projects.Include("project_tasks").First(x => x.project_id == projectId);
            }
        }
    }
}
