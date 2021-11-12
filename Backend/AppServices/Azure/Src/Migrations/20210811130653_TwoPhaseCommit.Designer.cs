﻿// <auto-generated />
using System;
using CloudYourself.Backend.AppServices.Azure.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloudYourself.Backend.AppServices.Azure.Migrations
{
    [DbContext(typeof(AzureDbContext))]
    [Migration("20210811130653_TwoPhaseCommit")]
    partial class TwoPhaseCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResource.ManagedResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("ManagedResources");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResourceDeployment.ManagedResourceDeployment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CommitDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManagedResourceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parameters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PrepareDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagedResourceId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("ManagedResourceDeployments");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.Subscription.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CloudAccountId")
                        .HasColumnType("int");

                    b.Property<string>("CreationOperationUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("SubscriptionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubscriptionLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.Tennant.TenantSettings", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TenantSettings");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResource.ManagedResource", b =>
                {
                    b.HasOne("CloudYourself.Backend.AppServices.Azure.Aggregates.Tennant.TenantSettings", null)
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResource.ArmTemplate", "ArmTemplate", b1 =>
                        {
                            b1.Property<int>("ManagedResourceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Template")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ManagedResourceId");

                            b1.ToTable("ManagedResources");

                            b1.WithOwner()
                                .HasForeignKey("ManagedResourceId");
                        });

                    b.OwnsOne("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResource.BaseData", "BaseData", b1 =>
                        {
                            b1.Property<int>("ManagedResourceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ManagedResourceId");

                            b1.ToTable("ManagedResources");

                            b1.WithOwner()
                                .HasForeignKey("ManagedResourceId");
                        });

                    b.OwnsOne("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResource.ComplianceSettings", "ComplianceSettings", b1 =>
                        {
                            b1.Property<int>("ManagedResourceId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("InitiativeAssignmentName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("InitiativeDefinitionId")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ManagedResourceId");

                            b1.ToTable("ManagedResources");

                            b1.WithOwner()
                                .HasForeignKey("ManagedResourceId");
                        });

                    b.Navigation("ArmTemplate");

                    b.Navigation("BaseData");

                    b.Navigation("ComplianceSettings");
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResourceDeployment.ManagedResourceDeployment", b =>
                {
                    b.HasOne("CloudYourself.Backend.AppServices.Azure.Aggregates.ManagedResource.ManagedResource", null)
                        .WithMany()
                        .HasForeignKey("ManagedResourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CloudYourself.Backend.AppServices.Azure.Aggregates.Subscription.Subscription", null)
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.Subscription.Subscription", b =>
                {
                    b.HasOne("CloudYourself.Backend.AppServices.Azure.Aggregates.Tennant.TenantSettings", null)
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CloudYourself.Backend.AppServices.Azure.Aggregates.Tennant.TenantSettings", b =>
                {
                    b.OwnsOne("CloudYourself.Backend.AppServices.Azure.Aggregates.Tennant.AppRegistration", "AppRegistration", b1 =>
                        {
                            b1.Property<int>("TenantSettingsId")
                                .HasColumnType("int");

                            b1.Property<string>("AzureAppRegistrationId")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AzureAppSecret")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AzureDirectoryTenantId")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TenantSettingsId");

                            b1.ToTable("TenantSettings");

                            b1.WithOwner()
                                .HasForeignKey("TenantSettingsId");
                        });

                    b.OwnsOne("CloudYourself.Backend.AppServices.Azure.Aggregates.Tennant.ManagementTarget", "ManagementTarget", b1 =>
                        {
                            b1.Property<int>("TenantSettingsId")
                                .HasColumnType("int");

                            b1.Property<string>("EnrollmentAccountId")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ManagementGroupId")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TenantSettingsId");

                            b1.ToTable("TenantSettings");

                            b1.WithOwner()
                                .HasForeignKey("TenantSettingsId");
                        });

                    b.Navigation("AppRegistration");

                    b.Navigation("ManagementTarget");
                });
#pragma warning restore 612, 618
        }
    }
}
