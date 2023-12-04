using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            DeleteEmployee = EmployeeList.SelectedIndex;
         //Может что то будет)   
        }

        private void Button_Click_Alter(object sender, RoutedEventArgs e)
        {
            if (DeleteEmployee != 0)
            {
                employee = (Employee)EmployeeList.SelectedItem;
                DeleteEmployee = employee.ID_employee;
                var SelectEmp = (Employee)EmployeeList.SelectedItem;
                AlterEmployee editPage = new AlterEmployee(SelectEmp);
                NavigationService.Navigate(editPage);
            }
            else
            {
                MessageBox.Show("Вы не выбрали сотрудника для изменения");
            }
        }

        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployee());
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (DeleteEmployee != 0)
            {
                EmployeeList.SelectedIndex = DeleteEmployee;
                employee.Visible = false;
                App.BD.SaveChanges();
                MessageBox.Show($"Cотрудник {employee.Name} успешно удалён") ;
                NavigationService.Navigate(new Employees());
            }
            else
            {
                MessageBox.Show("Вы не выбрали сотрудника для изменения");

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Employee empl = currectUserr;
            //Supervisor editPage = new Supervisor(currectUserr);
            //NavigationService.Navigate(editPage);
            NavigationService.Navigate(new Supervisor());
        }
    }
}
