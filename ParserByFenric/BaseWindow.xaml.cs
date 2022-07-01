using System;
using System.Windows;
using System.Windows.Controls;
using ViewModel;
using System.IO;

namespace ParserByFenric
{
    public partial class BaseWindow : Window
    {
        private ParseType pt;
        private ViewModelRegular vm;
        private IUIServices uis;

        //инициализация окна
        public BaseWindow(IUIServices uis, ParseType pt)
        {
            this.pt = pt;
            this.uis = uis;
            InitializeComponent();
            switch (pt)
            {
                case ParseType.Tag:
                    vm = new ViewModelTag(uis);
                    break;
                case ParseType.Pipeline:
                    vm = new ViewModelPipeline(uis);
                    break;
                case ParseType.Status:
                    vm = new ViewModelStatus(uis);
                    break;
                case ParseType.User:
                    vm = new ViewModelUser(uis);
                    break;
            }
            DataContext = vm;
            return;
        }

        //обработчик кнопки "Начать заново"
        private void New(object sender, RoutedEventArgs e)
        {
            switch (pt)
            {
                case ParseType.Tag:
                    vm = new ViewModelTag(uis);
                    break;
                case ParseType.Pipeline:
                    vm = new ViewModelPipeline(uis);
                    break;
                case ParseType.Status:
                    vm = new ViewModelStatus(uis);
                    break;
                case ParseType.User:
                    vm = new ViewModelUser(uis);
                    break;
            }
            DataContext = vm;
            return;
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
