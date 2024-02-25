namespace Ryujinx.Ava.UI.Models
{
    internal class TimeZone
    {
        public TimeZone(string utcDifference, string location, string abbreviation)
        {
            UtcDifference = utcDifference;
            Location = location;
            Abbreviation = abbreviation;
        }

        public string UtcDifference { get; set; }
        public string Location { get; set; }
        public string Abbreviation { get; set; }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 1ec71635b (sync with main branch)
