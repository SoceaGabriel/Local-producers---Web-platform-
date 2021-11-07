namespace ProducatoriLocali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addnewfieldsindb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ReenteredPassword = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Product", "Locality", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Locality");
            DropTable("dbo.User");
        }
    }
}
