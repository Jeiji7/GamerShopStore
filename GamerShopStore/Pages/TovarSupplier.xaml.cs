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
using GamerShopStore.BDSHKA;

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для TovarSupplier.xaml
    /// </summary>
    public partial class TovarSupplier : Page
    {
        public Supplier supplier;

        public TovarSupplier(Supplier SelectTovar)
        {
            InitializeComponent();
            supplier = SelectTovar;
            DataContext = SelectTovar;
            //ID_supTB.Text = SelectTovar.ID_sup.ToString();
            
            NamesCB.ItemsSource = App.BD.Tovar_Sup.Where(i => i.ID_sup == SelectTovar.ID_sup).ToList();
            NamesCB.DisplayMemberPath = "NameTovar";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Supplier());
        }

        private void NamesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var name = NamesCB.SelectedItem as Tovar_Sup;
            //var ID = ID_supTB.Text;
            //NamesCB.ItemsSource = App.BD.Tovar_Sup.Where(i => i.ID_sup == name.ID_sup).ToList();
        }
    }
}
