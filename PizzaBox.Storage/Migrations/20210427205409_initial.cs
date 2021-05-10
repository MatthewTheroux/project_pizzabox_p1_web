using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    vegan = table.Column<bool>(type: "bit", nullable: false),
                    veget = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    vegan = table.Column<bool>(type: "bit", nullable: false),
                    veget = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<double>(type: "float", nullable: false),
                    customerEntityId = table.Column<long>(type: "bigint", nullable: true),
                    storeEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_orders_Customers_customerEntityId",
                        column: x => x.customerEntityId,
                        principalTable: "Customers",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_orders_Stores_storeEntityId",
                        column: x => x.storeEntityId,
                        principalTable: "Stores",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderEntityId = table.Column<long>(type: "bigint", nullable: true),
                    CrustEntityId = table.Column<long>(type: "bigint", nullable: true),
                    SauceEntityId = table.Column<long>(type: "bigint", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pizzaType = table.Column<long>(type: "bigint", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Pizzas_Crusts_CrustEntityId",
                        column: x => x.CrustEntityId,
                        principalTable: "Crusts",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_orders_orderEntityId",
                        column: x => x.orderEntityId,
                        principalTable: "orders",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sauces_SauceEntityId",
                        column: x => x.SauceEntityId,
                        principalTable: "Sauces",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    EntityId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pizzaEntityId = table.Column<long>(type: "bigint", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    vegan = table.Column<bool>(type: "bit", nullable: false),
                    veget = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Toppings_Pizzas_pizzaEntityId",
                        column: x => x.pizzaEntityId,
                        principalTable: "Pizzas",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "EntityId", "name" },
                values: new object[] { 1L, "Uncle John" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Discriminator", "name" },
                values: new object[] { 1L, "ChicagoStore", "Chitown Main Street" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Discriminator", "name" },
                values: new object[] { 2L, "NewYorkStore", "Big Apple" });

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerEntityId",
                table: "orders",
                column: "customerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_storeEntityId",
                table: "orders",
                column: "storeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CrustEntityId",
                table: "Pizzas",
                column: "CrustEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_orderEntityId",
                table: "Pizzas",
                column: "orderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SauceEntityId",
                table: "Pizzas",
                column: "SauceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_pizzaEntityId",
                table: "Toppings",
                column: "pizzaEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
