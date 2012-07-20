using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EaImport.Entities
{
    public class EaProperty : EaItem
    {
        #region Constructors
        public EaProperty(string name, string id)
            : base(name, id)
        {
        }
        #endregion

        public override string Type
        {
            get { return "Property"; }
        }

        public override XElement GetXml(XmlGenerationConfig config)
        {
            //<ownedAttribute xmi:type="uml:Property" xmi:id="EAID_B8A8526F_1A9C_49c5_8DEC_AE546F181495" name="Prop1" ></ownedAttribute>

            var result = new XElement("ownedAttribute",
                new XAttribute(config.xmi + "type", GetTypeValue()),
                new XAttribute(config.xmi + "id", Id),
                new XAttribute("name", Name)
                );
            return result;
        }
    }
}
