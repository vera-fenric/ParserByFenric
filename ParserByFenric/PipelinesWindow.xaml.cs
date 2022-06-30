using System;
using System.Windows;
using System.Windows.Controls;
using ViewModel;
using System.IO;

namespace ParserByFenric
{
    public partial class PipelinesWindow : Window
    {
        //сам парсер
        private ViewModelStatus vm;

        //инициализация окна в двух вариантах: если есть интерфейс и если нет
        public PipelinesWindow()
        {
            InitializeComponent();
            vm = new ViewModelStatus(new UIServices());
            DataContext = vm;
        }
        public PipelinesWindow(IUIServices uis)
        {
            InitializeComponent();
            vm = new ViewModelStatus(uis);
            DataContext = vm;
        }

        //обработчик кнопки "Начать заново"
        private void New(object sender, RoutedEventArgs e)
        {
            vm = new ViewModelStatus(new UIServices());
            DataContext = vm;
        }

        //обработчик кнопки "Выбрать файлы"
        private void OpenFiles(object sender, RoutedEventArgs e)
        {
            vm.OpenFiles();
        }

        //обработчик кнопки "Сохранить"
        private void Save(object sender, RoutedEventArgs e)
        {
            vm.SaveResults();
        }

        //обработчик кнопки "Запустить"
        private void Parse(object sender, RoutedEventArgs e)
        {
            vm.Parse();
        }

        //обработчик кнопки "Выход"
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
            Owner.Close();
        }


        //обработчик кнопки "Выход в главное меню"
        private void ToMenu(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //обработчик процесса закрытия
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = vm.Closing();
        }

        //обработчик закрытия
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        //обработчик смены выбора в колонке со списком файлов (по-хорошему нужно переместить в модель)
        public void SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            string filename = InputFiles.SelectedItem.ToString();
            try
            {
                StreamReader sr = new StreamReader(filename, false);
                SelectedFile.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
