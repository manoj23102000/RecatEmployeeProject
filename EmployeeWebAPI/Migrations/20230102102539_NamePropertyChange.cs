using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NamePropertyChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "EmployeeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employees",
                newName: "Name");
        }
    }
}
