using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Kurs_PW.Models
{
    public partial class Characters
    {
        /// <summary>
        /// Возвращение названия фракции через его ID
        /// </summary>
        public string FractionName
        {
            get
            {
                if (FractionId == null)
                    return "Нет";
                else
                return App.Context.Fractions.First(p => p.FractionId == FractionId).Name;
            }
        }

        /// <summary>
        /// Возвращение названия класса через его ID
        /// </summary>
        public string ClassName
        {
            get
            {
                return App.Context.Classes.First(p => p.ClassId == ClassId).Name;
            }
        }

        /// <summary>
        /// Возвращение иконки класса через его ID
        /// </summary>
        public byte[] ClassIcon
        {
            get
            {
                return App.Context.Classes.First(p => p.ClassId == ClassId).Image;
            }
        }

        /// <summary>
        /// Возвращение картинки персонажа
        /// </summary>
        public byte[] ImageCharacter
        {
            get
            {
                if (Image != null)
                {
                    return Image;
                }

                else
                {
                    return Properties.Resources.ImageCharacterDefault;
                }
            }
        }
    }
}
