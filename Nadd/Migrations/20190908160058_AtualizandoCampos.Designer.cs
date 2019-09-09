﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nadd.Models;

namespace Nadd.Migrations
{
    [DbContext(typeof(NaddContext))]
    [Migration("20190908160058_AtualizandoCampos")]
    partial class AtualizandoCampos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nadd.Model.Area", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("Nadd.Model.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataConclusaoAvaliacao");

                    b.Property<DateTime>("DataInicioAvaliacao");

                    b.Property<int>("Diversificacao");

                    b.Property<int>("EquilibrioDistruibacaoValorQuestao");

                    b.Property<int>("MultiplaEscolhaDiscursiva");

                    b.Property<int>("NumeroQuestoes");

                    b.Property<string>("Observacoes");

                    b.Property<int>("QuestaoContextualizada");

                    b.Property<int>("ReferenciasBibliograficas");

                    b.Property<int>("SomatorioValoresQuestoes");

                    b.Property<int>("ValorProvaExplicito");

                    b.Property<int>("ValorQuestaoExplicito");

                    b.Property<int>("ValorTotalProva");

                    b.HasKey("Id");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Nadd.Model.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaID");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AreaID");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Nadd.Model.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano");

                    b.Property<int>("CargaHoraria");

                    b.Property<int>("CursoID");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Periodo");

                    b.Property<int>("ProfessorID");

                    b.HasKey("Id");

                    b.HasIndex("CursoID");

                    b.HasIndex("ProfessorID");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("Nadd.Model.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular");

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("Nadd.Model.Curso", b =>
                {
                    b.HasOne("Nadd.Model.Area", "Area")
                        .WithMany("Cursos")
                        .HasForeignKey("AreaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nadd.Model.Disciplina", b =>
                {
                    b.HasOne("Nadd.Model.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Nadd.Model.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}