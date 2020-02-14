namespace Book_Reading_Event_DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EventDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EventStartTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "EventStartTime", c => c.String());
            AlterColumn("dbo.Events", "EventDescription", c => c.String());
        }
    }
}
