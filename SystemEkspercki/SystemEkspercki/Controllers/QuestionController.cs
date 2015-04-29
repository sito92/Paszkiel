using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemEkspercki.Models;

namespace SystemEkspercki.Controllers
{
    public class QuestionController : BaseController
    {
        //
        // GET: /Question/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(context.Questions);
        }
        public ActionResult Show(int id)
        {
            var question = context.Questions.FirstOrDefault(x=>x.Id==id);
            if (question==null)
            {
                return HttpNotFound();
            }

            return ShowQuestion(question);
        }


        private ActionResult ShowBoolQuestion(BoolQuestion question)
        {

            return View("ShowBoolQuestion", question);
        }

        private ActionResult ShowFuzzyQuestion(FuzzyQuestion question)
        {

            return View("ShowFuzzyQuestion", question);
        }

        private ActionResult ShowQuestion<T>(T question)
        {

            return PartialView("Show"+GetQuestionClassName(question), question);

        }

        private string GetQuestionClassName<T>(T question)
        {
            var name = question.GetType().Name;
            int index = name.IndexOf("_");
            if (index > 0)
                name = name.Substring(0, index);
            return name;
        }

    }
}
