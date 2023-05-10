using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kurs_PW.Models
{
    /// <summary>
    /// Логика взаимодействия для StatusMenegment.xaml
    /// </summary>
    public partial class StatusMenegment : Window
    {
        public StatusMenegment()
        {
            InitializeComponent();
            MaxHeight = this.Height;
            MaxWidth = this.Width;
            MinHeight = this.Height;
            MinWidth = this.Width;
            CBoxUserSelection.ItemsSource = App.Context.Users.Where(c => c.RoleId == 1).Select(c => c.Nickname).ToList();
            
        }

        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var user = App.Context.Users.Where(p => p.Nickname == CBoxUserSelection.SelectedValue.ToString()).FirstOrDefault();

            if (CBoxUserSelection.SelectedValue != null && CBoxStatusSelection.SelectedValue != null)
            {
                user.StatusId = CBoxStatusSelection.SelectedIndex + 1;
                App.Context.SaveChanges();
                MessageBox.Show("Изменения были успешно сохранены", "Управление статусом пользователя", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }
    }
}
