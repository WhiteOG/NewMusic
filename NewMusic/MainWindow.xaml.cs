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

namespace NewMusic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        vpks1Entities ef;
        public MainWindow()
        {
            InitializeComponent();
            ef = new vpks1Entities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(log.Text))
            {
                if(!String.IsNullOrWhiteSpace(pass.Text))
                {
                    Customer cust = vpks1Entities.GetContext().Customer.FirstOrDefault(p => p.login == log.Text);

                    if (cust != null)
                    {
                        if(cust.password == pass.Text)
                        {
                            MessageBox.Show("Успешная авторизация");
                            UserInfo.Id = cust.id;
                            Home hm = new Home();
                            hm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверный пароль!");
                                pass.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин!");
                        pass.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Укажите данные для входа!");
                }
            }
            else
            {
                MessageBox.Show("Укажите данные для входа!");
            }
        }
    }
}
