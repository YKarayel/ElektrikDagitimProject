﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class asdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 17, 57, 17, 519, DateTimeKind.Local).AddTicks(5313));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 17, 37, 3, 156, DateTimeKind.Local).AddTicks(7994));
        }
    }
}