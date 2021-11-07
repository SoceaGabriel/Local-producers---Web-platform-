namespace ProducatoriLocali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", new[] { "User_Id" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", new[] { "User_UserId" });
        }
    }
}
