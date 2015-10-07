using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WPF
{
    public  static class StaticValues
    {
        public static User User { get; set; }

        public static bool developerMode { get; set; }
    }

    public class User
    {
        public string Name { get; set; }

        public DateTime Added { get; set; }

        public List<UserTest> Tests { get; set; }

        public User(string name)
        {
            Name = name;
            Added = DateTime.Now;
            Tests = new List<UserTest>();

            System.IO.Directory.CreateDirectory(name);
        }
    }

    public class UserTest
    {
        public string Name { get; set; }
        public int Radius { get; set; }
        public int Blurness { get; set; }

        public XDocument Document { get; set; }
        public DateTime Added { get; set; }

        public UserTest(string name, int radius, int blurness)
        {
            Name = name;
            Radius = radius;
            Blurness = blurness;
            Document= new XDocument();
            Document.Add(new XElement(name));
            Added = DateTime.Now;
        }

        public void SaveTest(string directory, int index, int blurness, int radius)
        {
            Document.Save(directory + "/" + index + "_" + Name + "." + blurness + "." + radius + ".xml");
        }
    }

    [Serializable]
    public class UserTestDocument
    {
        [XmlAttribute]
        public string DateTime { get; set; }
        public string Position { get; set; }
        public float Distance { get; set; }
    }

    public class Tests
    {
        public static List<UserTest> tests { get; set; }
    }
}
