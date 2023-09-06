using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfinityBeyondControllers.Migrations
{
    /// <inheritdoc />
    public partial class hoe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    şifra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oib = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.şifra);
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                columns: table => new
                {
                    şifra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destinacija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NacinPlacanja = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BrojMjesta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.şifra);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Usluga");
        }
    }
}
