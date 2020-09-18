using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Retails.Data.Migrations
{
    public partial class Begin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryToCustomers_Customers_CustomerID",
                table: "DeliveryToCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryToCustomers_Suppliers_SupplierID",
                table: "DeliveryToCustomers");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "DeliveryToCustomers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "DeliveryToCustomers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryToCustomers_Customers_CustomerID",
                table: "DeliveryToCustomers",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryToCustomers_Suppliers_SupplierID",
                table: "DeliveryToCustomers",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryToCustomers_Customers_CustomerID",
                table: "DeliveryToCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryToCustomers_Suppliers_SupplierID",
                table: "DeliveryToCustomers");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierID",
                table: "DeliveryToCustomers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "DeliveryToCustomers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryToCustomers_Customers_CustomerID",
                table: "DeliveryToCustomers",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryToCustomers_Suppliers_SupplierID",
                table: "DeliveryToCustomers",
                column: "SupplierID",
                principalTable: "Suppliers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
