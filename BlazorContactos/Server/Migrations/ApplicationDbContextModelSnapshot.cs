﻿// <auto-generated />
using BlazorContactos.Server.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorContactos.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorContactos.Server.Model.Entities.Contacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("BlazorContactos.Server.Model.Entities.MediosContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactoId");

                    b.ToTable("Medios");
                });

            modelBuilder.Entity("BlazorContactos.Server.Model.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("MediosContactoPais", b =>
                {
                    b.Property<int>("PaisesId")
                        .HasColumnType("int");

                    b.Property<int>("mediosContactosId")
                        .HasColumnType("int");

                    b.HasKey("PaisesId", "mediosContactosId");

                    b.HasIndex("mediosContactosId");

                    b.ToTable("MediosContactoPais");
                });

            modelBuilder.Entity("BlazorContactos.Server.Model.Entities.MediosContacto", b =>
                {
                    b.HasOne("BlazorContactos.Server.Model.Entities.Contacto", "Contacto")
                        .WithMany("Medios")
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");
                });

            modelBuilder.Entity("MediosContactoPais", b =>
                {
                    b.HasOne("BlazorContactos.Server.Model.Entities.Pais", null)
                        .WithMany()
                        .HasForeignKey("PaisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorContactos.Server.Model.Entities.MediosContacto", null)
                        .WithMany()
                        .HasForeignKey("mediosContactosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BlazorContactos.Server.Model.Entities.Contacto", b =>
                {
                    b.Navigation("Medios");
                });
#pragma warning restore 612, 618
        }
    }
}
