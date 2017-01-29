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
                return db.projects.Include("project_tasks").ToList().Select(x => new ProjectBo(x)).ToList();
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
    }
}
