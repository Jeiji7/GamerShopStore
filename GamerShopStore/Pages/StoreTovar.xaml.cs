﻿using GamerShopStore.BDSHKA;
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
            StoreTovarList.ItemsSource = App.BD.Tovar_Sup.Where(i => i.VisibleTovar == true).ToList();
        }

        private void StockTovarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Sorti()
        {

            var type = (TypeCB.SelectedItem as Type_Tovar).ID_type;
            if (type == 0)
                StoreTovarList.ItemsSource = App.BD.Tovar_Sup.ToList();
            else
                StoreTovarList.ItemsSource = App.BD.Tovar_Sup.Where(i => i.ID_type == type).ToList();
        }
        private void TypeCB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Sorti();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var type = (TypeCB.SelectedItem as Type_Tovar).ID_type;
            if (type == 0)
                StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.NameTovar.StartsWith(SearchTB.Text)));
            else
                StoreTovarList.ItemsSource = new List<Tovar_Sup>(App.BD.Tovar_Sup.Where(i => i.NameTovar.StartsWith(SearchTB.Text) && i.ID_type == type));
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

        }

        private void MinTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Sum()
        {

        }
    }
}
