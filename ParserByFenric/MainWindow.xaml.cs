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
            TagsWindow window = new TagsWindow(UI);
            window.Owner = this;
            window.Show();
            this.Hide();
        }

        //обработчик кнопки статусов
        private void OpenWindow_Pipelines(object sender, RoutedEventArgs e)
        {
            PipelinesWindow window = new PipelinesWindow(UI);
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
