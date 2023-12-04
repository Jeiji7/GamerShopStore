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
            PostCB.SelectedIndex = (int)(employee.ID_post - 1);

            Imagenaric = selectEmp.PhotoEmployee;
            
            MemoryStream byteStream = new MemoryStream(selectEmp.PhotoEmployee);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            MainImage.Source = image;
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
            employee.Name = NamesTB.Text.Trim();
            employee.Phone = PhoneTB.Text.Trim();
            employee.Login = LoginTB.Text.Trim();
            employee.Password = PasswordTB.Text.Trim();
            employee.Salary = Convert.ToDecimal(SalaryTB.Text);
            employee.Visible = true;
            employee.ID_post = (PostCB.SelectedItem as PostEmp).ID_post;
            employee.PhotoEmployee = Imagenaric;
           
            App.BD.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Employees());
        }

      
    }
}
