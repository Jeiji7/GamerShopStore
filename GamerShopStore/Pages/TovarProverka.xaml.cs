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
    /// Логика взаимодействия для TovarProverka.xaml
    /// </summary>
    public partial class TovarProverka : Page
    {

        public TovarProverka(Tovar_Sup SelectTovar)
        {
            InitializeComponent();
            //tovar = SelectTovar;
            //NamesTB.Text = tovar.NameTovar;
            //PriceTB.Text = Convert.ToString(tovar.Price);
            //CountTB.Text = Convert.ToString(tovar.Counts);
            //NameSupTB.Text = Convert.ToString(App.BD.Supplier.Where(i => i.ID_sup == SelectTovar.ID_sup).ToString());
            //VisibleTB.Text = Convert.ToString(tovar.VisibleTov);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StockTovar());
        }
    }
}
