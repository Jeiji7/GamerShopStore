﻿using GamerShopStore.BDSHKA;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GamerShopStore
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static GameStoreEntities BD = new GameStoreEntities();
        public static Employee employee; 
    }
}
