using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ProjektiHaldus.BusinessObjects;
using ProjektiHaldus.Services;

namespace ProjektiHaldus.ViewModels
{
    public class ProjectManagementVm : INotifyVM
    {

        private ProjectBo projectBo;
        private ObservableCollection<ProjectTaskBo> _tasks;

        public ProjectBo ProjectBo
        {
            get { return projectBo; }
            set { projectBo = value; }
        }

        public ObservableCollection<ProjectTaskBo> Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }

        public void LoadData(ProjectBo projectBo)
        {
            ProjectBo = projectBo;
            Tasks = ProjectBo.Tasks;
            if (Tasks == null)
            {
                Tasks = new ObservableCollection<ProjectTaskBo>();
            }
            NotifyPropertyChanged("ProjectBo");
        }

        public void updateProjectAndTasks()
        {
            ProjectService.UpdateProjectAndTasks(ProjectBo, Tasks);
            MessageBox.Show("Projekt uuendatud");
        }
    }
}
