﻿using GamerShopStore.BDSHKA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace GamerShopStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для Consultant.xaml
    /// </summary>
    public partial class Consultant : Page
    {
        public Employee employee;
        public DbSet<Employee> currentUser;

        public byte[] Imaginaric { get; set; }
        public Consultant(Employee currentUser)
        {
            InitializeComponent();
            employee = currentUser;
            Imaginaric = currentUser.PhotoEmployee;
            NamessTB.Text = currentUser.Name;

            MemoryStream byteStream = new MemoryStream(Imaginaric);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            Photo.Source = image;
        }
        public Consultant(DbSet<Employee> imagePhoto)
        {
            this.currentUser = imagePhoto;
        }

        public Consultant()
        {
            InitializeComponent();
            NamessTB.Text = "Рамиль";
            //ФОТКИ И НИКА НЕТ

        }
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Enter());
        }

        private void Button_Click_Store(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StoreTovar());
        }
    }
}
