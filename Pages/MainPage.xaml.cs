using Kurs_PW.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kurs_PW.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Characters character;
        public MainPage()
        {
            InitializeComponent();
            StatusUser.Text = App.Context.AccountStatus.Where(c => c.StatusId == App.CurrentUser.StatusId).Select(p => p.StatusName).FirstOrDefault();
            NicknameUser.Text = App.CurrentUser.Nickname.ToString();
            this.character = character;
            DataContext = this.character;
        }

        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void BtnMyCharacters_Click(object sender, RoutedEventArgs e)
        {
            
            if (App.CurrentUser.StatusId == 1)
            {
                NavigationService.Navigate(new MyCharactersPage(character));
            }

            /// <summary>
            /// Ограничение доступа пользователям со статусом Заморожен
            /// </summary>=
            if (App.CurrentUser.StatusId == 2)
            {
                MessageBox.Show("Вы не можете просматривать своих персонажей, так как вы временно заморожены. Вы можете написать нашему администратору. Его никнейм Нилий.", "Попытка зайти на страницу персонажей", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            /// <summary>
            /// Ограничение доступа пользователям со статусом Заблокирован
            /// </summary>=
            if (App.CurrentUser.StatusId == 3)
            {
                MessageBox.Show("Вы не можете просматривать своих персонажей, так как вы заблокированы. Вы можете написать нашему администратору. Его никнейм Нилий.", "Попытка зайти на страницу персонажей", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void BtnGuides_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GuidesPage());
        }
        private void BtnBackMPs_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MoreDetailedPage(character));
        }

        private void BtnChat_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChatPage());
        }
    }
}
