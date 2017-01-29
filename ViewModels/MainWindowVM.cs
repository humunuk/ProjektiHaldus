using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ProjektiHaldus.BusinessObjects;
using ProjektiHaldus.Services;

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
    }
}
