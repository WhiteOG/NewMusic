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
using System.Windows.Shapes;

namespace NewMusic
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {
            SHOP sh = new SHOP();
            sh.Show();
            this.Close();
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            SHOP sh = new SHOP();
            sh.Show();
            this.Close();
        }
    }
}
