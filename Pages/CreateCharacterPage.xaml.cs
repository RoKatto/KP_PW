using Kurs_PW.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для CreateCharacterPage.xaml
    /// </summary>
    public partial class CreateCharacterPage : Page
    {

        public CreateCharacterPage()
        {
            InitializeComponent();
        }

        private void CBoxRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (CBoxRace.SelectedValue.ToString() == "Люди")
            {
                CBoxClass.ItemsSource = new List<string>()
                {
                    "Воин", "Маг", "Стрелок"
                };
            }

            else if (CBoxRace.SelectedValue.ToString() == "Зооморфы")
            {
                CBoxClass.ItemsSource = new List<string>()
                {
                    "Оборотень", "Друид", "Странник"
                };
            }

            else if (CBoxRace.SelectedValue.ToString() == "Сиды")
            {
                CBoxClass.ItemsSource = new List<string>()
                {
                    "Паладин", "Лучник", "Жрец"
                };
            }

            else if (CBoxRace.SelectedValue.ToString() == "Амфибии")
            {
                CBoxClass.ItemsSource = new List<string>()
                {
                    "Шаман", "Убийца"
                };
            }

            else if (CBoxRace.SelectedValue.ToString() == "Древние")
            {
                CBoxClass.ItemsSource = new List<string>()
                {
                    "Страж", "Мистик"
                };
            }

            else if (CBoxRace.SelectedValue.ToString() == "Тени")
            {
                CBoxClass.ItemsSource = new List<string>()
                {
                    "Жнец", "Призрак"
                };
            }            
        }

        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (TBoxNicknameCharacter.Text == null)
            {
                MessageBox.Show("Вы не указали ник персонажа!", "Ошибка при создании персонажа", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (App.Context.Characters.FirstOrDefault(p => p.Nickname == TBoxNicknameCharacter.Text) != null)
            {
                MessageBox.Show("Персонаж с таким никнеймом уже существует!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (TBoxNicknameCharacter.Text.Length > 11)
            {
                MessageBox.Show("Ник персонажа не может привышать 11 символов!", "Ошибка при создании персонажа", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (CBoxRace.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали расу!", "Ошибка при создании персонажа", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if(CBoxClass.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали класс!", "Ошибка при создании персонажа", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (CBoxGender.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали пол!", "Ошибка при создании персонажа", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            else
            {
                try
                {
                    var character = new Models.Characters
                    {

                        
                        Nickname = TBoxNicknameCharacter.Text,
                        ClassId = App.Context.Classes.First(c => c.Name == CBoxClass.Text).ClassId,
                        Lvl = 1,
                        Rebirths = 0,
                        Guild = "Нет",
                        Spouse = "Нет",
                        Reputation = 0,
                        Status = "Стойкий",
                        Title = "Житель идеального мира",
                        LifeForce = 200,
                        MagicalEnergy = 100,
                        Spirit = 0,
                        PerformancePoints = 5,
                        Endurance = 5,
                        Intelligence = 5,
                        Power = 5,
                        Agility = 5,
                        PhysicalAttack = 50,
                        MagicAttack = 50,
                        CriticalStrikeChance = "0%",
                        AttackSpeed = "1.0 уд/сек",
                        Accuracy = 0,
                        IndicatorAttack = 0,
                        FightingSpirit = 0,
                        Stealth = 0,
                        MonsterDamage = 0,
                        PhysicalProtection = 200,
                        MagicProtection = 200,
                        CriticalDamage = "200%",
                        Speed = "5.0 м/сек",
                        Evasion = 0,
                        IndicatorProtection = 0,
                        Fortitude = 500,
                        Detection = 0,
                        MonsterProtection = 0,
                        MagicPunching = 0,
                        UserId = App.CurrentUser.UserId,
                        FractionId = null,
                        SoulChannels = null,
                        PhysicalPunching = 0

                    };



                    App.Context.Characters.Add(character);
                    App.Context.SaveChanges();

                    MessageBox.Show("Вы успешно создали персонажа.", "Создание персонажа", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new MyCharactersPage(character));
                }

                catch
                {
                    MessageBox.Show("Не удалось создать персонажа.", "Создание персонажа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }
    }
}
