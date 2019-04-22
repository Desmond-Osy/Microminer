﻿// <auto-generated />
using microminer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace microminer.Migrations
{
    [DbContext(typeof(DataDBContext))]
    partial class DataDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("microminer.Models.AlphabetizedDataModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Alphabetized");

                    b.HasKey("ID");

                    b.ToTable("AlphabetizedDataModels");
                });

            modelBuilder.Entity("microminer.Models.InputDataModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Input");

                    b.HasKey("ID");

                    b.ToTable("InputDataModels");
                });
#pragma warning restore 612, 618
        }
    }
}
