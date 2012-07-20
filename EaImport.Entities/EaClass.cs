using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EaImport.Entities
{
    public class EaClass : PackagedElement
    {
        #region Constructors
        public EaClass(string name, string id)
            : base(name, id)
        {
            Properties = new List<EaProperty>();
            Generalizations = new List<EaGeneralization>();
        }
        #endregion

        #region Override
        public override string Type
        {
            get { return "Class"; }
        }

        public override XElement GetXml(XmlGenerationConfig config)
        {
            var result = base.GetXml(config);

            EaItem.AddItems(Properties, result, config);
            EaItem.AddItems(Generalizations, result, config);

            return result;
        }
        #endregion

        #region Public
        public List<EaProperty> Properties { get; private set; }
        public List<EaGeneralization> Generalizations { get; private set; }
        #endregion
    }
}
