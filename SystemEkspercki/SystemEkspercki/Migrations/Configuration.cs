using System.Collections.Generic;
using SystemEkspercki.Models;
using DotNetOpenAuth.Messaging;

namespace SystemEkspercki.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SystemEkspercki.Models.SystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SystemEkspercki.Models.SystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<Answer> answers = new List<Answer>()
            {
                new Answer() {Name = "Bardzo wa�na", Weight = 10},
                new Answer() {Name = "Wa�na", Weight = 8},
                new Answer() {Name = "Przydatna", Weight = 5},
                new Answer() {Name = "Ma�o przydatna", Weight = 3},
                new Answer() {Name = "Niepotrzebna", Weight = 1}
            };
            answers.ForEach(x=>context.Answers.AddOrUpdate(x));
            context.SaveChanges();
            List<Question> questions = new List<Question>()
            {
                
                new BoolQuestion() {Name = "Czy chcesz u�ywa� laptopa bez zasilacza?"},
                new BoolQuestion() {Name = "Czy chcesz mie� kolekcj� film�w lub gier na swoim komputerze?"},
                new BoolQuestion() {Name = "Czy chcesz mie� kolekcj� film�w lub gier na swoim komputerze?"},
                new BoolQuestion() {Name = "Czy b�dziesz u�ywa� komputera w ekstremalnych warunkach?"},
                new BoolQuestion() {Name = "Czy b�dziesz wykorzystywa� komputer do d�ugotrwa�ego pisania?"},
                new BoolQuestion() {Name = "Czy b�dziesz wykorzystywa� komputer do tworzenia grafiki 2d lub obr�bki foto?"},
                new BoolQuestion() {Name = "Czy b�dziesz wykorzystywa� komputer do tworzenia grafiki 3d?"},
                new BoolQuestion() {Name = "Czy b�dziesz wykorzystywa� komputer do obr�bki materia��w wideo?"},

                new FuzzyQuestion() {Name = "Ile pieni�dzy chcesz przeznaczy� na laptop?"},
                new FuzzyQuestion() {Name = "Jak wa�na dla Ciebie jest mobilno�c?"},
                new FuzzyQuestion() {Name = "Jak wa�na dla ciebie jest kultura pracy?"},
                new FuzzyQuestion() {Name = "Jak wa�na jest dla Ciebie jako�� wy�wietlanego obrazu?"},
                new FuzzyQuestion() {Name = "Jak wa�na jest dla Ciebie jako�� odtwarzanego dzwi�ku?"},
                new FuzzyQuestion() {Name = "Jak wa�na jest dla Ciebie jako�� odtwarzanego dzwi�ku?"},
                new FuzzyQuestion() {Name = "Jak wa�na dla ciebie jest kultura pracy?"}, 
                new FuzzyQuestion() {Name = "Jaki system operacyjny ma mie� laptop?"},
                new FuzzyQuestion() {Name = "Jak du�y ma by� ekran?"},
                new FuzzyQuestion() {Name = "Jak d�ug� gwarancj� ma mie� komputer?"},
                new FuzzyQuestion() {Name = "Jak d�ugo laptop ma dzia�a� na bateri (z w��czonym wifi)?"}
            };

            


            var fuzzyQuestions = questions.OfType<FuzzyQuestion>();
            foreach (var fQ in fuzzyQuestions)
            {
                fQ.Answers= new List<Answer>();
                fQ.Answers.AddRange(answers);
            }
            questions.ForEach(x => context.Questions.AddOrUpdate(x));
            context.SaveChanges();

            List<Laptop> laptops = new List<Laptop>()
            {
                new Laptop()
                {
                    Description = "Bardzo wydajny laptop",
                    Link = "http://google.pl",
                    Name = "Wydajny x8",
                    Price = 2000
                },
                new Laptop()
                {
                    Description = "Bardzo mobilny laptop",
                    Link = "http://google.pl",
                    Name = "Mobilny x2",
                    Price = 1500
                },
                new Laptop()
                {
                    Description = "Bardzo kulturalny laptop",
                    Link = "http://google.pl",
                    Name = "Kulturalny x7",
                    Price = 3000
                },
                new Laptop()
                {
                    Description = "Bardzo wydajny i mobilny laptop",
                    Link = "http://google.pl",
                    Name = "Super x21",
                    Price = 6000
                },
            };

            laptops.ForEach(x=>context.Laptops.AddOrUpdate(x));
            context.SaveChanges();


            List<LaptopBoolValue> laptopBoolValues = new List<LaptopBoolValue>()
            {
                new LaptopBoolValue() {BoolQuestionId = 4, LaptopId = 1, Value = true},
                new LaptopBoolValue() {BoolQuestionId = 5, LaptopId = 1, Value = false},

                new LaptopBoolValue() {BoolQuestionId = 4, LaptopId = 2, Value = true},
                new LaptopBoolValue() {BoolQuestionId = 5, LaptopId = 2, Value = true},

                new LaptopBoolValue() {BoolQuestionId = 4, LaptopId = 3, Value = false},
                new LaptopBoolValue() {BoolQuestionId = 5, LaptopId = 3, Value = false},

                new LaptopBoolValue() {BoolQuestionId = 4, LaptopId = 4, Value = false},
                new LaptopBoolValue() {BoolQuestionId = 5, LaptopId = 4, Value = true},
            };
            laptopBoolValues.ForEach(x=>context.LaptopBoolValues.AddOrUpdate(x));
            context.SaveChanges();

            List<LaptopFuzzyValue> laptopFuzzyValues = new List<LaptopFuzzyValue>()
            {
                new LaptopFuzzyValue() {FuzzyQuestionId = 1, LaptopId = 1, Value = 5},
                new LaptopFuzzyValue() {FuzzyQuestionId = 2, LaptopId = 1, Value = 9},
                new LaptopFuzzyValue() {FuzzyQuestionId = 3, LaptopId = 1, Value = 4},

                new LaptopFuzzyValue() {FuzzyQuestionId = 1, LaptopId = 2, Value = 9},
                new LaptopFuzzyValue() {FuzzyQuestionId = 2, LaptopId = 2, Value = 6},
                new LaptopFuzzyValue() {FuzzyQuestionId = 3, LaptopId = 2, Value = 7},

                new LaptopFuzzyValue() {FuzzyQuestionId = 1, LaptopId = 3, Value = 7},
                new LaptopFuzzyValue() {FuzzyQuestionId = 2, LaptopId = 3, Value = 5},
                new LaptopFuzzyValue() {FuzzyQuestionId = 3, LaptopId = 3, Value = 9},

                new LaptopFuzzyValue() {FuzzyQuestionId = 1, LaptopId = 4, Value = 9},
                new LaptopFuzzyValue() {FuzzyQuestionId = 2, LaptopId = 4, Value = 8},
                new LaptopFuzzyValue() {FuzzyQuestionId = 3, LaptopId = 4, Value = 3},
            };

            laptopFuzzyValues.ForEach(x=>context.LaptopFuzzyValues.AddOrUpdate(x));
            context.SaveChanges();

            
        }
    }
}
