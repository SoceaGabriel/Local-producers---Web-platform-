namespace ProducatoriLocali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addsomefields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "UnitsNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Product", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImagePath");
            DropColumn("dbo.Product", "UnitsNumber");
        }
    }
}
