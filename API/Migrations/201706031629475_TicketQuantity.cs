namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketQuantity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "EventId" });
            AddColumn("dbo.Tickets", "QuantityAvailable", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "QuantityAvailable");
            CreateIndex("dbo.Tickets", "EventId");
            AddForeignKey("dbo.Tickets", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
