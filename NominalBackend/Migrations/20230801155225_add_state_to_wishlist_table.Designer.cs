﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NominalBackend.Persistence;

#nullable disable

namespace NominalBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230801155225_add_state_to_wishlist_table")]
    partial class add_state_to_wishlist_table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NominalBackend.Domain.Categories.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "state");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_at");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NominalBackend.Domain.Images.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "bytes");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "filename");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "item_id");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "size");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "state");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_at");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "url");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("NominalBackend.Domain.Items.Models.Dimensions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Depth")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "depth");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "height");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "unit");

                    b.Property<decimal?>("Width")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "width");

                    b.HasKey("Id");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("NominalBackend.Domain.Items.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<int?>("DimensionsId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "dimension_id");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "material");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "price");

                    b.Property<decimal>("PriceBeforeDiscount")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "price_before_discount");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "state");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "sub_category_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_at");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "weight");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DimensionsId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("NominalBackend.Domain.Purchases.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "payment_method");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "purchase_date");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "shipping_address");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "purchase_date");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasAnnotation("Relational:JsonPropertyName", "total_price");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("NominalBackend.Domain.Purchases.Models.PurchaseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "item_id");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "purchase_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "quantity");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PurchaseItem");
                });

            modelBuilder.Entity("NominalBackend.Domain.SubCategories.Models.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "category_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "state");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_at");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("NominalBackend.Domain.Users.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "birthDate");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit")
                        .HasAnnotation("Relational:JsonPropertyName", "blocked");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<bool>("EmailVerified")
                        .HasColumnType("bit")
                        .HasAnnotation("Relational:JsonPropertyName", "email_verified");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "firstName");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "gender");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "lastName");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "nationality");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "otp");

                    b.Property<bool>("OtpVerified")
                        .HasColumnType("bit")
                        .HasAnnotation("Relational:JsonPropertyName", "otp_verified");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasAnnotation("Relational:JsonPropertyName", "password");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "phone");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "role");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "state");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NominalBackend.Domain.Wishlists.Models.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "item_id");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "state");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "user_id");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("NominalBackend.Domain.Images.Models.Image", b =>
                {
                    b.HasOne("NominalBackend.Domain.Items.Models.Item", "Item")
                        .WithMany("Images")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("NominalBackend.Domain.Items.Models.Item", b =>
                {
                    b.HasOne("NominalBackend.Domain.Categories.Models.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");

                    b.HasOne("NominalBackend.Domain.Items.Models.Dimensions", "Dimensions")
                        .WithMany()
                        .HasForeignKey("DimensionsId");

                    b.HasOne("NominalBackend.Domain.SubCategories.Models.SubCategory", "SubCategory")
                        .WithMany("Items")
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("Category");

                    b.Navigation("Dimensions");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("NominalBackend.Domain.Purchases.Models.Purchase", b =>
                {
                    b.HasOne("NominalBackend.Domain.Users.Models.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NominalBackend.Domain.Purchases.Models.PurchaseItem", b =>
                {
                    b.HasOne("NominalBackend.Domain.Items.Models.Item", "Item")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NominalBackend.Domain.Purchases.Models.Purchase", "Purchase")
                        .WithMany("PurchaseItems")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("NominalBackend.Domain.SubCategories.Models.SubCategory", b =>
                {
                    b.HasOne("NominalBackend.Domain.Categories.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NominalBackend.Domain.Wishlists.Models.Wishlist", b =>
                {
                    b.HasOne("NominalBackend.Domain.Items.Models.Item", "Item")
                        .WithMany("Wishlists")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NominalBackend.Domain.Users.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NominalBackend.Domain.Categories.Models.Category", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("NominalBackend.Domain.Items.Models.Item", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("PurchaseItems");

                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("NominalBackend.Domain.Purchases.Models.Purchase", b =>
                {
                    b.Navigation("PurchaseItems");
                });

            modelBuilder.Entity("NominalBackend.Domain.SubCategories.Models.SubCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("NominalBackend.Domain.Users.Models.User", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
