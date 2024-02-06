using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Sessionize
{
    public class ScheduleGrid
    {
        public DateTime date { get; set; }
        public bool isDefault { get; set; }
        public List<GridRoom> rooms { get; set; }
        public List<TimeSlot> timeSlots { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class GridCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<CategoryItem> categoryItems { get; set; }
        public int sort { get; set; }
    }

    public class CategoryItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class GridRoom
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<GridSession> sessions { get; set; }
        public bool hasOnlyPlenumSessions { get; set; }
        public GridSession session { get; set; }
        public int index { get; set; }
    }

    public class GridSession
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startsAt { get; set; }
        public DateTime endsAt { get; set; }
        public bool isServiceSession { get; set; }
        public bool isPlenumSession { get; set; }
        public List<GridSpeaker> speakers { get; set; }
        public List<GridCategory> categories { get; set; }
        public int roomId { get; set; }
        public string room { get; set; }
        public object liveUrl { get; set; }
        public object recordingUrl { get; set; }
    }

    public class GridSession2
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startsAt { get; set; }
        public DateTime endsAt { get; set; }
        public bool isServiceSession { get; set; }
        public bool isPlenumSession { get; set; }
        public List<GridSpeaker> speakers { get; set; }
        public List<GridCategory> categories { get; set; }
        public int roomId { get; set; }
        public string room { get; set; }
        public object liveUrl { get; set; }
        public object recordingUrl { get; set; }
    }

    public class GridSpeaker
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class TimeSlot
    {
        public string slotStart { get; set; }
        public List<GridRoom> rooms { get; set; }
    }


}