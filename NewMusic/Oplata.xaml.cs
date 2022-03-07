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
    /// Логика взаимодействия для Oplata.xaml
    /// </summary>
    public partial class Oplata : Window
    {
        public Oplata()
        {
            InitializeComponent();
            getTotalPrice();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Поле имя должно быть заполнено!");
                return;
            }
            if (String.IsNullOrWhiteSpace(Address.Text))
            {
                MessageBox.Show("Поле адресс должно быть заполнено!");
                return;
            }

            bool isError = false;
            foreach (var currentCustomerItem in vpks1Entities.GetContext().Cart.Where(p => p.customerid == UserInfo.Id).ToList())
            {
                vpks1Entities.GetContext().Orders.Add(new Orders()
                {                   
                    details = Address.Text,
                    itemid = currentCustomerItem.itemid
                });

                try
                {
                    vpks1Entities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    isError = true;
                    break;
                }

                vpks1Entities.GetContext().Cart.Remove(currentCustomerItem);

                try
                {
                    vpks1Entities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    isError = true;
                    break;
                }
            }

            if (isError)
            {
                MessageBox.Show("Не удалось оформить заказ");
            }
            else
            {
                MessageBox.Show("Заказ офрмлоен! В ближайшее время с вами свяжется менеджер.");
                SHOP sh = new SHOP();
                sh.Show();
                this.Close();
            }

            
        }
        private void getTotalPrice()
        {
            double totalMoney = 0;
            foreach (var currentCustomerItem in vpks1Entities.GetContext().Cart.Where(p => p.customerid == UserInfo.Id).ToList())
            {
                totalMoney += Convert.ToInt32(vpks1Entities.GetContext().Item.Where(p => p.id == currentCustomerItem.itemid).First().price);
            }
            totalPrice.Text = Convert.ToString(totalMoney) + " Руб";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CartWindow cr = new CartWindow();
            cr.Show();
            this.Close();
        }
    }
}
