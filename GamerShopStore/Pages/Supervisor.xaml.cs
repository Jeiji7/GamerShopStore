using GamerShopStore.BDSHKA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
        public Employee employee;
        public DbSet<Employee> currectUserr;

        public byte[] Imaginaric { get; set; }
        public Supervisor(Employee currectUser)
        {
            InitializeComponent();
            employee = currectUser;
            Imaginaric = currectUser.PhotoEmployee;
            NamessTB.Text = currectUser.Name;

            MemoryStream byteStream = new MemoryStream(Imaginaric);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            Photo.Source = image;
        }

        public Supervisor(DbSet<Employee> imagePhoto)
        {
            this.currectUserr = imagePhoto;
        }

        private void Button_Click_Employees(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Employees());
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Enter());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierListik());
        }
    }
}
