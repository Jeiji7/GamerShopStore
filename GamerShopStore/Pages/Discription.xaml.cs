using GamerShopStore.BDSHKA;
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
    /// Логика взаимодействия для Discription.xaml
    /// </summary>
    public partial class Discription : Page
    {
        public Tovar_Sup tovar;
        public Discription(Tovar_Sup StoreTovar1)
        {
            InitializeComponent();
            DataContext = StoreTovar1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreTovar());
        }
    }
}
