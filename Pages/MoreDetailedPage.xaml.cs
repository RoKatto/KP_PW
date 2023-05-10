using Kurs_PW.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
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
using static System.Net.Mime.MediaTypeNames;

namespace Kurs_PW.Pages
{
    /// <summary>
    /// Логика взаимодействия для MoreDetailedPage.xaml
    /// </summary>
    public partial class MoreDetailedPage : Page
    {
        Characters character;
        
        public MoreDetailedPage(Characters character)
        {
            InitializeComponent();
            this.character = character;
            DataContext = this.character;
            
        }

        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentCharacter = (sender as Button).DataContext as Characters;
            if (MessageBox.Show($"Вы уверены, что хотите удалить персонажа: " + $"{currentCharacter.Nickname}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Characters.Remove(currentCharacter);
                App.Context.SaveChanges();
                NavigationService.Navigate(new MyCharactersPage(character));
            }

        }
        private void BtnEquipment_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Level.Text) < 40)
            {
                MessageBox.Show("Каналы души доступны только с 40-го уровня!", "Каналы души", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            NavigationService.Navigate(new SoulChannelsPage(character));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.character = character;
            DataContext = this.character;
        }

        private void BtnPlusEn_Click(object sender, RoutedEventArgs e)
        {
            if (PerfPoint.Text == "0")
            {
                MessageBox.Show("У вас больше нет доступных очков для развития", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int endur = Convert.ToInt32(Endurance.Text);
                endur += 1;
                Endurance.Text = Convert.ToString(endur);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint -= 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnMinusEn_Click(object sender, RoutedEventArgs e)
        {
            if (Endurance.Text == "5")
            {
                MessageBox.Show("Вы больше не можете снижать значение выносливости", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int endur = Convert.ToInt32(Endurance.Text);
                endur -= 1;
                Endurance.Text = Convert.ToString(endur);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint += 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnPlusPow_Click(object sender, RoutedEventArgs e)
        {
            if (PerfPoint.Text == "0")
            {
                MessageBox.Show("У вас больше нет доступных очков для развития", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int power = Convert.ToInt32(Power.Text);
                power += 1;
                Power.Text = Convert.ToString(power);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint -= 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnMinusPow_Click(object sender, RoutedEventArgs e)
        {
            if (Power.Text == "5")
            {
                MessageBox.Show("Вы больше не можете снижать значение силы", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int power = Convert.ToInt32(Power.Text);
                power -= 1;
                Power.Text = Convert.ToString(power);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint += 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnPlusInt_Click(object sender, RoutedEventArgs e)
        {
            if (PerfPoint.Text == "0")
            {
                MessageBox.Show("У вас больше нет доступных очков для развития", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int inteleg = Convert.ToInt32(Intelligence.Text);
                inteleg += 1;
                Intelligence.Text = Convert.ToString(inteleg);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint -= 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnMinushInt_Click(object sender, RoutedEventArgs e)
        {
            if (Intelligence.Text == "5")
            {
                MessageBox.Show("Вы больше не можете снижать значение интеллекта", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int inteleg = Convert.ToInt32(Intelligence.Text);
                inteleg -= 1;
                Intelligence.Text = Convert.ToString(inteleg);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint += 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnPlusAg_Click(object sender, RoutedEventArgs e)
        {
            if (PerfPoint.Text == "0")
            {
                MessageBox.Show("У вас больше нет доступных очков для развития", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int agil = Convert.ToInt32(Agility.Text);
                agil += 1;
                Agility.Text = Convert.ToString(agil);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint -= 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnMinusAg_Click(object sender, RoutedEventArgs e)
        {
            if (Agility.Text == "5")
            {
                MessageBox.Show("Вы больше не можете снижать значение ловкости", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                int agil = Convert.ToInt32(Agility.Text);
                agil -= 1;
                Agility.Text = Convert.ToString(agil);
                int perfpoint = Convert.ToInt32(PerfPoint.Text);
                perfpoint += 1;
                PerfPoint.Text = Convert.ToString(perfpoint);
            }
        }

        private void BtnSaveIz_Click(object sender, RoutedEventArgs e)
        {
            var ch = App.Context.Characters.Where(p => p.CharacterId == character.CharacterId).FirstOrDefault();
            ch.Agility = Convert.ToInt32(Agility.Text);
            ch.Power = Convert.ToInt32(Power.Text);
            ch.Intelligence = Convert.ToInt32(Intelligence.Text);
            ch.Endurance = Convert.ToInt32(Endurance.Text);
            ch.PerformancePoints = Convert.ToInt32(PerfPoint.Text);
            App.Context.SaveChanges();
            MessageBox.Show("Изменения были успешно сохранены", "Развитие персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnToPDF_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PrintPage(character));
        }
    }
}
