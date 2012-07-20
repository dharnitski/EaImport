using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EaImport.Entities
{
    public class XmlGenerationConfig
    {
        public XmlGenerationConfig()
        {
            uml = "http://schema.omg.org/spec/UML/2.1";
            xmi = "http://schema.omg.org/spec/XMI/2.1";
        }

        public XNamespace uml { get; private set; }
        public XNamespace xmi { get; private set; }
    }
}
