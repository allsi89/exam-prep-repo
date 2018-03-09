using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWhite
{
    public class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }
        public Dwarf(string name, string hatColor, int physics) 
        {
            this.Name = name;
            this.HatColor = hatColor;
            this.Physics = physics;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var dwarfs = new List<Dwarf>(); // we create new list of dwarfs 
            Dictionary<string, int> colorsCount = new Dictionary<string, int>(); // make a dictionary to save number of dwarfs with same color
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Once upon a time")
            {
                string[] inputLine = input.Split("<:> ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var dwarfName = inputLine[0];
                var dwarfHatColor = inputLine[1];
                var dwarfPhysics = int.Parse(inputLine[2]);

                var dwarf = dwarfs.SingleOrDefault(d => d.Name == dwarfName && d.HatColor == dwarfHatColor); // check if dwarf exists and find the one we need
                // SingleOrDefault will return null if there is no dwarf to satisfy search criteria 
                // search criteria is as we see above -> same name and same color
                if (dwarf == null) // if an object doesnt exist its value is null
                {
                    dwarfs.Add(new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics)); // we create new dwarf and add it to our list
                    if (!colorsCount.ContainsKey(dwarfHatColor)) // we check if our dictionary has the dwarf color 
                    {
                        colorsCount.Add(dwarfHatColor, 0); // when it doesnt, we add it
                    }
                    colorsCount[dwarfHatColor]++; // when color already in our dictionary -> we add 1 to the count, aka dc.Value + 1
                }
                else if (dwarf.Physics < dwarfPhysics) // here dwarf exists and we check dwarf physics 
                {
                    dwarf.Physics = dwarfPhysics; // if int dwarf physics is smaller than current physics -> dwarf.Physics = current physics
                }
            }
            // below we order the dwarfs
            // sort by color where each color has a count of dwarfs in it -> we sort by the int value in our dictionary
            // therefore, the second sorting will order the dwarfs by color.Value that is already saved in our colorDictionary 
            //->(color, 3), (color, 2), (color, 1) ...
            foreach (var dwarf in dwarfs.OrderByDescending(d => d.Physics).ThenByDescending(d => colorsCount[d.HatColor]))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            };
        }
    }
}
