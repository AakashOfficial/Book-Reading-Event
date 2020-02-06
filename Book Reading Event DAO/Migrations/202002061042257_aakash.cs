namespace Book_Reading_Event_DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aakash : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        EventDescription = c.String(),
                        EventOtherDetails = c.String(),
                        EventLocation = c.String(nullable: false),
                        EventDuration = c.Int(nullable: false),
                        EventType = c.Int(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        EventStartTime = c.String(),
                        EventActive = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvitationActive = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserEmail = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserId", "dbo.Users");
            DropForeignKey("dbo.Invitations", "EventId", "dbo.Events");
            DropIndex("dbo.Invitations", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Invitations");
            DropTable("dbo.Events");
        }
    }
}
