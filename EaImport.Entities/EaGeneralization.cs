using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EaImport.Entities
{
    public class EaGeneralization : EaItem
    {
        #region Constructors

        public EaGeneralization(string name, string id)
            : base(name, id)
        {
        }
        #endregion

        public override string Type
        {
            get { return "Generalization"; }
        }

        #region Public
        public string General { get; set; }
        #endregion

        public override XElement GetXml(XmlGenerationConfig config)
        {
            //<generalization xmi:type="uml:Generalization" xmi:id="EAID_80F022B1_2C22_4ac2_864F_BCDBAD9B89E7" general="EAID_92AE7CB3_831F_4a29_ABFB_30AE7E39B63A"/>

            var result = new XElement("generalization",
                new XAttribute(config.xmi + "type", GetTypeValue()),
                new XAttribute(config.xmi + "id", Id),
                new XAttribute("name", Name),
                new XAttribute("general", General)
                );
            return result;
        }
    }
}
