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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektiHaldus.BusinessObjects;
using ProjektiHaldus.ViewModels;
using ProjektiHaldus.Views;

namespace ProjektiHaldus
{
    public class WindowHelpers
    {
        public static void SelectAll(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.SelectAll();
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowVm _vm;
        
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainWindowVm();
            _vm.LoadData();
            this.DataContext = _vm;
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                ProjectBo projectBo = btn.CommandParameter as ProjectBo;
                if (projectBo != null)
                {
                    MessageBoxResult result = MessageBox.Show("Kas oled kindel, et tahad kutsutada?", "Kustuta", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        _vm.DeleteProject(projectBo);
                    }
                }
            }
        }

        private void BtnAddProject_OnClick(object sender, RoutedEventArgs e)
        {
            AddProject addProject = new AddProject();
            addProject.Show();
        }
    }
}
