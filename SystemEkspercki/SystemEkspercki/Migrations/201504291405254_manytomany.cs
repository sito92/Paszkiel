namespace SystemEkspercki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "FuzzyQuestion_Id", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "FuzzyQuestion_Id" });
            CreateTable(
                "dbo.AnswerFuzzyQuestions",
                c => new
                    {
                        Answer_Id = c.Int(nullable: false),
                        FuzzyQuestion_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Answer_Id, t.FuzzyQuestion_Id })
                .ForeignKey("dbo.Answers", t => t.Answer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.FuzzyQuestion_Id, cascadeDelete: true)
                .Index(t => t.Answer_Id)
                .Index(t => t.FuzzyQuestion_Id);
            
            DropColumn("dbo.Answers", "FuzzyQuestion_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "FuzzyQuestion_Id", c => c.Int());
            DropIndex("dbo.AnswerFuzzyQuestions", new[] { "FuzzyQuestion_Id" });
            DropIndex("dbo.AnswerFuzzyQuestions", new[] { "Answer_Id" });
            DropForeignKey("dbo.AnswerFuzzyQuestions", "FuzzyQuestion_Id", "dbo.Questions");
            DropForeignKey("dbo.AnswerFuzzyQuestions", "Answer_Id", "dbo.Answers");
            DropTable("dbo.AnswerFuzzyQuestions");
            CreateIndex("dbo.Answers", "FuzzyQuestion_Id");
            AddForeignKey("dbo.Answers", "FuzzyQuestion_Id", "dbo.Questions", "Id");
        }
    }
}
