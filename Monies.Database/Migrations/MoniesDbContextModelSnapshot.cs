﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monies.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Monies.Database.Migrations
{
    [DbContext(typeof(MoniesDbContext))]
    partial class MoniesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Monies.Database.Models.Salary", b =>
                {
                    b.Property<int>("SalaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("salary_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime>("ActiveFrom")
                        .HasColumnName("active_from")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ActiveTo")
                        .HasColumnName("active_to")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PeriodType")
                        .HasColumnName("period_type")
                        .HasColumnType("integer");

                    b.Property<decimal>("Value")
                        .HasColumnName("value")
                        .HasColumnType("numeric");

                    b.Property<int>("ValueType")
                        .HasColumnName("value_type")
                        .HasColumnType("integer");

                    b.HasKey("SalaryId")
                        .HasName("pk_salaries");

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("Monies.Database.Models.UserSetting", b =>
                {
                    b.Property<int>("UserSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_setting_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PreferredPeriodType")
                        .HasColumnName("preferred_period_type")
                        .HasColumnType("integer");

                    b.Property<int>("PreferredValueType")
                        .HasColumnName("preferred_value_type")
                        .HasColumnType("integer");

                    b.HasKey("UserSettingId")
                        .HasName("pk_user_settings");

                    b.ToTable("user_settings");
                });
#pragma warning restore 612, 618
        }
    }
}