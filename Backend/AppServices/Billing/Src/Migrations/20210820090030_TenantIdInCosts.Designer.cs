﻿// <auto-generated />
using System;
using CloudYourself.Backend.AppServices.Billing.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloudYourself.Backend.AppServices.Billing.Migrations
{
    [DbContext(typeof(BillingDbContext))]
    [Migration("20210820090030_TenantIdInCosts")]
    partial class TenantIdInCosts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Billing.Aggregates.AllocationKey.AllocationKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CloudAccountId")
                        .HasColumnType("int");

                    b.Property<int>("PayerAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CloudAccountId");

                    b.HasIndex("PayerAccountId");

                    b.ToTable("AllocationKeys");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Billing.Aggregates.CloudAccount.CloudAccount", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CloudAccounts");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Billing.Aggregates.Cost.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CloudAccountId")
                        .HasColumnType("int");

                    b.Property<string>("CostId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CostType")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CloudAccountId");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Billing.Aggregates.PayerAccount.PayerAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PayerAccounts");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Billing.Aggregates.AllocationKey.AllocationKey", b =>
                {
                    b.HasOne("CloudYourself.Backend.AppServices.Billing.Aggregates.CloudAccount.CloudAccount", null)
                        .WithMany()
                        .HasForeignKey("CloudAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloudYourself.Backend.AppServices.Billing.Aggregates.PayerAccount.PayerAccount", null)
                        .WithMany()
                        .HasForeignKey("PayerAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CloudYourself.Backend.AppServices.Billing.Aggregates.AllocationKey.AllocationKeyBaseData", "BaseData", b1 =>
                        {
                            b1.Property<int>("AllocationKeyId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("AllocationPercentage")
                                .HasColumnType("int");

                            b1.HasKey("AllocationKeyId");

                            b1.ToTable("AllocationKeys");

                            b1.WithOwner()
                                .HasForeignKey("AllocationKeyId");
                        });

                    b.Navigation("BaseData");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Billing.Aggregates.Cost.Cost", b =>
                {
                    b.HasOne("CloudYourself.Backend.AppServices.Billing.Aggregates.CloudAccount.CloudAccount", null)
                        .WithMany()
                        .HasForeignKey("CloudAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CloudYourself.Backend.AppServices.Billing.Aggregates.Cost.CostDetails", "CostDetails", b1 =>
                        {
                            b1.Property<int>("CostId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<float>("Amount")
                                .HasColumnType("real");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.Property<DateTime>("PeriodBegin")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("PeriodEnd")
                                .HasColumnType("datetime2");

                            b1.Property<string>("PeriodId")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CostId");

                            b1.ToTable("Costs");

                            b1.WithOwner()
                                .HasForeignKey("CostId");
                        });

                    b.Navigation("CostDetails");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Billing.Aggregates.PayerAccount.PayerAccount", b =>
                {
                    b.OwnsOne("CloudYourself.Backend.AppServices.Billing.Aggregates.PayerAccount.PayerAccountBaseData", "BaseData", b1 =>
                        {
                            b1.Property<int>("PayerAccountId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("ControllingContactPrincipalName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CostCenter")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CostCenterResponsiblePrincipalName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ProfitCenter")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PayerAccountId");

                            b1.ToTable("PayerAccounts");

                            b1.WithOwner()
                                .HasForeignKey("PayerAccountId");
                        });

                    b.Navigation("BaseData");
                });
#pragma warning restore 612, 618
        }
    }
}
