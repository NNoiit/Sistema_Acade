﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sistemaAcad.Data;

namespace sistemaAcad.Migrations
{
    [DbContext(typeof(DataSysContext))]
    [Migration("20220315113249_SistemaAcadV1")]
    partial class SistemaAcadV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("sistemaAcad.Models.AlunoModels", b =>
                {
                    b.Property<int>("IdAluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTurma")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaNota")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdAluno");

                    b.HasIndex("IdTurma");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("sistemaAcad.Models.ProfessorModels", b =>
                {
                    b.Property<int>("IdProfessor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdMateria")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Materia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdProfessor");

                    b.ToTable("professor");
                });

            modelBuilder.Entity("sistemaAcad.Models.TurmaModels", b =>
                {
                    b.Property<int>("IdTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("IdTurma");

                    b.ToTable("turma");
                });

            modelBuilder.Entity("sistemaAcad.Models.AlunoModels", b =>
                {
                    b.HasOne("sistemaAcad.Models.TurmaModels", "Turma")
                        .WithMany()
                        .HasForeignKey("IdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });
#pragma warning restore 612, 618
        }
    }
}
