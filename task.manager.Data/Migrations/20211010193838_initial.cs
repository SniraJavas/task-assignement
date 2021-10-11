using Microsoft.EntityFrameworkCore.Migrations;

namespace task.manager.data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Manager",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Surname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Manager", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Project",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false),
            //        Duration = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
            //        Remaining = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
            //        Manager_Id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Project", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Status",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Status", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Task",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Estimation = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
            //        Active = table.Column<bool>(type: "bit", nullable: false),
            //        Remaining = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
            //        Manager_Id = table.Column<int>(type: "int", nullable: false),
            //        Status_Id = table.Column<int>(type: "int", nullable: false),
            //        Project_Id = table.Column<int>(type: "int", nullable: false),
            //        Member_Id = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Task", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Worker",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Surname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Active = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Worker", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Worker");
        }
    }
}
