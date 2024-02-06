using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Sessionize
{
    public class SpeakersList
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string bio { get; set; }
        public string tagLine { get; set; }
        public string profilePicture { get; set; }
        public List<SpeakerSession> sessions { get; set; }
        public bool isTopSpeaker { get; set; }
        public List<SpeakerLink> links { get; set; }
        public List<object> questionAnswers { get; set; }
        public List<object> categories { get; set; }
    }
    public class SpeakerSession
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class SpeakerLink
    {
        public string title { get; set; }
        public string url { get; set; }
        public string linkType { get; set; }
    }
}