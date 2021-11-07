namespace ProducatoriLocali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "PostStartDate", c => c.DateTime());
            AlterColumn("dbo.Product", "PostEndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "PostEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Product", "PostStartDate", c => c.DateTime(nullable: false));
        }
    }
}
