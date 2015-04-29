namespace SystemEkspercki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Int(nullable: false),
                        FuzzyQuestion_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.FuzzyQuestion_Id)
                .Index(t => t.FuzzyQuestion_Id);
            
            CreateTable(
                "dbo.Laptops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LaptopBoolValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaptopId = c.Int(nullable: false),
                        BoolQuestionId = c.Int(nullable: false),
                        Value = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laptops", t => t.LaptopId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.BoolQuestionId, cascadeDelete: true)
                .Index(t => t.LaptopId)
                .Index(t => t.BoolQuestionId);
            
            CreateTable(
                "dbo.LaptopFuzzyValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaptopId = c.Int(nullable: false),
                        FuzzyQuestionId = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laptops", t => t.LaptopId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.FuzzyQuestionId, cascadeDelete: true)
                .Index(t => t.LaptopId)
                .Index(t => t.FuzzyQuestionId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LaptopFuzzyValues", new[] { "FuzzyQuestionId" });
            DropIndex("dbo.LaptopFuzzyValues", new[] { "LaptopId" });
            DropIndex("dbo.LaptopBoolValues", new[] { "BoolQuestionId" });
            DropIndex("dbo.LaptopBoolValues", new[] { "LaptopId" });
            DropIndex("dbo.Answers", new[] { "FuzzyQuestion_Id" });
            DropForeignKey("dbo.LaptopFuzzyValues", "FuzzyQuestionId", "dbo.Questions");
            DropForeignKey("dbo.LaptopFuzzyValues", "LaptopId", "dbo.Laptops");
            DropForeignKey("dbo.LaptopBoolValues", "BoolQuestionId", "dbo.Questions");
            DropForeignKey("dbo.LaptopBoolValues", "LaptopId", "dbo.Laptops");
            DropForeignKey("dbo.Answers", "FuzzyQuestion_Id", "dbo.Questions");
            DropTable("dbo.LaptopFuzzyValues");
            DropTable("dbo.LaptopBoolValues");
            DropTable("dbo.Laptops");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
        }
    }
}
