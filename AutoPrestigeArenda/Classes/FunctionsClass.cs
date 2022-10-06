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

namespace AutoPrestigeArenda
{
    class FunctionsClass
    {
        
       //НОУТ 
       //public MySqlConnection Connect = new MySqlConnection("server=localhost; userid=root;password=;database=arenda_auto;port=3306;");
        //ПК 
        public MySqlConnection Connect = new MySqlConnection("server=127.0.0.1; userid=root;password=;database=arenda_auto;port=3310;");
        public void Change(string Cmd, string Message, string ErrorType, string sucsessMessage)
        {
            try
            {
                MySqlCommand Command = new MySqlCommand(Cmd, Connect);
                Connect.Open();
                Command.ExecuteNonQuery();
                System.Windows.MessageBox.Show(sucsessMessage, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(Message, ErrorType, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Connect.Close();
            }
        }
        public void StringLoad(string Cmd, ref string str) 
        {
            try
            {
                MySqlCommand Command = new MySqlCommand(Cmd, Connect);
                Connect.Open();
                MySqlDataReader Data = Command.ExecuteReader();
                if (Data.Read())
                {
                    str = Data[0].ToString();
                }

            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show("Не удалось загрузить данные!", "Ошибка загрузки!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Connect.Close();
            }
        }

        public DataTable DT;
        public void Load(string Cmd, DataGrid dataGrid)
        {
            DT = new DataTable();
            try
            {
                MySqlCommand Command = new MySqlCommand(Cmd, Connect);
                Connect.Open();
                DT.Load(Command.ExecuteReader());
                dataGrid.DataContext = DT;
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show("Не удалось загрузить данные!", "Ошибка загрузки!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            { 
                Connect.Close(); 
            }

        }

        public void ComboLoad(string Cmd, ComboBox comboBox)
        {
            List<string[]> Data = new List<string[]>();
            try
            {
                MySqlCommand Command = new MySqlCommand(Cmd, Connect);
                Connect.Open();
                MySqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Data.Add(new string[1]);
                    Data[Data.Count - 1][0] = Reader.GetString(0);
                }
                for (int i = 0; i < Data.Count; i++)
                {
                    comboBox.Items.Add(Data[i][0]);
                }
                Data.Clear();

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Не удалось загрузить данные!", "Ошибка загрузки!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Connect.Close(); 
            }
        }

        public void Search(TextBox textBox)
        {
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                int Count = 0;
                List<object> sa = DT.Rows[i].ItemArray.ToList();
                foreach (var item in sa)
                {
                    if (item.ToString().ToLower().Contains(textBox.Text.ToLower()))
                        Count++;
                }
                if (Count == 0)
                {
                    DT.Rows.RemoveAt(i);
                    i--;
                }
            }
        }
        public string NeededRow;
        public void GetRow(DataGrid dataGrid, int i)
        {
            NeededRow = "";
            foreach (DataRowView Row in dataGrid.SelectedItems)
            {
                NeededRow = Row.Row.ItemArray[i].ToString();
            }
        }
        public BitmapImage LoadImage(byte[] imageData)
        {
            BitmapImage image = new BitmapImage();
            if (imageData == null || imageData.Length == 0) return null;
            using (var mem = new MemoryStream(imageData))
            {
                try
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            image.Freeze();
            return image;
        }
        public void ImageBox(string Cmd, Image ImageBox) 
        {
            try
            {
                Connect.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(Cmd, Connect);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                byte[] image = new byte[0];
                while (reader.Read())
                {
                    if (reader.GetValue(0).GetType().FullName != "System.DBNull")
                    {
                        image = (byte[])reader.GetValue(0);
                    }
                }
                ImageBox.Source = LoadImage(image);
            }
            catch (Exception err)
            {
                System.Windows.MessageBox.Show("Не удалось загрузить изображение!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                Connect.Close();
            }
            
        }
        public void UploadPicture(string Cmd, TextBox textBox, Image image) 
        {
            try
            {
                MySqlCommand CmdPhoto = new MySqlCommand(Cmd,Connect);
                byte[] BitImage = null;
                FileStream FStream = new FileStream(textBox.Text, FileMode.Open, FileAccess.Read);
                BinaryReader BR = new BinaryReader(FStream);
                BitImage = BR.ReadBytes((int)FStream.Length);
                Connect.Open();
                CmdPhoto.Parameters.Add(new MySqlParameter("@img", BitImage));
                CmdPhoto.ExecuteNonQuery();
                image.Source = null;
                textBox.Clear();
            }
            catch (Exception err)
            {

                System.Windows.MessageBox.Show("Не удалось импортировать изображение!", "Ошибка загрузки!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Connect.Close();
            }

        }
        public void MaskAuto(TextBox TB)
        {
            string Enter = "УКЕНХАВРОМСТукенхавромст";
            string Enter2 = "1234567890";
            TB.Text = TB.Text.ToUpper();
            int i = 0;
            foreach (var item in TB.Text)
            {
                if (i == 0)
                {
                    if (Enter.Contains(item)) 
                    {
                    
                    }
                    else
                    {
                        TB.Text = TB.Text.Substring(0, TB.Text.Length - 1);
                    }
                }
                if (i == 1 || i == 2 || i == 3)
                {
                    if (Enter2.Contains(item)) 
                    {
                    
                    }
                    else
                    {
                        if (TB.Text.Length != 0)
                        {
                            TB.Text = TB.Text.Substring(0, TB.Text.Length - 1);
                        }
                    }
                }
                if (i == 4 || i == 5)
                {
                    if (Enter.Contains(item))
                    {
                    
                    }
                    else
                    {
                        if (TB.Text.Length > 0)
                        {
                            if (TB.Text.Length <= 6)
                            {
                                TB.Text = TB.Text.Substring(0, TB.Text.Length - 1);
                                TB.Text = TB.Text.Substring(0, TB.Text.Length - 1);
                            }
                        }
                    }
                }
                TB.SelectionStart = TB.Text.Length;
                i++;
            }
        }
    }
}
