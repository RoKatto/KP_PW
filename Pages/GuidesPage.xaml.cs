using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для GuidesPage.xaml
    /// </summary>
    public partial class GuidesPage : Page
    {

        int i = 1;
        public GuidesPage()
        {
            InitializeComponent();
            Race.Text = "Люди";
            ImageClasses.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(Properties.Resources.People);
        }

        private void UpdateImageClasses()
        {
            if (i > 6)
            {
                i = 1;
            }

            else if (i < 1)
            {
                i = 6;
            }

            if (i == 1)
            {
                Race.Text = "Люди";
                ImageClasses.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(Properties.Resources.People);
                MarkCenterImg.Visibility = Visibility.Visible;
            }

            else if (i == 2)
            {
                Race.Text = "Оборотни";
                ImageClasses.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(Properties.Resources.Zoo);
                MarkCenterImg.Visibility = Visibility.Visible;
            }

            else if (i == 3)
            {
                Race.Text = "Сиды";
                ImageClasses.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(Properties.Resources.Sids);
                MarkCenterImg.Visibility = Visibility.Visible;
            }

            else if (i == 4)
            {
                Race.Text = "Амфибии";
                ImageClasses.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(Properties.Resources.Amphibians);
                MarkCenterImg.Visibility = Visibility.Collapsed;
            }

            else if (i == 5)
            {
                Race.Text = "Древние";
                ImageClasses.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(Properties.Resources.Ancient);
                MarkCenterImg.Visibility = Visibility.Collapsed;
            }

            else if (i == 6)
            {
                Race.Text = "Тени";
                ImageClasses.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(Properties.Resources.Ghosts);
                MarkCenterImg.Visibility = Visibility.Collapsed;
            }
        }
       
        private void BtnBackMP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            i++;

            UpdateImageClasses();
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            i--;
            UpdateImageClasses();
        }

        private void MarkRight_MouseMove(object sender, MouseEventArgs e)
        {
            MarkRightImg.Width = 25;
            if (i == 1)
            {
                MarkRight.Text = "Стрелки — прекрасные представители расы людей, владеющие ручными пушками. С помощью огнефосфора они атакуют " +
                    "врагов пылающими снарядами и устраивают настоящий огненный дождь во время битвы. Кроме того, стрелки умеют устанавливать разные " +
                    "ловушки на поле боя.";
            }

            if (i == 2)
            {
                MarkRight.Text = "Эти очаровательные представители расы зооморфов, способные превращаться в лис, весьма опасны в бою. Друиды могут " +
                    "приручать животных, наделяя своих питомцев боевыми навыками. Кроме того, страшное проклятие друидов ослабит любого противника.";
            }

            if (i == 3)
            {
                MarkRight.Text = "Лечит и воскрешает союзников, может исцелить даже смертельные раны. Но сила жрецов может быть и разрушительной — защищая себя, " +
                    "они могут наслать на противника смерч или дождь из молний, держать врага в длительном контроле и даже усыпить его.";
            }

            if (i == 4)
            {

                MarkRight.Text = "Шаманы повелевают стихиями воды и земли. Они способны как яростно сражаться с помощью боевых заклятий, так и поддерживать " +
                    "товарищей по команде, исцеляя их раны и накладывая различные заклинания помощи.";
            }

            if (i == 5)
            {

                MarkRight.Text = "Представитель расы Древних, которому подвластны законы природы. Мистик может исцелить союзника или сокрушить противника, " +
                    "черпая силу во флоре и фауне Идеального Мира.";
            }

            if (i == 6)
            {

                MarkRight.Text = "Призраки носят легкую броню и мастерски владеют саблями. Они невероятно быстры и хорошо защищены от дальних атак, а комбинации " +
                    "их умений наносят колоссальный урон по врагам. Кроме того, Призраки могут похищать заклинания у других классов.";
            }
        }

        private void MarkLeftImg_MouseMove(object sender, MouseEventArgs e)
        {
            MarkLeftImg.Width = 25;
            if (i == 1)
            {
                MarkLeft.Text = "Закаленный в постоянных тренировках мастер ближнего боя подходит для любителей динамичной игры." +
                    " Владеет 4 видами оружия, ловко избегает прямых атак. Умения воина позволяют ему надолго сделать противника беспомощным.";
            }

            if (i == 2)
            {
                MarkLeft.Text = "Устрашающий облик и несокрушимая сила — вот что можно сказать об оборотнях Идеального Мира. Они выдерживают любые атаки, " +
                    "прикрывая собой товарищей по команде, и способны превращаться в панду или белого тигра.";
            }

            if (i == 3)
            {
                MarkLeft.Text = "Паладины — верные последователи богов Идеального Мира. Бесстрашные, они отправились за своими покровителями даже в " +
                    "Бесконечную пустоту. Отважные паладины мастерски владеют мечом со щитом: они могут зачаровать клинок любой стихией, а щит используют " +
                    "равно для защиты и нападения.";
            }

            if (i == 4)
            {
                MarkLeft.Text = "Убийца — мастер скрытности, смертоносный воин, прячущийся в тени. Его быстрым атакам из укрытия почти невозможно противостоять." +
                    " Тот, кого убийца выбрал своей мишенью, не уйдет от удара двух острых кинжалов.";
            }

            if (i == 5)
            {
                MarkLeft.Text = "Cтражи – настоящие рыцари Идеального Мира. Они носят тяжелую броню, легко орудуют гигантскими двуручными мечами, но при этом " +
                    "имеют и арсенал дальних атак.";
            }

            if (i == 6)
            {
                MarkLeft.Text = "Вооруженные косами Жнецы повелевают силами металла и воды. Их уникальные атакующие умения можно использовать даже во время " +
                    "движения. Жнец способен создать воронку, притягивающую врагов, и даже призвать своего двойника.";
            }
        }

        private void MarkCenterImg_MouseMove(object sender, MouseEventArgs e)
        {
            MarkCenterImg.Width = 25;
            if (i == 1)
            {
                MarkCenter.Text = "Повелитель стихий, достигший успеха благодаря долгим годам обучения. Маг обрушит на противников лед и пламень, " +
                    "но сам нуждается в защите, поскольку может носить лишь легкую броню.";
            }

            if (i == 2)
            {
                MarkCenter.Text = "Ловкие, быстрые, владеют множеством приемов, мастера внезапной атаки, могут превращаться в белую обезьяну и демонстрировать " +
                    "неисчерпаемую силу.";
            }

            if (i == 3)
            {
                MarkCenter.Text = "Согласно легенде, лучники — потомки людей и богов. Их стрелы разят без промаха, и с высокой вероятностью урон от атаки лучника " +
                    "будет критическим. Крылатые воители, паря над полем битвы, вселяют ужас в сердца врагов.";
            }
        }

        private void MarkCenterImg_MouseLeave(object sender, MouseEventArgs e)
        {
            MarkCenterImg.Width = 20;
        }

        private void MarkLeftImg_MouseLeave(object sender, MouseEventArgs e)
        {
            MarkLeftImg.Width = 20;
        }

        private void MarkRightImg_MouseLeave(object sender, MouseEventArgs e)
        {
            MarkRightImg.Width = 20;
        }
    }
}
