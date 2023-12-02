using GamerShopStore.BDSHKA;
using Microsoft.Win32;
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
using System.IO;

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        public byte[] Imagenaric { get; set; }
        public Employee employee;
        public AddEmployee()
        {
            InitializeComponent();

            var typee = App.BD.PostEmp.ToList();
            PostCB.ItemsSource = typee.ToList();
            PostCB.DisplayMemberPath = "NamePost";
        }

        private void Button_Click_ADD(object sender, RoutedEventArgs e)
        {
                
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
                };
                if (openFileDialog.ShowDialog().GetValueOrDefault())
                {
                    Imagenaric = File.ReadAllBytes(openFileDialog.FileName);
                    MainImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                }
        }

      

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            Employee employee1 = new Employee()
            {
                Name = NamesTB.Text.Trim(),
                Phone = PhoneTB.Text.Trim(),
                Login = LoginTB.Text.Trim(),
                Password = PasswordTB.Text.Trim(),
                Salary = Convert.ToInt32(SalaryTB.Text),
                Visible = true,
                ID_post = (PostCB.SelectedItem as PostEmp).ID_post,
                PhotoEmployee = Imagenaric
            };
            App.BD.Employee.Add(employee1);
            App.BD.SaveChanges();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Employees());
        }
    }
}
