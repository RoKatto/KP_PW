﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kurs_PW.Models
{
    public partial class Kurs_PWContext : DbContext
    {
        public Kurs_PWContext()
        {
        }

        public Kurs_PWContext(DbContextOptions<Kurs_PWContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder e)
        {
            try
            {
                e.UseSqlServer(@"Data Source=.\SQLEXPRESS; Initial Catalog = Kurs_PW; Integrated Security=True; Trust Server Certificate = True");
            }

            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных!", "Ошибка подключения к серверу", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public virtual DbSet<AccountStatus> AccountStatus { get; set; }
        public virtual DbSet<Characters> Characters { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Fractions> Fractions { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SoulChannels> SoulChannels { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("StatusID");

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Characters>(entity =>
            {
                entity.HasKey(e => e.CharacterId);

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.AttackSpeed).HasMaxLength(20);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CriticalDamage).HasMaxLength(20);

                entity.Property(e => e.CriticalStrikeChance)
                    .HasMaxLength(4)
                    .IsFixedLength();

                entity.Property(e => e.FractionId).HasColumnName("FractionID");

                entity.Property(e => e.Guild).HasMaxLength(11);

                entity.Property(e => e.Heaven).HasMaxLength(50);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Nickname).HasMaxLength(11);

                entity.Property(e => e.SoulChannelsId).HasColumnName("SoulChannelsID");

                entity.Property(e => e.Speed).HasMaxLength(20);

                entity.Property(e => e.Spouse).HasMaxLength(11);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_Characters_Classes");

                entity.HasOne(d => d.Fraction)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.FractionId)
                    .HasConstraintName("FK_Characters_Fractions");

                entity.HasOne(d => d.SoulChannels)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.SoulChannelsId)
                    .HasConstraintName("FK_Characters_SoulChannels1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Characters_Users");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Fractions>(entity =>
            {
                entity.HasKey(e => e.FractionId)
                    .HasName("PK_Guilds");

                entity.Property(e => e.FractionId).HasColumnName("FractionID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Quartermasters).HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(250);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.RecipientId).HasColumnName("RecipientID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.Property(e => e.Text).HasMaxLength(100);

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.MessageRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .HasConstraintName("FK_Message_Users1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSender)
                    .HasForeignKey(d => d.SenderId)
                    .HasConstraintName("FK_Message_Users");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.NameRole).HasMaxLength(20);
            });

            modelBuilder.Entity<SoulChannels>(entity =>
            {
                entity.Property(e => e.SoulChannelsId).HasColumnName("SoulChannelsID");

                entity.Property(e => e.DotsSoul)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Users_Roles");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Users_AccountStatus1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}