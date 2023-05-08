namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactIsRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactIsRead");
        }
    }
}
