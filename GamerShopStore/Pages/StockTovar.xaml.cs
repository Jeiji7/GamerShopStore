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
using System.Xml.Linq;

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для StockTovar.xaml
    /// </summary>
    public partial class StockTovar : Page
    {
        public int value { get; set; }
        public StockTovar()
        {
            InitializeComponent();
            StockTovarList1.ItemsSource = App.BD.Tovar_Sup.ToList();
            var typee = App.BD.Type_Tovar.ToList();
            typee.Insert(0, new BDSHKA.Type_Tovar() { ID_type = 0, Name_type = "Все" });
            TypeCB.ItemsSource = typee.ToList();
            TypeCB.DisplayMemberPath = "Name_type";

        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminOkno());
        }

        private void TypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var type = TypeCB.SelectedItem as Type_Tovar;
            //StockTovarList.ItemsSource = App.BD.Tovar.Where(i => i.ID_type == type.ID_type).ToList();
            //SearchTB.Text = null;
            Tovar_Sup tovar = new Tovar_Sup();
            var typee = TypeCB.SelectedItem as Type_Tovar;
            tovar.ID_type = typee.ID_type;
            if (tovar.ID_type != 0)
            {
                StockTovarList1.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.ID_type == typee.ID_type));
                TypeCB.ItemsSource = App.BD.Tovar_Sup.Where(j => j.ID_type == typee.ID_type).ToList();
            }

            else
            {
                StockTovarList1.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup);
                TypeCB.ItemsSource = App.BD.Tovar_Sup.ToList();
            }
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StockTovarList1.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.NameTovar.StartsWith(SearchTB.Text)));
        }


        private void StockTovarList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectTovar = (Tovar_Sup)StockTovarList1.SelectedItem;
            TovarProverka editPage = new TovarProverka(SelectTovar);
            NavigationService.Navigate(editPage);
        }
    }
}
