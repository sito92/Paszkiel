using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemEkspercki.Models.ViewModel
{
    public class UserPreferencesViewModel
    {
        public UserPreferencesViewModel()
        {
            Answers = new Dictionary<int, int>();
            QuestionsIds = new List<int>();
        }
        public int QuestionId { get; set; }
        public List<int> QuestionsIds { get; set; } 
        public Dictionary<int, int> Answers { get; set; }

        public int MaxQuestionId
        {
            get { return QuestionsIds.Count(); }
        }

        public UserAnswerViewModel UserAnswerViewModel
        {
            get { return new UserAnswerViewModel() {QuestionId = QuestionId}; }
        }
    }
}