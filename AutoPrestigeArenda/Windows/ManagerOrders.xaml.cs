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
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using AutoPrestigeArenda;

namespace AutoPrestigeArenda
{
    /// <summary>
    /// Логика взаимодействия для ManagerOrders.xaml
    /// </summary>
    public partial class ManagerOrders : Window
    {
        public ManagerOrders()
        {
            InitializeComponent();
            functionsClass.Load("SELECT * FROM `orders`", DataGrid);
            functionsClass.ComboLoad("Select Number From car_list", AutoIdTB);
            functionsClass.ComboLoad("Select * From payment_types", PaymentTypeTB);
            functionsClass.ComboLoad("SELECT * FROM order_statuses Where Status!='Завершен' and Status!='Отменен'", Status);
            DictionaryCB.ItemsSource = Rus;
            OrderDate.DisplayDateStart = DateTime.Now;

        }

        List<string[]> Data = new List<string[]>();
        FunctionsClass functionsClass = new FunctionsClass();
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Login = new MainWindow();
            Login.Show();
            Close();
        }


        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItems != null)
            {

                if (AutoIdTB.Text == "" || RentTimeTB.Text == "" || PaymentTypeTB.Text == "" || Status.Text == "" || AutoIdTB.Text == "" || RentTimeTB.Text == ""
                    || FamilyTB.Text == "" || NameTB.Text == "" || SecondNameTB.Text == "" || PhoneTB.Text == "" || Series.Text == "" || Number.Text == "" ||
                    FamilyTB.Text == " " || NameTB.Text == " " || SecondNameTB.Text == " " || PhoneTB.Text == " " || Series.Text == " " || Number.Text == " "
                    || PaymentTypeTB.Text == "" || Status.Text == "" || PriceTB.Text == "" || PriceTB.Text == " " || AdressTB.Text == "" || AdressTB.Text == " ")
                {

                    MessageBox.Show("Заполните все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {

                    functionsClass.GetRow(DataGrid, 0);
                    functionsClass.Change("UPDATE `orders` SET `Auto_Id`='" + AutoIdTB.Text + "',`Rent_time`='" + RentTimeTB.Text + "',`Payment_type`='" + PaymentTypeTB.Text + "'," +
                        "`Order_date`='" + OrderDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "',`Final_price`='" + PriceTB.Text + "',`Adress`='" + AdressTB.Text + "',`Status`='" + Status.Text + "' WHERE ID='" + functionsClass.NeededRow + "' ", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                    functionsClass.Load("SELECT * FROM `orders`", DataGrid);

                }
            }
        }
        string status;
        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {


                if (AutoIdTB.Text == "" || RentTimeTB.Text == "" || PaymentTypeTB.Text == "" || Status.Text == "" || AutoIdTB.Text == "" || RentTimeTB.Text == ""
                    || FamilyTB.Text == "" || NameTB.Text == "" || SecondNameTB.Text == "" || PhoneTB.Text == "" || Series.Text == "" || Number.Text == "" ||
                    FamilyTB.Text == " " || NameTB.Text == " " || SecondNameTB.Text == " " || PhoneTB.Text == " " || Series.Text == " " || Number.Text == " "
                    || PaymentTypeTB.Text == "" || Status.Text == "" || PriceTB.Text == "" || PriceTB.Text == " " || AdressTB.Text == "" || AdressTB.Text == " ")
                {
                    MessageBox.Show("Заполните все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {

                    functionsClass.StringLoad("SELECT Status FROM car_list WHERE Number ='" + AutoIdTB.Text + "'", ref status);
                    if (status == "Занят")
                    {
                        MessageBox.Show("Данный автомобиль уже задействован в другом заказе! ", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        functionsClass.Change("INSERT INTO `orders`(`Auto_Id`, `Rent_time`, `Payment_type`, `Registration_date`, `Order_date`, `Family`, `Name`, `Secondname`, `ClientPhone`, `Passport_series`, `Passport_number`, `Final_price`, `Adress`, `Status`)" +
                        " VALUES ('" + AutoIdTB.Text + "','" + RentTimeTB.Text + "','" + PaymentTypeTB.Text + "','" + DateTime.Now.ToString("yyyy/MM/dd") + "','" + OrderDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "','" + FamilyTB.Text + "','" + NameTB.Text + "','" + SecondNameTB.Text + "','" + PhoneTB.Text + "','" + Series.Text + "','" + Number.Text + "','" + PriceTB.Text + "','" + AdressTB.Text + "','" + Status.Text + "')",
                        "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                        functionsClass.Change("UPDATE `car_list` SET `Status`='Занят' WHERE `Number`='" + AutoIdTB.Text + "'", "Не удалось выполнить операцию!", "Ошибка!", "Автомобиль под номером " + AutoIdTB.Text + " теперь свободен");
                        functionsClass.Load("SELECT * FROM `orders`", DataGrid);
                        functionsClass.ComboLoad("Select Number From car_list", AutoIdTB);

                    }
                }
            
          

        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItems != null)
            {
                functionsClass.GetRow(DataGrid, 1);
                functionsClass.StringLoad("SELECT Status FROM orders WHERE Auto_Id !='" + functionsClass.NeededRow + "'", ref status);
                if (status == "Завершен" || status == "Отменен")
                {
                    MessageBox.Show("Данное действие невозможно", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {

                    functionsClass.GetRow(DataGrid, 0);
                    functionsClass.Change("UPDATE `orders` SET `Status`='Отменен' WHERE `ID`='" + functionsClass.NeededRow + "'", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                    functionsClass.Change("UPDATE car_list SET Status='Свободен' Where Number='" + AutoIdTB.Text + "'", "Неудалось выполнить операцию!", "Ошибка", "Автомобиль под номером " + AutoIdTB.Text + " теперь свободен");
                    functionsClass.Load("SELECT * FROM `orders`", DataGrid);
                }
            }
            else
            {
                MessageBox.Show("Выбирте нужную запись!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView Row in DataGrid.SelectedItems)
            {
                AutoIdTB.Text = Row.Row.ItemArray[1].ToString();
                RentTimeTB.Text = Row.Row.ItemArray[2].ToString();
                PaymentTypeTB.Text = Row.Row.ItemArray[3].ToString();
                OrderDate.Text = Row.Row.ItemArray[5].ToString();
                FamilyTB.Text = Row.Row.ItemArray[6].ToString();
                NameTB.Text = Row.Row.ItemArray[7].ToString();
                SecondNameTB.Text = Row.Row.ItemArray[8].ToString();
                PhoneTB.Text = Row.Row.ItemArray[9].ToString();
                Series.Text = Row.Row.ItemArray[10].ToString();
                Number.Text = Row.Row.ItemArray[11].ToString();
                PriceTB.Text = Row.Row.ItemArray[12].ToString();
                AdressTB.Text = Row.Row.ItemArray[13].ToString();
                Status.Text = Row.Row.ItemArray[14].ToString();
            }

        }


        void Dictionary(MySqlCommand Cmd)
        {

            try
            {
                functionsClass.Connect.Open();
                MySqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    Data.Add(new string[1]);
                    Data[Data.Count - 1][0] = Reader.GetString(0);
                }
                for (int i = 0; i < Data.Count; i++)
                {
                    Filter.Items.Add(Data[i][0]);
                }
                Data.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Неудалось загрузить данные!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                functionsClass.Connect.Close();
            }
        }
        List<string> Rus = new List<string>() { "Тип оплаты", "Статус" };
        List<string> Eng = new List<string>() { "payment_types", "order_statuses" };
        List<string> ColumNames = new List<string>() { "Payment_type ", "Status" };
        bool chek = true;
        string Column;
        private void FilterBT_Click(object sender, RoutedEventArgs e)
        {
            if (Filter.Text != "")
            {
                chek = false;
                Column = "";
                Column = ColumNames[DictionaryCB.SelectedIndex];
                functionsClass.DT.Clear();
                functionsClass.Load("Select * from orders Where " + Column + " = '" + Filter.Text + "'", DataGrid);
                chek = true;
            }
        }

        private void CanelFilter_Click(object sender, RoutedEventArgs e)
        {
            functionsClass.DT.Clear();
            functionsClass.Load("SELECT * FROM `orders`", DataGrid);
            chek = false;
            DictionaryCB.Text = "";
            Filter.Text = "";
            chek = true;
        }

        private void DictionaryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chek)
            {
                Filter.Items.Clear();
                Dictionary(new MySqlCommand("Select * from " + Eng[DictionaryCB.SelectedIndex] + "", functionsClass.Connect));
            }
        }

        private void SearchText(object sender, TextChangedEventArgs e)
        {
            functionsClass.Load("SELECT * FROM `orders`", DataGrid);
            functionsClass.Search(SearchTB);
        }
        void statload()
        {
            xDate = new List<string>();
            yMoney = new List<int>();
            try
            {
                MySqlCommand Cmd = new MySqlCommand("SELECT `Order_date`, `Final_price` FROM `orders` where `Order_date` between '" + FirstDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "' and '" + SecondDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "' and `Status`='Завершен'", functionsClass.Connect);
                functionsClass.Connect.Open();
                MySqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    xDate.Add(Reader.GetString(0).Replace(" 0:00:00", ""));
                    yMoney.Add(Reader.GetInt32(1));
                }
            }
            catch (Exception ez)
            {
                MessageBox.Show("Неудалось загрузить данные!", "Ошибка подключения", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally { functionsClass.Connect.Close(); }
        }
        List<string> xDate;
        List<int> yMoney;
        private void Statistic_Click(object sender, RoutedEventArgs e)
        {
            if (FirstDate.SelectedDate != null || SecondDate.SelectedDate != null)
            {
                Chart.ChartAreas.Clear();
                Chart.Series.Clear();

                statload();
                Chart.ChartAreas.Add(new ChartArea("CUM"));
                Chart.Series.Add(new Series("Series1"));
                Chart.Series["Series1"].ChartArea = "CUM";
                Chart.Series["Series1"].ChartType = SeriesChartType.Column;
                Chart.Series["Series1"].Points.DataBindXY(xDate, yMoney);
            }
        }

        void FindAndReplace(object FindText, object ReplaceText, Word.Application App)
        {
            App.Selection.Find.Execute(ref FindText, true, true, false, false, false, true, false, 1, ref ReplaceText, 2, false, false, false, false);
        }

        private void Word_Click(object sender, RoutedEventArgs e)
        {
            if (FirstDate.SelectedDate != null || SecondDate.SelectedDate != null)
            {
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = "DOCX files(*.docx)|*.docx|All files(*.*)|*.*";
                if (SFD.ShowDialog() == true)
                {
                    try
                    {

                        Word.Application App = new Word.Application();
                        functionsClass.Connect.Open();
                        MySqlCommand Cmd = new MySqlCommand("SELECT `Auto_Id` AS 'Автомобиль',`Order_date` AS 'Дата аренды',`Final_price` AS 'Цена (Руб.)' FROM `orders` WHERE `Order_date` BETWEEN '" + FirstDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "' and '" + SecondDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "' AND `Status` = 'Завершен' union  SELECT 'ИТОГО','', sum(`Final_price`) FROM `orders` WHERE `Order_date` BETWEEN '" + FirstDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "' and '" + SecondDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "'", functionsClass.Connect);
                        DataTable SatsDT = new DataTable();
                        SatsDT.Load(Cmd.ExecuteReader());
                        Word.Document Doc = new Word.Document();
                        Doc.ReadOnlyRecommended = true;
                        string Sa = Directory.GetCurrentDirectory();
                        Doc = App.Documents.Open(Directory.GetCurrentDirectory() + @"\Otchet.docx");
                        FindAndReplace("DATE", DateTime.Now.ToString("dd.MM.yyyy"), App);
                        FindAndReplace("DATENOW", DateTime.Now.ToString("dd.MM.yyyy"), App);
                        FindAndReplace("FIRSTDATE", FirstDate.SelectedDate.Value.ToString("dd.MM.yyyy"), App);
                        FindAndReplace("SECONDDATE", SecondDate.SelectedDate.Value.ToString("dd.MM.yyyy"), App);
                        Word.Table Tab = Doc.Tables[1];
                        for (int i = 0; i < SatsDT.Rows.Count - 1; i++)
                        {
                            Tab.Rows.Add();
                        }
                        for (int i = 0; i < SatsDT.Columns.Count - 1; i++)
                        {
                            Tab.Columns.Add();
                        }
                        int Row = 0, Colums = 0, RowS = 0, Count = 0;
                        foreach (Word.Row row in Tab.Rows)
                        {
                            object[] sa = SatsDT.Rows[RowS].ItemArray;
                            Colums = 0;
                            Row = 0;
                            foreach (Word.Cell item in row.Cells)
                            {
                                if (item.RowIndex == 1)
                                {
                                    item.Range.Bold = 3;
                                    item.Range.Text = SatsDT.Columns[Colums].ColumnName;
                                    Colums++;
                                }
                                else
                                {
                                    item.Range.Text = sa[Row].ToString();
                                    Row++;
                                }
                            }
                            Count++;
                            RowS++;
                            if (Count == RowS)
                            { RowS = RowS - 1; }
                        }
                        Doc.SaveAs(FileName: SFD.FileName);
                        App.Documents.Open(System.IO.Path.Combine(Doc.Path, Doc.Name));
                        App.Documents.Close();
                    }
                    catch (Exception) { functionsClass.Connect.Close(); }

                }
            }
            else
            {
                MessageBox.Show("Выбирите необходимые даты!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        int Days;
        int FinalPrice;
        int Count;
        string Model;
        string Price;
        private void AutoIdTB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (AutoIdTB.Text != "")
                {
                    FinalPrice = 0;
                    functionsClass.StringLoad("SELECT `Model` FROM `car_list` WHERE `Number`='" + AutoIdTB.SelectedItem.ToString() + "' ", ref Model);
                    functionsClass.StringLoad("SELECT `Price` FROM `models` WHERE `Model`='" + Model + "'", ref Price);
                    PriceTB.Text = Price;
                    FinalPrice = Convert.ToInt32(Price);
                }
            }
            catch (Exception)
            {
                AutoIdTB.Text = "";

            }

        }

        private void RentTimeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            PriceTB.Text = FinalPrice.ToString();
            if (RentTimeTB.Text != "")
            {

                Days = Convert.ToInt32(RentTimeTB.Text);
                Count = FinalPrice * Days;
                PriceTB.Text = Count.ToString();
            }
        }

        private void PhoneTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        bool Phone = false;
        private void Mask(object sender, TextChangedEventArgs e)
        {
            if (!Phone)
            {

                Phone = true;
                string str = ((TextBox)sender).Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "");
                ((TextBox)sender).Text = "+";

                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 1)
                    {
                        ((TextBox)sender).Text += "(";
                    }
                    if (i == 4)
                    {
                        ((TextBox)sender).Text += ")";
                    }
                    if (i == 7)
                    {
                        ((TextBox)sender).Text += "-";
                    }
                    if (i == 9)
                    {
                        ((TextBox)sender).Text += "-";
                    }
                    ((TextBox)sender).Text += str[i];
                }
                Phone = false;
            }
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            //if (SP != null)
            //{
            //    SP.IsEnabled = false;
            InsertBT.IsEnabled = true;
            UpdateBT.IsEnabled = true;
            // }
        }
        private void PhoneTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            Mask(sender, e);
        }


        private void EmailTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void FinishBT_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItems != null)
            {
                functionsClass.GetRow(DataGrid, 1);
                functionsClass.StringLoad("SELECT Status FROM orders WHERE Auto_Id !='" + functionsClass.NeededRow + "'", ref status);
                if (status == "Завершен" || status == "Отменен")
                {
                    MessageBox.Show("Данное действие невозможно", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    functionsClass.GetRow(DataGrid, 0);
                    functionsClass.Change("UPDATE orders SET Status='Завершен' WHERE ID='" + functionsClass.NeededRow + "'", "Неудалось выполнить операцию!", "Ошибка", "Заказ успешно завершен!");
                    functionsClass.Change("UPDATE car_list SET Status='Свободен' Where Number='" + AutoIdTB.Text + "'", "Неудалось выполнить операцию!", "Ошибка", "Автомобиль под номером " + AutoIdTB.Text + " теперь свободен");
                    functionsClass.Load("SELECT * FROM `orders`", DataGrid);
                }
            }
            else
            {
                MessageBox.Show("Выбирте нужную запись!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        string Family;
        string Name;
        string SecondName;
        private void ContractBT_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.SelectedItem!=null)
            {
                functionsClass.GetRow(DataGrid, 0);
                functionsClass.StringLoad("SELECT `Family` FROM `orders` WHERE `ID`= '"+functionsClass.NeededRow+"'", ref Family);
                functionsClass.StringLoad("SELECT `Name` FROM `orders` WHERE `ID`='" + functionsClass.NeededRow + "' ", ref Name);
                functionsClass.StringLoad("SELECT `SecondName` FROM `orders` WHERE `ID`='" + functionsClass.NeededRow + "' ", ref SecondName);
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.Filter = "DOCX files(*.docx)|*.docx|All files(*.*)|*.*";
                if (SFD.ShowDialog() == true)
                {
                    try
                    {
                        Word.Application App = new Word.Application();
                        functionsClass.Connect.Open();
                        MySqlCommand Cmd = new MySqlCommand("SELECT `Auto_Id` AS 'Номер автомобиля', `Rent_time` AS 'Время аренды (сутки)', `Registration_date` AS 'Дата оформления', `Order_date` AS 'Дата начала аренды', `Final_price`AS 'Итоговая стоимость (Руб.)', `Adress` AS 'Адресс доставки', `Status`AS 'Статус заказа' FROM `orders` WHERE `ID`= '" + functionsClass.NeededRow + "'", functionsClass.Connect);
                        DataTable SatsDT = new DataTable();
                        SatsDT.Load(Cmd.ExecuteReader());
                        Word.Document Doc = new Word.Document();
                        Doc.ReadOnlyRecommended = true;
                        string Sa = Directory.GetCurrentDirectory();
                        Doc = App.Documents.Open(Directory.GetCurrentDirectory() + @"\Contract.docx");
                        FindAndReplace("DATE", DateTime.Now.ToString("dd.MM.yyyy"), App);
                        FindAndReplace("DATENOW", DateTime.Now.ToString("dd.MM.yyyy"), App);
                        FindAndReplace("ORDERNUM", functionsClass.NeededRow, App);
                        FindAndReplace("FAMILY", Family, App);
                        FindAndReplace("NAME", Name, App);
                        FindAndReplace("SECONDNAME", SecondName, App);
                        Word.Table Tab = Doc.Tables[1];
                        for (int i = 0; i < SatsDT.Rows.Count - 1; i++)
                        {
                            Tab.Rows.Add();
                        }
                        for (int i = 0; i < SatsDT.Columns.Count - 1; i++)
                        {
                            Tab.Columns.Add();
                        }
                        int Row = 0, Colums = 0, RowS = 0, Count = 0;
                        foreach (Word.Row row in Tab.Rows)
                        {
                            object[] sa = SatsDT.Rows[RowS].ItemArray;
                            Colums = 0;
                            Row = 0;
                            foreach (Word.Cell item in row.Cells)
                            {
                                if (item.RowIndex == 1)
                                {
                                    item.Range.Bold = 3;
                                    item.Range.Text = SatsDT.Columns[Colums].ColumnName;
                                    Colums++;
                                }
                                else
                                {
                                    item.Range.Text = sa[Row].ToString();
                                    Row++;
                                }
                            }
                            Count++;
                            RowS++;
                            if (Count == RowS)
                            { RowS = RowS - 1; }
                        }
                        Doc.SaveAs(FileName: SFD.FileName);
                        App.Documents.Open(System.IO.Path.Combine(Doc.Path, Doc.Name));
                        App.Documents.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    finally
                    {
                        functionsClass.Connect.Close();
                    }


                }
            } 
        }

        private void PhoneTB_PreviewKeyDown(object sender, KeyEventArgs e)
        {

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


