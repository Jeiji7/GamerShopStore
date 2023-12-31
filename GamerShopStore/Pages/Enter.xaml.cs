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
using GamerShopStore.BDSHKA;

namespace GamerShopStore.Pages
{
   
    public partial class Enter : Page
    {
        public static  Employee empl { get; set; }
        public static List<Employee> employee { get; set; }

        public Enter()
        {
           
            InitializeComponent();
        }

        private void Button_Click_Enter(object sender, RoutedEventArgs e)
        {
            string _login = LoginTB.Text.Trim();
            string _password = PasswordPS.Password.Trim();
            employee = new List<Employee>(App.BD.Employee.ToList());
            App.employee = employee.FirstOrDefault(x => x.Login == _login && x.Password == _password);
            empl = App.employee;
            if (App.employee != null)
            {
                MessageBox.Show($"Добро пожаловать {empl.Name} !!!");
                if (empl.ID_post == 1)
                {
                    Supervisor editPage = new Supervisor(App.employee);
                    NavigationService.Navigate(editPage);
                }
                else if (empl.ID_post == 2)
                {
                    AdminOkno editPage = new AdminOkno(App.employee);
                    NavigationService.Navigate(editPage);
                }
                else if (empl.ID_post == 3)
                {
                    Consultant editPage = new Consultant(App.employee);
                    NavigationService.Navigate(editPage);
                }

            }
            else
                MessageBox.Show("Неверный Логин или пароль!!!");

            
           
        }
    }
}
