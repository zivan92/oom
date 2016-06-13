using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Task6
{
    class SerialDeserial
    {
        public static void Run(HotelZimmer[] items)
        {
            var hotel = items[0];

           
            Console.WriteLine(JsonConvert.SerializeObject(hotel));
            Console.WriteLine(JsonConvert.SerializeObject(hotel, Formatting.Indented));

            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(items, settings));

            // json string to file "items.json" on your Desktop
            var text = JsonConvert.SerializeObject(items, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            File.WriteAllText(filename, text);

            // deserialize items from "items.json"
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<HotelZimmer[]>(textFromFile, settings);
           
            foreach (var x in itemsFromFile) Console.WriteLine($"{x.Zimmerpreis} {x.GebuchtVon}");
        }
    }
}
