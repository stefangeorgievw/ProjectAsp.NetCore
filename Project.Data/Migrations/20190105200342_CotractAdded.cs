using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Data.Migrations
{
    public partial class CotractAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_CompaniesProfiles_CompanyId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Jobs_JobId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_UserProfiles_UserId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_CompanyId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_JobId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_UserId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contracts",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ContractId",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Document",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContractId",
                table: "Jobs",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Contracts_ContractId",
                table: "Jobs",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Contracts_ContractId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ContractId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contracts",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobId",
                table: "Contracts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CompanyId",
                table: "Contracts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_JobId",
                table: "Contracts",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UserId",
                table: "Contracts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_CompaniesProfiles_CompanyId",
                table: "Contracts",
                column: "CompanyId",
                principalTable: "CompaniesProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Jobs_JobId",
                table: "Contracts",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_UserProfiles_UserId",
                table: "Contracts",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
