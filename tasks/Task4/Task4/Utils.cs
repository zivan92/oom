using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Task4
{
    public static class Utils
    {
        static readonly JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };

        public static string Serialisiere(object o) => JsonConvert.SerializeObject(o , settings );
       
        public static R DeSerialisiere<R>(string s)
        {
            return JsonConvert.DeserializeObject<R>(s);
        }

        public static string BuildFileName(Guid id)
        {
           var dirAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
           var filename = Path.Combine(dirAppData, $"items.json({id.ToString()})");
           return filename;
        }

        public static Guid SpeichereObj(object o)
        {
            var id = Guid.NewGuid();
            var filename = BuildFileName(id);
            var s = Serialisiere(o);
            File.WriteAllText(filename,s);

            return id;
        }
        public static void DeleteObj(Guid id )
        {
            if (File.Exists(id.ToString())) throw new ArgumentException("File already exists !", nameof(id));
            var filename = BuildFileName(id);
            File.Delete(filename);
        }
        public static T LadeObj<T>(Guid id)
        {
            T ret = default(T);
            var filename = BuildFileName(id);
            var textFromFile = File.ReadAllText(filename);
            ret = JsonConvert.DeserializeObject<T>(textFromFile, settings);
            return ret;
        }

        public static void SpeichereObj2(object o)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            var s = Serialisiere(o);
            File.WriteAllText(filename, s);
        }

        public static T LadeObj2<T>()
        {
            T ret = default(T);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "items.json");
            var textFromFile = File.ReadAllText(filename);
            ret = JsonConvert.DeserializeObject<T>(textFromFile, settings);
            return ret;
        }
    }
}

