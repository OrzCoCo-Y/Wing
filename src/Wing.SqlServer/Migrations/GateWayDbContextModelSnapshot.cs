﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wing.SqlServer;

namespace Wing.SqlServer.Migrations
{
    [DbContext(typeof(GateWayDbContext))]
    partial class GateWayDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wing.Persistence.GateWay.Log", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("AuthKey")
                        .HasColumnType("varchar(8000)");

                    b.Property<string>("ClientIp")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DownstreamUrl")
                        .HasColumnType("varchar(8000)");

                    b.Property<string>("GateWayServerIp")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Policy")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("datetime");

                    b.Property<string>("RequestUrl")
                        .HasColumnType("varchar(8000)");

                    b.Property<string>("RequestValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResponseTime")
                        .HasColumnType("datetime");

                    b.Property<string>("ResponseValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceAddress")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ServiceName")
                        .HasColumnType("varchar(800)");

                    b.Property<int>("StatusCode")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .HasColumnType("varchar(8000)");

                    b.HasKey("Id");

                    b.ToTable("GateWay_Log");
                });
#pragma warning restore 612, 618
        }
    }
}
