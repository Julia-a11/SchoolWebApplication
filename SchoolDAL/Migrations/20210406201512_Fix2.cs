using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDAL.Migrations
{
    public partial class Fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Sum",
                table: "Societies",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Sum",
                table: "Societies",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
