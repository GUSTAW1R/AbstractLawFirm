namespace AbstractLawFirm___ServiceImplementDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArchiveComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArchiveId = c.Int(nullable: false),
                        BlankId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Archives", t => t.ArchiveId, cascadeDelete: true)
                .ForeignKey("dbo.Blanks", t => t.BlankId, cascadeDelete: true)
                .Index(t => t.ArchiveId)
                .Index(t => t.BlankId);
            
            CreateTable(
                "dbo.Archives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArchiveName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlankName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DocumentBlanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentsId = c.Int(nullable: false),
                        BlankId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blanks", t => t.BlankId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentsId, cascadeDelete: true)
                .Index(t => t.DocumentsId)
                .Index(t => t.BlankId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentsName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DocumentsId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentsId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.DocumentsId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DocumentsId", "dbo.Documents");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.DocumentBlanks", "DocumentsId", "dbo.Documents");
            DropForeignKey("dbo.DocumentBlanks", "BlankId", "dbo.Blanks");
            DropForeignKey("dbo.ArchiveComponents", "BlankId", "dbo.Blanks");
            DropForeignKey("dbo.ArchiveComponents", "ArchiveId", "dbo.Archives");
            DropIndex("dbo.Orders", new[] { "DocumentsId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.DocumentBlanks", new[] { "BlankId" });
            DropIndex("dbo.DocumentBlanks", new[] { "DocumentsId" });
            DropIndex("dbo.ArchiveComponents", new[] { "BlankId" });
            DropIndex("dbo.ArchiveComponents", new[] { "ArchiveId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Documents");
            DropTable("dbo.DocumentBlanks");
            DropTable("dbo.Blanks");
            DropTable("dbo.Archives");
            DropTable("dbo.ArchiveComponents");
        }
    }
}
