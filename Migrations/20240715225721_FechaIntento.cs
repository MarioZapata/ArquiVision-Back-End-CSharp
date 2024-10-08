﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArquiVision.Migrations
{
    public partial class FechaIntento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIntento",
                table: "Usuarios",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaIntento",
                table: "Usuarios");
        }
    }
}
