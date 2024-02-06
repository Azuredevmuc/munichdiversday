using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Sessionize
{
    public class SpeakersWall
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string tagLine { get; set; }
        public string profilePicture { get; set; }
        public bool isTopSpeaker { get; set; }
    }
}