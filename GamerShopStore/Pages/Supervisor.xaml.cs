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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для Supervisor.xaml
    /// </summary>
    public partial class Supervisor : Page
    {
        public Supervisor()
        {
            InitializeComponent();
        }

        private void Button_Click_Employees(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Employees());
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
