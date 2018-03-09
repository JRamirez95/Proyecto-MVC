﻿// <auto-generated />
using Dodge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Dodge.Migrations
{
    [DbContext(typeof(DodgeContext))]
    [Migration("20180228001437_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dodge.Models.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<string>("identityCard");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.Property<string>("sectors");

                    b.Property<string>("webPage");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Dodge.Models.Contact", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("email");

                    b.Property<string>("jobPositions");

                    b.Property<string>("lastName");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.HasKey("id");

                    b.HasIndex("ClientId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Dodge.Models.Meetings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AVirtual");

                    b.Property<int>("ClientId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("date");

                    b.Property<string>("subject");

                    b.HasKey("id");

                    b.HasIndex("ClientId");

                    b.HasIndex("UserId");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("Dodge.Models.SupportTickets", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<string>("problem");

                    b.Property<string>("state");

                    b.Property<string>("subject");

                    b.Property<string>("who");

                    b.HasKey("id");

                    b.HasIndex("ClientId");

                    b.ToTable("SupportTickets");
                });

            modelBuilder.Entity("Dodge.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("job");

                    b.Property<string>("lastName");

                    b.Property<string>("name");

                    b.Property<string>("password");

                    b.Property<string>("phone");

                    b.Property<string>("userName");

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Dodge.Models.Contact", b =>
                {
                    b.HasOne("Dodge.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dodge.Models.Meetings", b =>
                {
                    b.HasOne("Dodge.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dodge.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dodge.Models.SupportTickets", b =>
                {
                    b.HasOne("Dodge.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
