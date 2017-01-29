using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjektiHaldus.BusinessObjects;
using ProjektiHaldus.Services;
using ProjektiHaldus.Views;

namespace ProjektiHaldus.ViewModels
{
    class MainWindowVm : INotifyVM
    {
        public MainWindowVm()
        {
        }

        public ObservableCollection<ProjectBo> Projects { get; set; }

        public void LoadData()
        {
            Projects = ProjectService.GetAllProjects();
            NotifyPropertyChanged("Projects");
        }
        
        internal void DeleteProject(ProjectBo projectBo)
        {
            Projects.Remove(projectBo);
            ProjectService.DeleteProject(projectBo.ProjectId);
        }

        public void SearchProjects(string searchString)
        {
            Projects = ProjectService.SearchProjects(searchString);
            NotifyPropertyChanged("Projects");
        }

        public void LoadAddProjectWindow()
        {
            AddProject addProject = new AddProject();
            addProject.Show();
        }
    }
}
