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
    /// Логика взаимодействия для ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page
    {
        Users selectedUser;
        public ChatPage()
        {
            InitializeComponent();
            CBoxUsers.ItemsSource = App.Context.Users.Where(c => c.Nickname != App.CurrentUser.Nickname).Select(c => c.Nickname).ToList();
            YourMessage.MaxLength = 100;

            /// <summary>
            /// Скрывать кнопку изменения статуса для пользователей
            /// </summary>
            if (App.CurrentUser.RoleId == 1)
                BtnStatusManagement.Visibility = Visibility.Collapsed;
        }
        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CBoxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = App.Context.Users.First(p => p.Nickname == CBoxUsers.SelectedValue);

            /// <summary>
            /// Отображение сообщений у пользователей, между которыми шла переписка
            /// </summary>
            ListMessages.ItemsSource = App.Context.Message.Where(c => c.RecipientId == App.CurrentUser.UserId && c.SenderId == selectedUser.UserId 
                || c.SenderId == App.CurrentUser.UserId && c.RecipientId == selectedUser.UserId).ToList();

            if(selectedUser.RoleId == 2)
            {
                TextAdmin.Text = "Вы общаетесь с администратором";
                TextAdmin.Foreground = Brushes.Red;
            }

            else
            {
                TextAdmin.Text = "Вы общаетесь с пользователем";
                TextAdmin.Foreground = Brushes.Black;
            }

        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser.UserId == App.CurrentUser.UserId)
            {
                MessageBox.Show("Вы не можете писать самому себе", "Ошибка при отправке сообщения", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (selectedUser != null && !string.IsNullOrWhiteSpace(YourMessage.Text))
            {
                var message = new Models.Message()
                {
                    SenderId = App.CurrentUser.UserId,
                    RecipientId = selectedUser.UserId,
                    Text = YourMessage.Text

                };
                App.Context.Message.Add(message);
                App.Context.SaveChanges();
                YourMessage.Clear();    
                ListMessages.ItemsSource = App.Context.Message.Where(c => c.RecipientId == App.CurrentUser.UserId && c.SenderId == selectedUser.UserId
                    || c.SenderId == App.CurrentUser.UserId && c.RecipientId == selectedUser.UserId).ToList();

            }

            
        }

        private void BtnStatusManagement_Click(object sender, RoutedEventArgs e)
        {
            StatusMenegment statusMenegment = new StatusMenegment();
            statusMenegment.ShowDialog();
        }
    }
}
