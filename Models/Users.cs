﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Kurs_PW.Models
{
    public partial class Users
    {
        public Users()
        {
            Characters = new HashSet<Characters>();
            MessageRecipient = new HashSet<Message>();
            MessageSender = new HashSet<Message>();
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public int? RoleId { get; set; }
        public int? StatusId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual AccountStatus Status { get; set; }
        public virtual ICollection<Characters> Characters { get; set; }
        public virtual ICollection<Message> MessageRecipient { get; set; }
        public virtual ICollection<Message> MessageSender { get; set; }
    }
}