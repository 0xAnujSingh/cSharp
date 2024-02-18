﻿// <auto-generated />
using DbFirst_practice2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace codeFirst_practice.Migrations
{
    [DbContext(typeof(CodeFirstPracticeContext))]
    [Migration("20240218093956_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DbFirst_practice2.Models.Department", b =>
                {
                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("DeptNo")
                        .HasName("PK__Departme__0148CAAEF7D4617E");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DbFirst_practice2.Models.Employee", b =>
                {
                    b.Property<int>("EmpNo")
                        .HasColumnType("int");

                    b.Property<decimal>("Basic")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("EmpNo")
                        .HasName("PK__Employee__AF2D66D3893C958C");

                    b.HasIndex("DeptNo");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DbFirst_practice2.Models.Employee", b =>
                {
                    b.HasOne("DbFirst_practice2.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
