using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GermogenovSubscriptions
{
    public partial class MainPage : Page
    {
        private MainWindow _mainWindow;
        public ObservableCollection<Subscription> Subscriptions { get; set; }

        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = _mainWindow; // Используем контекст данных из MainWindow

            // Привязка существующего списка подписок из MainWindow
            Subscriptions = _mainWindow.Subscriptions;
        }

        private void EditSubscription_Click(object sender, RoutedEventArgs e)
        {
            if (SubscriptionListView.SelectedItem is Subscription selectedSubscription)
            {
                _mainWindow.NavigateToEditPage(selectedSubscription);
            }
            else
            {
                MessageBox.Show("Подписка не выбрана");
            }
        }
    }
}
