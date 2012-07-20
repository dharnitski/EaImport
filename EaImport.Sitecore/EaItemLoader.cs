using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EaImport.Entities;
using Sitecore.Data.Items;
using Sitecore.Configuration;

namespace EaImport.Sitecore
{
    public class EaItemLoader
    {
        /// <summary>
        /// Loads EaItems three for item and all its sub-items
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static PackagedElement Load(Item item)
        {
            if (item == null)
                throw new ArgumentNullException("Item cannot be null");

            PackagedElement result;

            if (item.TemplateName == "Template")
            {
                var template = Factory.GetDatabase("master").GetTemplate(item.ID);

                //it is Template in Sitecore represented by class in EA
                var id = template.ID;
                var eaClass = new EaClass(item.Name, id.ToString());

                //load parents
                foreach (var baseTemplate in template.BaseTemplates)
                {
                    var generalization = new EaGeneralization(baseTemplate.Name, Guid.NewGuid().ToString());
                    generalization.General = baseTemplate.ID.ToString();
                    eaClass.Generalizations.Add(generalization);
                }

                //load fields
                foreach (var field in template.OwnFields)
                {
                    if (!field.Name.StartsWith("__"))//do not add standard fields
                    {
                        var property = new EaProperty(field.Name, field.ID.ToString());
                        eaClass.Properties.Add(property);
                    }
                }

                result = eaClass;
            }
            else
            {
                //it is not template - folder in Sitecore and Package in EA
                result = new EaPackage(item.Name, item.ID.ToString());
                //folder/package can contain sub-items (Packages and Classes)
                foreach (Item child in item.Children)
                {
                    var eaChild = Load(child);
                    result.Items.Add(eaChild);
                }

            }

            return result;
        }
    }
}
