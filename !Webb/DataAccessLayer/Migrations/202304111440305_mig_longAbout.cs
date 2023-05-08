﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_longAbout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterLongAbout", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterLongAbout");
        }
    }
}
