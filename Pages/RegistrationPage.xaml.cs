using Kurs_PW.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TBoxNickname.Text))
            {
                MessageBox.Show("Не указан никнейм!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (App.Context.Users.FirstOrDefault(p => p.Nickname == TBoxNickname.Text) != null)
            {
                MessageBox.Show("Пользователь с таким никнеймом уже зарегистрирован!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (TBoxNickname.Text.Length > 11)
            {
                MessageBox.Show("Слишком длинный никнейм! Никнейм может достигать 11", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (String.IsNullOrWhiteSpace(TBoxLogin.Text))
            {
                MessageBox.Show("Не указан логин!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (TBoxLogin.Text.Length < 3)
            {
                MessageBox.Show("Слишком короткий логин!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (TBoxLogin.Text.Length > 20)
            {
                MessageBox.Show("Слишком длинный логин!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (String.IsNullOrWhiteSpace(PBoxPassword.Password))
            {
                MessageBox.Show("Не указан пароль!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (PBoxPassword.Password != TPBoxPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (PBoxPassword.Password.Length < 8)
            {
                MessageBox.Show("Слишком короткий пароль!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (TBoxLogin.Text.Length < 3 & TBoxLogin.Text != String.Empty)
            {
                MessageBox.Show("Слишком короткий логин!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (TBoxLogin.Text.Length > 20)
            {
                MessageBox.Show("Слишком длинный логин!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (!(Regex.IsMatch(PBoxPassword.Password, @"\W") && (Regex.IsMatch(PBoxPassword.Password, @"\d") && Regex.IsMatch(PBoxPassword.Password, @"[а-я]") 
                && Regex.IsMatch(PBoxPassword.Password, @"[А-Я]") || Regex.IsMatch(PBoxPassword.Password, @"[a-z]") || Regex.IsMatch(PBoxPassword.Password, @"[A-Z]"))))
            {
                MessageBox.Show("Пароль должен содержать в себе хотя бы один символ, одну цифру, одну строчную букву и одну прописную букву!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (App.Context.Users.FirstOrDefault(p => p.Login == TBoxLogin.Text) != null)
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован!", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
            {
                var user = new Models.Users
                {
                    Login = TBoxLogin.Text,
                    Password = PBoxPassword.Password,
                    Nickname = TBoxNickname.Text,
                    RoleId = 1,
                    StatusId = 1
                };

                App.Context.Users.Add(user);
                App.Context.SaveChanges();

                MessageBox.Show("Вы успешно зарегистрировались.", "Успешная регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new LoginPage());
            }
        }

        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
