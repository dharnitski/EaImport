using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EaImport.Entities
{
    public abstract class PackagedElement : EaItem
    {
        #region Constructors

        public PackagedElement(string name, string id)
            : base(name, id)
        {
            Items = new List<PackagedElement>();
        }
        #endregion

        #region Public
        public List<PackagedElement> Items { get; private set; }
        #endregion

        public override string Type
        {
            get { throw new NotImplementedException(); }
        }

        public override XElement GetXml(XmlGenerationConfig config)
        {
            var result = new XElement("packagedElement", 
                new XAttribute(config.xmi + "type", GetTypeValue()),
                new XAttribute(config.xmi + "id", Id),
                new XAttribute("name", Name)
                );

            EaItem.AddItems(Items, result, config);

            return result;
        }
    }
}
