﻿using System;
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
using ProjektiHaldus.ViewModels;

namespace ProjektiHaldus.Views
{
    /// <summary>
    /// Interaction logic for AddProject.xaml
    /// </summary>
    public partial class AddProject : Window
    {
        private AddProjectVm _vm;
        public AddProject()
        {
            InitializeComponent();
            _vm = new AddProjectVm();
            this.DataContext = _vm;

        }

        private void BtnAddProject_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.SaveProject();
        }
    }
}
