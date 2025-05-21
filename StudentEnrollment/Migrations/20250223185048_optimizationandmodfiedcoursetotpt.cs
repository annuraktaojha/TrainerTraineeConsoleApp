using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class optimizationandmodfiedcoursetotpt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnsiteCourses",
                table: "OnsiteCourses");

            migrationBuilder.DropSequence(
                name: "CourseSequence");

            migrationBuilder.RenameTable(
                name: "OnsiteCourses",
                newName: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Courses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [CourseSequence]")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Courses",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollments_Courses_CourseId",
                table: "StudentEnrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollments_Courses_CourseId",
                table: "StudentEnrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "OnsiteCourses");

            migrationBuilder.CreateSequence(
                name: "CourseSequence");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "OnsiteCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "OnsiteCourses",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [CourseSequence]",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnsiteCourses",
                table: "OnsiteCourses",
                column: "CourseId");

            migrationBuilder.CreateTable(
                name: "OnlineCourses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [CourseSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCourses", x => x.CourseId);
                });
        }
    }
}
