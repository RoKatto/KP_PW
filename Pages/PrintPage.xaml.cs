using Kurs_PW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Логика взаимодействия для PrintPage.xaml
    /// </summary>
    public partial class PrintPage : Page
    {
        Characters character;
        public PrintPage(Characters character)
        {
            InitializeComponent();
            this.character = character;
            DataContext = this.character;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.character = character;
            DataContext = this.character;
        }

        /// <summary>
        /// Метод печати информации о персонаже
        /// </summary>
        public static void Print(Visual elementToPrint, string description)
        {
            using (var printServer = new LocalPrintServer())
            {
                
                var dialog = new PrintDialog();
                dialog.ShowDialog();
                var qs = printServer.GetPrintQueues();
                dialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
                dialog.PrintVisual(elementToPrint, description);
            }
        }
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            BtnPrint.Visibility = Visibility.Hidden;
            BtnBackMP.Visibility = Visibility.Hidden;
            Print(this, "Character Report");
            BtnPrint.Visibility = Visibility.Visible;
            BtnBackMP.Visibility = Visibility.Visible;
        }

        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
