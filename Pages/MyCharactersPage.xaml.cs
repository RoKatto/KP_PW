using Kurs_PW.Models;
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

namespace Kurs_PW.Pages
{
    /// <summary>
    /// Логика взаимодействия для MyCharactersPage.xaml
    /// </summary>
    public partial class MyCharactersPage : Page
    {

        Characters character;
        public MyCharactersPage(Characters character)
        {
            InitializeComponent();
            this.character = character;
            DataContext = this.character;
            ListCharacters.ItemsSource = App.Context.Characters.Where(c => c.UserId == App.CurrentUser.UserId).ToList();
        }

        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void BtnCreateACharacter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateCharacterPage());
        }

        private void CharacterSelected_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MoreDetailedPage((sender as StackPanel).DataContext as Characters));
        }
    }
}
