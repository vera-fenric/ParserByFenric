using System.Windows;
using ViewModel;


namespace ParserByFenric
{
    public partial class MainWindow : Window
    {
        //определение интерфейсов
        private IUIServices UI = new UIServices();

        //конструктор
        public MainWindow()
        {
            InitializeComponent();
        }

        //обработчик кнопки тегов
        private void OpenWindow_Tags(object sender, RoutedEventArgs e)
        {
            BaseWindow window = new BaseWindow(UI, ParseType.Tag);
            window.Owner = this;
            window.Show();
            this.Hide();
        }

        //обработчик кнопки Воронок
        private void OpenWindow_Pipelines(object sender, RoutedEventArgs e)
        {
            BaseWindow window = new BaseWindow(UI, ParseType.Pipeline);
            window.Owner = this;
            window.Show();
            this.Hide();
        }

        //обработчик кнопки статусов
        private void OpenWindow_Statuses(object sender, RoutedEventArgs e)
        {
            BaseWindow window = new BaseWindow(UI, ParseType.Status);
            window.Owner = this;
            window.Show();
            this.Hide();
        }

        private void OpenWindow_Users(object sender, RoutedEventArgs e)
        {
            BaseWindow window = new BaseWindow(UI, ParseType.User);
            window.Owner = this;
            window.Show();
            this.Hide();
        }

        //обработчик кнопки выхода
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
