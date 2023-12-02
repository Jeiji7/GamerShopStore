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
   
    public partial class Enter : Page
    {
        public static Employee empl;
        public static List<Employee> employee { get; set; }

        public Enter()
        {
           
            InitializeComponent();
        }

        private void Button_Click_Enter(object sender, RoutedEventArgs e)
        {
            string _login = LoginTB.Text.Trim();
            string _password = PasswordPS.Password.Trim();
            employee = new List<Employee>(App.BD.Employee.ToList());
            Employee currectUser = employee.FirstOrDefault(x => x.Login == _login && x.Password == _password);
            empl = currectUser;
            if (currectUser != null)
            {
                MessageBox.Show($"Добро пожаловать {empl.Name} !!!");
                if (empl.ID_post == 1)
                {
                    Supervisor editPage = new Supervisor(currectUser);
                    NavigationService.Navigate(editPage);
                }
                else if (empl.ID_post == 2)
                {
                    NavigationService.Navigate(new Supervisor(currectUser));

                }
                else if (empl.ID_post == 3)
                {

                    NavigationService.Navigate(new Supervisor(currectUser));
                }

            }
            else
                MessageBox.Show("Неверный Логин или пароль!!!");

            
           
        }
    }
}
