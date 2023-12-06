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
        public Tovar_Sup tovar_Sup;
        //Tovar_Sup tovar = new Tovar_Sup();

        public TovarProverka(Tovar_Sup SelectTovar2)
        {
            InitializeComponent();
            tovar_Sup = SelectTovar2;
            DataContext = SelectTovar2;
            

            if (tovar_Sup.VisibleTovar == true)
            {
                ChefCheck.IsChecked = true;
            }
            else
            {
                ChefCheck.IsChecked = false;
            }

        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StockTovar());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
               //tovar = new Tovar_Sup();
            if (ChefCheck.IsChecked == true)
            {
                tovar_Sup.VisibleTovar = true;
                tovar_Sup.Discription = DiscriptionTB.Text;
                App.BD.SaveChanges();
                MessageBox.Show("Товар успешно добавлен в каталог!!");
                NavigationService.Navigate(new StockTovar());
            }
            else
            {
                tovar_Sup.VisibleTovar = false;
                App.BD.SaveChanges();
                NavigationService.Navigate(new StockTovar());
                MessageBox.Show("Товар был убран или не добавлен в каталога");
            }
        }
    }
}
