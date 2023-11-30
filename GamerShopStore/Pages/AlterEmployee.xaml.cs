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
    }
}
