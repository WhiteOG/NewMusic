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
    /// Логика взаимодействия для SHOP.xaml
    /// </summary>
    public partial class SHOP : Window
    {
        public SHOP()
        {
            InitializeComponent();
            LViewItems.ItemsSource = vpks1Entities.GetContext().Item.ToList();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart();
            var item = (sender as Button).DataContext as Item;


            cart.itemid = item.id;
            cart.customerid = UserInfo.Id;
            vpks1Entities.GetContext().Cart.Add(cart);
            try
            {
                vpks1Entities.GetContext().SaveChanges();
                MessageBox.Show("Товар добавлен в корзину");
                CartWindow cr = new CartWindow();
                cr.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
