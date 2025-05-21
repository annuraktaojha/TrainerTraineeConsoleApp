using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentEnrollment.Migrations
{
    /// <inheritdoc />
    public partial class TPCstatergy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnlineCourses_Course_CourseId",
                table: "OnlineCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_OnsiteCourses_Course_CourseId",
                table: "OnsiteCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentEnrollments_Course_CourseId",
                table: "StudentEnrollments");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.CreateSequence(
                name: "CourseSequence");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "OnsiteCourses",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [CourseSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OnsiteCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "OnlineCourses",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR [CourseSequence]",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OnlineCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OnsiteCourses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OnlineCourses");

            migrationBuilder.DropSequence(
                name: "CourseSequence");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "OnsiteCourses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [CourseSequence]");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "OnlineCourses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR [CourseSequence]");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineCourses_Course_CourseId",
                table: "OnlineCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnsiteCourses_Course_CourseId",
                table: "OnsiteCourses",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentEnrollments_Course_CourseId",
                table: "StudentEnrollments",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
