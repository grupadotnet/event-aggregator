﻿// <auto-generated />
using System;
using Event_Aggregator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventAggregator.Migrations
{
    [DbContext(typeof(Event_AggregatorContext))]
    [Migration("20190112140529_EventMigration")]
    partial class EventMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Event_Aggregator.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Event_Aggregator.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("EndDate");

                    b.Property<byte[]>("Image");

                    b.Property<string>("Localization")
                        .IsRequired();

                    b.Property<string>("LongerTitle")
                        .HasMaxLength(60);

                    b.Property<string>("ShortTitle")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Event_Aggregator.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Login");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Event_Aggregator.Models.Event", b =>
                {
                    b.HasOne("Event_Aggregator.Models.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
