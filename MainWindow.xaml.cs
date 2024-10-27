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
    public partial class MainWindow : Window
    {
        public ObservableCollection<Subscription> Subscriptions { get; set; }
        public Subscription SelectedSubscription { get; set; }
        public List<string> PaymentMethods { get; } = new List<string> { "Карта", "Кошелек", "Банковский перевод" };
        public List<string> SubscriptionPlans { get; } = new List<string> { "Базовый", "Премиум", "Ультимативный" };
        public Subscription selectedSubscription { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Пример данных
            Subscriptions = new ObservableCollection<Subscription>
            {
                new Subscription { ServiceName = "Spotify", NextPaymentDate = "01.11.2024 00:00:00", MonthlyCost = "5 долл.", PaymentMethod = "Карта", Plan = "Базовый", IsPlanAvailable = true },
                new Subscription { ServiceName = "Yandex Plus", NextPaymentDate = "01.11.2024 00:00:00", MonthlyCost = "399 руб.", PaymentMethod = "Карта", Plan = "Базовый", IsPlanAvailable = false },
                new Subscription { ServiceName = "Dota Plus", NextPaymentDate = "01.11.2024 00:00:00", MonthlyCost = "389 руб.", PaymentMethod = "Карта", Plan = "", IsPlanAvailable = true }
            };

            MainFrame.Navigate(new MainPage(this));
        }

        private void SubscriptionListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedSubscription = (Subscription)((ListView)sender).SelectedItem;
        }

        private void EditSubscription_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSubscription != null)
            {
                // Проверка, отменена ли подписка
                if (SelectedSubscription.IsCanceled)
                {
                    MessageBox.Show("Подписка отменена. Невозможно редактировать.");
                    return; // Прерываем выполнение, если подписка отменена
                }

                var editPage = new EditSubscriptionPage(this, SelectedSubscription);
                MainFrame.Navigate(editPage);
            }
            else
            {
                MessageBox.Show("Подписка не выбрана");
            }
        }


        private void DeleteSubscription_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSubscription != null)
            {
                SelectedSubscription.CancelSubscription();
                MessageBox.Show("Подписка удалена");
                NavigateToMainPage();
            }
        }

        private void BackToMainPage_Click(object sender, RoutedEventArgs e)
        {
            NavigateToMainPage();
        }

        public void NavigateToMainPage()
        {
            MainFrame.Navigate(new MainPage(this));
        }

        public void NavigateToEditPage(Subscription subscription)
        {
            MainFrame.Navigate(new EditSubscriptionPage(this, subscription));
        }
        private void SimulateRenewalDate_Click(object sender, RoutedEventArgs e)
        {
            // Получаем текущую дату для проверки истекших подписок
            var currentDate = "01.11.2024 00:00:00";

            foreach (var subscription in Subscriptions)
            {
                // Проверяем, истекла ли подписка на сегодняшний день
                if (subscription.NextPaymentDate == currentDate)
                {
                    // Показываем уведомление для каждой истекшей подписки
                    var result = MessageBox.Show(
                        $"Ваша подписка на {subscription.ServiceName} закончилась. Желаете продлить?",
                        "Продление подписки",
                        MessageBoxButton.YesNo);

                    // Если пользователь выбирает "Да", обновляем дату и оставляем стоимость
                    if (result == MessageBoxResult.Yes)
                    {
                        // Устанавливаем новую дату на следующий месяц
                        subscription.NextPaymentDate = DateTime.Now.Date.AddMonths(1).ToString();
                    }
                    else
                    {
                        // Если "Нет", отменяем подписку
                        subscription.CancelSubscription();
                    }
                }
            }

            // Обновляем представление для отображения изменений
            MainFrame.Navigate(new MainPage(this));
        }
    }
}
