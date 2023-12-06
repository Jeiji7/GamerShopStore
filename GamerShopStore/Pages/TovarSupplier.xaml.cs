using System;
using System.Collections.Generic;
using System.IO;
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
        public int count { get; set; }
        public byte[] Imagenaric { get; set; }

        Tovar_Sup tovar = new Tovar_Sup();
        public TovarSupplier(Supplier SelectTovar)
        {
            InitializeComponent();
            supplier = SelectTovar;
            DataContext = SelectTovar;
            
            NamesCB.ItemsSource = App.BD.Tovar_Sup.Where(i => i.ID_sup == SelectTovar.ID_sup).ToList();
            NamesCB.DisplayMemberPath = "NameTovar";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierListik());
        }

        private void NamesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tovar = NamesCB.SelectedItem as Tovar_Sup;
            PriceTB.Text = Convert.ToString(tovar.Price);
            CountsTB.Text = Convert.ToString(tovar.CountsSup);
            CountsStock1TB.Text = Convert.ToString(tovar.CountsTovar);

            Imagenaric = tovar.ImageTovar;

            MemoryStream byteStream = new MemoryStream(tovar.ImageTovar);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            MainImage.Source = image;

            TypeTB.Text = Convert.ToString(tovar.Type_Tovar.Name_type);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tovar = NamesCB.SelectedItem as Tovar_Sup;
            count = Convert.ToInt32(CountsStockTB.Text);
            if (count != 0)
            {
                tovar.CountsSup = Convert.ToInt32(CountsTB.Text) - count;
                tovar.CountsTovar = Convert.ToInt32(CountsStock1TB.Text) + count;
                tovar.VisibleSup = true;
                App.BD.SaveChanges();
                MessageBox.Show("Товар успешно заказан");
                NavigationService.Navigate(new SupplierListik());
            }
            else
                MessageBox.Show("Произошла ошибка выбeрите количество товара");
        }
    }
}
