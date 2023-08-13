using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dentistry.Migrations
{
    /// <inheritdoc />
    public partial class InitialDBCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_OperationTypes_OperationTypeID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "OperationNotices",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "OperationsTeeths",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "OperationTypeID",
                table: "Patients",
                newName: "ReceptionID");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_OperationTypeID",
                table: "Patients",
                newName: "IX_Patients_ReceptionID");

            migrationBuilder.CreateTable(
                name: "Receptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReceptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OperationTypeID = table.Column<int>(type: "integer", nullable: false),
                    OperationsTeeths = table.Column<List<int>>(type: "integer[]", nullable: true),
                    OperationNotices = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receptions_OperationTypes_OperationTypeID",
                        column: x => x.OperationTypeID,
                        principalTable: "OperationTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receptions_OperationTypeID",
                table: "Receptions",
                column: "OperationTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Receptions_ReceptionID",
                table: "Patients",
                column: "ReceptionID",
                principalTable: "Receptions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Receptions_ReceptionID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Receptions");

            migrationBuilder.RenameColumn(
                name: "ReceptionID",
                table: "Patients",
                newName: "OperationTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_ReceptionID",
                table: "Patients",
                newName: "IX_Patients_OperationTypeID");

            migrationBuilder.AddColumn<string>(
                name: "OperationNotices",
                table: "Patients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "OperationsTeeths",
                table: "Patients",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_OperationTypes_OperationTypeID",
                table: "Patients",
                column: "OperationTypeID",
                principalTable: "OperationTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
