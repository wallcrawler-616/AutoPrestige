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
using System.Data;
using AutoPrestigeArenda;

namespace AutoPrestigeArenda
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            functionsClass.Load("SELECT * FROM `users` WHERE `Role`!='Администратор'", DataGrid);
            functionsClass.ComboLoad("Select * From Roles Where `Role` != 'Администратор'", RoleTB);
            DictionaryCB.ItemsSource = Rus;
            

        }
        FunctionsClass functionsClass = new FunctionsClass();
        string Login;
        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
                if (SurnameTB.Text != "" && NameTB.Text != "" && FathernameTB.Text != "" && LoginTB.Text != "" && PassTB.Text != "" && RoleTB.Text != "" && 
                    SurnameTB.Text != " " && NameTB.Text != " " && FathernameTB.Text != " " && LoginTB.Text != " " && PassTB.Text != " " && RoleTB.Text != " " )
                {
                    functionsClass.StringLoad("SELECT Login FROM users WHERE Login = '"+LoginTB.Text+"'", ref Login);
                    if (Login!=LoginTB.Text)
                    {
                        functionsClass.Change("INSERT INTO `users`(`Family_name`, `Name`, `Secondname`, `Login`, `Password`, `Role`) VALUES ('" + SurnameTB.Text + "','" + NameTB.Text + "','" + FathernameTB.Text + "','" + LoginTB.Text + "','" + PassTB.Text + "','" + RoleTB.Text + "')", "Не удалось выполнить операцию!\nВозможно пользователь с таким логином уже имеется", "Ошибка!", "Успешно!");
                        functionsClass.Load("SELECT * FROM `users` WHERE `Role`!='Администратор'", DataGrid);
                        SurnameTB.Clear();
                        NameTB.Clear();
                        FathernameTB.Clear();
                        LoginTB.Clear();
                        PassTB.Clear();
                        RoleTB.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            functionsClass.GetRow(DataGrid,0);
            functionsClass.Change("UPDATE `users` SET `Role`='Удален' WHERE `Id` ='" + functionsClass.NeededRow + "'", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
            functionsClass.Load("SELECT * FROM `users` WHERE `Role`!='Администратор'", DataGrid);
            SearchTB.Text = "sdfsdfsdfsdf";
            SearchTB.Clear();
            SurnameTB.Clear();
            NameTB.Clear();
            FathernameTB.Clear();
            LoginTB.Clear();
            PassTB.Clear();
            RoleTB.Text = "";
            
        }
        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            functionsClass.GetRow(DataGrid, 0);
            if (SurnameTB.Text != "" && NameTB.Text != "" && FathernameTB.Text != "" && LoginTB.Text != "" && PassTB.Text != "" && RoleTB.Text != "" &&
               SurnameTB.Text != " " && NameTB.Text != " " && FathernameTB.Text != " " && LoginTB.Text != " " && PassTB.Text != " " && RoleTB.Text != " ")
            {
                functionsClass.StringLoad("SELECT Login FROM users WHERE Login = '" + LoginTB.Text + "'", ref Login);
                if (Login != LoginTB.Text)
                {
                    functionsClass.Change("UPDATE `users` SET `Family_name`='" + SurnameTB.Text + "',`Name`='" + NameTB.Text + "',`Secondname`='" + FathernameTB.Text + "',`Login`='" + LoginTB.Text + "',`Password`='" + PassTB.Text + "',`Role`='" + RoleTB.Text + "' WHERE `Id`='" + functionsClass.NeededRow + "'", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
            functionsClass.Load("SELECT * FROM `users` WHERE `Role`!='Администратор'", DataGrid);
            SurnameTB.Clear();
            NameTB.Clear();
            FathernameTB.Clear();
            LoginTB.Clear();
            PassTB.Clear();
            RoleTB.Text = "";
           

        }

       
        
        
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView Row in DataGrid.SelectedItems)
            {
                SurnameTB.Text = Row.Row.ItemArray[1].ToString();
                NameTB.Text = Row.Row.ItemArray[2].ToString();
                FathernameTB.Text = Row.Row.ItemArray[3].ToString();
                LoginTB.Text = Row.Row.ItemArray[4].ToString();
                PassTB.Text = Row.Row.ItemArray[5].ToString();
                RoleTB.Text = Row.Row.ItemArray[6].ToString();
                


            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Login = new MainWindow();
            Login.Show();
            Close();
        }

       
        
        private void SearchText(object sender, TextChangedEventArgs e)
        {

            functionsClass.Load("SELECT * FROM `users` WHERE `Role`!='Администратор'", DataGrid);
            functionsClass.Search(SearchTB);

        }
        
        List<string> Rus = new List<string>() { "Роли пользователей", "Классы автомобилей", "Производители", "Страны производителей", "Типы приводов", "Коробка передач", "Статусы автомобилей", "Типы оплаты", "Статусы заказов" };
        List<string> Eng = new List<string>() { "roles", "class_auto", "brand_list", "country_list", "driver_units", "transmission_types", "car_statuses", "payment_types", "order_statuses" };
        List<string> ColumNames = new List<string>() { "Role", "Class", "Brand", "Country", "Driver unit", "Transmission", "Status", "Type", "Status" };
        public class Sprav 
        { 
            public string Spraw { get; set; }

        }
        private void DictionaryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             Dictionary();
        }
        void Dictionary() 
        {
            functionsClass.Connect.Open();
            MySqlCommand Cmd = new MySqlCommand("Select * from " + Eng[DictionaryCB.SelectedIndex] + "", functionsClass.Connect);
            MySqlDataReader Reader = Cmd.ExecuteReader();
            Colum1.Header = DictionaryCB.SelectedItem;
            try
            {
                DictionaryList.Items.Clear();
                while (Reader.Read())
                {
                    Sprav Spraws = new Sprav();
                    Spraws.Spraw = Reader.GetString(0);
                    DictionaryList.Items.Add(Spraws);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Не удалось изображение!", "Ошибка загрузки!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                functionsClass.Connect.Close();
            }
        }

        private void DictionaryAdd_Click(object sender, RoutedEventArgs e)
        {
            if (DictionaryTB.Text != "" || DictionaryTB.Text != " ")
            {
                functionsClass.Change("INSERT INTO " + Eng[DictionaryCB.SelectedIndex] + " VALUES ('" + DictionaryTB.Text + "')", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                Dictionary();
            }
        }
        string Column;
        private void DictionaryUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {


                if (DictionaryTB.Text != "" || DictionaryTB.Text != " ")
                {
                    string text = "";
                    foreach (Sprav Row in DictionaryList.SelectedItems)
                    {
                        text = Row.Spraw.ToString(); //ItemArray[0].ToString();
                    }
                    Column = "";
                    Column = ColumNames[DictionaryCB.SelectedIndex];
                    functionsClass.Change("UPDATE " + Eng[DictionaryCB.SelectedIndex] + " SET " + Column + " ='" + DictionaryTB.Text + "' WHERE " + Column + "='" + text + "'", "Не удалось выполнить операцию!\nВозможно данное поле используется в другой таблице", "Ошибка!", "Успешно!");
                    Dictionary();
                }
            }
        }

        private void DictionaryDElete_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem!=null)
            {

            
                if (DictionaryTB.Text != "" || DictionaryTB.Text != " ")
                {

                    MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить данную запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            string text = "";
                            foreach (Sprav Row in DictionaryList.SelectedItems)
                            {
                                text = Row.Spraw.ToString(); //ItemArray[0].ToString();
                            }
                            Column = "";
                            Column = ColumNames[DictionaryCB.SelectedIndex];
                            functionsClass.Change("DELETE FROM " + Eng[DictionaryCB.SelectedIndex] + " WHERE " + Column + " = '" + text + "' ", "Не удалось выполнить операцию!\nВозможно данное поле используется в другой таблице", "Ошибка!", "Успешно!");
                            Dictionary();
                        } 
                }
            }
        }

        private void SearchTB_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            functionsClass.Load("SELECT * FROM `users`", DictionaryList);
            functionsClass.Search(SearchTB_Copy);
        }

      

        private void PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
  