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

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminOkno.xaml
    /// </summary>
    public partial class AdminOkno : Page
    {
        public AdminOkno()
        {
            InitializeComponent();
        }

       

        private void Button_Click_Stock(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StockTovar());
        }

        private void Button_Click_Store(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new());
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Enter());
        }
    }
}
