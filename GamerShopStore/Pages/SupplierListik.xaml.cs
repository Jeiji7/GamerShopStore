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
    /// Логика взаимодействия для SupplierListik.xaml
    /// </summary>
    public partial class SupplierListik : Page
    {
        public Supplier supplier;
        public int SupplierChoice { get; set; }
        public SupplierListik()
        {
            InitializeComponent();
            SupplierList.ItemsSource =  App.BD.Supplier.ToList();
        }

        private void EmployeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SupplierChoice = SupplierList.SelectedIndex;
        }

        private void Button_Click_Order(object sender, RoutedEventArgs e)
        {
            if (SupplierChoice != 0)
            {
                supplier = (Supplier)SupplierList.SelectedItem;
                SupplierChoice = supplier.ID_sup;
                var SelectTovar = (Supplier)SupplierList.SelectedItem;
                TovarSupplier editPage = new TovarSupplier(SelectTovar);
                NavigationService.Navigate(editPage);
            }
            else
            {
                MessageBox.Show("Вы не выбрали сотрудника для изменения");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Supervisor());
        }
    }
}
