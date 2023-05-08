namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writerattention : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAttention1", c => c.String(maxLength: 30));
            AddColumn("dbo.Writers", "WriterAttention2", c => c.String(maxLength: 30));
            AddColumn("dbo.Writers", "WriterAttention3", c => c.String(maxLength: 30));
            AddColumn("dbo.Writers", "WriterAttention4", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterAttention4");
            DropColumn("dbo.Writers", "WriterAttention3");
            DropColumn("dbo.Writers", "WriterAttention2");
            DropColumn("dbo.Writers", "WriterAttention1");
        }
    }
}
