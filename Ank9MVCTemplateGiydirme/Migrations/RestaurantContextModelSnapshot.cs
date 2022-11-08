﻿// <auto-generated />
using Ank9MVCTemplateGiydirme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ank9MVCTemplateGiydirme.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    partial class RestaurantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Kategori", b =>
                {
                    b.Property<int>("KategoriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriId"), 1L, 1);

                    b.Property<int>("KategoriAdi")
                        .HasColumnType("int");

                    b.HasKey("KategoriId");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            KullaniciId = 1,
                            Email = "info@example.com",
                            Sifre = "1234"
                        });
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Malzeme", b =>
                {
                    b.Property<int>("MalzemeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MalzemeId"), 1L, 1);

                    b.Property<string>("MalzemeAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MalzemeId");

                    b.ToTable("Malzemeler");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Urun", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UrunId"), 1L, 1);

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UrunFiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UrunResimURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrunTanimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UrunId");

                    b.HasIndex("KategoriId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.UrunMalzeme", b =>
                {
                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.Property<int>("MalzemeId")
                        .HasColumnType("int");

                    b.HasKey("UrunId", "MalzemeId");

                    b.HasIndex("MalzemeId");

                    b.ToTable("UrunlerMalzemeler");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Urun", b =>
                {
                    b.HasOne("Ank9MVCTemplateGiydirme.Models.Kategori", "Kategori")
                        .WithMany("Urunler")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.UrunMalzeme", b =>
                {
                    b.HasOne("Ank9MVCTemplateGiydirme.Models.Malzeme", "Malzeme")
                        .WithMany("UrunMalzemeler")
                        .HasForeignKey("MalzemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ank9MVCTemplateGiydirme.Models.Urun", "Urun")
                        .WithMany("UrunlerMalzemeler")
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Malzeme");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Kategori", b =>
                {
                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Malzeme", b =>
                {
                    b.Navigation("UrunMalzemeler");
                });

            modelBuilder.Entity("Ank9MVCTemplateGiydirme.Models.Urun", b =>
                {
                    b.Navigation("UrunlerMalzemeler");
                });
#pragma warning restore 612, 618
        }
    }
}
