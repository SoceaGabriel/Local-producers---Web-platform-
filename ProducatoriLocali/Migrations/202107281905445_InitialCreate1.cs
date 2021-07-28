namespace ProducatoriLocali.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalProducer",
                c => new
                    {
                        LocalProducerId = c.Guid(nullable: false, identity: true),
                        PageTitle = c.String(nullable: false),
                        Description = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.LocalProducerId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Guid(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Single(nullable: false),
                        SellerId = c.Guid(nullable: false),
                        Category = c.Int(nullable: false),
                        SubCategory = c.Int(nullable: false),
                        PostStartDate = c.DateTime(nullable: false),
                        PostEndDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UsersMessages",
                c => new
                    {
                        MessageId = c.Guid(nullable: false, identity: true),
                        UserWhoSendMessageId = c.Guid(nullable: false),
                        UserWhoReceiveMessage = c.Guid(nullable: false),
                        UserWhoSendMessageName = c.String(),
                        UserWhoReceivedMessageName = c.String(),
                        MessageText = c.String(nullable: false),
                        GeneratedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Product", new[] { "User_Id" });
            DropTable("dbo.UsersMessages");
            DropTable("dbo.Product");
            DropTable("dbo.LocalProducer");
        }
    }
}
