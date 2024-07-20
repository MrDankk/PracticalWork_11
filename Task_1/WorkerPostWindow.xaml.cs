using System.Windows;

namespace Task_1
{
    /// <summary>
    /// Логика взаимодействия для WorkerPostWindow.xaml
    /// </summary>
    public partial class WorkerPostWindow : Window
    {
        MainWindow MainWindow;

        public WorkerPostWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
        }

        private void ConsultantChoice(object sender, RoutedEventArgs e)
        {
            MainWindow.WorkerPostChoice(0);
            this.Close();
        }

        private void ManagerChoice(object sender, RoutedEventArgs e)
        {
            MainWindow.WorkerPostChoice(1);
            this.Close();
        }
    }
}
