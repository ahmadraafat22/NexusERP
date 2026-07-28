using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusERP.Infrasructure.Migrations
{
    /// <inheritdoc />
    public partial class addSupplierSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "SupplierSequence");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "SupplierSequence");
        }
    }
}
