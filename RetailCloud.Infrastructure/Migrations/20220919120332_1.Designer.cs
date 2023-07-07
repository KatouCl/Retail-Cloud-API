﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RetailCloud.Infrastructure.Data;

namespace RetailCloud.Infrastracture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220919120332_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RetailCloud.Core.Entities.Barcode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserCreatedId");

                    b.ToTable("Barcode");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Enterprises", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FsrarId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Kpp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Enterprises");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.GroupProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMarked")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductType")
                        .HasColumnType("integer");

                    b.Property<long>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.ToTable("GroupProduct");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Producer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Country")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FsrarId")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Inn")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Kpp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrganizationType")
                        .HasColumnType("integer");

                    b.Property<int?>("RegionCode")
                        .HasColumnType("integer");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.Property<int>("TaxIndexType")
                        .HasColumnType("integer");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Artikul")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("GroupProductId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("ItemType")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PrintName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ProducerId")
                        .HasColumnType("bigint");

                    b.Property<int>("TaxIndexType")
                        .HasColumnType("integer");

                    b.Property<long>("UnitsId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GroupProductId");

                    b.HasIndex("ProducerId");

                    b.HasIndex("UnitsId");

                    b.HasIndex("UserCreatedId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.SalesJournal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CheckNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FiscalNumberDocument")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("KktSerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberTransaction")
                        .HasColumnType("text");

                    b.Property<string>("PaymentId")
                        .HasColumnType("text");

                    b.Property<int>("PaymentMethodType")
                        .HasColumnType("integer");

                    b.Property<int>("PaymentStatusType")
                        .HasColumnType("integer");

                    b.Property<string>("PaymentToken")
                        .HasColumnType("text");

                    b.Property<string>("QR_Sign")
                        .HasColumnType("text");

                    b.Property<string>("QR_URL")
                        .HasColumnType("text");

                    b.Property<string>("Rrn")
                        .HasColumnType("text");

                    b.Property<int?>("SessionNumber")
                        .HasColumnType("integer");

                    b.Property<long>("TotalPrice")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SalesJournal");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.SalesJournalPosition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cis")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<double>("Quantity")
                        .HasColumnType("double precision");

                    b.Property<long>("SalesJournalId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalesJournalId");

                    b.ToTable("SalesJournalPosition");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Units", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserCreatedId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telephone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Barcode", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailCloud.Core.Entities.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Enterprises", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.GroupProduct", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Product", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.GroupProduct", "GroupProduct")
                        .WithMany()
                        .HasForeignKey("GroupProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailCloud.Core.Entities.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailCloud.Core.Entities.Units", "Units")
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailCloud.Core.Entities.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.SalesJournal", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.SalesJournalPosition", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RetailCloud.Core.Entities.SalesJournal", "SalesJournal")
                        .WithMany()
                        .HasForeignKey("SalesJournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.Units", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RetailCloud.Core.Entities.User", b =>
                {
                    b.HasOne("RetailCloud.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
