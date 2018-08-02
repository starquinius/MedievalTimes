﻿// <auto-generated />
using System;
using MedievalTimes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedievalTimes.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedievalTimes.Areas.CharCreation.Models.Attributes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Charisma");

                    b.Property<int>("Constitution");

                    b.Property<int>("Dexterity");

                    b.Property<int>("Intelligence");

                    b.Property<int>("Strength");

                    b.Property<int>("Wisdom");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("MedievalTimes.Areas.CharCreation.Models.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Alignment");

                    b.Property<int>("Attitude");

                    b.Property<Guid?>("AttributesId");

                    b.Property<int>("Beroepen");

                    b.Property<bool>("IsFinished");

                    b.Property<string>("Name");

                    b.Property<Guid?>("RacesRaceId");

                    b.Property<int>("Sexe");

                    b.HasKey("Id");

                    b.HasIndex("AttributesId");

                    b.HasIndex("RacesRaceId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("MedievalTimes.Areas.CharCreation.Models.Dice", b =>
                {
                    b.Property<Guid>("DiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiceSide");

                    b.Property<int>("Modifier");

                    b.Property<int>("NrDice");

                    b.HasKey("DiceId");

                    b.ToTable("Dice");
                });

            modelBuilder.Entity("MedievalTimes.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("DesiredRol");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MedievalTimes.Models.AttrStrength", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BendBarsLiftGates");

                    b.Property<int>("DmgAdj");

                    b.Property<int>("HitProb");

                    b.Property<int>("MaxPress");

                    b.Property<string>("Notes");

                    b.Property<int>("OpenClosedDoors");

                    b.Property<int>("OpenDoors");

                    b.Property<int>("Str");

                    b.Property<int>("StrMaxP");

                    b.Property<int>("StrMinP");

                    b.Property<int>("WeightAllow");

                    b.HasKey("Id");

                    b.ToTable("Strength");
                });

            modelBuilder.Entity("MedievalTimes.Models.Class", b =>
                {
                    b.Property<Guid>("ClassId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HitDiceMaxLvl");

                    b.Property<int>("HitDiceMaxLvlModifier");

                    b.Property<int>("HitDiceNr");

                    b.Property<int>("HitDiceSide");

                    b.Property<int>("Name");

                    b.Property<Guid?>("XpLevelingId");

                    b.HasKey("ClassId");

                    b.HasIndex("XpLevelingId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("MedievalTimes.Models.ClassAbilityRequirements", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Beroep");

                    b.Property<bool>("ChaPrime");

                    b.Property<bool>("ConPrime");

                    b.Property<bool>("DexPrime");

                    b.Property<bool>("IntPrime");

                    b.Property<int>("MinCha");

                    b.Property<int>("MinCon");

                    b.Property<int>("MinDex");

                    b.Property<int>("MinInt");

                    b.Property<int>("MinStr");

                    b.Property<int>("MinWis");

                    b.Property<bool>("RaceDwarf");

                    b.Property<bool>("RaceElf");

                    b.Property<bool>("RaceGnome");

                    b.Property<bool>("RaceHalfElf");

                    b.Property<bool>("RaceHalfling");

                    b.Property<bool>("RaceHuman");

                    b.Property<bool>("StrPrime");

                    b.Property<bool>("WisPrime");

                    b.HasKey("Id");

                    b.ToTable("ClassAttrReq");
                });

            modelBuilder.Entity("MedievalTimes.Models.Race", b =>
                {
                    b.Property<Guid>("RaceId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AgeModifierDiceId");

                    b.Property<int>("BaseAge");

                    b.Property<int>("BaseHeightF");

                    b.Property<int>("BaseHeightM");

                    b.Property<int>("BaseMaxAge");

                    b.Property<int>("BaseWeightF");

                    b.Property<int>("BaseWeightM");

                    b.Property<Guid?>("HeightModifierDiceId");

                    b.Property<Guid?>("MaxAgeModifierDiceId");

                    b.Property<string>("Name");

                    b.Property<Guid?>("WeightModifierDiceId");

                    b.HasKey("RaceId");

                    b.HasIndex("AgeModifierDiceId");

                    b.HasIndex("HeightModifierDiceId");

                    b.HasIndex("MaxAgeModifierDiceId");

                    b.HasIndex("WeightModifierDiceId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("MedievalTimes.Models.RacialAttributeAdjustment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChaModifier");

                    b.Property<int>("ConModifier");

                    b.Property<int>("DexModifier");

                    b.Property<int>("IntModifier");

                    b.Property<int>("MaxCha");

                    b.Property<int>("MaxCon");

                    b.Property<int>("MaxDex");

                    b.Property<int>("MaxInt");

                    b.Property<int>("MaxStr");

                    b.Property<int>("MaxWis");

                    b.Property<int>("MinCha");

                    b.Property<int>("MinCon");

                    b.Property<int>("MinDex");

                    b.Property<int>("MinInt");

                    b.Property<int>("MinStr");

                    b.Property<int>("MinWis");

                    b.Property<Guid?>("RaceId");

                    b.Property<int>("StrModifier");

                    b.Property<int>("WisModifier");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("RacialAttrReq");
                });

            modelBuilder.Entity("MedievalTimes.Models.XpLeveling", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("XpNeededLvl1");

                    b.Property<int>("XpNeededLvl10");

                    b.Property<int>("XpNeededLvl11");

                    b.Property<int>("XpNeededLvl12");

                    b.Property<int>("XpNeededLvl13");

                    b.Property<int>("XpNeededLvl14");

                    b.Property<int>("XpNeededLvl15");

                    b.Property<int>("XpNeededLvl16");

                    b.Property<int>("XpNeededLvl17");

                    b.Property<int>("XpNeededLvl18");

                    b.Property<int>("XpNeededLvl19");

                    b.Property<int>("XpNeededLvl2");

                    b.Property<int>("XpNeededLvl20");

                    b.Property<int>("XpNeededLvl3");

                    b.Property<int>("XpNeededLvl4");

                    b.Property<int>("XpNeededLvl5");

                    b.Property<int>("XpNeededLvl6");

                    b.Property<int>("XpNeededLvl7");

                    b.Property<int>("XpNeededLvl8");

                    b.Property<int>("XpNeededLvl9");

                    b.Property<int>("XpNeededMax");

                    b.HasKey("Id");

                    b.ToTable("XpLeveling");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MedievalTimes.Areas.CharCreation.Models.Character", b =>
                {
                    b.HasOne("MedievalTimes.Areas.CharCreation.Models.Attributes", "Attributes")
                        .WithMany()
                        .HasForeignKey("AttributesId");

                    b.HasOne("MedievalTimes.Models.Race", "Races")
                        .WithMany()
                        .HasForeignKey("RacesRaceId");
                });

            modelBuilder.Entity("MedievalTimes.Models.Class", b =>
                {
                    b.HasOne("MedievalTimes.Models.XpLeveling", "XpLeveling")
                        .WithMany()
                        .HasForeignKey("XpLevelingId");
                });

            modelBuilder.Entity("MedievalTimes.Models.Race", b =>
                {
                    b.HasOne("MedievalTimes.Areas.CharCreation.Models.Dice", "AgeModifier")
                        .WithMany()
                        .HasForeignKey("AgeModifierDiceId");

                    b.HasOne("MedievalTimes.Areas.CharCreation.Models.Dice", "HeightModifier")
                        .WithMany()
                        .HasForeignKey("HeightModifierDiceId");

                    b.HasOne("MedievalTimes.Areas.CharCreation.Models.Dice", "MaxAgeModifier")
                        .WithMany()
                        .HasForeignKey("MaxAgeModifierDiceId");

                    b.HasOne("MedievalTimes.Areas.CharCreation.Models.Dice", "WeightModifier")
                        .WithMany()
                        .HasForeignKey("WeightModifierDiceId");
                });

            modelBuilder.Entity("MedievalTimes.Models.RacialAttributeAdjustment", b =>
                {
                    b.HasOne("MedievalTimes.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MedievalTimes.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MedievalTimes.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedievalTimes.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MedievalTimes.Areas.Identity.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
