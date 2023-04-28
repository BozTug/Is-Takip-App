using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IsTakip.Repository.Migrations
{
    /// <inheritdoc />
    public partial class IsTakip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customerRepresentatives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerRepresentatives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmtpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmtpPort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionLeads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productionOrder = table.Column<int>(type: "int", nullable: false),
                    LeadTime = table.Column<int>(type: "int", nullable: false),
                    productionLeadType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionLeads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleDescription = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    MailNotification = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Officer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OfficerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TaxAdministration = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CustomerClassId = table.Column<int>(type: "int", nullable: false),
                    customerRestriction = table.Column<int>(type: "int", nullable: false),
                    CustomerRepresentativeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerClasses_CustomerClassId",
                        column: x => x.CustomerClassId,
                        principalTable: "CustomerClasses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_customerRepresentatives_CustomerRepresentativeId",
                        column: x => x.CustomerRepresentativeId,
                        principalTable: "customerRepresentatives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "wareHouseShelves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WareHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wareHouseShelves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wareHouseShelves_Warehouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OfferType = table.Column<int>(type: "int", nullable: false),
                    OfferNo = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndNoticeSituation = table.Column<int>(type: "int", nullable: false),
                    BusinessPriority = table.Column<int>(type: "int", nullable: false),
                    CustomerOrderNo = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    BusinessNote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    materialType = table.Column<int>(type: "int", nullable: false),
                    thickness = table.Column<int>(type: "int", nullable: false),
                    Workmanship = table.Column<int>(type: "int", nullable: false),
                    MaterialNote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductionOrder = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Businesses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "wareHouseInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WareHouseId = table.Column<int>(type: "int", nullable: false),
                    WareHouseShelfId = table.Column<int>(type: "int", nullable: false),
                    materialType = table.Column<int>(type: "int", nullable: false),
                    thickness = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wareHouseInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wareHouseInventories_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wareHouseInventories_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wareHouseInventories_Warehouses_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_wareHouseInventories_wareHouseShelves_WareHouseShelfId",
                        column: x => x.WareHouseShelfId,
                        principalTable: "wareHouseShelves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobfileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobfiles_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CustomerClasses",
                columns: new[] { "Id", "Description", "Explanation" },
                values: new object[,]
                {
                    { 1, "Key Accounts", "Partial Partners for our Company" },
                    { 2, "Channel Accounts", "Local Partners for our Company" }
                });

            migrationBuilder.InsertData(
                table: "ProductionLeads",
                columns: new[] { "Id", "LeadTime", "productionLeadType", "productionOrder" },
                values: new object[] { 1, 87, 0, 0 });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Description", "Email", "Explanation", "PhoneNumber" },
                values: new object[] { 1, "SONY Turkey", "sonyturkey@sony.com", "Supplier for Electronic stuff. ", "02169875643" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CustomerId", "MailNotification", "Name", "RoleDescription", "Surname", "UserCode", "UserPassword" },
                values: new object[,]
                {
                    { 1, 1, 0, "Kemal", 0, "Öztürk", "Kemalztrk", "Kemal1234" },
                    { 2, 2, 1, "Eray", 1, "Baydur", "Eraybydr", "Eray1234" },
                    { 3, 3, 0, "Serkan", 3, "Kılıçkap", "Serkanklnckp", "Serkan1234" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Description", "Explanation", "Officer", "OfficerPhone" },
                values: new object[] { 1, "SONY Warehouse", "Electronical Side", "Ziya Duran", "05436785432" });

            migrationBuilder.InsertData(
                table: "customerRepresentatives",
                columns: new[] { "Id", "CustomerId", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, 1, "kemalozturk@gmail.com", "Kemal", "05302427531", "Öztürk" },
                    { 2, 2, "eraybaydur@gmail.com", "Eray", "05302486592", "Baydur" },
                    { 3, 3, "serkanklnckp@gmail.com", "Serkan", "05362428531", "Kılıçkap" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CustomerClassId", "CustomerRepresentativeId", "Description", "Email", "Explanation", "PhoneNumber", "TaxAdministration", "TaxNumber", "UserId", "customerRestriction" },
                values: new object[,]
                {
                    { 1, "İstinye ShoppingMall, -1. Floor, Istanbul/Turkey", 1, 1, "Tarlacılar AŞ.", "tarlacılar@gmail.com", "Outlet Store in Europian Side of Istanbul", "05447986543", "Şişli Tax Administration", 1928374650, 1, 0 },
                    { 2, "Cevahir ShoppingMall, 2. Floor, Istanbul/Turkey", 2, 2, "Akmel AŞ.", "akmel@gmail.com", "Local Partner in Europian Side of Istanbul", "05438974562", "Besiktas Tax Administration", 1928374651, 2, 1 },
                    { 3, "Onur OfisPark Plaza, 3. Floor, Istanbul/Turkey", 1, 3, "Teknosa", "teknosa@gmail.com", "Crucial Partner in Europian Side of Istanbul", "05437674562", "Kadıköy Tax Administration", 1928374653, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "wareHouseShelves",
                columns: new[] { "Id", "Description", "Explanation", "WareHouseId" },
                values: new object[] { 1, "Block A", "Electronical Side", 1 });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "CustomerId", "Explanation" },
                values: new object[] { 1, 1, "The additional information has been given to partner about their business." });

            migrationBuilder.InsertData(
                table: "Businesses",
                columns: new[] { "Id", "BusinessNote", "BusinessPriority", "CustomerId", "CustomerOrderNo", "EndNoticeSituation", "MaterialNote", "OfferNo", "OfferType", "Price", "ProductionOrder", "SupplierId", "Workmanship", "materialType", "thickness" },
                values: new object[] { 1, "It should be delivered within one week", 1, 1, 1, 0, "There is no additional İnformation.", 89765432, 0, 250.00m, 0, 1, 0, 0, 2 });

            migrationBuilder.InsertData(
                table: "wareHouseInventories",
                columns: new[] { "Id", "Amount", "CustomerId", "Explanation", "Length", "SupplierId", "WareHouseId", "WareHouseShelfId", "Weight", "Width", "materialType", "thickness" },
                values: new object[] { 1, 2.3m, 1, "There is sufficient stock.", 10.2m, 1, 1, 1, 0.6m, 12.5m, 0, 0 });

            migrationBuilder.InsertData(
                table: "Jobfiles",
                columns: new[] { "Id", "BusinessId", "JobfileName" },
                values: new object[] { 1, 1, "Order Inluding Playstations" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_CustomerId",
                table: "Agendas",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_CustomerId",
                table: "Businesses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_SupplierId",
                table: "Businesses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerClassId",
                table: "Customers",
                column: "CustomerClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerRepresentativeId",
                table: "Customers",
                column: "CustomerRepresentativeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobfiles_BusinessId",
                table: "Jobfiles",
                column: "BusinessId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_wareHouseInventories_CustomerId",
                table: "wareHouseInventories",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_wareHouseInventories_SupplierId",
                table: "wareHouseInventories",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_wareHouseInventories_WareHouseId",
                table: "wareHouseInventories",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_wareHouseInventories_WareHouseShelfId",
                table: "wareHouseInventories",
                column: "WareHouseShelfId");

            migrationBuilder.CreateIndex(
                name: "IX_wareHouseShelves_WareHouseId",
                table: "wareHouseShelves",
                column: "WareHouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Jobfiles");

            migrationBuilder.DropTable(
                name: "MailParameters");

            migrationBuilder.DropTable(
                name: "ProductionLeads");

            migrationBuilder.DropTable(
                name: "wareHouseInventories");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "wareHouseShelves");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "CustomerClasses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "customerRepresentatives");
        }
    }
}
