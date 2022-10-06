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
using System.Windows.Forms;


namespace AutoPrestigeArenda
{
    /// <summary>
    /// Логика взаимодействия для ManagerBuy.xaml
    /// </summary>
    public partial class ManagerBuy : Window
    {
        public ManagerBuy()
        {
            InitializeComponent();
            functionsClass.Load("SELECT * FROM `car_list`", Cars);
            functionsClass.Load("SELECT * FROM `models`", ModelsTabel);
            functionsClass.ComboLoad("SELECT * FROM `class_auto`",  ClassTB); 
            functionsClass.ComboLoad("SELECT `Brand` FROM `brand_list`",  BrandTB); 
            functionsClass.ComboLoad("SELECT * FROM `driver_units`",  DriverUnitTB); 
            functionsClass.ComboLoad("SELECT * FROM `transmission_types`", TransmissionTB); 
            functionsClass.ComboLoad("SELECT * FROM `car_statuses`",Status);
            functionsClass.ComboLoad("SELECT `Model` FROM `models` WHERE `Count`>'0'", ModelCB);
            ModelsDictionaryCB.ItemsSource = ModelsRus;
            DictionaryCB.ItemsSource = CarsRus;
        }

        FunctionsClass functionsClass = new FunctionsClass();
       
      
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Login = new MainWindow();
            Login.Show();
            Close();
        }
     
        

        private void A_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Car_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                functionsClass.GetRow(Cars, 1);
                functionsClass.ImageBox("SELECT Photo FROM photos WHERE `Model`='" + functionsClass.NeededRow + "'", Photo);
                foreach (DataRowView Row in Cars.SelectedItems)
                {
                    NumberTB.Text = Row.Row.ItemArray[0].ToString();
                    ModelCB.Text = Row.Row.ItemArray[1].ToString();
                    DriverUnitTB.Text = Row.Row.ItemArray[2].ToString();
                    ComputerTB.Text = Row.Row.ItemArray[3].ToString();
                    TransmissionTB.Text = Row.Row.ItemArray[4].ToString();
                    Status.Text = Row.Row.ItemArray[5].ToString();


                }
            }
            catch (Exception)
            {

                
            }
           
        }
        List<string> CarsRus = new List<string>() { "Модель", "Привод", "Бортовой компьютер", "Коробка передач","Статус автомобиля" };
        List<string> CarsEng = new List<string>() { "models", "driver_units", "onboard_computer", "transmission_types", "car_statuses"};
        List<string> CarsColumNames = new List<string>() { "Model","Drive_unit", "Onboard_computer", "Transmission", "Status" };
        List<string> ModelsRus = new List<string>() { "Производители", "Классы автомобилей" };
        List<string> ModelsEng = new List<string>() { "brand_list", "class_auto"};
        List<string> ModelsColumNames = new List<string>() { "Brand", "Class"};

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {

            if (NumberTB.Text == "" || DriverUnitTB.Text == "" || ComputerTB.Text == "" || TransmissionTB.Text == "" ||Status.Text == "" ||
                NumberTB.Text == " " || DriverUnitTB.Text == " " || ComputerTB.Text == " " || TransmissionTB.Text == " " || Status.Text == " ")
            {
                System.Windows.MessageBox.Show("Должны быть заполнены все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                
                functionsClass.Change("INSERT INTO `car_list`(`Number`, `Model`, `Drive_unit`, `Onboard_computer`, `Transmission`, `Status`) VALUES ('" + NumberTB.Text + "','" + ModelTB.Text + "','" + DriverUnitTB.Text + "','" + ComputerTB.Text + "','" + TransmissionTB.Text + "','" + Status.Text + "')", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                functionsClass.Load("SELECT * FROM `car_list`", Cars);
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {

            if (Cars.SelectedItem != null)
            {
                if (NumberTB.Text == "" || DriverUnitTB.Text == "" || ComputerTB.Text == "" || TransmissionTB.Text == "" || Status.Text == "" ||
               NumberTB.Text == " " || DriverUnitTB.Text == " " || ComputerTB.Text == " " || TransmissionTB.Text == " " || Status.Text == " ")
                {

                    System.Windows.MessageBox.Show("Должны быть заполнены все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    functionsClass.GetRow(Cars, 0);
                    functionsClass.Change("UPDATE `car_list` SET `Number`='" + NumberTB.Text + "',`Model`='" + ModelCB.Text + "',`Drive_unit`='" + DriverUnitTB.Text + "',`Onboard_computer`= '" + ComputerTB.Text + "',`Transmission`='" + TransmissionTB.Text + "' ,`Status`= '" + Status.Text + "' WHERE `Model`='" + functionsClass.NeededRow + "'", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                    functionsClass.Load("SELECT * FROM `car_list`", Cars);
                }
            }
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedItem!=null)
            {
               functionsClass.GetRow(Cars,0);
               functionsClass.Change("UPDATE `car_list` SET `Status`='Списан' WHERE `Number` = '" + functionsClass.NeededRow+"'", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
               functionsClass.Load("SELECT * FROM `car_list`", Cars);
            }
        }
    
        
        bool chek = true;
        string Column;
        private void DictionaryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chek)
            {
                Filter.Items.Clear();
                functionsClass.ComboLoad("Select * from " + CarsEng[DictionaryCB.SelectedIndex] + "", Filter);
            }
        }

        private void FilterBT_Click(object sender, RoutedEventArgs e)
        {
            if (Filter.Text != "")
            {
                functionsClass.DT.Clear();
                chek = false;
                Column = "";
                Column = CarsColumNames[DictionaryCB.SelectedIndex];
                functionsClass.Load("Select * from car_list Where " + Column + " = '" + Filter.Text + "'", Cars);
                chek = true;
            }
            else
            {
                System.Windows.MessageBox.Show("Выбирите фильтры!!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
        }

        private void CanelFilter_Click(object sender, RoutedEventArgs e)
        {
            functionsClass.DT.Clear();
            functionsClass.Load("SELECT * FROM `car_list`", Cars);
            chek = false;
            DictionaryCB.Text = "";
            Filter.Text = "";
            chek = true;
        }
       
        private void SearchText(object sender, TextChangedEventArgs e)
        {
            functionsClass.Load("SELECT * FROM `car_list`", Cars);
            functionsClass.Search(SearchTB);

        }

        private void AddPicture_Click(object sender, RoutedEventArgs e)
        {
            
            
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Image|*.png;*.jpg";
            OFD.ShowDialog();
            PictureTB.Text = OFD.FileName;

           
                try
                {
                    var size = new FileInfo(OFD.FileName).Length;

                     if (size < 83886080)
                     {
                      
                        var Picture = new Uri(PictureTB.Text);
                        var bitmap = new BitmapImage(Picture);
                        ModelPhoto.Source = bitmap;
                     }
                    else
                    {
                    System.Windows.MessageBox.Show("Слишком большой размер изображения!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                }
                catch (Exception err)
                {
                    System.Windows.MessageBox.Show("Выбирите фото!","Внимание",MessageBoxButton.OK, MessageBoxImage.Warning);
                    ModelPhoto.Source = null;
                }
          

        }

        private void SearchModelTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            functionsClass.Load("SELECT * FROM `models`", ModelsTabel);
            functionsClass.Search(SearchModelTB);
        }

        private void InsertModelBT_Click(object sender, RoutedEventArgs e)
        {
            if (ModelCB.Text == "" || BrandTB.Text == "" || ClassTB.Text == "" || CountTB.Text == "" || PriceTB.Text == "" ||
             ModelCB.Text == " " || BrandTB.Text == " " || ClassTB.Text == " " || CountTB.Text == " " || PriceTB.Text == " " || PictureTB.Text==""|| PictureTB.Text == " ")
            {
                System.Windows.MessageBox.Show("Необходимо заполнить все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else 
            {
                functionsClass.Change("INSERT INTO `models`(`Model`, `Brand`, `Class`, `Count`, `Price`) VALUES ('" + ModelTB.Text + "','" + BrandTB.Text + "','" + ClassTB.Text + "','" + CountTB.Text + "', '" + PriceTB.Text + "')", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                functionsClass.UploadPicture("INSERT INTO photos (`Model`, `Photo`) VALUE ('" + ModelTB.Text + "', @img)", PictureTB, ModelPhoto);
               
            }
            functionsClass.Load("SELECT * FROM `car_list`", Cars);
            functionsClass.Load("SELECT * FROM `models`", ModelsTabel); 
            functionsClass.ComboLoad("SELECT `Model` FROM `models` WHERE `Count`>'0'", ModelCB);
            ModelsDictionaryCB.ItemsSource = ModelsRus;
            DictionaryCB.ItemsSource = CarsRus;
            
        }

        private void DeleteModelBT_Click(object sender, RoutedEventArgs e)
        {
            if (ModelsTabel.SelectedItem!=null)
            {

            
            if (functionsClass.NeededRow != "" || ModelsTabel.SelectedItem != null)
            {
                functionsClass.GetRow(ModelsTabel, 0);
                functionsClass.Change("DELETE FROM `models` WHERE `Model`='" + functionsClass.NeededRow + "'", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
            }
            else 
            {
                System.Windows.MessageBox.Show("Выбирите элемент!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            functionsClass.Load("SELECT * FROM `car_list`", Cars);
            functionsClass.Load("SELECT * FROM `models`", ModelsTabel);
            functionsClass.ComboLoad("SELECT `Model` FROM `models` WHERE `Count`>'0'", ModelCB);
            ModelsDictionaryCB.ItemsSource = ModelsRus;
            DictionaryCB.ItemsSource = CarsRus;
            }


        }

        private void UpdateModelBT_Click(object sender, RoutedEventArgs e)
        {
            if (functionsClass.NeededRow != "" || ModelsTabel.SelectedItem != null)
            {
                if (ModelCB.Text == "" || BrandTB.Text == "" || ClassTB.Text == "" || CountTB.Text == "" ||
                 ModelCB.Text == " " || BrandTB.Text == " " || ClassTB.Text == " " || CountTB.Text == " ")
                {
                    System.Windows.MessageBox.Show("Необходимо заполнить все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
                else
                {

                    functionsClass.GetRow(ModelsTabel, 0);
                    functionsClass.Change("UPDATE `models` SET `Model`='" + ModelTB.Text + "',`Brand`='" + BrandTB.Text + "',`Class`='" + ClassTB.Text + "',`Count`='" + CountTB.Text + "', `Price`='" + PriceTB.Text + "' WHERE `Model`='" + functionsClass.NeededRow + "'", "Не удалось выполнить операцию!", "Ошибка!", "Успешно!");
                    if (PictureTB.Text != "")
                    {
                        functionsClass.UploadPicture("UPDATE `photos` SET `Photo`= @img Where `Model`='" + functionsClass.NeededRow + "'", PictureTB, ModelPhoto);
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Выбирите элемент!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            functionsClass.Load("SELECT * FROM `car_list`", Cars);
            functionsClass.Load("SELECT * FROM `models`", ModelsTabel);
            functionsClass.ComboLoad("SELECT `Model` FROM `models` WHERE `Count`>'0'", ModelCB);
            ModelsDictionaryCB.ItemsSource = ModelsRus;
            DictionaryCB.ItemsSource = CarsRus;
        }

        private void ModelsTabel_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (DataRowView Row in ModelsTabel.SelectedItems)
            {
                ModelTB.Text = Row.Row.ItemArray[0].ToString();
                BrandTB.Text = Row.Row.ItemArray[1].ToString();
                ClassTB.Text = Row.Row.ItemArray[2].ToString();
                CountTB.Text = Row.Row.ItemArray[3].ToString();
                PriceTB.Text = Row.Row.ItemArray[4].ToString();

            }
            functionsClass.GetRow(ModelsTabel, 0);
            functionsClass.ImageBox("SELECT Photo FROM photos WHERE `Model`='" + functionsClass.NeededRow + "'", ModelPhoto);
           
        }
      
        private void NumberTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            functionsClass.MaskAuto(NumberTB);
        }
        bool cheka = true;
        string Columna;
        private void ModelsFilterBT_Click(object sender, RoutedEventArgs e)
        {
            if (ModelsFilter.Text != "")
            {
                functionsClass.DT.Clear();
                cheka = false;
                Columna = "";
                Columna = ModelsColumNames[ModelsDictionaryCB.SelectedIndex];
                functionsClass.Load("Select * from `models` Where " + Columna + " = '" + ModelsFilter.Text + "'", ModelsTabel);
                cheka = true;
            }
            else
            {
                System.Windows.MessageBox.Show("Выбирите фильтры!!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
      
        private void ModelsCanelFilter_Click(object sender, RoutedEventArgs e)
        {
            functionsClass.DT.Clear();
            functionsClass.Load("SELECT * FROM `models`", ModelsTabel);
            cheka = false;
            ModelsDictionaryCB.Text = "";
            ModelsFilter.Text = "";
            cheka = true;
        }
      
        private void ModelsDictionaryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cheka)
            {
                ModelsFilter.Items.Clear();
                functionsClass.ComboLoad("Select * from " + ModelsEng[ModelsDictionaryCB.SelectedIndex] + "", ModelsFilter);
            }
        }

        private void PriceTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != ".")
            {
                e.Handled = !(Char.IsDigit(e.Text, 0));  
            }
        }

        private void NumberTB_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
