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
            var typee = App.BD.Tovar_Sup.ToList();
            NamesCB.ItemsSource = typee.ToList();
            NamesCB.DisplayMemberPath = "NameTovar";
            //NamesCB.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.ID_sup == typee.ID_sup));
            //NameCB.ItemsSource = Connection.BD.Product.Where(j => j.ID_type == type.ID_type).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Supplier());
        }
    }
}
