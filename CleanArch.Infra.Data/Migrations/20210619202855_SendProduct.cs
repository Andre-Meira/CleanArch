using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SendProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Categories(Name) Values ('Andre')");


            migrationBuilder.Sql("INSERT iNTO Products(Name,Description,Price,Stock,Image,CategoryId) " +
                "VALUES('Caderno Aspiral', 'Caderno Aspiral 100 folhas', 7.45, 50, 'caderno1.png', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
    
        }
    }
}
