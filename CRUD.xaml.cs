﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CRUD.xaml
    /// </summary>
    public partial class CRUD : Window
    {
        public CRUD(int x)
        {
            InitializeComponent();
                      
            
            switch(x)

            {
                case 1:
                    AddData addData = new AddData();
                    MainFrame.Content = addData;
                    break;
                case 2:
                    DellData dellData = new DellData();
                    MainFrame.Content = dellData;
                    break;
                    case 3:
                    updData updData = new updData();
                    MainFrame.Content = updData;
                    break;

            }
        }
    }
}
