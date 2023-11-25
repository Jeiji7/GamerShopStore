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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductInStore.xaml
    /// </summary>
    public partial class ProductInStore : Page
    {
        public ProductInStore()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CategTb.Visibility = Visibility.Hidden;
        }
    }
}
