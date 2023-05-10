using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kurs_PW
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Models.Kurs_PWContext Context
        { get; } = new Models.Kurs_PWContext();
        public static Models.Users CurrentUser = null;
    }
}
