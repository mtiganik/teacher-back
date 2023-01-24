using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teacher.Db.Migrations
{
    public partial class defaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "DateOfBirth", "Description", "Email", "FirstName", "HighestDegree", "Languages", "LastName", "Location", "Phone", "PicturePath", "PriceMax", "PriceMin", "Speciality" },
                values: new object[] { 1, new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Õpetan matemaatikat, Füüsikat, programmeerimist keskkooli, ülikooli tasemel", "mtiganik@gmail.com", "Mihkel", "Ülikool", "Eesti, Inglise, Vene", "Tiganik", "Tallinn, Harjumaa", "55655828", "https://scontent-hel3-1.xx.fbcdn.net/v/t39.30808-6/246660293_10216443541721640_696967518917121996_n.jpg?_nc_cat=106&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=dLGcrq3NYUUAX8ZejJ6&_nc_ht=scontent-hel3-1.xx&oh=00_AfBVRoRLRJF0b3vz2J4XKZ52_WHH7DQLmv-ShjxvRIpxwg&oe=63D174B9", 50, 30, "Insener, Õpetaja" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Basic", "Elementary", "High", "Name", "PostId", "University" },
                values: new object[,]
                {
                    { 1, true, false, true, "Matemaatika", 1, true },
                    { 2, true, true, true, "Füüsika", 1, true },
                    { 3, true, true, true, "Programmeerimine", 1, true }
                });

            migrationBuilder.InsertData(
                table: "TeachingTakesPlace",
                columns: new[] { "Id", "Online", "OtherLocation", "PostId", "StudentsPlace", "TeachersPlace" },
                values: new object[] { 1, true, false, 1, true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeachingTakesPlace",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);
        }
    }
}
