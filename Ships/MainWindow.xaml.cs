﻿using System;
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

namespace Ships
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HostButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oczekuję na przeciwnika");
            Ships___Online playWindow = new Ships___Online(true, null);
            playWindow.Show();
            Close();
        }

        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            Ships___Online playWindow = new Ships___Online(false, IPBOX.Text);
            playWindow.Show();
            Close();
        }
    }
}
