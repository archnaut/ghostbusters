namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicketsToEvent : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tickets", "EventId");
            AddForeignKey("dbo.Tickets", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "EventId" });
        }
    }
}
