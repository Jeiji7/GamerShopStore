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
    /// Логика взаимодействия для StockTovar.xaml
    /// </summary>
    public partial class StockTovar : Page
    {
        //public static Tovar_stock tovar_stocks;

        public int ZakazTovar { get; set; }
        public StockTovar()
        {
            InitializeComponent();
            StockTovarList.ItemsSource = App.BD.Tovar.ToList();
        }

        private void Button_Click_back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminOkno());
        }

        private void StockTovarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectTovar = (Tovar)StockTovarList.SelectedItem;
            SpecificTovarStock EditPage = new SpecificTovarStock(SelectTovar);
            NavigationService.Navigate(EditPage);
        }
    }
}
