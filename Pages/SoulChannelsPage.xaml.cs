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
    /// Логика взаимодействия для SoulChannelsPage.xaml
    /// </summary>
    public partial class SoulChannelsPage : Page
    {
        Characters character;
        public SoulChannelsPage(Characters character)
        {
            InitializeComponent();
            this.character = character;
            DataContext = App.Context.SoulChannels.Where(p => p.SoulChannelsId == character.SoulChannelsId).ToList(); 
            
        }

        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
