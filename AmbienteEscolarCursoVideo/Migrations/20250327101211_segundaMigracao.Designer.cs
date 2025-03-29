﻿// <auto-generated />
using System;
using AmbienteEscolarCursoVideo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmbienteEscolarCursoVideo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250327101211_segundaMigracao")]
    partial class segundaMigracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.AlunoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.HistoricoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<double>("Media")
                        .HasColumnType("float");

                    b.Property<double>("Nota1")
                        .HasColumnType("float");

                    b.Property<double>("Nota2")
                        .HasColumnType("float");

                    b.Property<double>("Nota3")
                        .HasColumnType("float");

                    b.Property<double>("Nota4")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.MateriaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Matemática"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Português"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "História"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Ciências"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Química"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Educação Física"
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Redação"
                        });
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.ProfessorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MateriaId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.TurmaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("ProfessorModelTurmaModel", b =>
                {
                    b.Property<int>("ProfessoresId")
                        .HasColumnType("int");

                    b.Property<int>("TurmasId")
                        .HasColumnType("int");

                    b.HasKey("ProfessoresId", "TurmasId");

                    b.HasIndex("TurmasId");

                    b.ToTable("ProfessorModelTurmaModel");
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.AlunoModel", b =>
                {
                    b.HasOne("AmbienteEscolarCursoVideo.Models.TurmaModel", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.HistoricoModel", b =>
                {
                    b.HasOne("AmbienteEscolarCursoVideo.Models.AlunoModel", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AmbienteEscolarCursoVideo.Models.MateriaModel", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.ProfessorModel", b =>
                {
                    b.HasOne("AmbienteEscolarCursoVideo.Models.MateriaModel", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("ProfessorModelTurmaModel", b =>
                {
                    b.HasOne("AmbienteEscolarCursoVideo.Models.ProfessorModel", null)
                        .WithMany()
                        .HasForeignKey("ProfessoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AmbienteEscolarCursoVideo.Models.TurmaModel", null)
                        .WithMany()
                        .HasForeignKey("TurmasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AmbienteEscolarCursoVideo.Models.TurmaModel", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
