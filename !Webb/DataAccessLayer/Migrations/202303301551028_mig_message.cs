namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageInboxIsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageInboxIsRead");
        }
    }
}
