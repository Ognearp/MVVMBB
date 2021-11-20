using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotMVMMSuck.Data
{
   public class BaseEntity
   {
        public object GetProperty(string propetry)
        {
            if (!string.IsNullOrEmpty(propetry))
            {
                return this.GetType().GetProperty(propetry).GetValue(this);
            }
            return null;
        }
   }
}
