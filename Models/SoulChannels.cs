﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Kurs_PW.Models
{
    public partial class SoulChannels
    {
        public SoulChannels()
        {
            Characters = new HashSet<Characters>();
        }

        public int SoulChannelsId { get; set; }
        public string DotsSoul { get; set; }
        public int? HealthBonus { get; set; }
        public int? PhysicalАttackBonus { get; set; }
        public int? MagiclАttackBonus { get; set; }
        public int? PhysicalProtectionBonus { get; set; }
        public int? MagicProtectionBonus { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Characters> Characters { get; set; }
    }
}