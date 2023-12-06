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
    /// Логика взаимодействия для StoreTovar.xaml
    /// </summary>
    public partial class StoreTovar : Page
    {
        public StoreTovar()
        {
            InitializeComponent();
            StoreTovarList.ItemsSource = App.BD.Tovar_Sup.Where(i => i.VisibleTovar == true && i.VisibleSup == true).ToList();
            var typee = App.BD.Type_Tovar.ToList();
            typee.Insert(0, new BDSHKA.Type_Tovar() { ID_type = 0, Name_type = "Все" });
            TypeCB.ItemsSource = typee.ToList();
            TypeCB.DisplayMemberPath = "Name_type";
            TypeCB.SelectedIndex = 0;


        }

        private void StockTovarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var StoreTovar1 = (Tovar_Sup)StoreTovarList.SelectedItem;
            Discription editPage = new Discription(StoreTovar1);
            NavigationService.Navigate(editPage);
        }
        private void Sorti()
        {

            var type = (TypeCB.SelectedItem as Type_Tovar).ID_type;
            if (type == 0)
                StoreTovarList.ItemsSource = App.BD.Tovar_Sup.Where(i => i.VisibleTovar == true && i.VisibleSup == true).ToList();
            else
                StoreTovarList.ItemsSource = App.BD.Tovar_Sup.Where(i => i.ID_type == type && i.VisibleTovar == true && i.VisibleSup == true).ToList();
        }
        private void TypeCB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Sorti();
        }

        private void SearchTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var type = (TypeCB.SelectedItem as Type_Tovar).ID_type;
            if (type == 0)
                StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.NameTovar.StartsWith(SearchTB.Text) && i.VisibleTovar == true && i.VisibleSup == true));
            else
                StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.NameTovar.StartsWith(SearchTB.Text) && i.ID_type == type && i.VisibleTovar == true && i.VisibleSup == true));
            if (SearchTB.Text == "" || SearchTB.Text == null)
            {
                Sorti();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var num = Convert.ToInt32(App.employee.ID_post);
            if (num == 2)
                NavigationService.Navigate(new AdminOkno(App.employee));
            else if(num ==1)
                NavigationService.Navigate(new Supervisor(App.employee));
            else
                NavigationService.Navigate(new Consultant(App.employee));
        }

        private void MaxTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Sum();
            var max = Convert.ToInt32(MaxTB.Text);
            if (MinTB.Text == "" || MinTB.Text == null)
                StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.Price.Value <= max && i.VisibleTovar == true && i.VisibleSup == true));
        }

        private void MinTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Sum();
            var min = Convert.ToInt32(MinTB.Text);
            if (MaxTB.Text == "" || MaxTB.Text == null)
                StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.Price.Value >= min && i.VisibleTovar == true && i.VisibleSup == true));
        }

        //public void Sum()
        //{
        //    var max = Convert.ToInt32(MaxTB.Text);
        //    var min = Convert.ToInt32(MinTB.Text);
        //    if (MaxTB.Text == "" || MaxTB.Text == null || MinTB.Text == null || MinTB.Text == "")
        //        StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.Price.Value <= max &&  i.Price.Value >= min && i.VisibleTovar == true && i.VisibleSup == true));
        //        //StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.Price.Value >= min && i.VisibleTovar == true && i.VisibleSup == true));
        //}
    }
}
