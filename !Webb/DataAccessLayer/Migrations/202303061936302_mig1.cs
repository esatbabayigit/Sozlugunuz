namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "Heading_HeadingWriter", "dbo.Headings");
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "Heading_HeadingWriter" });
            DropColumn("dbo.Contents", "HeadingID");
            RenameColumn(table: "dbo.Contents", name: "Heading_HeadingWriter", newName: "HeadingID");
            DropPrimaryKey("dbo.Headings");
            AlterColumn("dbo.Headings", "HeadingID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Contents", "WriterID", c => c.Int());
            AlterColumn("dbo.Contents", "HeadingID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Headings", "HeadingID");
            CreateIndex("dbo.Contents", "HeadingID");
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID");
            DropColumn("dbo.Headings", "HeadingWriter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "HeadingWriter", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            DropPrimaryKey("dbo.Headings");
            AlterColumn("dbo.Contents", "HeadingID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Contents", "WriterID", c => c.Int(nullable: false));
            AlterColumn("dbo.Headings", "HeadingID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Headings", "HeadingWriter");
            RenameColumn(table: "dbo.Contents", name: "HeadingID", newName: "Heading_HeadingWriter");
            AddColumn("dbo.Contents", "HeadingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "Heading_HeadingWriter");
            CreateIndex("dbo.Contents", "WriterID");
            AddForeignKey("dbo.Contents", "WriterID", "dbo.Writers", "WriterID", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "Heading_HeadingWriter", "dbo.Headings", "HeadingWriter");
        }
    }
}
