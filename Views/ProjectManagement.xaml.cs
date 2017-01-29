using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjektiHaldus.BusinessObjects;
using ProjektiHaldus.Services;
using ProjektiHaldus.ViewModels;

namespace ProjektiHaldus.Views
{
    /// <summary>
    /// Interaction logic for ProjectManagement.xaml
    /// </summary>
    public partial class ProjectManagement : Window
    {
        private ProjectManagementVm _vm;
        public ProjectManagement()
        {
            InitializeComponent();
            _vm = new ProjectManagementVm();
            this.DataContext = Vm;
        }

        public ProjectManagementVm Vm
        {
            get { return _vm; }
        }

        private void BtnAddProjectTask_OnClick(object sender, RoutedEventArgs e)
        {
            ProjectTaskBo taskBo = new ProjectTaskBo(null);
            _vm.Tasks.Add(taskBo);
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ProjectTaskBo taskBo = btn.CommandParameter as ProjectTaskBo;
                if (taskBo != null)
                {
                    _vm.Tasks.Remove(taskBo);
                }
            }
        }

        private void BtnAddSaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.updateProjectAndTasks();
        }
    }
}
