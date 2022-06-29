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
            TagsWindow tagsWindow = new TagsWindow(UI);
            tagsWindow.Owner = this;
            tagsWindow.Show();
            this.Hide();
        }

        //обработчик кнопки выхода
        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
