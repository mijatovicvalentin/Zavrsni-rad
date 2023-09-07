using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityBeyondControllers.Migrations
{
    /// <inheritdoc />
    public partial class vrsta_djelatnia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NacinPlacanja",
                table: "Usluga",
                newName: "nacin_placanja");

            migrationBuilder.RenameColumn(
                name: "BrojMjesta",
                table: "Usluga",
                newName: "broj_mjesta");

            migrationBuilder.RenameColumn(
                name: "şifra",
                table: "Usluga",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "şifra",
                table: "Korisnik",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Usluga",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Oib",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "vrste_djelatnika",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vrste_djelatnika", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vrste_djelatnika");

            migrationBuilder.RenameColumn(
                name: "nacin_placanja",
                table: "Usluga",
                newName: "NacinPlacanja");

            migrationBuilder.RenameColumn(
                name: "broj_mjesta",
                table: "Usluga",
                newName: "BrojMjesta");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usluga",
                newName: "şifra");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Korisnik",
                newName: "şifra");

            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Usluga",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Oib",
                table: "Korisnik",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "Korisnik",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
