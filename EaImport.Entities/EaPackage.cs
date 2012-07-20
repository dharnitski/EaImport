using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaImport.Entities
{
    public class EaPackage : PackagedElement
    {
        #region Constructors

        public EaPackage(string name, string id)
            : base(name, id)
        {
        }
        #endregion

        public override string Type
        {
            get { return "Package"; }
        }
    }
}
