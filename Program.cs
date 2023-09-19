using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class VideoGame : IComparable<VideoGame>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NASales { get; set; }
        public double EUSales { get; set; }
        public double JPSales { get; set; }
        public double OtherSales { get; set; }
        public double GlobalSales { get; set; }

        public VideoGame(string name, string platform, string year, string genre, string publisher, double nASales, double eUSales, double jPSales, double otherSales, double globalSales)
        {
            this.Name = name;
            this.Platform = platform;
            this.Year = year;
            this.Genre = genre;
            this.Publisher = publisher;
            this.NASales = nASales;
            this.EUSales = eUSales;
            this.JPSales = jPSales;
            this.OtherSales = otherSales;
            this.GlobalSales = globalSales;
        }

        // off stackoverflow https://stackoverflow.com/questions/20373149/proper-way-of-implementing-compareto-method

        public int CompareTo(VideoGame? other)
        {
            int result = Name.CompareTo(other.Name);
            return result;
        }

        public override string ToString()
        {
            string msg = "";
            msg += $"Name: {Name}\n" +
                $"Platform: {Platform}\n" +
                $"Year: {Year}\n" +
                $"Genre: {Genre}\n" +
                $"Publisher: {Publisher}\n" +
                $"North American Sales: {NASales}\n" +
                $"European Sales: {EUSales}\n" +
                $"Japanese Sales: {JPSales}\n" +
                $"Other Sales: {OtherSales}\n" +
                $"Global Sales: {GlobalSales}\n";
            return msg;
        }
    }
}
