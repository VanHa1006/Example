﻿using MilkShop.WPF.UI;
using MilkShop.WPFApp.UI;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MilkShop.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Open_wProduct_Click(object sender, RoutedEventArgs e)
        {
            var p = new wProduct();
            p.Owner = this;
            p.Show();
        }

        private void Open_wCompany_Click(object sender, RoutedEventArgs e)
        {
            var p = new wCompany();
            p.Owner = this;
            p.Show();
        }
        private void Open_wOrder_Click(object sender, RoutedEventArgs e)
        {
            var p = new wOrder();
            p.Owner = this;
            p.Show();
        }

        private void Open_wCusomer_Click(object sender, RoutedEventArgs e)
        {
            var p = new wCustomer();
            p.Owner = this;
            p.Show();
        }

    }
}