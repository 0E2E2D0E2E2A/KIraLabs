using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    class Skaner
    {
        public string Name { get; set; }
        public string DPI { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }


        public Skaner(string Name, string DPI, string Type, string Color)
        {
            this.Name = Name;
            this.DPI = DPI;
            this.Type = Type;
            this.Color = Color;
        }
    }

    public partial class MainWindow : Window
    {
        ObservableCollection<Skaner> items;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            items = new ObservableCollection<Skaner>();
            dataGrid.ItemsSource = items;

            items.Add(new Skaner("имя", "dpi", "тип сканера", "цвет"));
            items.Add(new Skaner("имя", "dpi", "тип сканера", "цвет"));
            items.Add(new Skaner("имя", "dpi", "тип сканера", "цвет"));
            items.Add(new Skaner("имя", "dpi", "тип сканера", "цвет"));
        }

        private void Add_btn_Click_1_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox_Name.Text;
            string power = textBox_DPI.Text;
            string volume = textBox_Type.Text;
            string color = textBox_Color.Text;

            items.Add(new Skaner(name, power, volume, color));


            textBox_Name.Text = null;
            textBox_DPI.Text = null;
            textBox_Type.Text = null;
            textBox_Color.Text = null;
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var index = dataGrid.SelectedIndex;

                dataGrid.Items.RemoveAt(index);
            }
        }

        private void delete_btn_Click_1_Click(object sender, RoutedEventArgs e)
        {
            var index = dataGrid.SelectedIndex;

            try
            {
                items.RemoveAt(index);
            }
            catch
            {
                MessageBox.Show("Ошибка! Вы не выбрали элемент, который нужно удалить");
            }
        }

        private void dataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var items = dataGrid.SelectedItem as Skaner;

            //DataRowView data = (DataRowView)dataGrid.SelectedItems[0];
            //textBox_Name.Text = data.ToString();

            try
            {
                textBox_Name.Text = items.Name;
                textBox_DPI.Text = items.DPI;
                textBox_Type.Text = items.Type;
                textBox_Color.Text = items.Color;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Null");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}