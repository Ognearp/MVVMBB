using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotMVMMSuck.Model
{
    public class FilterItem
    {
        public string Title { get; set; }
        public string Property { get; set; }
        public FilterItem(string property, string title)
        {
            
            Property = property;
            Title = title;
        }
    }
}
