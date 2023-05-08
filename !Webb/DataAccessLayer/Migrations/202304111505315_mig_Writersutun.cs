namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Writersutun : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterExperience", c => c.String());
            AddColumn("dbo.Writers", "WriterPhoneNumber", c => c.String());
            AddColumn("dbo.Writers", "WriterSkill1", c => c.String());
            AddColumn("dbo.Writers", "WriterSkill11", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "WriterSkill2", c => c.String());
            AddColumn("dbo.Writers", "WriterSkill22", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "WriterSkill3", c => c.String());
            AddColumn("dbo.Writers", "WriterSkill33", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "WriterSkill4", c => c.String());
            AddColumn("dbo.Writers", "WriterSkill44", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "WriterSkill5", c => c.String());
            AddColumn("dbo.Writers", "WriterSkill55", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "WriterSkill6", c => c.String());
            AddColumn("dbo.Writers", "WriterSkill66", c => c.Int(nullable: false));
            AddColumn("dbo.Writers", "WriterDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterDateTime");
            DropColumn("dbo.Writers", "WriterSkill66");
            DropColumn("dbo.Writers", "WriterSkill6");
            DropColumn("dbo.Writers", "WriterSkill55");
            DropColumn("dbo.Writers", "WriterSkill5");
            DropColumn("dbo.Writers", "WriterSkill44");
            DropColumn("dbo.Writers", "WriterSkill4");
            DropColumn("dbo.Writers", "WriterSkill33");
            DropColumn("dbo.Writers", "WriterSkill3");
            DropColumn("dbo.Writers", "WriterSkill22");
            DropColumn("dbo.Writers", "WriterSkill2");
            DropColumn("dbo.Writers", "WriterSkill11");
            DropColumn("dbo.Writers", "WriterSkill1");
            DropColumn("dbo.Writers", "WriterPhoneNumber");
            DropColumn("dbo.Writers", "WriterExperience");
        }
    }
}
