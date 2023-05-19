using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rocket_Launch_Database__2_.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LaunchSites')
BEGIN
    CREATE TABLE [dbo].[LaunchSites] (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(MAX) NOT NULL,
        [Location] NVARCHAR(MAX) NOT NULL,
        CONSTRAINT [PK_LaunchSites] PRIMARY KEY ([Id])
    );
END
");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LaunchVehicles')
BEGIN
    CREATE TABLE [dbo].[LaunchVehicles] (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(MAX) NOT NULL,
        [Manufacturer] NVARCHAR(MAX) NOT NULL,
        CONSTRAINT [PK_LaunchVehicles] PRIMARY KEY ([Id])
    );
END
");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Payloads')
BEGIN
    CREATE TABLE [dbo].[Payloads] (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(MAX) NOT NULL,
        [Type] NVARCHAR(MAX) NOT NULL,
        [Weight] REAL NOT NULL,
        CONSTRAINT [PK_Payloads] PRIMARY KEY ([Id])
    );
END
");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users')
BEGIN
    CREATE TABLE [dbo].[Users] (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [Name] NVARCHAR(MAX) NOT NULL,
        [Email] NVARCHAR(MAX) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END
");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RocketLaunches')
BEGIN
    CREATE TABLE [dbo].[RocketLaunches] (
        [Id] INT NOT NULL IDENTITY(1, 1),
        [LaunchSiteId] INT NOT NULL,
        [LaunchVehicleId] INT NOT NULL,
        [PayloadId] INT NOT NULL,
        [UserId] INT NOT NULL,
        [LaunchDate] DATETIME2 NOT NULL,
        [MissionOutcome] NVARCHAR(MAX) NOT NULL,
        CONSTRAINT [PK_RocketLaunches] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RocketLaunches_LaunchSites_LaunchSiteId] FOREIGN KEY ([LaunchSiteId]) REFERENCES [LaunchSites] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RocketLaunches_LaunchVehicles_LaunchVehicleId] FOREIGN KEY ([LaunchVehicleId]) REFERENCES [LaunchVehicles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RocketLaunches_Payloads_PayloadId] FOREIGN KEY ([PayloadId]) REFERENCES [Payloads] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_RocketLaunches_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END
");

            migrationBuilder.InsertData(
                table: "LaunchSites",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
            { 1, "USA", "Site A" },
            { 2, "Russia", "Site B" }
                });

            migrationBuilder.InsertData(
                table: "LaunchVehicles",
                columns: new[] { "Id", "Manufacturer", "Name" },
                values: new object[,]
                {
            { 1, "SpaceX", "Falcon 9" },
            { 2, "Roscosmos", "Soyuz" }
                });

            migrationBuilder.InsertData(
                table: "Payloads",
                columns: new[] { "Id", "Name", "Type", "Weight" },
                values: new object[,]
                {
            { 1, "Payload A", "Satellite", 1000f },
            { 2, "Payload B", "Spacecraft", 2000f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
            { 1, "alice@example.com", "Alice" },
            { 2, "bob@example.com", "Bob" }
                });

            migrationBuilder.InsertData(
    table: "RocketLaunches",
    columns: new[] { "Id", "LaunchDate", "LaunchSiteId", "LaunchVehicleId", "MissionOutcome", "PayloadId", "UserId" },
    values: new object[,]
    {
        { 1, "2023-01-01", 1, 1, "Success", 1, 1 },
        { 2, "2023-02-01", 2, 2, "Failure", 2, 2 }
    });



            migrationBuilder.CreateIndex(
                name: "IX_RocketLaunches_LaunchSiteId",
                table: "RocketLaunches",
                column: "LaunchSiteId");

            migrationBuilder.CreateIndex(
    name: "IX_RocketLaunches_LaunchVehicleId",
    table: "RocketLaunches",
    column: "LaunchVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_RocketLaunches_PayloadId",
                table: "RocketLaunches",
                column: "PayloadId");

            migrationBuilder.CreateIndex(
                name: "IX_RocketLaunches_UserId",
                table: "RocketLaunches",
                column: "UserId");
        }




        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RocketLaunches");

            migrationBuilder.DropTable(
                name: "LaunchSites");

            migrationBuilder.DropTable(
                name: "LaunchVehicles");

            migrationBuilder.DropTable(
                name: "Payloads");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
