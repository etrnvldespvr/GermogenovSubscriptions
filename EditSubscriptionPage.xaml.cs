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

namespace GermogenovSubscriptions
{
    public partial class EditSubscriptionPage : Page
    {
        private MainWindow _mainWindow;
        private Subscription _subscription;

        public EditSubscriptionPage(MainWindow mainWindow, Subscription subscription)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _subscription = subscription;

            // Инициализация ComboBox
            PaymentMethodComboBox.ItemsSource = mainWindow.PaymentMethods;
            PlanComboBox.ItemsSource = mainWindow.SubscriptionPlans;

            // Установка выбранных значений
            PaymentMethodComboBox.SelectedItem = _subscription.PaymentMethod;
            PlanComboBox.SelectedItem = _subscription.Plan;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateToMainPage();
        }

        private void DeleteSubscription_Click(object sender, RoutedEventArgs e)
        {
            _subscription.CancelSubscription();
            MessageBox.Show("Подписка удалена");
            _mainWindow.NavigateToMainPage();
        }

        private void PaymentMethodComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обновляем PaymentMethod подписки
            if (PaymentMethodComboBox.SelectedItem != null)
            {
                _subscription.PaymentMethod = PaymentMethodComboBox.SelectedItem.ToString();
            }
        }

        private void PlanComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обновляем Plan подписки
            if (PlanComboBox.SelectedItem != null)
            {
                _subscription.Plan = PlanComboBox.SelectedItem.ToString();
            }
        }
    }
}
