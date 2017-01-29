using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektiHaldus.BusinessObjects;
using ProjektiHaldus.Services;

namespace ProjektiHaldus.ViewModels
{
    
    class AddProjectVm
    {
        private ProjectBo project;

        public AddProjectVm()
        {
            Project = new ProjectBo(null);
        }

        public ProjectBo Project
        {
            get { return project; }
            set { project = value; }
        }

        public bool SaveProject()
        {
            return ProjectService.SaveNewProject(Project.ParseDomain());
        }
    }
}
