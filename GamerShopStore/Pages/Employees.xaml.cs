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
using GamerShopStore.BDSHKA;
using Microsoft.Win32;

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public static Employee employee;
        public int DeleteEmployee { get; set; }
        public Employees()
        {
            InitializeComponent();
            EmployeeList.ItemsSource = App.BD.Employee.Where(x => x.Visible == true).ToList();

        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            employee = (Employee)EmployeeList.SelectedItem;
            DeleteEmployee = employee.ID_employee;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeList.SelectedIndex = DeleteEmployee;
            employee.Visible = false;
            App.BD.SaveChanges();
            NavigationService.Navigate(new Employees());
        }

        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployee());
        }
    }
}
