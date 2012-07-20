using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EaImport.Entities
{
    public abstract class EaItem
    {
        #region Abstract
        public abstract string Type { get; }
        /// <summary>
        /// Returns XML for object. Kind of serialization.
        /// </summary>
        /// <returns></returns>
        public abstract XElement GetXml(XmlGenerationConfig config);
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Could be empty (for example in Generalization)</param>
        /// <param name="id">Should be not empty</param>
        public EaItem(string name, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("id cannot be empty");

            Name = name;
            Id = id;
        }
        #endregion
        
        #region Public
        public string Name { get; private set; }
        public string Id { get; private set; }
        public XElement GetRootXml(XmlGenerationConfig config)
        {
  //<xmi:XMI xmi:version="2.1" xmlns:uml="http://schema.omg.org/spec/UML/2.1" xmlns:xmi="http://schema.omg.org/spec/XMI/2.1">
  //<xmi:Documentation exporter="Enterprise Architect" exporterVersion="6.5"/>
  //<uml:Model xmi:type="uml:Model" name="EA_Model" visibility="public">

            XElement result = new XElement(config.xmi + "XMI",
                new XAttribute(XNamespace.Xmlns + "xmi", config.xmi.NamespaceName),
                new XAttribute(XNamespace.Xmlns + "uml", config.uml.NamespaceName),
                new XAttribute(config.xmi + "version", "2.1"),
                new XElement(config.xmi + "Documentation", 
                    new XAttribute("exporterVersion", "6.5")
                    )
                );
            var model = new XElement(config.uml + "Model", 
                new XAttribute(config.xmi + "type", "uml:Model"),
                new XAttribute("name", "Templates")
                );

            model.Add(GetXml(config));
            result.Add(model);

            return result;
        }
        #endregion

        #region Protected
        
        protected string GetTypeValue()
        {
            return "uml:" + Type;
        }

        protected static void AddItems(IEnumerable<EaItem> items, XElement xmlElent, XmlGenerationConfig config)
        {
            foreach (var item in items)
            {
                var xml = item.GetXml(config);
                xmlElent.Add(xml);
            }
        }
        #endregion
    }
}
