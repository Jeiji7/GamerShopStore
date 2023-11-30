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
    /// Логика взаимодействия для AlterEmployee.xaml
    /// </summary>
    public partial class AlterEmployee : Page
    {
        public byte[] Imagenaric { get; set; }
        public Employee employee;
        public AlterEmployee(Employee selectEmp)
        {
            InitializeComponent();
            employee = selectEmp;
            var typee = App.BD.PostEmp.ToList();
            PostCB.ItemsSource = typee.ToList();
            PostCB.DisplayMemberPath = "NamePost";
            
            NamesTB.Text = selectEmp.Name.ToString();
            PhoneTB.Text = selectEmp.Phone.ToString();
            SalaryTB.Text = selectEmp.Salary.ToString();
            LoginTB.Text = selectEmp.Login.ToString();
            PasswordTB.Text = selectEmp.Password.ToString();
            PostCB.Text = Convert.ToString(employee.ID_post);
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
    }
}
