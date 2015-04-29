using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemEkspercki.Models;
using SystemEkspercki.Models.ViewModel;
using DotNetOpenAuth.Messaging;

namespace SystemEkspercki.Controllers
{
    public class HomeController : BaseController
    {
        private const string UserPreferences = "viewModel";
        public ActionResult Index(int id =1)
        {
            UserPreferencesViewModel model;
            if (Session[UserPreferences] == null)
            {

                model = new UserPreferencesViewModel()
                    {
                        QuestionId = id,
                        QuestionsIds = context.Questions.Select(x => x.Id).ToList(),
                    

                    };
                Session[UserPreferences] = model;
            }
            else
            {
                model = (UserPreferencesViewModel)Session[UserPreferences];
                model.QuestionId = id;
            }
            return View(model);
        }

        public ActionResult AnswerQuestion(UserAnswerViewModel viewModel)
        {
            var model = (UserPreferencesViewModel)Session[UserPreferences];
            model.QuestionId++;
            if (model.Answers.ContainsKey(viewModel.QuestionId))
            {
                model.Answers[viewModel.QuestionId] = viewModel.Answer;
            }
            else
            {
                model.Answers.Add(viewModel.QuestionId, viewModel.Answer);
            }
            if (model.QuestionId>model.MaxQuestionId)
            {
                return RedirectToAction("Summary");
            }
            else
            {
                return RedirectToAction("Index",new {id = model.QuestionId});
            }
           
        }

        public ActionResult Summary()
        {
            var model = (UserPreferencesViewModel)Session[UserPreferences];
            Dictionary<Laptop,int> laptopsWithSummary = new Dictionary<Laptop, int>();
            foreach (var laptop in context.Laptops)
            {
                laptopsWithSummary.Add(laptop, 0);
            }
            foreach (var answer in model.Answers)
            {
                foreach (var laptop in context.Laptops)
                {
                    var question = context.Questions.FirstOrDefault(x => x.Id == answer.Key);
                   
                    if (question.GetType() == typeof(BoolQuestion))
                    {
                        var laptopAnswerValue = context.LaptopBoolValues.Where(x => x.BoolQuestionId == answer.Key).Where(x=>x.LaptopId==laptop.Id).Select(x => x.Value).FirstOrDefault();
                        if (Convert.ToInt32(laptopAnswerValue) != answer.Value)
                        {
                            laptopsWithSummary.Remove(laptop);
                        }
                        
                    }
                    else
                    {
                        var laptopAnswerValue = context.LaptopFuzzyValues.Where(x => x.FuzzyQuestionId == answer.Key).Where(x=>x.LaptopId==laptop.Id).Select(x => x.Value).FirstOrDefault();
                        laptopsWithSummary[laptop] += answer.Value*laptopAnswerValue;
                    }
                    
                }   
            }

            
            return View(laptopsWithSummary.OrderBy(x => x.Value).Select(x=>x.Key));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
