using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StuffForSale.Migrations
{
    public partial class _007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 99);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c", 0, "ae5ebbc6-ba14-4132-8714-a9f6aca723be", "nmaciej@protonmail.com", true, true, null, "NMACIEJ@PROTONMAIL.COM", "MACIEK", "AQAAAAEAACcQAAAAELAzZ3tmJKhfsN/fhGiVPdOBk/eXlUAIHHcL7PCLAI1vnOMpxlEmSB35k55kZcGUeA==", null, false, "XMYKPC2LMH5E6DBEY6DGSAWZZJ6NL6M2", false, "Maciek" },
                    { "a0340822-14f8-4566-b6ee-4e3ef5c78703", 0, "2b12c3c3-495c-41d1-b440-7d6128b8b8b8", "tomek@gmail.com", true, true, null, "TOMEK@GMAIL.COM", "TOMEK", "AQAAAAEAACcQAAAAEBV+zKkaD9R58syCgGx3mvRUzxt+hPywa9nTLpNNddanIa63J/QcH4K6UMOt/5txMQ==", null, false, "OWUMF4V3ZJ2NYNXS4M5FNJNPPK6NOZ6U", false, "Tomek" },
                    { "b3d46ee7-2dac-48ea-9e05-98d76b506c91", 0, "3769e618-c6c9-49e0-81b8-6ec173dd44fa", "magda@gmail.com", true, true, null, "MAGDA@GMAIL.COM", "MAGDA", "AQAAAAEAACcQAAAAENyD3d41SivJb80HeW+AVkDZcY/d3WdNwJFCaj3c1BB4U+acGCjSd6aNN3sRJBUWFA==", null, false, "KLPSNGMDE435QGKUUF7SSTPRG6OOYDXF", false, "Magda" },
                    { "e973450a-ae95-427a-8bf9-6eaa367bac15", 0, "6f5d76d0-33a6-4a30-a58d-5381e5e4003b", "fleamarketstuffforsale@gmail.com", true, true, null, "FLEAMARKETSTUFFFORSALE@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEEKkaUCUXCB4DCuQJ3kw0fK/7wwZNYH0ZSo9fpoAO6B3r1R26XdrOfGh3Ons+oOrTQ==", null, false, "OYG5PPEIRBJDZISCE62VMDZXOBYXM5YL", false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Name" },
                values: new object[,]
                {
                    { 103, "Books" },
                    { 104, "Cars" },
                    { 105, "Others" },
                    { 106, "Clothes" },
                    { 107, "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DateAdded", "Description", "Name", "Price", "Quantity", "TagId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Advanced programming", "ASP.NET Core MVC 2", 119.99m, 5, 103, "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                    { 2, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Stanisław Lem", "Solaris", 43.99m, 2, 103, "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                    { 3, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Corolla", "Toyota", 1999.00m, 1, 104, "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                    { 4, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Civic", "Honda", 2500.00m, 1, 104, "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                    { 5, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Green", "Sofa", 99.00m, 1, 107, "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                    { 6, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Python basics", "Learn Python", 35.00m, 1, 103, "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                    { 7, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Python ML", "Sklearn & Tensorflow", 44.00m, 1, 103, "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c" },
                    { 9, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "BOSH", "Drill", 345.00m, 1, 105, "a0340822-14f8-4566-b6ee-4e3ef5c78703" },
                    { 10, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Flat", "Screwdriver", 15.00m, 1, 105, "a0340822-14f8-4566-b6ee-4e3ef5c78703" },
                    { 8, new DateTime(2018, 10, 19, 22, 1, 44, 0, DateTimeKind.Unspecified), "Oak", "Chair", 1599.00m, 1, 107, "b3d46ee7-2dac-48ea-9e05-98d76b506c91" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e973450a-ae95-427a-8bf9-6eaa367bac15", "6f5d76d0-33a6-4a30-a58d-5381e5e4003b" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2ff1abb4-7cf1-461e-a1f0-c322fa09f73c", "ae5ebbc6-ba14-4132-8714-a9f6aca723be" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a0340822-14f8-4566-b6ee-4e3ef5c78703", "2b12c3c3-495c-41d1-b440-7d6128b8b8b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b3d46ee7-2dac-48ea-9e05-98d76b506c91", "3769e618-c6c9-49e0-81b8-6ec173dd44fa" });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: 107);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Name" },
                values: new object[] { 98, "98" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Name" },
                values: new object[] { 99, "99" });
        }
    }
}
