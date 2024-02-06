using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Sessionize
{
    public class SessionsList
    {
        public int groupId { get; set; }
        public string groupName { get; set; }
        public List<SessionDetails> sessions { get; set; }
        public bool isDefault { get; set; }
    }
    public class SessionCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<CategoryItem> categoryItems { get; set; }
        public int sort { get; set; }
    }

    public class SessionCategoryItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class SessionQuestionAnswer
    {
        public int id { get; set; }
        public string question { get; set; }
        public string questionType { get; set; }
        public string answer { get; set; }
        public int sort { get; set; }
        public object answerExtra { get; set; }
    }

    public class SessionDetails
    {
        public List<QuestionAnswer> questionAnswers { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startsAt { get; set; }
        public DateTime endsAt { get; set; }
        public bool isServiceSession { get; set; }
        public bool isPlenumSession { get; set; }
        public List<Speaker> speakers { get; set; }
        public List<Category> categories { get; set; }
        public int roomId { get; set; }
        public string room { get; set; }
        public object liveUrl { get; set; }
        public object recordingUrl { get; set; }
    }

    public class SessionSpeaker
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}