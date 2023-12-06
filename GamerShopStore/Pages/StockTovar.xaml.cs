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
        //public int value { get; set; }
        public Tovar_Sup tovar;
        public StockTovar()
        {
            InitializeComponent();
            StockTovarList1.ItemsSource = App.BD.Tovar_Sup.Where(i => i.VisibleSup == true).ToList();
            var typee = App.BD.Type_Tovar.ToList();
            typee.Insert(0, new BDSHKA.Type_Tovar() { ID_type = 0, Name_type = "Все" });
            TypeCB.ItemsSource = typee.ToList();
            TypeCB.DisplayMemberPath = "Name_type";
            TypeCB.SelectedIndex = 0;

            

           
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminOkno());
        }

        private void Sorti()
        {

            var type = (TypeCB.SelectedItem as Type_Tovar).ID_type;
            if (type == 0)
                StockTovarList1.ItemsSource = App.BD.Tovar_Sup.ToList();
            else
                StockTovarList1.ItemsSource = App.BD.Tovar_Sup.Where(i => i.ID_type == type).ToList();
        }

        private void TypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sorti();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var type = (TypeCB.SelectedItem as Type_Tovar).ID_type;
            if (type == 0)
                StockTovarList1.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.NameTovar.StartsWith(SearchTB.Text)));
            else
                StockTovarList1.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.NameTovar.StartsWith(SearchTB.Text) && i.ID_type == type));
            if (SearchTB.Text == "" || SearchTB.Text == null)
            {
                Sorti();
            }

        }


        private void StockTovarList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectTovar2 = (Tovar_Sup)StockTovarList1.SelectedItem;
            TovarProverka editPage = new TovarProverka(SelectTovar2);
            NavigationService.Navigate(editPage);
        }
    }
}
