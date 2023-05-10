using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_PW.Models
{
    public partial class Message
    {
        /// <summary>
        /// Возвращение никнеймов персонажей в чате
        /// </summary>
        public string NicnameChat
        {
            get
            {
                if (SenderId == App.CurrentUser.UserId)
                {
                    return App.CurrentUser.Nickname;
                }

                else if (RecipientId == App.CurrentUser.UserId)
                {
                    return App.Context.Users.First(p => p.UserId == SenderId).Nickname;
                }

                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
