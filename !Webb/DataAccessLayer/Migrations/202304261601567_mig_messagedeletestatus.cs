namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messagedeletestatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageDeleteStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageDeleteStatus");
        }
    }
}
