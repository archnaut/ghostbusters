using System.Data.Entity.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    OnSale = c.DateTime(false),
                    Start = c.DateTime(false),
                    End = c.DateTime(false),
                    DoorsOpen = c.DateTime(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tickets",
                c => new
                {
                    Id = c.Int(false, true),
                    EventId = c.Int(false),
                    Name = c.String(),
                    Price = c.Decimal(false, 18, 2)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, true)
                .Index(t => t.EventId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropIndex("dbo.Tickets", new[] {"EventId"});
            DropTable("dbo.Tickets");
            DropTable("dbo.Events");
        }
    }
}