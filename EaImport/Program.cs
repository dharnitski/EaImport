using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EaImport.Entities;

namespace EaImport
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = CreateData();
            var data = item.GetRootXml(new XmlGenerationConfig());
            var str = data.ToString();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "1.xml");
            File.WriteAllText(path, str);

            Console.WriteLine(str);
            Console.ReadKey();
        }

        public static PackagedElement CreateData()
        {
            var result = new EaPackage("SmpPackage", Guid.NewGuid().ToString());
            var class1 = new EaClass("Class1", Guid.NewGuid().ToString());
            class1.Properties.Add(new EaProperty("prop1", Guid.NewGuid().ToString()));
            var class2 = new EaClass("Class2", Guid.NewGuid().ToString());
            class2.Properties.Add(new EaProperty("prop2", Guid.NewGuid().ToString()));
            var generalization = new EaGeneralization(string.Empty, Guid.NewGuid().ToString());
            generalization.General = class1.Id;
            class2.Generalizations.Add(generalization);
            result.Items.Add(class1);
            result.Items.Add(class2);
            return result;
        }
    }
}
