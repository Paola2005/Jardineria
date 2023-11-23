using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.DataMigrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_Statuses_StatusCode",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "status");

            migrationBuilder.UpdateData(
                table: "status",
                keyColumn: "NameStatus",
                keyValue: null,
                column: "NameStatus",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NameStatus",
                table: "status",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_status",
                table: "status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_status_StatusCode",
                table: "orders",
                column: "StatusCode",
                principalTable: "status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_status_StatusCode",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_status",
                table: "status");

            migrationBuilder.RenameTable(
                name: "status",
                newName: "Statuses");

            migrationBuilder.AlterColumn<string>(
                name: "NameStatus",
                table: "Statuses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Statuses_StatusCode",
                table: "orders",
                column: "StatusCode",
                principalTable: "Statuses",
                principalColumn: "Id");
        }
    }
}
