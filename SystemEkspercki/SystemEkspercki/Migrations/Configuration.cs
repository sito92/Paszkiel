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
                new Answer() {Name = "Bardzo wa¿na", Weight = 10},
                new Answer() {Name = "Wa¿na", Weight = 8},
                new Answer() {Name = "Przydatna", Weight = 5},
                new Answer() {Name = "Ma³o przydatna", Weight = 3},
                new Answer() {Name = "Niepotrzebna", Weight = 1}
            };
            answers.ForEach(x => context.Answers.AddOrUpdate(x));
            context.SaveChanges();
            List<Question> questions = new List<Question>()
            {
                
                new BoolQuestion() {Name = "Czy chcesz u¿ywaæ laptopa bez zasilacza?"},
                new BoolQuestion() {Name = "Czy chcesz mieæ kolekcjê filmów lub gier na swoim komputerze?"},
                new BoolQuestion() {Name = "Czy chcesz mieæ kolekcjê filmów lub gier na swoim komputerze?"},
                new BoolQuestion() {Name = "Czy bêdziesz u¿ywa³ komputera w ekstremalnych warunkach?"},
                new BoolQuestion() {Name = "Czy bêdziesz wykorzystywa³ komputer do d³ugotrwa³ego pisania?"},
                new BoolQuestion() {Name = "Czy bêdziesz wykorzystywa³ komputer do tworzenia grafiki 2d lub obróbki foto?"},
                new BoolQuestion() {Name = "Czy bêdziesz wykorzystywa³ komputer do tworzenia grafiki 3d?"},
                new BoolQuestion() {Name = "Czy bêdziesz wykorzystywa³ komputer do obróbki materia³ów wideo?"},

                new FuzzyQuestion() {Name = "Ile pieniêdzy chcesz przeznaczyæ na laptop?"},
                new FuzzyQuestion() {Name = "Jak wa¿na dla Ciebie jest mobilnoœc?"},
                new FuzzyQuestion() {Name = "Jak wa¿na dla ciebie jest kultura pracy?"},
                new FuzzyQuestion() {Name = "Jak wa¿na jest dla Ciebie jakoœæ wyœwietlanego obrazu?"},
                new FuzzyQuestion() {Name = "Jak wa¿na jest dla Ciebie jakoœæ odtwarzanego dzwiêku?"},
                new FuzzyQuestion() {Name = "Jak wa¿na jest dla Ciebie jakoœæ odtwarzanego dzwiêku?"},
                new FuzzyQuestion() {Name = "Jak wa¿na dla ciebie jest kultura pracy?"}, 
                new FuzzyQuestion() {Name = "Jaki system operacyjny ma mieæ laptop?"},
                new FuzzyQuestion() {Name = "Jak du¿y ma byæ ekran?"},
                new FuzzyQuestion() {Name = "Jak d³ug¹ gwarancjê ma mieæ komputer?"},
                new FuzzyQuestion() {Name = "Jak d³ugo laptop ma dzia³aæ na bateri (z w³¹czonym wifi)?"}
            };




            var fuzzyQuestions = questions.OfType<FuzzyQuestion>();
            foreach (var fQ in fuzzyQuestions)
            {
                fQ.Answers = new List<Answer>();
                fQ.Answers.AddRange(answers);
            }
            questions.ForEach(x => context.Questions.AddOrUpdate(x));
            context.SaveChanges();

            List<Laptop> laptops = new List<Laptop>()
            {
                new Laptop()
                {
                    Name = "Asus R510DP-XX118H",
                    Price = 1899,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-r510dp-xx118h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1366 x 768 pikseli
Procesor: AMD® A-Series A10-5750M 2,5 - 3,5 GHz
System operacyjny: Windows 8.1 64-bit
Pamiêæ RAM: 4 GB\nPojemnoœæ dysku: 1000 GB
Grafika: AMD® Radeon HD 8670M + Radeon HD 8650G
Ekran dotykowy: nie
Kod producenta: R510DP-XX118H
Seria: R510"
                },
                new Laptop()
                {
                    Name = "Asus R556LD-XO125H",
                    Price = 2399,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-r556ld-xo125h-w8-1_1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1366 x 768 pikseli
System operacyjny: Windows 8.1
Procesor: Intel® Core™ i5 4gen 4210U 1,7 - 2,7 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 1000 GB
Grafika: nVidia® GeForce 820M + Intel HD Graphics 4400
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus X553MA-SX284B",
                    Price = 1199,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-x553ma-sx284b.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1366 x 768 pikseli
System operacyjny: Windows 8.1
Procesor: Intel® Celeron® N2830 2,16 - 2,41 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 500 GB
Grafika: Intel® HD Graphics
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus N551JM-CN135H",
                    Price = 4599,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-n551jm-cn135h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8.1
Procesor: Intel® Core™ i7 4gen 4710HQ 2,5 - 3,5 GHz
Pamiêæ RAM: 12 GB
Pojemnoœæ dysku: 1000 GB
Grafika: nVidia® GeForce GTX 860M + Intel HD Graphics 4600
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus Transformer Book T100TAL-DK032B",
                    Price = 1899,
                    Link =
                        "http://www.euro.com.pl/laptopy-i-netbooki/asus-transformer-book-t100tal-dk032b-lte-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 10,1 cala, 1366 x 768 pikseli
System operacyjny: Windows 8.1
Procesor: Intel® Atom® Z3735D 1,33 - 1,83 GHz
Pamiêæ RAM: 2 GB
Pojemnoœæ dysku: 64 GB eMMC
Grafika: Intel® HD Graphics
Ekran dotykowy: tak"
                },
                new Laptop()
                {
                    Name = "Asus G750JM-T4030",
                    Price = 3799,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-g750jm-t4030.bhtml#opis",
                    Description =
                        @"Ekran: 17,3 cala, 1920 x 1080 pikseli
System operacyjny: brak
Procesor: Intel® Core™ i5 4gen 4200H 2,8 - 3,4 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 750 GB
Grafika: nVidia® Geforce GTX 860M + Intel HD Graphics 4600
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus G551JM-CN082H",
                    Price = 4599,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-g551jm-cn082h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ i7 4gen 4710HQ 2,5 - 3,5 GHz
Pamiêæ RAM: 8 GB
Pojemnoœæ dysku: 750 GB
Grafika: nVidia® GeForce GTX 860M + Intel HD Graphics 4600
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus Zenbook UX303LN-R4337H",
                    Price = 3699,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-zenbook-ux303ln-r4337h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 13,3 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ i5 5gen 5200U 2,2 - 2,7 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 750 GB
Grafika: nVidia® GeForce 840M + Intel HD Graphics 5500
Ekran dotykowy: nie
Parametry dodatkowe: USB 3.0, Bluetooth, gruboœæ 18 mm, waga 1,4 kg"
                },
                new Laptop()
                {
                    Name = "Asus K450LAV-CA256H",
                    Price = 1899,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-k450lav-ca256h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 14 cali, 1366 x 768 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ i3 4gen 4030U 1,9 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 500 GB
Grafika: Intel® HD Graphics 4400
Ekran dotykowy: tak"
                },
                new Laptop()
                {
                    Name = "Asus Zenbook UX305FA(MS)-FC051H",
                    Price = 2999,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-zenbook-ux305fams-fc051h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 13,3 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ M-series 5Y10 0,8 - 2,0 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 128 GB SSD
Grafika: Intel® HD Graphics 5300
Ekran dotykowy: nie
Parametry dodatkowe: USB 3.0, Bluetooth, 128 GB SSD, waga 1,2 kg"
                },
                new Laptop()
                {
                    Name = "Asus R556LD-XO482H",
                    Price = 2099,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-r556ld-xo482h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 13,3 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ M-series 5Y10 0,8 - 2,0 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 128 GB SSD
Grafika: Intel® HD Graphics 5300
Ekran dotykowy: nie
Parametry dodatkowe: USB 3.0, Bluetooth, 128 GB SSD, waga 1,2 kg"
                },
                new Laptop()
                {
                    Name = "Asus R553LN-XX136H",
                    Price = 2699,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-r553ln-xx136h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1366 x 768 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ i7 4gen 4500U 1,8 - 3,0 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 1000 GB
Grafika: nVidia® GeForce 840M + Intel HD Graphics 4400
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus R510JK-DM011H",
                    Price = 3099,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-r510jk-dm011h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8 64 bit
Procesor: Intel® Core™ i5 4gen 4200H 2,8 - 3,4 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 500 GB
Grafika: nVidia® GeForce GTX 850M + Intel HD Graphics 4600
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus Zenbook UX303LA-RO371H",
                    Price = 3399,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-zenbook-ux303la-ro371h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8 64 bit
Procesor: Intel® Core™ i5 4gen 4200H 2,8 - 3,4 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 500 GB
Grafika: nVidia® GeForce GTX 850M + Intel HD Graphics 4600
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus R556LN-XO046H",
                    Price = 2499,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-r556ln-xo046h-w8-1_1.bhtml#opis",
                    Description =
                        @"Ekran: 15,6 cala, 1366 x 768 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ i5 4gen 4210U 1,7 - 2,7 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 1000 GB
Grafika: nVidia® GeForce 840M + Intel HD Graphics 4400
Ekran dotykowy: nie"
                },
                new Laptop()
                {
                    Name = "Asus G750JM-T4060H",
                    Price = 3899,
                    Link = "http://www.euro.com.pl/laptopy-i-netbooki/asus-g750jm-t4060h-w8-1.bhtml#opis",
                    Description =
                        @"Ekran: 17,3 cala, 1920 x 1080 pikseli
System operacyjny: Windows 8.1 64-bit
Procesor: Intel® Core™ i5 4gen 4200H 2,8 - 3,4 GHz
Pamiêæ RAM: 4 GB
Pojemnoœæ dysku: 750 GB
Grafika: nVidia® Geforce GTX 860M + Intel HD Graphics 4600
Ekran dotykowy: nie"
                },
            };




            laptops.ForEach(x => context.Laptops.AddOrUpdate(x));
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
            laptopBoolValues.ForEach(x => context.LaptopBoolValues.AddOrUpdate(x));
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

            laptopFuzzyValues.ForEach(x => context.LaptopFuzzyValues.AddOrUpdate(x));
            context.SaveChanges();


        }
    }
}
