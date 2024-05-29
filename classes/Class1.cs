using System;
using System.Collections.Generic;

namespace classes
{
    public class Knight
    {
        public Knight(string name1, float money1) 
        {
            name = name1;
            money = money1;
        }
        public string name { get; set; }
        public float money { get; set; }

    }
    public class Tavern
    {
        public Tavern(string name1, int seats1, int guests1, int beds1, int stars1, int bandits1, int year1, string adress1, string phone1, float money1, string work1, string type1)
        {
            name = name1;
            seats = seats1;
            guests = guests1;
            beds = beds1;
            stars = stars1;
            bandits = bandits1;
            yearOfFounding = year1;
            adress = adress1;
            phone = phone1;
            money = money1;
            workingTime = work1;
            type = type1;
            knights = new List<Knight> { };
        }
        public string name { get; set; }
        public int seats { get; set; }
        public int guests { get; set; }
        public int beds { get; set; }
        public int stars { get; set; }
        public int bandits { get; set; }
        public int yearOfFounding { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public float money { get; set; }
        public string workingTime { get; set; }
        public string type { get; set; }
        public List<Knight> knights { get; set; }
    }
}
