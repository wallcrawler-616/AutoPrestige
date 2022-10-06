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
using MySql.Data.MySqlClient;
using System.IO;

namespace AutoPrestigeArenda
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CaptchaText.Visibility = Visibility.Hidden;
            CaptchaTB.Visibility = Visibility.Hidden;
            RepeatCaptcha.Visibility = Visibility.Hidden;
            CaptchaPic.Visibility = Visibility.Hidden;
            
        }
        int LogCount = 0;
        string Role = "";
        FunctionsClass functionsClass = new FunctionsClass();

        private void Login()
        {
            MySqlCommand Cmd = new MySqlCommand("SELECT Role FROM users WHERE `Login`='"+LoginTB.Text+"' and `Password`='" + PasswordBox.Password.ToString() + "';", functionsClass.Connect);
            try
            {
                functionsClass.Connect.Open();
                MySqlDataReader Data = Cmd.ExecuteReader();
                if (Data.Read())
                {
                    Role = Data[0].ToString();
                }
                else
                {
                    MessageBox.Show("Неверный логин и/или пароль", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Не удалось получить данные!", "Ошибка подключения!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { functionsClass.Connect.Close(); }

        }
        
        private void Capcha()
        {
            string Cap = String.Empty;
            Random Rnd = new Random();
            string Alf = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 6; i++)
            {
                Cap += Alf[Rnd.Next(Alf.Length)];
            }
            CaptchaText.Content = Cap;

        }
        private void RepeatCaptcha_Click(object sender, RoutedEventArgs e)
        {
            CaptchaTB.Text = "";
            CaptchaText.Content = "";
            Capcha();
        }

       

        private void ShowPassBT_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                ShowPassBT.Content = "[👁‍]";
                PasswordBox.Visibility = Visibility.Collapsed;
                ShowPassTB.Visibility = Visibility.Visible;
                ShowPassTB.Text = PasswordBox.Password;

            }
            else
            {
                ShowPassBT.Content = "[   ]";
                PasswordBox.Visibility = Visibility.Visible;
                ShowPassTB.Visibility = Visibility.Collapsed;
                PasswordBox.Password = ShowPassTB.Text;
            }
        }

        private void LoginBT_Click(object sender, RoutedEventArgs e)
        {
            if (LogCount == 3)
            {
                Capcha();
                
                CaptchaText.Visibility = Visibility.Visible;
                CaptchaTB.Visibility = Visibility.Visible;
                RepeatCaptcha.Visibility = Visibility.Visible;
                CaptchaPic.Visibility = Visibility.Visible;
            }
            if (LoginTB.Text != "" && PasswordBox.Password != "")
            {
                if (LogCount <= 3)
                {
                    Login();

                }
                else
                {
                    if (CaptchaTB.Text == CaptchaText.Content.ToString())
                    {
                        Login();
                    }
                    else
                    {
                        MessageBox.Show("Капча не валидна!","Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                        Capcha();
                    }
                }
                switch (Role)
                {
                        case "Администратор":
                            {
                                Admin admin = new Admin();
                                admin.Show();
                                Close();
                                break;
                            }
                        case "Менеджер по аренде":
                            {
                                ManagerOrders orders = new ManagerOrders();
                                orders.Show();
                                Close();
                                
                                break;
                            }
                        case "Менеджер по закупкам":
                            {
                                ManagerBuy Buy = new ManagerBuy();
                                Buy.Show();
                                Close();
                               
                                break;
                            }
                        case "Удален":
                            {
                             MessageBox.Show("Пользователь удален", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                           
                                break;
                            }
                }
                
            }
            else
            {
                MessageBox.Show("Данные не заполнены!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            LogCount++;
        }

      
    }
}
