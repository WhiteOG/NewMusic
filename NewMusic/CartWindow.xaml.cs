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
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            CountCartPrice();
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            SHOP sh = new SHOP();
            sh.Show();
            this.Close();
        }

        private void ord_Click(object sender, RoutedEventArgs e)
        {
            var cart = vpks1Entities.GetContext().Cart.Where(p => p.customerid == UserInfo.Id).ToList();
            List<Item> items = new List<Item>();

            foreach (var currentitem in cart)
            {
                items.Add(vpks1Entities.GetContext().Item.Where(p => p.id == currentitem.itemid).First());
            }
            double totalMoney = 0;
            foreach (var item in items)
            {
                totalMoney += Convert.ToDouble(item.price);
            }

            if (totalMoney == 0)
                MessageBox.Show("Нельзя оформить заказ, пока корзина пустая!");
            else
            {
                Oplata op = new Oplata();
                op.Show();
                this.Close();
            }
        }

        private void CountCartPrice()
        {
            var cart = vpks1Entities.GetContext().Cart.Where(p => p.customerid == UserInfo.Id).ToList();
            List<Item> items = new List<Item>();

            foreach (var currentitem in cart)
            {
                items.Add(vpks1Entities.GetContext().Item.Where(p => p.id == currentitem.itemid).First());
            }
            LViewCart.ItemsSource = items;
            double totalMoney = 0;
            foreach (var item in items)
            {
                totalMoney += Convert.ToDouble(item.price);
            }

            if (totalMoney == 0)
                totalprixe.Text = "Корзина пустая";
            else
                totalprixe.Text = $"Итоговая сумма корзины: {Convert.ToString(totalMoney)} руб";
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
