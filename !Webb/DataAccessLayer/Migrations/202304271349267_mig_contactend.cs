namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactStatusEnd", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactStatusEnd");
        }
    }
}
